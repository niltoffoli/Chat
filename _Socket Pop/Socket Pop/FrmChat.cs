using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ChatProdan
{
    public partial class FrmChat : Form
    {
        
        public FrmChat(string args)
        {
            InitializeComponent();
            lstUsuarios.MultiSelect = false;
            lstUsuarios.FullRowSelect = true;
            lstUsuarios.SmallImageList = statusIcons;
            bandeja.Visible = true;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            lblStatus.Text = "v. " + version.Major + "." + version.Minor; 
            StartParams(args);
            
            Closing += FrmChat_Closing;
            this.FormClosing += FrmChat_FormClosing;
            HandleCreated += FrmChat_HandleCreated;
            lstUsuarios.MouseClick += lstUsuarios_MouseClick;
            lstUsuarios.KeyDown += lstUsuarios_KeyDown;
            bandeja.DoubleClick += bandeja_DoubleClick;
            btnMenu.Click += btnMenu_Click;
            Resize += FrmChat_Resize;
            usuárioToolStripMenuItem.Click += usuárioToolStripMenuItem_Click;
            opçõesToolStripMenuItem.Click += opçõesToolStripMenuItem_Click;
            históricoToolStripMenuItem.Click += históricoToolStripMenuItem_Click;
            sairToolStripMenuItem1.Click += sairToolStripMenuItem_Click;

            if (!Config.Default.ParamSetados)
            {
                Config cfg = new Config();
                cfg.DefineParam();
            }

            SetHeight(lstUsuarios, 25); // método para definir espaçamento da listview
            //RecebeMensagem();
            StartListening();

            #region Delegate Lista de Usuários

            lstDelegate = delegate(object item)
            {

                string[] split = item.ToString().Split('|');
                string username = split[0];
                string userIP = split[1];
                string userTCP = split[2];
                string evento = split[3];
                string status = split[4];

                if (evento.Contains("add"))
                {
                    AddUser(username, userIP, userTCP, "online");
                }
                else if (evento.Contains("remove"))
                {
                    RemoveUser(userIP);
                    return null;
                }
                GravaDadosUser(username, userIP, userTCP, status);                  
                return null;
            };

            #endregion

            #region Delegate Recebimento de Mensagem

            msgDelegate = delegate(object msg)
            {
                Mensagem dados = msg as Mensagem;
                FrmPrivado chat = null;
                if (string.IsNullOrEmpty(dados.EVENTO))
                {
                    chat = SetMessage(dados.SenderIP);
                    if (chat.DadosJanela == null)
                    {
                        DadosConversa conversa = new DadosConversa();
                        conversa.ReceiverIP = dados.SenderIP;
                        conversa.ReceiverUSER = dados.SenderUSER;
                        conversa.SenderIP = Config.Default.UserIP;
                        conversa.SenderUSER = Config.Default.Username;
                        chat.DadosJanela = conversa;
                    }
                    chat.RecebeMsg(dados);
                    return null;
                }               
                else if((chat = IsOpenChat(dados.SenderIP)) != null)
                {
                    chat.Eventos(dados);
                }
                else if (dados.EVENTO == "img_request")
                {
                    SendUserPicture(dados);
                }
                return null;
            };

            #endregion

        }

        #region Inicio

        /// <summary>
        /// Adiciona dados dos usuários recebidos por broadcast na Listview principal.
        /// </summary>
        /// <param name="username">Nome do usuário remoto</param>
        /// <param name="userIP">IP do usuário remoto</param>
        /// <param name="portaTCP">Porta TCP usada pelo usuário</param>
        /// <param name="status">status do usuário</param>
        public void AddUser(string username, string userIP, string portaTCP, string status)
        {
            bool verifica = false;
            string ReceiverIP = string.Empty;
            foreach (ListViewItem listboxitem in lstUsuarios.Items)
            {
                DadosConversa user = listboxitem.Tag as DadosConversa;
                if (user != null && userIP.Equals(user.ReceiverIP))
                {
                    verifica = true;
                    ReceiverIP = user.ReceiverIP;
                    break;
                }
            }
            if (!verifica)
            {
                ListViewItem lstitem = new ListViewItem();
                lstitem.Text = username;
                lstitem.Tag = new DadosConversa() { ReceiverIP = userIP, ReceiverTCP = portaTCP, ReceiverUSER = username, ReceiverStatus = status };
                lstUsuarios.Items.Add(lstitem);
                SetaStatus(lstitem, status);
             
                if (userIP != Config.Default.UserIP)
                {
                    Online();
                }
            }
            else
            {
                FrmPrivado chat = lstAtivos.FirstOrDefault(jujuba => jujuba.DadosJanela.ReceiverIP.Equals(userIP));
                if (chat != null)
                {                   
                    SetaEvento(chat, "user_online");
                }
            } 
        }

        /// <summary>
        /// Remove usuários desconectados da Listview e dispara o evento user offline.
        /// </summary>
        /// <param name="userIP">IP do usuário remoto</param>
        public void RemoveUser(string userIP)
        {
            ListViewItem lstitem = null;
            string ReceiverIP = string.Empty;
            foreach (ListViewItem listboxitem in lstUsuarios.Items)
            {
                DadosConversa user = listboxitem.Tag as DadosConversa;
                if (user != null && userIP.Equals(user.ReceiverIP))
                {
                    lstitem = listboxitem;
                    ReceiverIP = user.ReceiverIP;
                    break;
                }
            }
            if (lstitem != null)
            {
                lstUsuarios.Items.Remove(lstitem);
                Mensagem eve = new Mensagem();
                FrmPrivado chat = IsOpenChat(ReceiverIP);
                if (chat != null)
                {
                    SetaEvento(chat, "user_offline");
                }
            }
        }
        private string mystatus = "online";
        public void UpdateUser(object sender, EventArgs args)
        {
            string[] novosdados = sender as string[];
            mystatus = novosdados[3];
            lstAtivos.All(x => (x.DadosJanela.SenderUSER = novosdados[0]) != "");
            //novosdados[0] Nome de Usuário
            //novosdados[1] Ip Usuario
            //novosdados[2] Porta TCP Usuário
            //novosdados[3] Status Usuário
            EnviaBroadcast(novosdados[3]);           
        }

        public void GravaDadosUser(string Novonome, string userIP, string userTCP, string Novostatus)
        {
            string ReceiverIP = string.Empty;
            foreach (ListViewItem listitem in lstUsuarios.Items)
            {
                DadosConversa dadosatuais = listitem.Tag as DadosConversa;
                if (dadosatuais != null && userIP.Equals(dadosatuais.ReceiverIP))
                {
                    if (!Novonome.Equals(dadosatuais.ReceiverUSER) || !Novostatus.Equals(dadosatuais.ReceiverStatus))
                    {
                        listitem.Text = Novonome;
                        listitem.Tag = new DadosConversa()
                        {
                            ReceiverIP = userIP,
                            ReceiverTCP = userTCP,
                            ReceiverUSER = Novonome,
                            ReceiverStatus = Novostatus
                        };

                        SetaStatus(listitem, Novostatus);
                                             
                    }
                }
            }
            FrmPrivado chat = lstAtivos.FirstOrDefault(jujuba => jujuba.DadosJanela.ReceiverIP.Equals(userIP));
            if (chat != null)
            {
                chat.DadosJanela.ReceiverUSER = Novonome;
                chat.DadosJanela.ReceiverStatus = Novostatus;
                chat.Text = Novonome;
                SetaEvento(chat, "UserChanged");
            }
        }

        public void SetaStatus (ListViewItem lstitem, string status)
        {
            if (status.Contains("online"))
            {
                lstUsuarios.Items[lstitem.Index].StateImageIndex = 0;
            }
            else if (status.Contains("ausente"))
            {
                lstUsuarios.Items[lstitem.Index].StateImageIndex = 1;
            }
            else if (status.Contains("ocupado"))
            {
                lstUsuarios.Items[lstitem.Index].StateImageIndex = 2;
            }
        }

        public void SendUserPicture(Mensagem Dados)
        {
            IpEnvio = Dados.SenderIP;


        }

        public void StartParams(string args)
        {
            try
            {               
                if (args == "-min") //se o parametro recebibo for -min inicia aplicativo minimizado 
                {
                    WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    bandeja.BalloonTipText = "Chat Prodan está em execução!";
                    bandeja.ShowBalloonTip(300);
                }
            }
            catch (SystemException excp)
            {
                MessageBox.Show(excp.Message);
            }
        }

        async void FrmChat_HandleCreated(object sender, EventArgs e)
        {
            RecebeBroadcast();
            Thread.Sleep(1000);
            Online();
        }

        public void Online()
        {
            EnviaBroadcast("add");
        }
        public void Offline()
        {
            EnviaBroadcast("remove");
        }

        #endregion

        #region Menu Opções

        void btnMenu_Click(object sender, EventArgs e)
        {
            menuPrincipal.Show(btnMenu, new Point(0, btnMenu.Height));
            //FrmConfig config = new FrmConfig(DefineParametros);
            //config.ShowDialog(this);
        }

        void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadosConversa MyUser = null;
            foreach (ListViewItem listitem in lstUsuarios.Items)
            {
                MyUser = listitem.Tag as DadosConversa;
                if (listitem != null && MyUser.ReceiverIP == Config.Default.UserIP)
                    break;
            }            
            FrmUsuario user = new FrmUsuario(MyUser, UpdateUser);
            user.ShowDialog();
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig config = new FrmConfig();
            config.ShowDialog(this);
        }

        void históricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorico hist = new FrmHistorico();
            hist.Show(this);
        }

        #endregion

        #region Eventos
        private void SetaEvento(FrmPrivado chat, string evento)
        {
            Mensagem eve = new Mensagem();
            eve.ReceiverIP = chat.DadosJanela.ReceiverIP;
            eve.SenderIP = chat.DadosJanela.SenderIP;
            eve.ReceiverUSER = chat.DadosJanela.ReceiverUSER;
            eve.SenderUSER = chat.DadosJanela.SenderUSER;
            eve.EVENTO = evento;
            chat.Eventos(eve);
        }

        #endregion

        #region Controle de Janelas

        List<FrmPrivado> lstAtivos = new List<FrmPrivado>();

        void lstUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                AbrirJanela();
        }

        void lstUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            AbrirJanela();
        }

        /// <summary>
        /// abrir chat novo pela listview
        /// </summary>
        private void AbrirJanela()
        {
            bool debug = false; // "true" permite abrir janela do proprio usuario para testes.
            DadosConversa user = lstUsuarios.SelectedItems[0].Tag as DadosConversa;
            if (user.ReceiverIP.Equals(Config.Default.UserIP) && !debug)
            {
                MessageBox.Show("Não fale sozinho.");

            }
            else
            {
                FrmPrivado chat =  IsOpenChat(user.ReceiverIP);
                chat = chat == null ? OpenChat() : chat;
                if (chat.DadosJanela == null)
                {
                    DadosConversa dados = new DadosConversa();
                    dados.ReceiverIP = user.ReceiverIP;
                    dados.ReceiverUSER = user.ReceiverUSER;
                    dados.SenderIP = Config.Default.UserIP;
                    dados.SenderUSER = Config.Default.Username;
                    chat.DadosJanela = dados;
                }
                SetTop(chat);
            }
        }

        /// <summary>
        /// Seta o foco da janela para o topo
        /// </summary>
        /// <param name="chat"></param>
        private void SetTop(FrmPrivado chat)
        {
            if (chat == null)
                return;
            chat.TopMost = true;
            chat.TopMost = false;
            chat.WindowState = FormWindowState.Normal;
            chat.Show();
        }


        /// <summary>
        /// Verifica se o chat já foi criado e está na lista de ativos
        /// </summary>
        /// <param name="ReceiverIP"> Ip de origem</param>
        /// <returns></returns>
        private FrmPrivado IsOpenChat(string ReceiverIP)
        {
            foreach (FrmPrivado chat in lstAtivos) // testa se já existe chat aberto com o usuário remoto
            {
                FrmPrivado novochat = null;
                if (chat != null && chat.DadosJanela.ReceiverIP.Equals(ReceiverIP))
                {
                    return chat;
                }
            }

            return null;
        }

        /// <summary>
        /// Cria janela do chat e adiciona na lista
        /// </summary>
        /// <returns></returns>
        private FrmPrivado OpenChat()
        {
            FrmPrivado novochat = new FrmPrivado(Fechar);
            novochat.Resize += novochat_Activated;
            novochat.Activated += novochat_Activated;
            lstAtivos.Add(novochat);
            novochat.WindowState = FormWindowState.Minimized;
            return novochat;
        }

        /// <summary>
        /// Verifica se o Chat possui foco
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        private FrmPrivado HasFocus(FrmPrivado chat)
        {
            return (chat.Focused || chat.Controls.Cast<Control>().Any(x => x.Focused)) ? chat : null;
        }

        /// <summary>
        /// Verifica se algum chat da lista possui foco
        /// </summary>
        /// <param name="listChat">List de chat aberto</param>
        /// <returns></returns>
        private FrmPrivado HasFocus(List<FrmPrivado> listChat)
        {
            return listChat.FirstOrDefault(x => HasFocus(x) != null);
        }
        

        /// <summary>
        /// Exibe mensagem recebida do cliente
        /// </summary>
        /// <param name="ReceiverIP">Ip do cliente</param>
        private FrmPrivado SetMessage(string ReceiverIP)
        {
            FrmPrivado novochat = null;
            novochat = IsOpenChat(ReceiverIP);
            //se chat não tiver aberto criar novo
            if (novochat == null)
                novochat = OpenChat();
            FrmPrivado focused = HasFocus(lstAtivos);
            if (novochat == focused)
                return novochat;
            if (Config.Default.AbrirJanela)
            {
                //Se abrir verificar foco dos chats
                if (focused != null)
                {
                    focused.TopMost = true;
                    novochat.WindowState = FormWindowState.Normal;
                    novochat.Show();
                    Thread.Sleep(450);
                    focused.TopMost = false;
                    Flash(false, novochat.Handle);
                }
                else
                {
                    SetTop(novochat);
                }
            }
            else
            {
                novochat.Show();
                Flash(false, novochat.Handle);
            }
            return novochat;
        }


        void novochat_Activated(object sender, EventArgs e)
        {
            Form frm = sender as Form;
            if (frm != null && frm.WindowState == FormWindowState.Normal)
                Flash(true, frm.Handle);
        }

        /// <summary>
        /// Recebe mensagem que o usuário fechou a janela de chat e o remove da lista de chats ativos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Fechar(object sender, EventArgs e)
        {
            DadosConversa user = sender as DadosConversa;
            foreach (FrmPrivado chat in lstAtivos)
            {
                if (user.ReceiverIP.Equals(chat.DadosJanela.ReceiverIP))
                {
                    lstAtivos.Remove(chat);
                    break;
                }
            }

        }

        #endregion //feio

        #region Recebe Mensagem

        private Thread EBroad_thread, RBroad_thread, Recebe_thread, Envia_thread;
        private TcpClient _socket = null;

        void EnviaMensagem(object sender, EventArgs e)
        {
            Mensagem dados_recebidos = sender as Mensagem;
            Envia_thread = new Thread(new ThreadStart(delegate()
            {
                try
                {
                    IPAddress ip = IPAddress.Parse(dados_recebidos.ReceiverIP);
                    _socket = new TcpClient();
                    _socket.Connect(ip, Config.Default.PortaTCP);
                    //_socket.con
                    byte[] msg = Serializa(dados_recebidos);
                    NetworkStream stream = _socket.GetStream();
                    stream.Write(msg, 0, msg.Length);
                }
                catch (SocketException ee)
                {
                    //if (dados_recebidos.EVENTO = "chat_close"

                }
                catch (Exception excp)
                {
                    EnviaMensagem(sender, e);

                }
            }));
            Envia_thread.Start();
        }

        #region
         public static ManualResetEvent allDone = new ManualResetEvent(false);

    public void StartListening() {
        // Data buffer for incoming data.
        byte[] bytes = new Byte[1024];

        // Establish the local endpoint for the socket.
        // The DNS name of the computer
        // running the listener is "host.contoso.com".
        IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, Config.Default.PortaTCP);

        // Create a TCP/IP socket.
        Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp );
        Recebe_thread = new Thread(new ThreadStart(delegate()
        {
            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                listener.Close();
                StartListening();
            }
        }));
        Recebe_thread.Start();

        //Console.WriteLine("\nPress ENTER to continue...");
        //Console.Read();

    }

    public  void AcceptCallback(IAsyncResult ar) {
        // Signal the main thread to continue.
        allDone.Set();

        // Get the socket that handles the client request.
        Socket listener = (Socket) ar.AsyncState;
        Socket handler = listener.EndAccept(ar);

        // Create the state object.
        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
    }

    public void ReadCallback(IAsyncResult ar) {
        try
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject) ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));
                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = state.sb.ToString();
                object message = Deserealiza(state.buffer);
                this.Invoke(msgDelegate, new object[] {message});
                ///////////////////////////////////////////////
                //if (content.IndexOf("<EOF>") > -1) {
                //    // All the data has been read from the 
                //    // client. Display it on the console.
                //    this.Invoke(msgDelegate, new object[] { message });

                //} else {
                //    // Not all data received. Get more.
                //    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                //    new AsyncCallback(ReadCallback), state);
                //}
            }
        }
        catch (Exception ee)
        {
            i = i + 1;
            if (i == 3)
            {
                i = 0;
                return;
            }
            ReadCallback(ar);
        }
    }

        private int i = 0;
        #endregion

        private void RecebeMensagem()
        {
            TcpClient tcpClient = null;
            NetworkStream netStream = null;
            TcpListener Listener = null;
            object message = null;
            Recebe_thread = new Thread(new ThreadStart(delegate()
            {

                try
                {
                    Listener = new TcpListener(IPAddress.Any, Config.Default.PortaTCP);
                    Listener.Start();
                    while (true)
                    {

                        if (!Listener.Pending())
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                        tcpClient = Listener.AcceptTcpClient();
                        
                        netStream = tcpClient.GetStream();
                        int cc;
                        byte[] buffer = new byte[1024];
                        while ((cc = netStream.Read(buffer, 0, buffer.Length)) > -1)
                        {
                            message = Deserealiza(buffer);
                            break;
                        }
                        this.Invoke(msgDelegate, new object[] { message });
                    }
                }
                catch (Exception excp)
                {
                    if (tcpClient != null)
                    {
                        tcpClient.Close();
                        netStream.Close();
                        Listener.Stop();
                    }
                    MessageBox.Show(excp.Message);
                    RecebeMensagem();

                }

            }));
            Recebe_thread.Start();

        }

        #endregion

        #region Envia
        // ManualResetEvent instances signal completion.
        private ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private ManualResetEvent sendDone =
            new ManualResetEvent(false);

        private Socket client = null;

        private void StartClient()
        {

            // Connect to a remote device.
            Thread Envia_thread = new Thread(delegate()
            {

                try
                {
                    // Establish the remote endpoint for the socket.
                    // The name of the 
                    IPAddress ipAddress = IPAddress.Parse(IpEnvio);
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, Config.Default.PortaTCP);

                    // Create a TCP/IP socket.
                    client = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);

                    // Connect to the remote endpoint.
                    client.BeginConnect(remoteEP,
                        new AsyncCallback(ConnectCallback), client);
                    //connectDone.WaitOne();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            });
            Envia_thread.Start();
        }

        private void CloseConection(Socket client)
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
        
        private void Send(Mensagem msg, int i)
        {
            try
            {
                if (i == 3)
                    return;
                StartClient();
                // Convert the string data to byte data using ASCII encoding.
                byte[] byteData = Serializa(msg);
                // Begin sending the data to the remote device.
                client.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), client);
            }
            catch (Exception ee)
            {
                //Send(msg,i++);
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                // Signal that all bytes have been sent.
                sendDone.Set();
            }
            catch (Exception e)
            {

            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;
                // Complete the connection.
                client.EndConnect(ar);
                // Signal that the connection has been made.
                connectDone.Set();
            }
            catch (Exception e)
            {

            }
        }


        #endregion


        #region Serialização

        byte[] Serializa(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private Object Deserealiza(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            return binForm.Deserialize(memStream);
        }

        #endregion

        #region Broadcast

        public string EnviaBroadcast(string evento)
        {

            string Usuario = Config.Default.Username + "|" + Config.Default.UserIP + "|" + Config.Default.PortaTCP + "|" + evento + "|" + mystatus;
            EBroad_thread = new Thread(new ThreadStart(delegate()
            {

                try
                {

                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    var bytes = System.Text.UTF8Encoding.UTF8.GetBytes(Usuario);
                    IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, Config.Default.PortaUDP);
                    socket.EnableBroadcast = true;
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                    socket.SendTo(bytes, iep);
                    socket.Close();
                }
                catch (Exception excp)
                {
                    EnviaBroadcast(evento);
                }

            }));
            EBroad_thread.Start();
            return null;
        }

        private async Task RecebeBroadcast()
        {
            RBroad_thread = new Thread(new ThreadStart(delegate()
            {
                try
                {
                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    byte[] buffer = new byte[1024];
                    var iep = new IPEndPoint(IPAddress.Any, Config.Default.PortaUDP);
                    socket.Bind(iep);
                    var ep = iep as EndPoint;
                    while (true)
                    {
                        socket.ReceiveFrom(buffer, ref ep);
                        var data = Encoding.UTF8.GetString(buffer);
                        this.Invoke(lstDelegate, new object[] { data });

                    }
                }
                catch (Exception excp)
                {
                    RecebeBroadcast();
                }

            }));
            RBroad_thread.Start();
        }

        #endregion

        #region Sair

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Offline();
            bandeja.Dispose();
            Environment.Exit(Environment.ExitCode);
        }

        void FrmChat_Closing(object sender, CancelEventArgs e)
        {
            //Offline();
            //bandeja.Dispose();
            //Environment.Exit(Environment.ExitCode);
        }

        void FrmChat_FormClosing(object sender, FormClosingEventArgs e) // Minimizar ao fechar
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {         
                this.Hide();
                e.Cancel = true;
            }
        }
       

        #endregion

        #region Auxiliares

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void bandeja_DoubleClick(object sender, EventArgs e) //clique duplo no ícone da bandeja traz o form de volta a vida
        {
            //Show();
            WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        void FrmChat_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        #endregion

        public string IpEnvio { get; set; }

        #region Definição Delegates

        public delegate object DelegateThread(object msg);
        public DelegateThread msgDelegate;
        public delegate object listDelegate(object item);
        public listDelegate lstDelegate;

        #endregion
     
        #region Flash Janela

        [DllImport("user32.dll")]
        static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        // stop flashing
        const uint FLASHW_STOP = 0;

        // flash the window title
        const uint FLASHW_CAPTION = 2;

        // flash the taskbar button
        const uint FLASHW_TRAY = 2;

        // 1 | 2
        const uint FLASHW_ALL = 3;

        // flash continuously
        const uint FLASHW_TIMER = 4;

        // flash until the window comes to the foreground
        const uint FLASHW_TIMERNOFG = 12;


        public void Flash(bool stop, IntPtr handler)
        {
            FLASHWINFO fw = new FLASHWINFO();
            
            fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO)));
            fw.hwnd = handler;
            if (!stop)                
                fw.dwFlags = 3;
            else
                fw.dwFlags = 0;
            fw.uCount = UInt32.MaxValue;

            FlashWindowEx(ref fw);
        }
        
        #endregion


    }
}

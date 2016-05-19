using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ChatProdan
{
    public partial class FrmPrivado : Form
    {
        EventHandler _args = null;
        EventHandler _msg = null;
        private Mensagem _user;

        public FrmPrivado(EventHandler fechar) //fechar: método 
        {
            InitializeComponent();
            FormClosing += frmPrivado_FormClosing;
            btnPrivEnvia.Click += btnPrivEnvia_Click;
            rtbPrivEnvia.KeyDown += rtbPrivEnvia_KeyDown;
            rtbPrivEnvia.TextChanged += rtbPrivEnvia_TextChanged;
            this.Activated += FrmPrivado_Activated;
            _args = fechar;
            //_msg = msg;
            rtbPrivEnvia.Focus();
            rtbPrivEnvia.Select();
            defaultFont = rtbPrivChat.SelectionFont;
            defaultColor = rtbPrivChat.SelectionColor;
            
        }

        void FrmPrivado_Activated(object sender, EventArgs e)
        {
            //SetaImagem();
        }

        #region Envio e Recebimento de Msg

        /// <summary>
        /// Chama método de envio ao teclar Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtbPrivEnvia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                EnviaMsg();
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Enter)
            {
                rtbPrivEnvia.AppendText("\n");
            }
        }        

        /// <summary>
        /// Chama método de envio ao clicar no botão.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnPrivEnvia_Click(object sender, EventArgs e)
        {
            EnviaMsg();
            rtbPrivEnvia.Focus();
            rtbPrivEnvia.Select();
        }

        /// <summary>
        /// Formata os dados da janela do usuário na classe Mensagem e envia ao método EnviaMensagem da classe principal.
        /// </summary>
        private void EnviaMsg()
        {
            if (string.IsNullOrWhiteSpace(rtbPrivEnvia.Text))
                return;
            Mensagem msg = new Mensagem();
            msg.MENSAGEM = rtbPrivEnvia.Text;
            msg.TIMESTAMP = string.Format("[{0:T}]", DateTime.Now);
            msg.SenderIP = DadosJanela.SenderIP;
            msg.SenderUSER = DadosJanela.SenderUSER;
            msg.ReceiverUSER = DadosJanela.ReceiverUSER;
            msg.ReceiverIP = DadosJanela.ReceiverIP;
            rtbPrivEnvia.Clear();
            RecebeMsg(msg);
            Send(msg,1);
            //if (_msg != null)
            //    _msg.Invoke(msg, null);               
        }
       
        public void RecebeMsg(Mensagem dados)
        {
            rtbPrivChat.SelectionFont = defaultFont;
            rtbPrivChat.SelectionColor = defaultColor;
            string mensagem = string.Format("{0} {1}: {2}", dados.TIMESTAMP, dados.SenderUSER, dados.MENSAGEM.Trim());
            rtbPrivChat.AppendText(mensagem + Environment.NewLine);
            rtbPrivChat.ScrollToCaret();
            CriaHistorico(dados);
        }

        #endregion

        #region Gravação Histórico

        public void CriaHistorico(Mensagem dados)
        {
            try
            {
                string folder = Config.Default.HistLocal;
                string filename = string.Empty;

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                if (dados.SenderIP.Equals(Config.Default.UserIP))
                {
                    filename = string.Format("{0}\\{1}.xml", folder, dados.ReceiverUSER);
                }
                else
                {
                    filename = string.Format("{0}\\{1}.xml", folder, dados.SenderUSER);
                }

                if (!File.Exists(filename))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;
                    xmlWriterSettings.NewLineOnAttributes = true;
                    using (XmlWriter xmlWriter = XmlWriter.Create(filename, xmlWriterSettings))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("root");
                        xmlWriter.WriteStartElement("DADOS_MENSAGEM");
                        xmlWriter.WriteElementString("Data", (DateTime.Now.ToString("dd-MM-yyyy")));
                        xmlWriter.WriteElementString("Hora", string.Format("{HH:mm:ss}", dados.TIMESTAMP));
                        xmlWriter.WriteElementString("SenderUser", dados.SenderUSER);
                        xmlWriter.WriteElementString("SenderIP", dados.SenderIP);
                        xmlWriter.WriteElementString("ReceiverUser", dados.ReceiverUSER);
                        xmlWriter.WriteElementString("ReceiverIP", dados.ReceiverIP);
                        xmlWriter.WriteElementString("Mensagem", dados.MENSAGEM);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
                }
                else
                {
                    XDocument xDocument = XDocument.Load(filename);
                    XElement root = xDocument.Element("root");
                    IEnumerable<XElement> rows = root.Descendants("DADOS_MENSAGEM");
                    XElement firstRow = rows.First();
                    firstRow.AddBeforeSelf(
                       new XElement("DADOS_MENSAGEM",
                       new XElement("Data", (DateTime.Now.ToString("dd-MM-yyyy"))),
                       new XElement("Hora", dados.TIMESTAMP),
                       new XElement("SenderUser", dados.SenderUSER),
                       new XElement("SenderIP", dados.SenderIP),
                       new XElement("ReceiverUser", dados.ReceiverUSER),
                       new XElement("ReceiverIP", dados.ReceiverIP),
                       new XElement("Mensagem", dados.MENSAGEM)));
                    xDocument.Save(filename);
                }
            }
            catch (System.IO.IOException IOexcp)
            {
            }
            catch (System.Xml.XmlException XMLexcp)
            {
            }
            catch (System.FormatException formexcp)
            {
            }         
        }

        #endregion

        #region Eventos

        void rtbPrivEnvia_TextChanged(object sender, EventArgs e)
        {
            if (rtbPrivEnvia.TextLength == 1)
            {
                Mensagem eve = new Mensagem();
                eve.ReceiverIP = DadosJanela.ReceiverIP;
                eve.SenderIP = DadosJanela.SenderIP;
                eve.ReceiverUSER = DadosJanela.ReceiverUSER;
                eve.SenderUSER = DadosJanela.SenderUSER;
                eve.EVENTO = "start_typing";
                Send(eve, 1);
            }
            if (rtbPrivEnvia.TextLength == 0)
            {
                Mensagem eve = new Mensagem();
                eve.ReceiverIP = DadosJanela.ReceiverIP;
                eve.SenderIP = DadosJanela.SenderIP;
                eve.ReceiverUSER = DadosJanela.ReceiverUSER;
                eve.SenderUSER = DadosJanela.SenderUSER;
                eve.EVENTO = "stop_typing";
                Send(eve, 1);
            }

        }

        public void Eventos(Mensagem dados)
        {
            string mensagem = string.Empty;
            switch (dados.EVENTO)
            {
                case "start_typing":
                    typetxt.Text = dados.SenderUSER + " está digitando...";
                    typePic.Visible = true;
                    typetxt.Visible = true;
                    break;

                case "stop_typing":
                    typetxt.Text = "";
                    typePic.Visible = false;
                    typetxt.Visible = false;
                    break;

                case "chat_close":
                    typetxt.Text = "";
                    typePic.Visible = false;
                    typetxt.Visible = false;
                    rtbPrivChat.SelectionFont = new Font("Tahoma", 7, FontStyle.Italic);
                    mensagem = string.Format("{0} {1} Fechou a janela.", dados.TIMESTAMP, dados.SenderUSER);
                    rtbPrivChat.AppendText(mensagem + Environment.NewLine);
                    rtbPrivChat.ScrollToCaret();
                    break;

                case "user_offline":
                    typetxt.Text = "";
                    typePic.Visible = false;
                    typetxt.Visible = false;
                    rtbPrivChat.SelectionFont = new Font("Tahoma", 7, FontStyle.Italic);
                    rtbPrivChat.SelectionColor = System.Drawing.Color.Red;
                    mensagem = string.Format("{0} {1} Ficou Offline.", dados.TIMESTAMP, dados.ReceiverUSER);
                    EventoStatus(mensagem, false);
                    rtbPrivChat.ScrollToCaret();
                    rtbPrivEnvia.ReadOnly = true;
                    btnPrivEnvia.Enabled = false;
                    break;

                case "user_online":
                    typetxt.Text = "";
                    typePic.Visible = false;
                    typetxt.Visible = false;
                    rtbPrivChat.SelectionFont = new Font("Tahoma", 7, FontStyle.Italic);
                    rtbPrivChat.SelectionColor = System.Drawing.Color.Green;
                    mensagem = string.Format("{0} {1} Esta Online.", dados.TIMESTAMP, dados.ReceiverUSER);
                    EventoStatus(mensagem, true);
                    rtbPrivChat.ScrollToCaret();
                    rtbPrivEnvia.ReadOnly = false;
                    btnPrivEnvia.Enabled = true;
                    break;

                case "UserChanged":
                    rtbPrivChat.SelectionFont = new Font("Tahoma", 7, FontStyle.Italic);
                    mensagem = string.Format("{0} {1} Alterou o nome.", dados.TIMESTAMP, dados.ReceiverUSER);
                    rtbPrivChat.AppendText(mensagem + Environment.NewLine);
                    this.Text = dados.ReceiverUSER;
                    this.Refresh();
                    break;
            }

        }
        bool ItsOnline = true;
        Font defaultFont = null;
        Color defaultColor;
        private void EventoStatus(string status, bool online)
        {
            if (online != ItsOnline)
            {
                rtbPrivChat.AppendText(status + Environment.NewLine);
                ItsOnline = online;
            }
            rtbPrivChat.SelectionFont = defaultFont;
            rtbPrivChat.SelectionColor = defaultColor;
        }

        #endregion

        # region Fechar

        /// <summary>
        /// Dispara evento informando ao destinatário quando o usuário fecha a janela de chat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmPrivado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mensagem eve = new Mensagem();
            eve.ReceiverIP = DadosJanela.ReceiverIP;
            eve.SenderIP = DadosJanela.SenderIP;
            eve.ReceiverUSER = DadosJanela.ReceiverUSER;
            eve.SenderUSER = DadosJanela.SenderUSER;
            eve.EVENTO = "chat_close";
            Send(eve,1);
            if (_args != null)
                _args.Invoke(DadosJanela, null);
        }
       
        /// <summary>
        /// Método para fechar tela de chat com tecla ESC
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Imagem Usuário

        public void SetaImagem()
        {
            pictboxSender.ImageLocation = Config.Default.UserImg;
            string ReceiverImg = String.Format("{0}\\Imagens\\{1}.jpg", Application.StartupPath, DadosJanela.ReceiverIP);
            if (File.Exists(ReceiverImg))
            {
                pictboxReceiver.ImageLocation = ReceiverImg;
            }
            else
            {
                SolicitaImagem();
            }
        }

        public void SolicitaImagem()
        {
            Mensagem eve = new Mensagem();
            eve.ReceiverIP = DadosJanela.ReceiverIP;
            eve.SenderIP = DadosJanela.SenderIP;
            eve.ReceiverUSER = DadosJanela.ReceiverUSER;
            eve.SenderUSER = DadosJanela.SenderUSER;
            eve.EVENTO = "img_request";
            SendReceive send = new SendReceive();
            send.DadosJanela = DadosJanela;
            //send._msgDelegate.
            Send(eve, 1);
        }

        public 

        #endregion

        #region Properties

        DadosConversa _dados = null;
        public DadosConversa DadosJanela
        {
            get { return _dados; }
            set
            {
                _dados = value;
                if (_dados != null)
                {
                    Text = _dados.ReceiverUSER;
                    //StartClient();
                }
            }
        }

        public Mensagem Mensagem
        {
            get { return _user; }
            set
            {
                _user = value;
            }
        }

        #endregion

        #region Envia
        // ManualResetEvent instances signal completion.
        private  ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private  ManualResetEvent sendDone =
            new ManualResetEvent(false);

        private Socket client = null;
        
        private void StartClient()
        {
            
            // Connect to a remote device.
            Thread Envia_thread = new Thread(delegate(){
                
            try
            {
                // Establish the remote endpoint for the socket.
                // The name of the 
                IPAddress ipAddress = IPAddress.Parse(DadosJanela.ReceiverIP);
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

        private  void SendCallback(IAsyncResult ar)
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
                Console.WriteLine(e.ToString());
            }
        }

        private  void ConnectCallback(IAsyncResult ar)
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
                Console.WriteLine(e.ToString());
            }
        }


        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatProdan
{
    class SendReceive
    {
        DadosConversa _dados = null;
        public DadosConversa DadosJanela
        {
            get { return _dados; }
            set
            {
                _dados = value;               
            }
        }


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
        public void Send(Mensagem msg, int i)
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
                Console.WriteLine(e.ToString());
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
                Console.WriteLine(e.ToString());
            }
        }


        #endregion


        #region Recebe Mensagem

        private Thread EBroad_thread, RBroad_thread, Recebe_thread, Envia_thread;
        private TcpClient _socket = null;

        

        
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public void StartListening()
        {
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
                SocketType.Stream, ProtocolType.Tcp);
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

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
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
                    
                    //this.Invoke(msgDelegate, new object[] { message });
                    //if (content.IndexOf("<EOF>") > -1) {
                    //    // All the data has been read from the 
                    //    // client. Display it on the console.
                    //    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                    //        content.Length, content );
                    //    // Echo the data back to the client.
                    //    Send(handler, content);
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

        private Object Deserealiza(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            return binForm.Deserialize(memStream);
        }

        private int i = 0;
        #endregion

        public delegate object DelegateThread(object rcvr);
        public DelegateThread msgReceiver;
    }
}

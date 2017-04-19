using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parcial2_1
{
    public class Client
    {
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public int Port = 0;
        public string Alias = "";
        public string AliasChat = "";
        public IPAddress IP = null;
        private const int BUFFER_SIZE = 2048;
        public string ID = "";
        public bool state { get; set; }
        public bool expused { get; set; }
        public List<Data> box { get; set; }
        Thread listenClient;
        public Client(int port, string id, string alias)
        {
            this.Port = port;
            IPAddress.TryParse(id, out IP);
            this.ID = id;
            this.Alias = alias;
            this.state = true;
            this.expused = false;
            this.box = new List<Data>();
        }

        public void ConnectToServer()
        {
            int attempts = 0;

            // Mientras que no se conecta el cliente
            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    // Indica los intentos de conección
                    //IPAddress address = Dns.Resolve("localhost").AddressList[0];
                    IPEndPoint EPHost = new IPEndPoint(IP, this.Port);
                    // Intenta conectarse nuevamente a las Ip cerca.
                    ClientSocket.Connect(EPHost);
                }
                catch (SocketException)
                {

                }
            }
            MessageBox.Show("Se ha conectado al chat",
            "Se ha conectado al chat",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            Thread listenClient = new Thread(new ThreadStart(ReceiveResponse));
        }
        private void Exit()
        {
            string salir = (int)typeMessage.offLine + "|"+this.Alias+"|" + (int)flagMessage.stop;
            SendString(salir); // Le indicamos al sevidor que se salga
            ClientSocket.Shutdown(SocketShutdown.Both); // Apaga el socket tanto como el de envío y resibido
            ClientSocket.Close(); // Cerramos la conexión
        }
        public void SendRequest(typeMessage Type, string message)
        {
            if ((int)Type == 0)
            {
                Exit();
                MessageBox.Show("Mensaje enviado",
                "mensaje para desconectar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else if ((int)Type == 1)
            {
                message = getMessage(message);
                if (message == "1")
                {
                    MessageBox.Show("El mensaje no tiene contenido",
                    "El mensaje no ha sido enviado",
                    MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                    return;
                }
                if (message == "2")
                {
                    MessageBox.Show("El mensaje es extenso",
                    "El mensaje no ha sido enviado",
                    MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                    return;
                }
                SendString(message);
                MessageBox.Show("Mensaje enviado",
                "se ha enviado un mensaje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else if ((int)Type == 4)
            {
                SendString((int)typeMessage.login + "|" + this.Alias + "|0"  );
            }
            else
            {
                message = getPathSearch(message);
                if (message == "1")
                {
                    MessageBox.Show("El path es a buscar es demasiado largo",
                    "El mensaje no ha sido enviado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
                else if (message == "2")
                {
                    MessageBox.Show("No se ha escrito el path",
                    "El mensaje no ha sido enviado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    SendString(message);
                }
                MessageBox.Show("Mensaje enviado",
                "mensaje para buscar path",
                MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
            }

        }

        public string getPathSearch(string path)
        {
            if (path.Length > BUFFER_SIZE - 4)
            {
                return "1";
            }
            if (path.Length == 0)
            {
                return "2";
            }
            return (int)typeMessage.buscar + "|" + path + "|" + (int)flagMessage.stop;
        }

        public string getMessage(string message)
        {
            if (message.Length == 0)
            {
                return "1";
            }
            if (message.Length > BUFFER_SIZE - 204)
            {
                return "2";
            }
            string request = (int)typeMessage.message + "|" + AliasChat + "°" + Alias  + "°" +  message + "|" + (int)flagMessage.stop;
            return request;
        }

        public List<string> search(string path)
        {
            List<string> files = new List<string>();
            List<string> requests = new List<string>();
            if (!Directory.Exists(path))
            {
                requests.Add((int)typeMessage.path + "|" + AliasChat + "°" + Alias + "°" + "path not Found" + (int)flagMessage.stop);
                return requests;
            }
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (var fi in di.GetFiles())
            {
                files.Add(fi.Name);
            }
            string request = (int)typeMessage.path + "|" + AliasChat + "°" + Alias + "°";
            int i = 0;
            int controNextlFlag = (int)flagMessage.next;
            int controlSizeFlag = BUFFER_SIZE - 205;
            while (i < files.Count)
            {
                while (request.Length + files[i].Length < controlSizeFlag)
                {
                    request += files[i];
                    request += "°";
                    i++;
                    if (i == files.Count)
                    {
                        controNextlFlag = (int)flagMessage.stop;
                        break;
                    }
                }
                request = request.Substring(0, request.Length - 1);
                request += "|" + controNextlFlag.ToString();
                requests.Add(request);
                request = (int)typeMessage.path + "|" + AliasChat + "°" + Alias + "°";
            }
            return requests;
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        private void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            try
            {
                ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
            catch (Exception)
            {
                this.state = false;
                MessageBox.Show("Desconexión con el chat (Servidor)");
                throw;
            }
        }

        public void ReceiveResponse()
        {
            while(true)
            {
                var buffer = new byte[BUFFER_SIZE];
                try
                {
                    int received = ClientSocket.Receive(buffer, SocketFlags.None);
                    if (received == 0)
                    {
                        break;
                    }
                    Data dt = new parcial2_1.Data();
                    var data = new byte[received];
                    Array.Copy(buffer, data, received);
                    string msg = Encoding.ASCII.GetString(data);
                    string[] message = msg.Split('|');
                    dt.row = message[1].Split('°');
                    dt.tm = (typeMessage)Convert.ToInt32(message[0]);
                    if (dt.tm == typeMessage.buscar)
                    {
                        List<string> paths = search(message[1]);
                        foreach (string path in paths)
                        {
                            SendString(path);
                        }
                    }
                    else
                    {
                        box.Add(dt);
                    }
                    
                }
                catch (Exception ex)
                {
                    this.state = false;
                    this.ConnectToServer();
                    break;
                }
            }
        }

    }
}

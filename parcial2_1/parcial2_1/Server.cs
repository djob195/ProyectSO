using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace parcial2_1
{
    public enum typeMessage
    {
        offLine,
        message,
        path,
        buscar,
        login
    }

    public enum flagMessage
    {
        stop,
        next
    }
    public class Server
    {

        /// <summary>
        /// Instanciamos el servidor, la cual se puede conectar toda la Familia Stream, en dos via (Comunicación envio
        /// y recibido), a partir del protocolo de comunicación TCP.
        /// </summary>
        private readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        /// <summary>
        /// Lista de clientes conectado al servidor.
        /// </summary>
        private readonly List<Socket> clientSockets = new List<Socket>();
        public List<string[]> dgvClients { get; set; }

        /// <summary>
        /// Tamaño de bytes, del mensaje del comunicación.
        /// </summary>
        private const int BUFFER_SIZE = 2048;
        /// <summary>
        /// Puerto en la cualel socket esta escuchando
        /// </summary>
        public int PORT = 0;
        public IPAddress IP = null;
        public string ALIAS = "";
        /// <summary>
        /// Mensaje de informacción
        /// </summary>
        private readonly byte[] buffer = new byte[BUFFER_SIZE];

        public Server(int port, IPAddress ip, string alias)
        {
            IP = ip;
            PORT = port;
            ALIAS = alias;
            serverSocket.Bind(new IPEndPoint(ip, port));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
            this.dgvClients = new List<string[]>();
        }

        public void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;
            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (Exception)
            {
                return;
            }
            clientSockets.Add(socket); 
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        public void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState; 
            int received;
            try
            {
                received = current.EndReceive(AR); // Esperando el mensaje del cliente
            }
            catch (SocketException)
            {
                current.Close(); 
                clientSockets.Remove(current); 
                return;
            }

            byte[] recBuf = new byte[received]; // Cantidad de informacción recibida
            Array.Copy(buffer, recBuf, received); // Copiamos la informacción recibida a otro vector
            string req = Encoding.ASCII.GetString(recBuf); // Encodificamos la informacción
            string[] partToMessage = req.Split('|');
            int typeMsg = Convert.ToInt32(partToMessage[0]);
            switch (typeMsg)
            {
                case (int)typeMessage.offLine:
                    {
                        // Usuario se desconecto del chat
                        current.Close();
                        clientSockets.Remove(current);
                        break;
                    }
                case (int)typeMessage.message:
                    {
                        foreach (Socket client in clientSockets)
                        {
                            client.Send(Encoding.ASCII.GetBytes(req));
                        }
                        break;
                    }
                case (int)typeMessage.buscar:
                    {
                        foreach (Socket client in clientSockets)
                        {
                            client.Send(Encoding.ASCII.GetBytes(req));
                        }
                        break;
                    }
                case (int)typeMessage.path:
                    {
                        foreach (Socket client in clientSockets)
                        {
                            client.Send(Encoding.ASCII.GetBytes(req));
                        }
                        break;
                    }
                case (int)typeMessage.login:
                    {
                        string[] cl = new string[1];
                        cl[0] = partToMessage[1];
                        dgvClients.Add(cl);
                        break;
                    }
                default:
                    break;
            }
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current); // Se llama recursivamente par establecer la informacción
        }
        public void deleteClient(int i)
        {
            //Eliminar un usuario del chat
            Socket s = this.clientSockets[i];
            this.clientSockets.RemoveAt(i);
            dgvClients.RemoveAt(i);
            s.Send(Encoding.ASCII.GetBytes((int)typeMessage.offLine+"|"+ALIAS+"°Ha sido Eliminado del chat|" + (int)flagMessage.stop));
            s.Close();
        }
    }
}

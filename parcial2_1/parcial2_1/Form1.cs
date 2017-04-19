using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace parcial2_1
{
    public partial class CHAT : Form
    {
        Server server;
        List<Client> clients = new List<Client>();
        List<Client> inactiveClients = new List<Client>();
        Thread listenerBox;
        Thread activeClients;
        Thread logins;
        public CHAT()
        {
            InitializeComponent();
        }

        public void addClientActive()
        {
            while (true)
            {
                if (server == null)
                {
                    break;
                }
                if (server.dgvClients.Count >  DGVMyChat.Rows.Count)
                {
                    for (int i = DGVMyChat.RowCount; i < server.dgvClients.Count; i++)
                    {
                        DGVMyChat.Rows.Add(server.dgvClients[i]);
                    }
                }
            }
        }
        public void activeClient()
        {
            while (true)
            {
                for (int i = 0; i < inactiveClients.Count; i++)
                {
                    Client client = inactiveClients[i];
                    if (client.state)
                    {
                        inactiveClients.RemoveAt(i);
                        clients.Add(client);
                        dgvOffChat.Rows.RemoveAt(i);
                        DGVOtherChats.Rows.Add(DGVOtherChats.RowCount.ToString(),client.AliasChat, client.Alias);
                    }
                }
            }
        }
        public void listenBox()
        {
            while(true)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    Client client = clients[i];
                    foreach (Data msg in client.box)

                    {
                        switch (msg.tm)
                        {
                            case typeMessage.offLine:
                                {
                                    dgvAlerts.Rows.Add(msg.row);
                                    MessageBox.Show("Mensaje recibido",
                                    "Has sido eliminado de un chat",
                                    MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                                    client.expused = true;
                                    clients.RemoveAt(i);
                                    DGVOtherChats.Rows.RemoveAt(i);
                                    break;
                                }
                            case typeMessage.message:
                                {
                                    DGVChats.Rows.Add(msg.row);
                                    MessageBox.Show("Mensaje recibido",
                                    "Te ha llegado un mensaje",
                                    MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                                    break;
                                }
                            case typeMessage.path:
                                {
                                    DGVPath.Rows.Add(msg.row);
                                    MessageBox.Show("Mensaje recibido",
                                    "Te ha llegado un path",
                                    MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    if (client.state == false && client.expused == false)
                    {
                        inactiveClients.Add(client);
                        clients.RemoveAt(i);
                        DGVOtherChats.Rows.RemoveAt(i);
                        dgvOffChat.Rows.Add(client.AliasChat, client.Alias);
                        break;
                    }
                }
            }
        }

        #region RBT
        /// <summary>
        /// Evento la cual impide que escriba el caracter de escape '|', remplazando por un espacio (' ').
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RTBMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='|')
            {
                e.KeyChar = ' ';
            }
            if (e.KeyChar == '°')
            {
                e.KeyChar = ' ';
            }
        }
        #endregion

        #region BTN
        private void btnEnviarMessage_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = DGVOtherChats.SelectedRows;
            btnEnviarMessage.Enabled = false;
            if (filas.Count < 1)
            {
                btnEnviarMessage.Enabled = true;
                MessageBox.Show("No se ha seleccionado ninguna fila de la tabla \" Other Chat \"");
                return;
            }
            foreach (DataGridViewRow item in filas)
            {
                int index = Convert.ToInt32(item.Cells[0].Value.ToString());
                Client client = clients[index];
                if (rbMessage.Checked)
                {
                    client.SendRequest(typeMessage.message, RTBMessage.Text);
                }
                else
                {
                    client.SendRequest(typeMessage.path, RTBMessage.Text);
                }
            }
            RTBMessage.Text = "";
            btnEnviarMessage.Enabled = true;
        }

        private void btnInicializarChat_Click(object sender, EventArgs e)
        {
            if (!ExecuteQuery.insertChat(ExecuteQuery.getIP().ToString(), (int)NUDPort.Value, tbAliasMyChat.Text))
            {
                MessageBox.Show("Servidor ya creado");
                return;
            }
            try
            {
                server = new Server((int)NUDPort.Value, ExecuteQuery.getIP(), tbAliasMyChat.Text);
            }
            catch(Exception ex)
            {
                ExecuteQuery.deleteChat(tbAliasMyChat.Text);
                MessageBox.Show("hubo un error al crear el server, intentélo más tarde");
                return;
            }
            pnMyChat.Enabled = false;
            DGVMyChat.Enabled = true;
            
            Client client = new Client(server.PORT, ExecuteQuery.getIP().ToString(), server.ALIAS);
            client.AliasChat = tbAliasMyChat.Text;
            client.ConnectToServer();
            clients.Add(client);
            client.SendRequest(typeMessage.login, "");
            DGVOtherChats.Rows.Add(DGVOtherChats.RowCount.ToString(), client.AliasChat, client.Alias);
        }
        #endregion

        #region DGV
        private void DGVOtherChats_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }
        private void DGVMyChat_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            server.deleteClient(e.Row.Index);
            DGVMyChat.Rows.RemoveAt(e.Row.Index);
        }
        #endregion

        private void CHAT_Load(object sender, EventArgs e)
        {
            server = ExecuteQuery.startServer();
            if (server != null)
            {
                pnMyChat.Enabled = false;
                NUDPort.Value = server.PORT;
                tbAliasMyChat.Text = server.ALIAS;
                DGVMyChat.Enabled = true;
                Client client = new Client(server.PORT, server.IP.ToString(), server.ALIAS);
                client.AliasChat = server.ALIAS;
                client.ConnectToServer();
                clients.Add(client);
                client.SendRequest(typeMessage.login, "");
                DGVOtherChats.Rows.Add(DGVOtherChats.RowCount.ToString(), client.AliasChat, client.Alias);
            }
            listenerBox = new Thread(new ThreadStart(listenBox));
            activeClients = new Thread(new ThreadStart(activeClient));
            listenClient = new Thread(new ThreadStart(addClientActive));
            listenClient.Start();
            listenerBox.Start();
            activeClients.Start();
        }

        private void btnConectarChat_Click(object sender, EventArgs e)
        {
            if (buscarServidor(tbOtherChat.Text))
            {
                MessageBox.Show("Tratando de conectarse al chat");
            }
            else
            {
                pnOtherChat.Enabled = false;
                string[] conOtherChat = ExecuteQuery.getChat(tbOtherChat.Text);
                Client client = null;
                if (conOtherChat != null)
                {
                    client = new Client(Convert.ToInt32(conOtherChat[0]), conOtherChat[1], tbOtherChat.Text);
                    client.ConnectToServer();
                    tbMyAlias.Text = "";
                    tbOtherChat.Text = "";
                    tbOtherChat.Enabled = true;
                    client.SendRequest(typeMessage.login, "");
                    clients.Add(client);
                    client.AliasChat = tbOtherChat.Text;
                    DGVOtherChats.Rows.Add(DGVOtherChats.RowCount.ToString().ToString(),client.AliasChat, client.Alias);
                    clients.Add(client);
                }
            }
        }

        private bool buscarServidor(string aliasChat)
        {
            foreach(DataGridViewRow row in dgvOffChat.Rows)
            {
                string dgvAlias = (string)row.Cells[0].Value;
                if (dgvAlias == aliasChat)
                {
                    return true;
                }
            }
            return false;
        }

        private void CHAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                listenerBox.Abort();
                activeClients.Abort();
                logins.Abort();
                ExecuteQuery.updateStateChat(0, server.ALIAS);
                foreach (Client client in clients)
                {
                    ExecuteQuery.deleteUserToChat(client.Alias, client.AliasChat);
                }
                foreach (Client client in inactiveClients)
                {
                    ExecuteQuery.deleteUserToChat(client.Alias, client.AliasChat);
                }
            }
        }
    }
}

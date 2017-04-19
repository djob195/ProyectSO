using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace parcial2_1
{
    public class ExecuteQuery
    {
        public const string stringConexion = "Data Source=LAPTOP-4DTTC4T2;Initial Catalog=SOParcial2;Integrated Security=True";
       
        public static IPAddress getIP()
        {
            IPHostEntry iph = Dns.Resolve(Dns.GetHostName());
            IPAddress ipa = iph.AddressList[0];
            return ipa;
        }
        public static string getChatBypathID(string ID, int Port)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(stringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand(Querys.getChatBypathID(), conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Port", Port);
                        SqlDataReader reader = cmd.ExecuteReader();
                        string alias = "";
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                alias = reader["Alias"].ToString();
                            }
                        }
                        else
                        {
                            return null;
                        }
                        reader.Close();
                        return alias;
                    }
                }
            }
            catch (Exception E)
            {
                return null;
            }
        }
        public static bool insertChat(string id, int port, string alias)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(stringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand(Querys.insertChat(), conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Port", port);
                        cmd.Parameters.AddWithValue("@Alias", alias);
                        cmd.Parameters.AddWithValue("@state", 1);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        public static bool updateStateChat(int state, string Alias)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(stringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand(Querys.updateStateChat(), conn))
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                        cmd.Parameters.AddWithValue("@Alias", Alias);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        public static string[] getChat(string Alias)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(stringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand(Querys.getUserToChat(), conn))
                    {
                        cmd.Parameters.AddWithValue("@Alias", Alias);
                        SqlDataReader reader = cmd.ExecuteReader();
                        string[] row = new string[2];
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                row[0] = reader["Port"].ToString();
                                row[1] = reader["ID"].ToString();
                            }
                        }
                        reader.Close();
                        return row;
                    }
                }
            }
            catch (Exception E)
            {
                return null;
            }
        }
        public static string[] getUserToChat(string Alias, string chatAlias)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(stringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand(Querys.getUserToChat(), conn))
                    {
                        cmd.Parameters.AddWithValue("@Alias", Alias);
                        cmd.Parameters.AddWithValue("@chatAlias", chatAlias);
                        SqlDataReader reader = cmd.ExecuteReader();
                        string[] row = new string[1];
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                row[0] = reader["Alias"].ToString();
                            }
                        }
                        reader.Close();
                        return row;
                    }
                }
            }
            catch  (Exception E)
            {
                return null;
            }
        }
        public static bool deleteChat(string Alias)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(stringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand(Querys.deleteChat(), conn))
                    {
                        cmd.Parameters.AddWithValue("@Alias", Alias);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        public static bool deleteUserToChat(string Alias, string chatAlias)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(stringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand(Querys.deleteUserToChat(), conn))
                    {
                        cmd.Parameters.AddWithValue("@Alias", Alias);
                        cmd.Parameters.AddWithValue("@chatAlias", chatAlias);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        public static bool insertUserToChat(string Alias, string chatAlias)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(stringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand(Querys.insertChat(), conn))
                    {
                        cmd.Parameters.AddWithValue("@Alias", Alias);
                        cmd.Parameters.AddWithValue("@Port", chatAlias);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        public static Server startServer()
        {
            using (SqlConnection con = new SqlConnection(stringConexion))
            {
                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    return null;
                    throw;
                }
                SqlCommand command = new SqlCommand(Querys.getChats(), con);
                SqlParameter Id = new SqlParameter();
                IPAddress ip = getIP();
                command.Parameters.AddWithValue("@ID", ip.ToString());
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    string[] row = null;
                    while (reader.Read())
                    {
                        row = new string[3];
                        row[0] = reader["ID"].ToString();
                        row[1] = reader["Port"].ToString();
                        row[2] = reader["Alias"].ToString().Trim();
                    }
                    if (row == null)
                    {
                        return null;
                    }
                    reader.Close();
                    Server server = new Server(Convert.ToInt32(row[1]), ip, row[2]);
                    command = new SqlCommand(Querys.getAllUsertoChat(), con);
                    command.Parameters.AddWithValue(" @chatAlias", row[2]);
                    List<string []> rowUser = new List<string[]>();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        row = new string[1];
                        row[0] = reader["Alias"].ToString();
                        rowUser.Add(row);
                    }
                    reader.Close();
                    server.dgvClients = rowUser;
                    con.Close();
                    while(!updateStateChat(1, row[0]))
                    {

                    }
                    return server;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
        }

    }
}

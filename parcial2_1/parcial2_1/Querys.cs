using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace parcial2_1
{
    public class Querys
    {
        public static string getChats()
        {
            return @" SELECT * 
                FROM Chat 
                WHERE  ID = @ID 
                AND state = 0";
        }

        public static string insertChat()
        {
            return @"INSERT INTO  Chat (ID,Port,Alias,state)
                VALUES (@ID,@Port,@Alias,@state)";
        }

        public static string insertUserToChat()
        {
            return @"INSERT INTO User (Alias,chatAlias)
                VALUES (@Alias,@chatAlias)";
        }

        public static string updateStateChat()
        {
            return @"UPDATE Chat
                SET state = @state
                WHERE Alias = @Alias";
        }

        public static string deleteUserToChat()
        {
            return @"DELETE FROM User
                    WHERE Alias = @Alias
                    AND chatAlias = @chatAlias";
        }

        public static string deleteChat()
        {
            return @"DELETE FROM Chat
                    WHERE Alias = @Alias";
        }
        public static string getUserToChat()
        {
            return @" SELECT Alias 
                FROM User
                WHERE  chatAlias  =  @chatAlias
                AND Alias = @Alias";
        }
        public static string getChatBypathID()
        {
            return @" SELECT Alias 
                FROM Chat
                WHERE  ID = @ID
                AND Port = @Port";
        }
        public static string getAllUsertoChat()
        {
            return @" SELECT Alias 
                FROM User
                WHERE  chatAlias  =  @chatAlias";
        }
        public static string getChat()
        {
            return @" Port, ID
                FROM Chat
                WHERE  Alias  =  @Alias";
        }
    }
}

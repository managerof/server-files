using System;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

namespace Revenge
{
    class mysql
    {
        private static MySqlConnection _connection;
        private String _host { get; set; }
        private String _user { get; set; }
        private String _pwd { get; set; }
        private String _base { get; set; }

        private mysql()
        {
            this._host = "localhost";
            this._user = "root";
            this._pwd = "";
            this._base = "ragemp_base";
        }

        public static void InitConnection()
        {
            mysql sql = new mysql();
            String SQLconnection = $"SERVER={sql._host}; DATABASE={sql._base}; UID={sql._user}; PASSWORD={sql._pwd}";
            _connection = new MySqlConnection(SQLconnection);

            try
            {
                _connection.Open();
                NAPI.Util.ConsoleOutput("Success connection to server MYSQL");
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput("Failed connection to server MYSQL");
                NAPI.Util.ConsoleOutput("Exception: " + ex);
                NAPI.Task.Run(() =>
                {
                    Environment.Exit(0);
                }, delayTime: 5000);
            }
        }
        
        public static bool IsAccountExist(string name)
        {
            MySqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT * FROM accounts WHERE name=@name LIMIT 1";
            command.Parameters.AddWithValue("@name", name);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
        }
    }
}

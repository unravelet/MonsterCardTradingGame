using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Server {
    class Database {


        public void TestInsert(string username, string password) {

            var connString = "Host=localhost;Username=postgres;Password=KnautschgesichtmitDatenbank;Database=MCTG";

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("INSERT INTO Users (name) VALUES (@n,@p", conn);
            cmd.Parameters.AddWithValue("n", username);
            cmd.Parameters.AddWithValue("p", username);

            cmd.ExecuteNonQuery();

        }

        
    }
}

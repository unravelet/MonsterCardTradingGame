using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Server {
    class Database {


        public Database() {
            Connect();
        }

        public async void Connect() {

            var connString = "Host=localhost;Username=postgres;Password=KnautschgesichtmitDatenbank;Database=MCTG";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            // Insert some data
            await using (var cmd = new NpgsqlCommand("INSERT INTO Users username VALUES hi", conn)) {
                cmd.Parameters.AddWithValue("p", "Hello world");
                await cmd.ExecuteNonQueryAsync();
            }

            // Retrieve all rows
            await using (var cmd = new NpgsqlCommand("SELECT username FROM Users", conn))
            await using (var reader = await cmd.ExecuteReaderAsync()) {
                while (await reader.ReadAsync())
                    Console.WriteLine(reader.GetString(0));
            }

        }

        

        

    }
}

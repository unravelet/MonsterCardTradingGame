using Npgsql;

namespace DAL.DB {
    public class Database {
        public NpgsqlConnection conn;

        public NpgsqlConnection Conn { get; set; }


        public Database(string connString) {
            conn = new NpgsqlConnection(connString);

            OpenCon();

        }

        public bool OpenCon() {
            if (conn.State == System.Data.ConnectionState.Open) {
                return true;
            }
            Console.WriteLine("opening connection to database");
            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open) {
                return true;
            }
            return false;

        }

        public bool CloseCon(string connString) {
            if (conn.State == System.Data.ConnectionState.Closed) {
                return true;
            }
            Console.WriteLine("closing con");
            conn.Close();

            if (conn.State == System.Data.ConnectionState.Closed) {
                return true;
            }
            return false;
        }

        public bool ExecuteNonQuery(NpgsqlCommand cmd) {
            cmd.Connection = conn;
            if (cmd.ExecuteNonQuery() == -1) {
                return false;
            }

            return true;
        }

        public NpgsqlDataReader ExecuteQuery(NpgsqlCommand cmd) {
            cmd.Connection = conn;
            return cmd.ExecuteReader();
        }
    }
}

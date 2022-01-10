using DAL.DB;
using Models;
using Npgsql;


namespace DAL.Repository {
    public class UserRepository : IRepository<User> {

        public Database _db;

        public UserRepository(Database db) {
            _db = db;
        }

        //works
        public bool Create(User data) {

            if (UsernameExists(data.Username)){
                Console.WriteLine("Username already exists");
                return false;
            }
            string sql = "INSERT INTO users (username, uid, password, coins) Values (@u,@id,@p,@c)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("u", data.Username);
            cmd.Parameters.AddWithValue("id", data.Uid);
            cmd.Parameters.AddWithValue("p", data.Password);
            cmd.Parameters.AddWithValue("c", data.Coins);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        //works
        public bool Delete(string name) {
            string sql = "DELETE FROM users WHERE username = @u";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("u", name);

            if (_db.ExecuteNonQuery(cmd) && DeleteUsersCards(name)) {
                return true;
            }
            else {
                return false;
            }

        }

        public User Read(string name) {
            throw new NotImplementedException();
        }

        //works
        public List<User> ReadAll() {

            List<User> list = new List<User>();
            string sql = "SELECT * FROM users";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {
                while (reader.Read()) {
                    list.Add(new User(reader.GetValue(0).ToString(),    //username
                        reader.GetValue(1).ToString(),                 //uid
                        reader.GetValue(2).ToString(),                  //password
                        Convert.ToInt32(reader.GetValue(3))             //coins
                        ));
                }
                return list;
            }
        }

        //works
        public bool Update(User data) {

            string sql = "UPDATE users SET password = @p, coins = @c WHERE username = @u";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("p", data.Password);
            cmd.Parameters.AddWithValue("c", data.Coins);
            cmd.Parameters.AddWithValue("u", data.Username);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        //works
        public User FindUser(string username) {

            string sql = "SELECT * FROM users WHERE username = @u";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("u", username);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                if (reader.Read()) {
                    return new User(reader.GetValue(0).ToString(),      //username
                        reader.GetValue(1).ToString(),                  //uid
                        reader.GetValue(2).ToString(),                  //password
                        Convert.ToInt32(reader.GetValue(3))             //coins
                        );
                }
                return null;
            }
        }

        //works
        public bool UsernameExists(string username) {
            string sql = "SELECT username FROM users";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                while (reader.Read()) {
                    if (username == reader.GetValue(0).ToString()) {
                        return true;
                    }
                }
                return false;
            }
        }

        //works
        public string GetUid(string username) {
            string sql = "SELECT uid FROM users WHERE username = @u";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("u", username);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                if (reader.Read()) {
                    return reader.GetValue(0).ToString();
                }

            }
            return null;

        }

        public bool DeleteUsersCards(string owner) {
            string sql = "DELETE FROM cards WHERE owner = @o";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("o", owner);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool UserLogin(string username, string password) {
            if (UsernameExists(username)) {
                string sql = "SELECT password FROM users WHERE username = @u";
                NpgsqlCommand cmd = new NpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("u", username);

                using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                    if (reader.Read()) {
                        if (password == reader.GetValue(0).ToString()) {
                            
                            return true;
                        }
                        else {
                            return false;
                        }
                    } 
                }
            }
            return false;

        }
    }
}

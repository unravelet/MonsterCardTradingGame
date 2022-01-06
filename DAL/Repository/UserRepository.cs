using MonsterCardTradingGame.Models;
using DAL.DB;
using Npgsql;


namespace DAL.Repository {
    class UserRepository : IRepository<User> {

        public Database _db;

        public UserRepository(Database db) { 
            _db = db;
        }

        //works
        public bool Create(User data) {
            string sql = "INSERT INTO users (username, uid, password, coins) Values (@u,@id,@p,@c)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("u", data.Username);
            cmd.Parameters.AddWithValue("id", data.Uid.ToString());
            cmd.Parameters.AddWithValue("p", data.Password);
            cmd.Parameters.AddWithValue("c", data.Coins);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        //works with GetUid(username)
        public bool Delete(Guid id) {
            string sql = "DELETE FROM users WHERE uid = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", id.ToString());

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public User Read(Guid id) {
            throw new NotImplementedException();


        }

        public List<User> ReadAll() {
            
            List<User> list = new List<User>();
            string sql = "SELECT * FROM users";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);

            using (NpgsqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read()) { 
                    list.Add(new User(reader.GetValue(0).ToString(),    //username
                        new Guid(reader.GetValue(1).ToString()),        //uid
                        reader.GetValue(2).ToString(),                  //password
                        Convert.ToInt32(reader.GetValue(3))             //coins
                        ));
                }
                return list;
            }
        }

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

        public User FindUser(string username) {

            string sql = "SELECT FROM users WHERE username = @u";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("u", username);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                if (reader.Read()) {
                    return new User(username,                           //username
                        new Guid(reader.GetValue(1).ToString()),        //uid
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

                while(reader.Read()) {
                    Console.WriteLine(reader.GetValue(0).ToString());
                    if (username == reader.GetValue(0).ToString()) {
                        return true;
                    }
                }
                return false;
            }

        }

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
    }
}

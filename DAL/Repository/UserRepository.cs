using MonsterCardTradingGame.Models;
using DAL.DB;
using Npgsql;


namespace DAL.Repository {
    class UserRepository : IRepository<User> {

        public Database _db;

        public UserRepository(Database db) { 
            _db = db;
        }

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
            throw new NotImplementedException();
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
    }
}

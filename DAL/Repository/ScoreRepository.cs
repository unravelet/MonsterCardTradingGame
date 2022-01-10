using DAL.DB;
using Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository {
    public class ScoreRepository : IRepository<User> {

        public Database _db;

        public ScoreRepository(Database db) {
            _db = db;
        }

        
        public bool Create(User data) {
            if (!UsernameExists(data.Username)) {
                string sql = "INSERT INTO scoreboard (username, score, wins, losses, winloseratio) Values (@u,@s,@w,@l,@wl)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("u", data.Username);
                cmd.Parameters.AddWithValue("s", data.Score);
                cmd.Parameters.AddWithValue("w", data.Wins);
                cmd.Parameters.AddWithValue("l", data.Losses);
                cmd.Parameters.AddWithValue("wl", data.WinLoseRatio);
                if (_db.ExecuteNonQuery(cmd)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        public bool Delete(string name) {
            throw new NotImplementedException();
        }

        public User Read(string name) {
            throw new NotImplementedException();
        }

        public List<User> ReadAll() {
            throw new NotImplementedException();
        }

        public bool Update(User data) {
            if (UsernameExists(data.Username)) {
                string sql = "UPDATE scoreboard SET score = @s, wins = @w, losses = @l, winloseratio = @wl WHERE username = @u";
                NpgsqlCommand cmd = new NpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("u", data.Username);
                cmd.Parameters.AddWithValue("s", data.Score);
                cmd.Parameters.AddWithValue("w", data.Wins);
                cmd.Parameters.AddWithValue("l", data.Losses);
                cmd.Parameters.AddWithValue("wl", data.WinLoseRatio);
                if (_db.ExecuteNonQuery(cmd)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return Create(data);
            }
        }

        public bool UsernameExists(string username) {
            string sql = "SELECT username FROM scoreboard";
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

        public ScoreBoard GetScoreData(string username) {
            
            string sql = "SELECT * FROM scoreboard WHERE username = @u";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("u", username);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                if (reader.Read()) {
                    return new ScoreBoard(reader.GetValue(0).ToString(),  //username
                        Convert.ToInt32(reader.GetValue(1)),                //score
                        Convert.ToInt32(reader.GetValue(2)),                //wins                  
                        Convert.ToInt32(reader.GetValue(3)),                //losses
                        Convert.ToInt32(reader.GetValue(4))                 //winloseratio
                        );
                }
                return null;
            }
        }

        public List<ScoreBoard> GetAllScores() {
            List<ScoreBoard> list = new List<ScoreBoard>();
            string sql = "SELECT * FROM scoreboard";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {
                while (reader.Read()) {
                    list.Add(new ScoreBoard(reader.GetValue(0).ToString(),  //username
                        Convert.ToInt32(reader.GetValue(1)),                //score
                        Convert.ToInt32(reader.GetValue(2)),                //wins                  
                        Convert.ToInt32(reader.GetValue(3)),                //losses
                        Convert.ToDouble(reader.GetValue(4))                 //winloseratio
                        ));
                }
                return list;
            }
        }

        
    }
}

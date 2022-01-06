using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterCardTradingGame.Models;
using DAL.DB;
using Npgsql;

namespace DAL.Repository {

    class CardRepository : IRepository<Card> {

        public Database _db;

        public CardRepository(Database db) {
            _db = db;
        }

        public bool Create(Card data) {
            string sql = "INSERT INTO Cards (id, owner, name, damage, speed, element, monster, isSpell, description) Values (@id,@o,@n,@d,@s,@e,@m,@is,@de)";

            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", data.Id.ToString());
            cmd.Parameters.AddWithValue("o", data.Owner);
            cmd.Parameters.AddWithValue("n", data.Name);
            cmd.Parameters.AddWithValue("d", data.Damage);
            cmd.Parameters.AddWithValue("s", data.Speed);
            cmd.Parameters.AddWithValue("e", data.ElementType.ToString());
            cmd.Parameters.AddWithValue("m", data.MonsterType.ToString());
            cmd.Parameters.AddWithValue("is", data.IsSpell);
            cmd.Parameters.AddWithValue("de", data.Description);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool Delete(Guid id) {
            string sql = "DELETE FROM cards WHERE id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", id.ToString());

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public Card Read(Guid id) {
            throw new NotImplementedException();
        }

        public List<Card> ReadAll() {
            throw new NotImplementedException();
        }

        public bool Update(Card data) {
            throw new NotImplementedException();
        }

        public List<Card> GetUserStack(User user) { 
        
            List<Card> stack = new List<Card>();

            string sql = "SELECT * FROM cards WHERE owner=@o";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("o", user.Username);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                while (reader.Read()) { 
                
                    stack.Add(new Card(new Guid(reader.GetValue(0).ToString()),                                         //id
                        reader.GetValue(1).ToString(),                                                                  //owner
                        reader.GetValue(2).ToString(),                                                                  //name
                        Convert.ToInt32(reader.GetValue(3)),                                                            //damage
                        Convert.ToInt32(reader.GetValue(4)),                                                            //speed
                        (Card.ElementalType)Enum.Parse(typeof(Card.ElementalType),reader.GetValue(5).ToString()),       //element
                        (Card.Monster)Enum.Parse(typeof(Card.Monster), reader.GetValue(5).ToString()),                  //monster
                        bool.Parse(reader.GetValue(7).ToString()),                                                      //isspell
                        reader.GetValue(8).ToString()                                                                   //description
                        ));                        
                }
                return stack;

            }

        }
    }
}

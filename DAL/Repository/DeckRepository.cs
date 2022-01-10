using DAL.DB;
using Models;
using Npgsql;

namespace DAL.Repository {
    public class DeckRepository : IRepository<Card> {
        public Database _db;
        public DeckRepository(Database db) {
            _db = db;
        }
        public bool Create(Card data) {
            string id = Guid.NewGuid().ToString();
            if (!CheckFullDeck(data.Owner)) {
                string sql = "INSERT INTO deck (id, owner, cardname, damage, speed, element, monster, isSpell, description) Values (@id,@o,@n,@d,@s,@e,@m,@is,@de)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("o", data.Owner);
                cmd.Parameters.AddWithValue("n", data.Name);
                cmd.Parameters.AddWithValue("d", data.Damage);
                cmd.Parameters.AddWithValue("s", data.Speed);
                cmd.Parameters.AddWithValue("e", Convert.ToInt32(data.ElementType));
                cmd.Parameters.AddWithValue("m", Convert.ToInt32(data.MonsterType));
                cmd.Parameters.AddWithValue("is", data.IsSpell);
                cmd.Parameters.AddWithValue("de", data.Description);

                if (_db.ExecuteNonQuery(cmd)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return Update(data);
            }



        }

        public bool Delete(string name) {
            string sql = "DELETE FROM deck WHERE owner = @u";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("u", name);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public Card Read(string name) {
            throw new NotImplementedException();
        }

        public List<Card> ReadAll() {
            throw new NotImplementedException();
        }

        public bool Update(Card data) {
            if (Delete(data.Owner)) {

                return Create(data);

            }
            else {
                return false;
            }
        }

        public bool CheckFullDeck(string owner) {
            int counter = 0;
            string sql = "SELECT owner FROM deck";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                while (reader.Read()) {
                    if (owner == reader.GetValue(0).ToString()) {
                        counter++;
                    }
                }

            }
            if (counter == 4) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool CheckEmptyDeck(string owner) {
            int counter = 0;
            string sql = "SELECT owner FROM deck";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                while (reader.Read()) {
                    if (owner == reader.GetValue(0).ToString()) {
                        counter++;
                    }
                }

            }
            if (counter > 0) {
                return false;
            }
            else {
                return true;
            }
        }

        public List<Card> GetUserDeck(string username) {
            List<Card> deck = new List<Card>();

            if (CheckFullDeck(username)) {
                string sql = "SELECT * FROM deck WHERE owner=@o";
                NpgsqlCommand cmd = new NpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("o", username);

                using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                    while (reader.Read()) {

                        deck.Add(new Card(Guid.NewGuid().ToString(),                    //id
                            reader.GetValue(1).ToString(),                              //owner
                            reader.GetValue(2).ToString(),                              //name
                            Convert.ToInt32(reader.GetValue(3)),                        //damage
                            Convert.ToInt32(reader.GetValue(4)),                        //speed
                            (Card.ElementalType)reader.GetValue(5),                     //element
                            (Card.Monster)reader.GetValue(6),                           //monster
                            bool.Parse(reader.GetValue(7).ToString()),                  //isspell
                            reader.GetValue(8).ToString()                               //description
                            ));
                    }

                }
                return deck;
            }
            return null;
        }
    }
}

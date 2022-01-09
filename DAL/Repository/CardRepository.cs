using DAL.DB;
using Models;
using Npgsql;

namespace DAL.Repository {

    public class CardRepository : IRepository<Card> {

        public Database _db;

        public CardRepository(Database db) {
            _db = db;
        }

        //works
        public bool Create(Card data) {
            string sql = "INSERT INTO Cards (id, owner, name, damage, speed, element, monster, isSpell, description) Values (@id,@o,@n,@d,@s,@e,@m,@is,@de)";

            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", data.Id.ToString());
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

        //works
        public bool Delete(string name) {
            string sql = "DELETE FROM cards WHERE name = @n";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("n", name);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public Card Read(string name) {
            string sql = "SELECT * FROM cards WHERE name = @n";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("n", name);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                if (reader.Read()) {
                    return new Card(reader.GetValue(0).ToString(),                         //id
                        reader.GetValue(1).ToString(),                          //owner
                        reader.GetValue(2).ToString(),                          //name
                        Convert.ToInt32(reader.GetValue(3)),                    //damage
                        Convert.ToInt32(reader.GetValue(4)),                    //speed
                        (Card.ElementalType)reader.GetValue(5),                 //element
                        (Card.Monster)reader.GetValue(6),                       //monster
                        bool.Parse(reader.GetValue(7).ToString()),              //isspell
                        reader.GetValue(8).ToString()                           //description
                        );
                }
                return null;
            }
        }

        public List<Card> ReadAll() {
            throw new NotImplementedException();
        }

        public bool Update(Card data) {
            throw new NotImplementedException();
        }


        //works
        public List<Card> GetUserStack(string username) {

            List<Card> stack = new List<Card>();

            string sql = "SELECT * FROM cards WHERE owner=@o";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("o", username);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                while (reader.Read()) {

                    stack.Add(new Card(reader.GetValue(0).ToString(),               //id
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
                return stack;

            }

        }
    }
}

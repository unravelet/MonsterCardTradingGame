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

            Console.WriteLine(data.Owner);
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
    }
}

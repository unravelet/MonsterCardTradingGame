using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Server {
    public class HttpWriter {

        public void Write(HttpResponse response, StreamWriter writer) {
            writer.WriteLine($"{response.Status}");
        
        }

    }
}

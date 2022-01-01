using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    class Package {
       
        public List<Card> _package;

        public Package() { 
            _package = new List<Card>();

            Console.WriteLine("\nCards in package: ");
            for (int j = 0; j < 5; j++) {
                Card card = new Card();
                _package.Add(card.GetCard());
                
            }

        }

        

    }
}

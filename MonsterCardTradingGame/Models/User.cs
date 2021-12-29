using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    class User {
        string _username;
        string _password;
        int _coins;


        public string Username { get { return _username; }
            set { 
                //unique username
                //TODO check database for username
                _username = value; 
            } 
        }
        public string Password { get { return _password;}}
        public int Coins { get { return _coins;} 
            set { 
                if(_coins - value < 0) {
                    _coins = 0;
                }else {
                    _coins += value;
                }
            }
        }
        public User(string username, string password) {
            _username=username;
            _password=password;
            _coins = 20;
        }
    }

}

using DAL.DB;
using DAL.Repository;
using MonsterCardTradingGame.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Server {
    public class HttpServer {

        protected int _port;
        TcpListener _listener;
        public Dictionary<string, HttpController> Controllers;
        Database _db;
        public UserRepository _userRepo;
        public CardRepository _cardRepo;

        public HttpServer(int port, Database db) {
            _port = port;
            _db = db;
            _userRepo = new UserRepository(db);
            _cardRepo = new CardRepository(db);
            Controllers = new Dictionary<string, HttpController>();
            InitController();

        }

        public void Run() {
            _listener = new TcpListener(IPAddress.Loopback, _port);
            _listener.Start(5);
            while (true) {
                TcpClient s = _listener.AcceptTcpClient();
                HttpProcessor processor = new HttpProcessor(s, this);
                new Thread(processor.Process).Start();
                Thread.Sleep(1); 
            }
        }

        

        public void RegisterController(string path, HttpController controller) { 
            Controllers[path] = controller;
        }

        public void InitController() {
            RegisterController("/users", new UserController(this._userRepo));
            RegisterController("/session", new SessionController(this._userRepo));
            RegisterController("/cards", new CardController(this._userRepo, this._cardRepo));
            RegisterController("/deck", new DeckController(this._userRepo, this._cardRepo));
            RegisterController("/package", new PackageController(this._userRepo, this._cardRepo));
            RegisterController("/battle", new BattleController(this._userRepo, this._cardRepo));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Server {
    public class HttpController {

        public virtual HttpResponse Get(HttpRequest request) {
            var r = new HttpResponse();
            r.Status = HttpStatus.BadRequest;

            return r;
        }

        public virtual HttpResponse Post(HttpRequest request) {
            var r = new HttpResponse();
            r.Status = HttpStatus.BadRequest;

            return r;
        }

        public virtual HttpResponse Delete(HttpRequest request) {
            var r = new HttpResponse();
            r.Status = HttpStatus.BadRequest;

            return r;
        }

        public virtual HttpResponse Put(HttpRequest request) {
            var r = new HttpResponse();
            r.Status = HttpStatus.BadRequest;

            return r;
        }

    }
}

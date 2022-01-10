namespace MonsterCardTradingGame.Server {
    public class HttpController {

        public virtual HttpResponse Get(HttpRequest request) {
            var r = new HttpResponse();
            r.Status = (int)HttpStatus.BadRequest;

            return r;
        }

        public virtual HttpResponse Post(HttpRequest request) {
            var r = new HttpResponse();
            r.Status = (int)HttpStatus.BadRequest;

            return r;
        }

        public virtual HttpResponse Delete(HttpRequest request) {
            var r = new HttpResponse();
            r.Status = (int)HttpStatus.BadRequest;

            return r;
        }

        public virtual HttpResponse Put(HttpRequest request) {
            var r = new HttpResponse();
            r.Status = (int)HttpStatus.BadRequest;

            return r;
        }

    }
}

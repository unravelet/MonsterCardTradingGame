namespace MonsterCardTradingGame.Server {


    public enum HttpStatus {
        OK = 200,
        Accepted = 201,
        Created = 202,
        BadRequest = 400,
        Forbidden = 401,
        Notfound = 404
    };


    public class HttpResponse {

        private Dictionary<string, string> _headers;
        public string version = "HTTP/1.1";

        public HttpResponse() {
            _headers = new Dictionary<string, string>();

        }

        public string Body { get; set; }

        public string GetHeaderValue(string header) {
            string value = null;

            if (_headers.TryGetValue(header, out value)) {
                return value;
            }
            else {
                return "";
            }
        }

        
        public void AddHeader(string key, string value) {
            _headers.Add(key, value);
        }

        public HttpStatus Status { get; set; }



    }
}


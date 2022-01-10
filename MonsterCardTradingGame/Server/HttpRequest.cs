namespace MonsterCardTradingGame.Server {
    public class HttpRequest {

        public Dictionary<string, string> _headers;
        public string _method;
        public string _path;
        public string _body;
        public string _version;

        public HttpRequest() {
            _headers = new Dictionary<string, string>();
        }

        public string Method {
            get { return _method; }
            set { _method = value; }
        }
        public string Path {
            get { return _path; }
            set { _path = value; }
        }

        public string Body {
            get { return _body; }
            set { _body = value; }
        }

        public string Version {
            get { return _version; }
            set { _version = value; }
        }

        public string GetHeaderValue(string header) {
            string value = null;

            if (_headers.TryGetValue(header, out value)) {
                return value;
            }
            else {
                return "";
            }
        }

        public void AddHeaders(string key, string value) {
            _headers.Add(key, value);
        }


    }
}

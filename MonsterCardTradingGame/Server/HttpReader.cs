namespace MonsterCardTradingGame.Server {
    public class HttpReader {

        public HttpRequest ReadRequest(StreamReader streamReader) {
            HttpRequest request = new HttpRequest();
            string line = null;

            while ((line = streamReader.ReadLine()) != null) {
                Console.WriteLine(line);

                if (line.Length == 0) {
                    break;
                }

                if (request.Method == null) {
                    var parts = line.Split(' ');
                    request.Method = parts[0];
                    request.Path = parts[1];
                    request.Version = parts[2];
                }
                else {
                    var parts = line.Split(' ');
                    request.AddHeaders(parts[0], parts[1]);
                }
            }

            string body = "";
            while (streamReader.Peek() >= 0) {
                body += (char)streamReader.Read();
            }

            request.Body = body;
            Console.WriteLine(request.Method + " " + request.Path + " " + request.Version);

            return request;
        }


    }
}

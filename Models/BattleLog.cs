namespace Models {
    public class BattleLog {

        string _path;
        string _timeStamp;
        public BattleLog(string filename) {
            _timeStamp = GetTimeStamp();
            //_path = "D:/" + _timeStamp + " " + filename + ".txt";
            _path = "C:/Users/rebek/source/repos/MonsterCardTradingGame/BattleLogs/" + _timeStamp + " " + filename + ".txt";

        }

        public void CreateBattleLog(string text) {
            try {
                TextWriter textWriter = new StreamWriter(_path, true);
                textWriter.WriteLine(text);
                textWriter.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

        }

        public string GetTimeStamp() {

            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

    }
}


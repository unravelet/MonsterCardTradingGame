namespace MonsterCardTradingGame.Models {
    class BattleLog {

        string _path;

        public BattleLog(string filename) {
            _path = "D:/" + filename + ".txt";

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

    }
}

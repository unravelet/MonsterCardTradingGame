namespace Models {
    public class ScoreBoard {

        public string Username { get; set; }
        public int Score { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double WinLoseRatio { get; set; }

        public ScoreBoard(string username, int score, int wins, int losses, double winloseratio) {
            Username = username;
            Score = score;
            Wins = wins;
            Losses = losses;
            WinLoseRatio = winloseratio;
        }

        public string PrintStats() {
            string stats = "\n" + Username +
                ":\nScore: " + Score +
                "\nWins: " + Wins +
                "\nLosses: " + Losses +
                "\nWin-Lose-Ratio: " + WinLoseRatio;

            Console.WriteLine(stats);
            return stats;

        }



    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Beware.Utilities {
    public class ScoreKeeper {
        private static ScoreKeeper instance;
        private float multiplyExpireTime = 0.0f;
        private float multiplierTimeLeft;
        private int maxMultiplier = 20;
        private int scoreForExtraLife;
        private int increaseScoreBy;
        private const string highScoreFileName = "highscore.txt";

        public int Score { get; private set; } = 12345;
        public int HighScore { get; private set; } 
        public int Multiplier { get; private set; }
        public int Lives { get; private set; }
        public bool IsGameOver { get { return Lives == 0; } }

        public static ScoreKeeper Instance {
            get {
                if (instance == null) {
                    instance = new ScoreKeeper();
                }
                return instance;
            }
        }

        private ScoreKeeper() {
            HighScore = LoadHighScore();
            Reset();
        }

        public void Update() {
            if (Multiplier > 1) {
                if ((multiplierTimeLeft -= TimeKeeper.Instance.TotalSeconds) <= 0) {
                    multiplierTimeLeft = multiplyExpireTime;
                    Multiplier = 1;
                }
            }
        }

        public void Reset() {
            if (Score > HighScore) {
                SaveHighScore(HighScore = Score);
            }

            Score = 0;
            Multiplier = 1;
            Lives = 4;
            increaseScoreBy = 20;
            scoreForExtraLife = increaseScoreBy;
            multiplierTimeLeft = 0;
        }

        public void RemoveLife() {
            Lives--;
        }

        // TODO: not sure if this method is really needed.
        public void RemoveRemainingLives() {
            Lives = 0;
        }

        public void IncreaseMultiplier() {
            // TODO: add play IsDead logic == true
            //if (false) {
            //    return;
            //}

            multiplierTimeLeft = multiplyExpireTime;

            if (Multiplier < maxMultiplier) {
                Multiplier++;
            }
        }

        public void DrawScore(Vector2 position) {
            int score = Score;
            int print = score % 10;

            for (int i = 1; i <= 8; i++) {
                Texture2D digit = Helpers.GetDigit(0);

                if (score > 0) {
                    digit = Helpers.GetDigit(print);
                    score = score / 10;
                    print = score % 10;
                }

                BewareGame.Instance._spriteBatch.Draw(digit, position, null, Color.White, 0, new Vector2(digit.Width, digit.Height) / 2.0f, 0.3f, 0, 0.0f);
                position.X = position.X - 50;
            }
        }

        public void DrawHighScore(Vector2 position) {

        }

        private void SaveHighScore(int score) {
            // TODO: digure out how to save top 10.
            File.WriteAllText(highScoreFileName, score.ToString());
        }

        private void AddPoints(int basePoints) {
            // TODO: add player instance IsDead == true.
            //if (false) {
            //    return;
            //}

            Score += Multiplier * basePoints;

            if (Score >= scoreForExtraLife) {
                scoreForExtraLife += increaseScoreBy;
                Lives++;
            }
        }

        private int LoadHighScore() {
            // TODO: digure out how to load top 10.
            return File.Exists(highScoreFileName) && int.TryParse(File.ReadAllText(highScoreFileName), out int score) ? score : 0;
        }
    }
}

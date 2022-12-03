using Beware.Entities;
using Beware.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Beware.Utilities {
    static class ScoreKeeper {
        private static float multiplyExpireTime = 0.0f;
        private static float multiplierTimeLeft;
        private static int maxMultiplier = 20;
        private static int scoreForExtraLife;
        private static int increaseScoreBy;
        private const string highScoreFileName = "highscore.txt";

        public static int Score { get; private set; } = 0;
        public static int HighScore { get; private set; } 
        public static int Multiplier { get; private set; }
        public static int Lives { get; private set; }
        public static bool IsGameOver { get { return Lives == 0; } }

        public static void Initialize() {
            HighScore = LoadHighScore();
            Reset();
        }

        public static void Update() {
            if (Multiplier > 1) {
                if ((multiplierTimeLeft -= TimeKeeper.TotalSeconds) <= 0) {
                    multiplierTimeLeft = multiplyExpireTime;
                    Multiplier = 1;
                }
            }
        }

        public static void Reset() {
            if (Score > HighScore) {
                SaveHighScore(HighScore = Score);
            }

            Score = 0;
            Multiplier = 1;
            Lives = 4;
            increaseScoreBy = 2000;
            scoreForExtraLife = increaseScoreBy;
            multiplierTimeLeft = 0;
        }

        public static void RemoveLife() {
            Lives--;
        }

        // TODO: not sure if this method is really needed.
        public static void RemoveRemainingLives() {
            Lives = 0;
        }

        public static void IncreaseMultiplier() {
            if (PlayerModel.Instance.IsDead) {
                return;
            }

            multiplierTimeLeft = multiplyExpireTime;

            if (Multiplier < maxMultiplier) {
                Multiplier++;
            }
        }

        public static void DrawScore(Vector2 position) {
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

        public static void DrawScoreForNintendo() {
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{Score}", new Vector2(25, ViewportManager.GameboardView.Height - 50), Color.Yellow);

            BewareGame.Instance._spriteBatch.Draw(EntityArt.Player1, new Vector2(ViewportManager.GameboardView.Width - 50, ViewportManager.GameboardView.Height - 40), null, Color.Red, PlayerModel.Instance.Orientation, PlayerModel.Instance.Size / 2f, 1.0f, 0, 0.3f);
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{Lives}", new Vector2(ViewportManager.GameboardView.Width - 60, ViewportManager.GameboardView.Height - 60), Color.Yellow);
        }

        public static void DrawHighScore(Vector2 position) {

        }

        private static void SaveHighScore(int score) {
            // TODO: figure out how to save top 10.
            File.WriteAllText(highScoreFileName, score.ToString());
        }

        public static void AddPoints(int basePoints) {
            if (PlayerModel.Instance.IsDead) {
                return;
            }

            Score += Multiplier * basePoints;

            if (Score >= scoreForExtraLife) {
                scoreForExtraLife += increaseScoreBy;
                Lives++;
            }
        }

        private static int LoadHighScore() {
            // TODO: digure out how to load top 10.
            return File.Exists(highScoreFileName) && int.TryParse(File.ReadAllText(highScoreFileName), out int score) ? score : 0;
        }
    }
}

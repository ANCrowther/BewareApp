using Beware.Entities;
using Beware.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Beware.Utilities {
    static class ScoreKeeper {
        private static int increaseGameRoundBy;
        private static int checkForNextGameRound;
        private const string highScoreFileName = "highscore.txt";

        public static event Action NextRound;

        public static int Score { get; private set; } = 0;
        public static int HighScore { get; private set; }
        public static int EnemyCount { get; private set; } = 0;
        public static int GameRound { get; private set; } = 1;

        public static void Initialize() {
            HighScore = LoadHighScore();
            checkForNextGameRound = increaseGameRoundBy = 5;
            Reset();
        }

        public static void Reset() {
            if (Score > HighScore) {
                SaveHighScore(HighScore = Score);
            }
            Score = 0;
            EnemyCount = 0;
            GameRound = 1;
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

        public static void DrawNintendo(Vector2 position) {
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"Round {GameRound}", position, Color.MintCream);
        }

        public static void DrawScoreForNintendo() {
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{Score}", new Vector2(25, ViewportManager.GameboardView.Height - 50), Color.Yellow);
            BewareGame.Instance._spriteBatch.Draw(EntityArt.Player1, new Vector2(ViewportManager.GameboardView.Width - 50, ViewportManager.GameboardView.Height - 40), null, Color.Red, PlayerModel.Instance.Orientation, PlayerModel.Instance.Size / 2f, 1.0f, 0, 0.3f);
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{GameRound}", new Vector2(ViewportManager.GameboardView.Width - 50, ViewportManager.GameboardView.Height - 50), Color.Yellow);
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{EnemyCount}", new Vector2(ViewportManager.GameboardView.Width / 2, ViewportManager.GameboardView.Height - 50), Color.Yellow);
        }

        public static void DrawGameOverScore(Vector2 position) {
            Vector2 position2 = position;
            position2.X += 400;
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, "Score:", position, Color.MintCream);
            position.Y += 60;
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, "High Score:", position, Color.MintCream);
            position.Y += 60;
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, "Rounds Survived:", position, Color.MintCream);
            position.Y += 60;
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, "Enemies Killed:", position, Color.MintCream);

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{Score}", position2, Color.BlanchedAlmond);
            position2.Y += 60;
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{HighScore}", position2, Color.BlanchedAlmond);
            position2.Y += 60;
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{GameRound}", position2, Color.BlanchedAlmond);
            position2.Y += 60;
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{EnemyCount}", position2, Color.BlanchedAlmond);
        }

        private static void SaveHighScore(int score) {
            // TODO: figure out how to save top 10.
            File.WriteAllText(highScoreFileName, score.ToString());
        }

        public static void AddPoints(int basePoints) {
            if (PlayerModel.Instance.IsExpired) {
                return;
            }
            Score += basePoints;
            UpdateEnemyCountAndGameRound();
        }

        private static void UpdateEnemyCountAndGameRound() {
            EnemyCount++;
            if (EnemyCount == checkForNextGameRound) {
                GameRound++;
                NextRound?.Invoke();
                checkForNextGameRound += increaseGameRoundBy;
            }
        }

        private static int LoadHighScore() {
            // TODO: digure out how to load top 10.
            return File.Exists(highScoreFileName) && int.TryParse(File.ReadAllText(highScoreFileName), out int score) ? score : 0;
        }
    }
}

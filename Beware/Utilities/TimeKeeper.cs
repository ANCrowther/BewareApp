using Beware.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    public class TimeKeeper {
        private static TimeKeeper instance;
        private int print = 0;
        private int minute = 0;
        private int second = 0;
        public int Minutes { get; private set; } = 0;
        public int Seconds { get; private set; } = 0;
        public int MilliSeconds { get; private set; } = 0;
        public float TotalSeconds { get { return (float)BewareGame.GameTime.ElapsedGameTime.TotalSeconds; } }
        public static TimeKeeper Instance {
            get {
                if (instance == null) {
                    instance = new TimeKeeper();
                }
                return instance;
            }
        }

        private TimeKeeper() { }

        public void Update() {
            MilliSeconds += BewareGame.GameTime.ElapsedGameTime.Milliseconds;

            if (MilliSeconds >= 1000) {
                Seconds++;
                MilliSeconds = MilliSeconds / 1000;
            }

            if (Seconds >= 60) {
                Minutes++;
                Seconds = 0;
            }

            // This part allows the Draw feature to create the individual numbers without messing with the clock.
            minute = Minutes;
            second = Seconds;
            print = Seconds % 10;
        }

        public void Draw(Vector2 position) {
            for (int i = 0; i < 4; i++) {
                Texture2D digit = Helpers.GetDigit(0);

                if (i < 2) {
                    if (second > 0) {
                        digit = Helpers.GetDigit(print);
                        second = second / 10;
                        print = second % 10;
                    }
                }
                if (i >= 2) {
                    print = minute % 10;
                    if (minute > 0) {
                        digit = Helpers.GetDigit(print);
                        minute = minute / 10;
                    }
                }

                BewareGame.Instance._spriteBatch.Draw(digit, position, null, Color.White, 0, new Vector2(digit.Width, digit.Height) / 2.0f, 0.3f, 0, 0.0f);
                position.X = position.X - 50;

                //Prints the ':' for the time clock.
                if (i == 1) {
                    digit = Helpers.GetDigit(10);
                    BewareGame.Instance._spriteBatch.Draw(digit, position, null, Color.White, 0, new Vector2(digit.Width, digit.Height) / 2.0f, 0.3f, 0, 0.0f);
                    position.X = position.X - 50;
                }
            }
        }
    }
}

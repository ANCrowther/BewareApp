using Beware.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beware.Utilities {
    public static class Helpers {
        public static string[] menuOptions = { "Play Game", "Player Settings", "Game Settings", "Quit" };

        public static Texture2D GetDigit(int digit) {
            switch (digit) {
                case 1:  return Art.One;
                case 2:  return Art.Two;
                case 3:  return Art.Three;
                case 4:  return Art.Four;
                case 5:  return Art.Five;
                case 6:  return Art.Six;
                case 7:  return Art.Seven;
                case 8:  return Art.Eight;
                case 9:  return Art.Nine;
                case 0:  return Art.Zero;
                default: return Art.Colon; // Simple solution to insert a ':' into the integer time clock
            }
        }

        public static Vector2 GetDirection(Mode type) {
            Vector2 direction = (((type == Mode.Move) ? ControlMap.Move : ControlMap.Shoot) == Buttons.LeftStick) ?
                PlayerInputStates.gamePadState.ThumbSticks.Left : PlayerInputStates.gamePadState.ThumbSticks.Right;
            direction.Y *= -1;

            if (direction.LengthSquared() > 0) {
                direction.Normalize();
            }

            return direction;
        }
    }
}

using Beware.Entities;
using Beware.Enums;
using Beware.ExtensionSupport;
using Beware.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beware.Utilities {
    public static class Helpers {
        public static string[] menuOptions = { "Play Game", "Player Settings", "Game Settings", "Quit" };
        public static Color[] colors = { Color.WhiteSmoke, Color.Gainsboro, Color.Aqua, Color.DeepSkyBlue, Color.Gold, Color.Orange, Color.DarkOrange, Color.Tomato, Color.Red, Color.DarkRed };
        public static Color[] colors2 = { Color.LightCyan, Color.Cyan, Color.MediumSpringGreen, Color.GreenYellow, Color.Yellow, Color.Orange, Color.Tomato, Color.Red };

        public static Texture2D GetDigit(int digit) => digit switch {
            1 => Art.One,
            2 => Art.Two,
            3 => Art.Three,
            4 => Art.Four,
            5 => Art.Five,
            6 => Art.Six,
            7 => Art.Seven,
            8 => Art.Eight,
            9 => Art.Nine,
            0 => Art.Zero,
            _ => Art.Colon
        };

        public static Vector2 GetDirection(Mode type) {
            Vector2 direction = (((type == Mode.Move) ? ControlMap.Move : ControlMap.Shoot) == Buttons.LeftStick) ?
                PlayerInputStates.GamePadState.ThumbSticks.Left : PlayerInputStates.GamePadState.ThumbSticks.Right;
            direction.Y *= -1;

            if (direction.LengthSquared() > 0) {
                direction.Normalize();
            }

            return direction;
        }

        public static void UpdatePlayerGunBehaviour(PlayerModel player) {
            player.MainGun.Aim = Helpers.GetDirection(Mode.Shoot);
            player.MainGun.Orientation = player.Engine.Orientation;
            player.MainGun.IsShooting = Input.IsButtonHeldDown(ControlMap.Shoot);

            if (player.MainGun.Aim.LengthSquared() > 0) {
                player.MainGun.Aim.Normalize();
                player.MainGun.Orientation = player.MainGun.Aim.ToAngle();
            }
        }
    }
}

using Microsoft.Xna.Framework.Input;
using System;

namespace Beware.Inputs {
    public class ControlMap {
        public static Keys MoveUp { get; set; } = Keys.W;
        public static Keys MoveDown { get; set; } = Keys.S;
        public static Keys MoveLeft { get; set; } = Keys.A;
        public static Keys MoveRight { get; set; } = Keys.D;
        public static Keys Pause { get; set; } = Keys.P;
        public static Keys ShootUp { get; set; } = Keys.Up;
        public static Keys ShootDown { get; set; } = Keys.Down;
        public static Keys ShootLeft { get; set; } = Keys.Left;
        public static Keys ShootRight { get; set; } = Keys.Right;
        public static Keys Slow { get; set; } = Keys.Space;
        public static Keys Special { get; set; } = Keys.Y;
        public static Keys Back { get; private set; } = Keys.OemTilde;
        public static Keys Enter { get; private set; } = Keys.Enter;
        public static Keys Mute { get; private set; } = Keys.OemPipe;

        public static Buttons Move_pad { get; set; } = Buttons.LeftStick;
        public static Buttons Shoot_pad { get; set; } = Buttons.RightStick;
        public static Buttons Pause_pad { get; set; } = Buttons.Start;
        public static Buttons Slow_pad { get; set; } = Buttons.LeftTrigger;
        public static Buttons Special_pad { get; set; } = Buttons.RightTrigger;
        public static Buttons Back_pad { get; private set; } = Buttons.Back;
        public static Buttons Enter_pad { get; private set; } = Buttons.Start;
        public static Buttons Mute_pad { get; private set; } = Buttons.DPadDown;

        public static float MaxSpeed { get; set; } = 8.0f;
        public static float MinSpeed { get; set; } = 3.0f;
        public static int MaxLife { get; set; } = 100;
    }
}

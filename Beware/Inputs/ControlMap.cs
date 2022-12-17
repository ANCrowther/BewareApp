using Microsoft.Xna.Framework.Input;

namespace Beware.Inputs {
    public static class ControlMap {
        public static Keys AimDown { get; set; } = Keys.Down;
        public static Keys AimLeft { get; set; } = Keys.Left;
        public static Keys AimRight { get; set; } = Keys.Right;
        public static Keys AimUp { get; set; } = Keys.Up;
        public static Keys MoveUp { get; set; } = Keys.W;
        public static Keys MoveDown { get; set; } = Keys.S;
        public static Keys MoveLeft { get; set; } = Keys.A;
        public static Keys MoveRight { get; set; } = Keys.D;
        public static Keys Shoot { get; set; } = Keys.Space;
        public static Keys Slow { get; set; } = Keys.Q;
        public static Keys Special { get; set; } = Keys.Y;

        public static Keys Back { get; private set; } = Keys.OemTilde;
        public static Keys Enter { get; private set; } = Keys.Enter;
        public static Keys Mute { get; private set; } = Keys.OemPipe;
        public static Keys Pause { get; private set; } = Keys.P;
        public static Keys VolumeUp { get; private set; } = Keys.OemPlus;
        public static Keys VolumeDown { get; private set; } = Keys.OemMinus;


        public static Buttons Aim_pad { get; set; } = Buttons.RightStick;
        public static Buttons Move_pad { get; set; } = Buttons.LeftStick;
        public static Buttons Shoot_pad { get; set; } = Buttons.RightTrigger;
        public static Buttons Slow_pad { get; set; } = Buttons.RightShoulder;
        public static Buttons Special_pad { get; set; } = Buttons.LeftTrigger;
        public static Buttons Boost_pad { get; set; } = Buttons.LeftShoulder;
        public static Buttons SwitchSpecial_Pad { get; set; } = Buttons.Y;

        public static Buttons Back_pad { get; private set; } = Buttons.Back;
        public static Buttons Enter_pad { get; private set; } = Buttons.Start;
        public static Buttons Mute_pad { get; private set; } = Buttons.DPadDown;
        public static Buttons Pause_pad { get; private set; } = Buttons.Start;
        public static Buttons VolumeUp_pad { get; private set; } = Buttons.DPadRight;
        public static Buttons VolumeDown_pad { get; private set; } = Buttons.DPadLeft;

        public static float MaxSpeed { get; set; } = 8.0f;
        public static float MinSpeed { get; set; } = 3.0f;
        public static int MaxLife { get; set; } = 100;
    }
}

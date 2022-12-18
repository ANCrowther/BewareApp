using Microsoft.Xna.Framework.Input;

namespace Beware.Inputs {
    public static class ControlMap {
        // Mappable controls
        public static Buttons Aim { get; set; } = Buttons.RightStick;
        public static Buttons Move { get; set; } = Buttons.LeftStick;
        public static Buttons Shoot { get; set; } = Buttons.RightTrigger;
        public static Buttons Slow { get; set; } = Buttons.RightShoulder;
        public static Buttons Special { get; set; } = Buttons.LeftTrigger;
        public static Buttons Boost { get; set; } = Buttons.LeftShoulder;
        public static Buttons SwitchSpecial { get; set; } = Buttons.Y;
        public static Buttons Accept { get; set; } = Buttons.A;

        // Non-mappable controls
        public static Buttons Back { get; private set; } = Buttons.Back;
        public static Buttons Enter { get; private set; } = Buttons.Start;
        public static Buttons Mute { get; private set; } = Buttons.DPadDown;
        public static Buttons Pause { get; private set; } = Buttons.Start;
        public static Buttons VolumeUp { get; private set; } = Buttons.DPadRight;
        public static Buttons VolumeDown { get; private set; } = Buttons.DPadLeft;
        public static Keys Mute_key { get; private set; } = Keys.OemPipe;
        public static Keys VolumeUp_key { get; private set; } = Keys.OemPlus;
        public static Keys VolumeDown_key { get; private set; } = Keys.OemMinus;
    }
}

namespace Beware.Utilities {
    static class PlayerStatus {
        public static int SpecialAmmoCount { get; set; } = 0;
        public static int MaxShieldCountdown { get; private set; } = 5;
        public static int MaxBoostCountdown { get; private set; } = 2;
        public static int MaxBoostWaitCountdown { get; private set; } = 5;
        public static bool IsPaused { get; set; } = false;
        public static bool IsSpecialDefensive { get; set; } = true;
    }
}

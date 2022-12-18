namespace Beware.Utilities {
    static class PlayerStatus {
        public static int SpecialAmmoCount { get; set; } = 0;
        public static bool IsSlow { get; set; } = false;
        public static float MaxSpeed { get; set; } = 8.0f;
        public static float MinSpeed { get; set; } = 3.0f;
    }
}

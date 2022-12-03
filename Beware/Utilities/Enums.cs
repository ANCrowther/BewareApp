namespace Beware.Utilities {
    public enum Direction {
        Down,
        Left,
        Right,
        Up
    }

    public enum Dimension {
        Nintendo,
        Standard
    }

    public enum GameSettings {
        Layout,
        Volume
    }

    public enum PlayerSettings {
        Keyboard,
        Gamepad,
        Generic,
        Standard
    }

    public enum Mode {
        Move,
        Shoot
    }

    public enum Resolution {
        Game,
        Menu
    }

    public enum View {
        GamePlay,
        InfoOne,
        InfoTwo,
        Menu,
        Ticker,
    }

    public enum ViewportLayout {
        Layout1,
        Layout2,
        Layout3
    }

    public enum VolumeType {
        Master,
        Music,
        SFX
    }

    public enum BehaviourCategory {
        Move,
        Shoot,
        Slow,
        Special
    }

    public enum PlayerBehaviourType {
        PlayerAttack1,
        PlayerAttack2,
        PlayerMove1,
        PlayerSlow1,
        PlayerSpecial
    }

    public enum EntityType {
        Enemy_Wandering,
        Enemy_Seeker
    }
}

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
        HUD,
        InfoOne,
        InfoTwo,
        Menu,
        Ticker,
    }

    public enum ViewportLayout {
        Nintendo,
        NoPanel,
        Parallel,
        SinglePanelLeft,
        SinglePanelRIght,
        Unbalanced
    }

    public enum VolumeType {
        Master,
        Music,
        SFX
    }

    public enum BehaviourCategory {
        Boost,
        Move,
        Shoot,
        SpecialDefensive,
        SpecialOffensive
    }

    public enum PlayerBehaviourType {
        RapidFire,
        SabotShoot,
        PlayerBasicMove,
        PlayerBoost,
        PlayerSlow1,
        PlayerShield,
        PlayerShieldMove
    }

    public enum EntityBehaviourType {
        SeekerMove,
        SeekerShield,
        SeekerShoot,
        WandererMove,
        WandererShield,
        WandererShoot
    }

    public enum DroppedItemBehaviourType {
        AmmoDrop,
        ShieldDrop
    }

    public enum DroppedItemType {
        SabotAmmoDrop,
        RegularShieldDrop
    }

    public enum EntityType {
        Enemy_Wandering,
        Enemy_Seeker
    }
}

using Beware.Behaviours;
using Beware.Utilities;

namespace Beware.Entities {
    public static class PlayerBehaviourBuilder {
        public static IBehaviour Factory(PlayerBehaviourType behaviour) => behaviour switch {
            PlayerBehaviourType.RapidFire => new PlayerRapidFireBehaviour(),
            PlayerBehaviourType.SabotShoot => new PlayerSabotShootBehaviour(),
            PlayerBehaviourType.PlayerBasicMove => new PlayerMoveBehaviour(),
            PlayerBehaviourType.PlayerShield => new PlayerShieldBehaviour(),
            PlayerBehaviourType.PlayerBoost => new PlayerBoostBehaviour(),
            _ => new PlayerRapidFireBehaviour()
        };
    }
}

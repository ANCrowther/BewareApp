using Beware.Behaviours;
using Beware.Utilities;

namespace Beware.Entities {
    public static class PlayerBehaviourBuilder {
        public static IBehaviour Factory(PlayerBehaviourType behaviour) {
            switch (behaviour) {
                case PlayerBehaviourType.RapidFire:
                    return new PlayerRapidFireBehaviour();
                case PlayerBehaviourType.SabotShoot:
                    return new PlayerSabotShootBehaviour();
                case PlayerBehaviourType.PlayerBasicMove:
                    return new PlayerMoveBehaviour();
                case PlayerBehaviourType.PlayerShield:
                    return new PlayerShieldBehaviour();
                default:
                    return new PlayerRapidFireBehaviour();
            }
        }
    }
}

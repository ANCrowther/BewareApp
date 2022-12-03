using Beware.Behaviours;
using Beware.Utilities;

namespace Beware.Entities {
    public static class PlayerBehaviourBuilder {
        public static IBehaviour Factory(PlayerBehaviourType behaviour) {
            switch (behaviour) {
                case PlayerBehaviourType.PlayerAttack1:
                    return new PlayerAttackBehaviour();
                case PlayerBehaviourType.PlayerMove1:
                    return new PlayerMoveBehaviour();
                case PlayerBehaviourType.PlayerSlow1:
                    return new PlayerSlowBehaviour();
                default:
                    return new PlayerAttackBehaviour();
            }
        }
    }
}

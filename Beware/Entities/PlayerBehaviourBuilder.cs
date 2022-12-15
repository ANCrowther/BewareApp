﻿using Beware.Behaviours;
using Beware.Utilities;

namespace Beware.Entities {
    public static class PlayerBehaviourBuilder {
        public static IBehaviour Factory(PlayerBehaviourType behaviour) {
            switch (behaviour) {
                case PlayerBehaviourType.RapidFire:
                    return new PlayerRapidFireBehaviour();
                case PlayerBehaviourType.SabotShoot:
                    return new PlayerSabotShootBehaviour();
                case PlayerBehaviourType.PlayerMove1:
                    return new PlayerMoveBehaviour();
                case PlayerBehaviourType.PlayerSlow1:
                    return new PlayerSlowBehaviour();
                default:
                    return new PlayerRapidFireBehaviour();
            }
        }
    }
}

using Beware.Enums;

namespace Beware.Behaviours {
    static class EntityBehaviourBuilder {
        public static IBehaviour Factory(EntityBehaviourType behaviour) {
            return behaviour switch {
                EntityBehaviourType.SeekerMove => new EnemySeekerMoveBehaviour(),
                EntityBehaviourType.SeekerShield => null,
                EntityBehaviourType.SeekerShoot => new EnemyShootBehaviour(),
                EntityBehaviourType.WandererMove => new EnemyWandererMoveBehaviour(),
                EntityBehaviourType.WandererShield => null,
                EntityBehaviourType.WandererShoot => new EnemyRandomShootBehaviour(),
                _ => null,
            };
        }
    }
}

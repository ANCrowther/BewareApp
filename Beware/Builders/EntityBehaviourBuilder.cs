using Beware.Utilities;

namespace Beware.Behaviours {
    static class EntityBehaviourBuilder {
        public static IBehaviour Factory(EntityBehaviourType behaviour) {
            switch (behaviour) {
                case EntityBehaviourType.SeekerMove:
                    return new EnemySeekerMoveBehaviour();
                case EntityBehaviourType.SeekerShield:
                    return null;
                case EntityBehaviourType.SeekerShoot:
                    return new EnemyShootBehaviour();
                case EntityBehaviourType.WandererMove:
                    return new EnemyWandererMoveBehaviour();
                case EntityBehaviourType.WandererShield:
                    return null;
                case EntityBehaviourType.WandererShoot:
                    return new EnemyRandomShootBehaviour();
                default:
                    return null;
            }
        }
    }
}

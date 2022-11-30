using Beware.Utilities;

namespace Beware.Entities {
    public static class EntityBuilder {
        public static EntityModel Factory(EntityType entityType) {
            switch (entityType) {
                case EntityType.Enemy_Wandering:
                    return new EnemyWandererModel();
                default:
                    return new EnemyWandererModel();
            }
        }
    }
}

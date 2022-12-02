using Beware.Behaviours;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public static class EntityBuilder {
        public static EntityModel Factory(EntityType selection, Vector2 position) {
            switch (selection) {
                case EntityType.Enemy_Wandering:
                    EnemyWandererModel wanderer = new EnemyWandererModel(EntityArt.EnemyWanderer, position);
                    wanderer.SetBehaviour(new EnemyWandererMoveBehaviour());
                    return wanderer;
                case EntityType.Enemy_Seeker:
                    EnemyFollowerModel follower = new EnemyFollowerModel(EntityArt.EnemySeeker, position);
                    follower.SetBehaviour(new EnemyFollowerMoveBehaviour());
                    return follower;
                default:
                    EnemyWandererModel defaultEnemy = new EnemyWandererModel(EntityArt.EnemyWanderer, position);
                    defaultEnemy.SetBehaviour(new EnemyWandererMoveBehaviour());
                    return defaultEnemy;
            }
        }
    }
}

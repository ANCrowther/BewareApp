using Beware.Behaviours;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public static class EntityBuilder {
        public static EntityModel Factory(EntityType selection, Vector2 position) {
            switch (selection) {
                case EntityType.Enemy_Wandering:
                    EnemyWandererModel wanderer = new EnemyWandererModel(EntityArt.EnemyWanderer, position);
                    wanderer.SetBehaviour(BehaviourCategory.Move, new EnemyWandererMoveBehaviour());
                    return wanderer;
                case EntityType.Enemy_Seeker:
                    EnemyFollowerModel follower = new EnemyFollowerModel(EntityArt.EnemySeeker, position);
                    follower.SetBehaviour(BehaviourCategory.Move, new EnemyFollowerMoveBehaviour());
                    return follower;
                default:
                    EnemyWandererModel defaultEnemy = new EnemyWandererModel(EntityArt.EnemyWanderer, position);
                    defaultEnemy.SetBehaviour(BehaviourCategory.Move, new EnemyWandererMoveBehaviour());
                    return defaultEnemy;
            }
        }
    }
}

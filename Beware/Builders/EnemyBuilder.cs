﻿using Beware.Behaviours;
using Beware.EntityFeatures;
using Beware.Enums;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public static class EnemyBuilder {
        public static EntityModel Factory(EnemyType selection, Vector2 position) {
            switch (selection) {
                case EnemyType.Enemy_Wandering:
                    EnemyWandererModel wanderer = new EnemyWandererModel(new Engine(position, Vector2.Zero), new Sprite(EntityArtType.EnemyWanderer), (int)(ScoreKeeper.GameRound * 1.15), (int)(ScoreKeeper.GameRound * 1.15) + 1);
                    wanderer.SetBehaviour(BehaviourCategory.Move, EntityBehaviourBuilder.Factory(EntityBehaviourType.WandererMove));
                    wanderer.SetBehaviour(BehaviourCategory.Shoot, EntityBehaviourBuilder.Factory(EntityBehaviourType.WandererShoot));
                    return wanderer;
                case EnemyType.Enemy_Seeker:
                    EnemyFollowerModel seeker = new EnemyFollowerModel(new Engine(position, Vector2.Zero), new Sprite(EntityArtType.EnemySeeker), (int)(ScoreKeeper.GameRound * 1.25), (int)(ScoreKeeper.GameRound * 1.25) + 1);
                    seeker.SetBehaviour(BehaviourCategory.Move, EntityBehaviourBuilder.Factory(EntityBehaviourType.SeekerMove));
                    seeker.SetBehaviour(BehaviourCategory.Shoot, EntityBehaviourBuilder.Factory(EntityBehaviourType.SeekerShoot));
                    return seeker;
                default:
                    EnemyWandererModel defaultEnemy = new EnemyWandererModel(new Engine(position, Vector2.Zero), new Sprite(EntityArtType.EnemyWanderer), (int)(ScoreKeeper.GameRound * 1.15), (int)(ScoreKeeper.GameRound * 1.15) + 1);
                    defaultEnemy.SetBehaviour(BehaviourCategory.Move, EntityBehaviourBuilder.Factory(EntityBehaviourType.WandererMove));
                    return defaultEnemy;
            }
        }
    }
}

﻿using Beware.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Beware.Managers {
    static class EntityManager {
        private static bool isUpdating;
        private static List<EntityModel> entityList = new List<EntityModel>();
        private static List<EntityModel> addEntityList = new List<EntityModel>();
        private static List<EnemyModel> enemyList = new List<EnemyModel>();

        public static int Count { get { return entityList.Count; } }

        public static void Add(EntityModel entity) {
            if (isUpdating == false) {
                AddEntity(entity);
            } else {
                addEntityList.Add(entity);
            }
        }

        private static void AddEntity(EntityModel entity) {
            entityList.Add(entity);

            if (entity is EnemyModel) {
                enemyList.Add(entity as EnemyModel);
            }
        }

        public static void Update() {
            isUpdating = true;
            HandleCollisions();

            foreach (var entity in entityList) {
                entity.Update();
            }

            isUpdating = false;

            foreach (var entity in addEntityList) {
                AddEntity(entity);
            }

            BulletManager.Update();

            addEntityList.Clear();

            entityList = entityList.Where(x => x.IsExpired == false).ToList();
            enemyList = enemyList.Where(x => x.IsExpired == false).ToList();
        }

        public static void Draw() {
            foreach (var entity in entityList) {
                entity.Draw();
            }
            BulletManager.Draw();
        }

        private static bool IsColliding(EntityModel a, EntityModel b) {
            float radius = a.CollisionRadius + b.CollisionRadius;
            return !a.IsExpired && !b.IsExpired && Vector2.DistanceSquared(a.Position, b.Position) < radius * radius;
        }

        static void HandleCollisions() {
            // Collisions between enemies
            for (int i = 0; i < enemyList.Count; i++) {
                for (int j = 0; j < enemyList.Count; j++) {
                    if (IsColliding(enemyList[i], enemyList[j])) {
                        enemyList[i].HandleCollision(enemyList[j]);
                        enemyList[j].HandleCollision(enemyList[i]);
                    }
                }
            }

            // Collisions between bullets and enemies
            for (int i = 0; i < enemyList.Count; i++) {
                for (int j = 0; j < BulletManager.playerBullets.Count; j++) {
                    if (IsColliding(enemyList[i], BulletManager.playerBullets[j])) {
                        enemyList[i].Hit(BulletManager.playerBullets[j].ImpactDamage);
                        if (!(BulletManager.playerBullets[j] is SabotRound)) {
                            BulletManager.playerBullets[j].IsExpired = true;
                        } 
                            
                    }
                }
            }

            // Collisions between player and enemies
            for (int i = 0; i < enemyList.Count; i++) {
                if (PlayerModel.Instance.Shield != null) {
                    if (enemyList[i].IsActive && IsColliding(PlayerModel.Instance.Shield, enemyList[i])) {
                        PlayerModel.Instance.Shield.Hit(enemyList[i].ImpactDamage);
                        enemyList[i].Hit(PlayerModel.Instance.Shield.ImpactDamage);
                        break;
                    }
                }
                if (enemyList[i].IsActive && IsColliding(PlayerModel.Instance, enemyList[i])) {
                    PlayerModel.Instance.Hit(enemyList[i].ImpactDamage);
                    enemyList[i].Hit(PlayerModel.Instance.ImpactDamage);
                    break;
                }
            }

            for (int i = 0; i < BulletManager.enemyBullets.Count; i++) {
                if (BulletManager.enemyBullets[i].IsExpired == false && IsColliding(PlayerModel.Instance, BulletManager.enemyBullets[i])) {
                    PlayerModel.Instance.Hit(BulletManager.enemyBullets[i].ImpactDamage);
                    BulletManager.enemyBullets[i].Hit(PlayerModel.Instance.ImpactDamage);
                    break;
                }
            }
        }

        public static void Clear() {
            entityList.Clear();
            addEntityList.Clear();
            enemyList.Clear();
            BulletManager.Clear();
        }

        public static void RoundChange() {
            addEntityList.Clear();
            enemyList.Clear();
            BulletManager.Clear();
        }
    }
}

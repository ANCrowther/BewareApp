using Beware.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Beware.Managers {
    static class EntityManager {
        private static bool isUpdating;
        private static List<EntityModel> entityList = new List<EntityModel>();
        private static List<EntityModel> addEntityList = new List<EntityModel>();
        private static List<EnemyModel> enemyList = new List<EnemyModel>();
        private static List<BulletModel> bulletList = new List<BulletModel>();

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

            if (entity is BulletModel) {
                bulletList.Add(entity as BulletModel);
            } else if (entity is EnemyModel) {
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

            addEntityList.Clear();

            entityList = entityList.Where(x => x.IsExpired == false).ToList();
            bulletList = bulletList.Where(x => x.IsExpired == false).ToList();
            enemyList = enemyList.Where(x => x.IsExpired == false).ToList();
        }

        public static void Draw() {
            foreach (var entity in entityList) {
                entity.Draw();
            }
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
                for (int j = 0; j < bulletList.Count; j++) {
                    if (IsColliding(enemyList[i], bulletList[j])) {
                        enemyList[i].WasShot();
                        bulletList[j].IsExpired = true;
                    }
                }
            }

            // Collisions between player and enemies
            for (int i = 0; i < enemyList.Count; i++) {
                if (enemyList[i].IsActive && IsColliding(PlayerModel.Instance, enemyList[i])) {
                    PlayerModel.Instance.Kill();
                    enemyList.ForEach(x => x.WasShot());
                    break;
                }
            }
        }

        public static void Clear() {
            entityList.Clear();
            addEntityList.Clear();
            enemyList.Clear();
            bulletList.Clear();
        }
    }
}

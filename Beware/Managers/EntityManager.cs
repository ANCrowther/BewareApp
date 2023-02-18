using Beware.Entities;
using Beware.ExtensionSupport;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Beware.Managers {
    static class EntityManager {
        private static bool isUpdating;
        private static List<EntityModel> entityList = new List<EntityModel>();
        private static readonly List<EntityModel> addEntityList = new List<EntityModel>();
        private static List<EnemyModel> enemyList = new List<EnemyModel>();
        private static List<DroppedItemModel> droppedItemList = new List<DroppedItemModel>();

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

            if (entity is EnemyModel e) {
                enemyList.Add(e);
            }
            if(entity is DroppedItemModel d) {
                droppedItemList.Add(d);
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

            AmmoManager.Update();

            addEntityList.Clear();

            entityList = entityList.Where(x => x.IsExpired == false).ToList();
            enemyList = enemyList.Where(x => x.IsExpired == false).ToList();
            droppedItemList = droppedItemList.Where(x => x.IsExpired == false).ToList();
        }

        public static void Draw() {
            foreach (var entity in entityList) {
                entity.Draw();
            }
            AmmoManager.Draw();
        }

        static void HandleCollisions() {
            // Collisions between enemies
            for (int i = 0; i < enemyList.Count; i++) {
                for (int j = 0; j < enemyList.Count; j++) {
                    if (enemyList[i].CollisionCircle.Intersects(enemyList[j].CollisionCircle)) {
                        enemyList[i].HandleCollision(enemyList[j]);
                        enemyList[j].HandleCollision(enemyList[i]);
                    }
                }
            }

            // Collisions between bullets and enemies
            for (int i = 0; i < enemyList.Count; i++) {
                for (int j = 0; j < AmmoManager.playerBullets.Count; j++) {
                    if (enemyList[i].CollisionCircle.Intersects(AmmoManager.playerBullets[j].CollisionCircle)) {
                        enemyList[i].Hit(AmmoManager.playerBullets[j].ImpactDamage);
                        AmmoManager.playerBullets[j].Hit(enemyList[i].ImpactDamage);
                    }
                }
            }

            // Collisions between player and enemies
            for (int i = 0; i < enemyList.Count; i++) {
                if (PlayerModel.Instance.Shield != null) {
                    if (enemyList[i].Shield != null) {
                        if (enemyList[i].IsActive && PlayerModel.Instance.Shield.CollisionCircle.Intersects(enemyList[i].Shield.CollisionCircle)) {
                            PlayerModel.Instance.Shield.Hit(enemyList[i].ImpactDamage);
                            enemyList[i].Shield.Hit(PlayerModel.Instance.Shield.ImpactDamage);
                            break;
                        }
                    }else {
                        if (enemyList[i].IsActive && PlayerModel.Instance.Shield.CollisionCircle.Intersects(enemyList[i].CollisionCircle)) {
                            PlayerModel.Instance.Shield.Hit(enemyList[i].ImpactDamage);
                            enemyList[i].Hit(PlayerModel.Instance.Shield.ImpactDamage);
                            break;
                        }
                    }


                } else {
                    if (enemyList[i].Shield != null) {
                        if (enemyList[i].IsActive && PlayerModel.Instance.CollisionCircle.Intersects(enemyList[i].Shield.CollisionCircle)) {
                            PlayerModel.Instance.Hit(enemyList[i].ImpactDamage);
                            enemyList[i].Shield.Hit(PlayerModel.Instance.ImpactDamage);
                            break;
                        }
                    } else {
                        if (enemyList[i].IsActive && PlayerModel.Instance.CollisionCircle.Intersects(enemyList[i].CollisionCircle)) {
                            PlayerModel.Instance.Hit(enemyList[i].ImpactDamage);
                            enemyList[i].Hit(PlayerModel.Instance.ImpactDamage);
                            break;
                        }
                    }

                }

            }

            // Collisions between player and droppedItems
            for (int i = 0; i < droppedItemList.Count; i++) {
                if (droppedItemList[i].IsExpired == false && PlayerModel.Instance.CollisionCircle.Intersects(droppedItemList[i].CollisionCircle)) {
                    droppedItemList[i].Hit(Vector2.Zero);
                    break;
                }
            }

            for (int i = 0; i < AmmoManager.enemyBullets.Count; i++) {
                if (PlayerModel.Instance.Shield != null) {
                    if (PlayerModel.Instance.Shield.CollisionCircle.Intersects(AmmoManager.enemyBullets[i].CollisionCircle)) {
                        PlayerModel.Instance.Shield.Hit(AmmoManager.enemyBullets[i].ImpactDamage);
                        AmmoManager.enemyBullets[i].Hit(PlayerModel.Instance.Shield.ImpactDamage);
                    }
                } else {
                    if (PlayerModel.Instance.CollisionCircle.Intersects(AmmoManager.enemyBullets[i].CollisionCircle)) {
                        PlayerModel.Instance.Hit(AmmoManager.enemyBullets[i].ImpactDamage);
                        AmmoManager.enemyBullets[i].Hit(PlayerModel.Instance.ImpactDamage);
                    }
                }
            }
        }

        public static void Clear() {
            entityList.Clear();
            addEntityList.Clear();
            enemyList.Clear();
            droppedItemList.Clear();
            AmmoManager.Clear();
        }

        public static void RoundChange() {
            addEntityList.Clear();
            enemyList.Clear();
            AmmoManager.Clear();
        }
    }
}

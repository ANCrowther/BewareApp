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
                EnemyManager.Add(e);
            }
            if (entity is AmmoModel b) {
                AmmoManager.Add(b);
            }
            if (entity is DroppedItemModel d) {
                DroppedItemManager.Add(d);
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
            EnemyManager.Update();
            DroppedItemManager.Update();

            addEntityList.Clear();
            entityList = entityList.Where(x => x.IsExpired == false).ToList();
        }

        public static void Draw() {
            PlayerModel.Instance.Draw();
            AmmoManager.Draw();
            EnemyManager.Draw();
            DroppedItemManager.Draw();
        }

        static void HandleCollisions() {
            // Collisions between enemies
            for (int i = 0; i < EnemyManager.enemies.Count; i++) {
                for (int j = 0; j < EnemyManager.enemies.Count; j++) {
                    if (EnemyManager.enemies[i].CollisionCircle.Intersects(EnemyManager.enemies[j].CollisionCircle)) {
                        EnemyManager.enemies[i].HandleCollision(EnemyManager.enemies[j]);
                        EnemyManager.enemies[j].HandleCollision(EnemyManager.enemies[i]);
                    }
                }
            }

            // Collisions between bullets and enemies
            for (int i = 0; i < EnemyManager.enemies.Count; i++) {
                for (int j = 0; j < AmmoManager.playerBullets.Count; j++) {
                    if (EnemyManager.enemies[i].CollisionCircle.Intersects(AmmoManager.playerBullets[j].CollisionCircle)) {
                        EnemyManager.enemies[i].Hit(AmmoManager.playerBullets[j].ImpactDamage);
                        AmmoManager.playerBullets[j].Hit(EnemyManager.enemies[i].ImpactDamage);
                    }
                }
            }

            // Collisions between player and enemies
            for (int i = 0; i < EnemyManager.enemies.Count; i++) {
                if (PlayerModel.Instance.Shield != null) {
                    if (EnemyManager.enemies[i].Shield != null) {
                        if (EnemyManager.enemies[i].IsActive && PlayerModel.Instance.Shield.CollisionCircle.Intersects(EnemyManager.enemies[i].Shield.CollisionCircle)) {
                            PlayerModel.Instance.Shield.Hit(EnemyManager.enemies[i].ImpactDamage);
                            EnemyManager.enemies[i].Shield.Hit(PlayerModel.Instance.Shield.ImpactDamage);
                            break;
                        }
                    }else {
                        if (EnemyManager.enemies[i].IsActive && PlayerModel.Instance.Shield.CollisionCircle.Intersects(EnemyManager.enemies[i].CollisionCircle)) {
                            PlayerModel.Instance.Shield.Hit(EnemyManager.enemies[i].ImpactDamage);
                            EnemyManager.enemies[i].Hit(PlayerModel.Instance.Shield.ImpactDamage);
                            break;
                        }
                    }


                } else {
                    if (EnemyManager.enemies[i].Shield != null) {
                        if (EnemyManager.enemies[i].IsActive && PlayerModel.Instance.CollisionCircle.Intersects(EnemyManager.enemies[i].Shield.CollisionCircle)) {
                            PlayerModel.Instance.Hit(EnemyManager.enemies[i].ImpactDamage);
                            EnemyManager.enemies[i].Shield.Hit(PlayerModel.Instance.ImpactDamage);
                            break;
                        }
                    } else {
                        if (EnemyManager.enemies[i].IsActive && PlayerModel.Instance.CollisionCircle.Intersects(EnemyManager.enemies[i].CollisionCircle)) {
                            PlayerModel.Instance.Hit(EnemyManager.enemies[i].ImpactDamage);
                            EnemyManager.enemies[i].Hit(PlayerModel.Instance.ImpactDamage);
                            break;
                        }
                    }
                }
            }

            // Collisions between player and droppedItems
            for (int i = 0; i < DroppedItemManager.items.Count; i++) {
                if (DroppedItemManager.items[i].IsExpired == false && PlayerModel.Instance.CollisionCircle.Intersects(DroppedItemManager.items[i].CollisionCircle)) {
                    DroppedItemManager.items[i].Hit();
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
            ClearManagers();
        }

        public static void RoundChange() {
            addEntityList.Clear();
            ClearManagers();
        }

        private static void ClearManagers() {
            EnemyManager.Clear();
            DroppedItemManager.Clear();
            AmmoManager.Clear();
        }
    }
}

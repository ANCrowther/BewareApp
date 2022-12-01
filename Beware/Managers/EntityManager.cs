using Beware.Entities;
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

        public static void Clear() {
            entityList.Clear();
            addEntityList.Clear();
            enemyList.Clear();
            bulletList.Clear();
        }
    }
}

using Beware.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beware.Managers {
    static class EnemyManager {
        public static List<EnemyModel> enemies = new List<EnemyModel>();

        public static void Add(EnemyModel enemy) {
            enemies.Add(enemy);
        }

        public static void Update() {
            foreach (var enemy in enemies) {
                enemy.Update();
            }

            enemies = enemies.Where(x => x.IsExpired == false).ToList();
        }

        public static void Clear() {
            enemies.Clear();
        }

        public static void Draw() {
            foreach (var enemy in enemies) {
                enemy.Draw();
            }
        }
    }
}

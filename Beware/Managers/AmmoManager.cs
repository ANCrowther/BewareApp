using Beware.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beware.Managers {
    static class AmmoManager {
        public static List<AmmoModel> playerBullets = new List<AmmoModel>();
        public static List<AmmoModel> enemyBullets = new List<AmmoModel>();

        public static void AddPlayerBullet(AmmoModel bullet) {
            playerBullets.Add(bullet);
        }

        public static void AddEnemyBullets(AmmoModel bullet) {
            enemyBullets.Add(bullet);
        }

        public static void Update() {
            foreach (var bullet in playerBullets) {
                bullet.Update();
            }
            foreach (var bullet in enemyBullets) {
                bullet.Update();
            }

            playerBullets = playerBullets.Where(x => x.IsExpired == false).ToList();
            enemyBullets = enemyBullets.Where(x => x.IsExpired == false).ToList();
        }

        public static void Clear() {
            playerBullets.Clear();
            enemyBullets.Clear();
        }

        public static void Draw() {
            foreach (var bullet in playerBullets) {
                bullet.Draw();
            }
            foreach (var bullet in enemyBullets) {
                bullet.Draw();
            }
        }
    }
}

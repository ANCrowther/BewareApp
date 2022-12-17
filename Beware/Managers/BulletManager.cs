using Beware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beware.Managers {
    static class BulletManager {
        public static List<BulletModel> playerBullets = new List<BulletModel>();
        public static List<BulletModel> enemyBullets = new List<BulletModel>();

        public static void AddPlayerBullet(BulletModel bullet) {
            playerBullets.Add(bullet);
        }

        public static void AddEnemyBullets(BulletModel bullet) {
            playerBullets.Add(bullet);
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

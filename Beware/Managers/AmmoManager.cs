using Beware.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beware.Managers {
    static class AmmoManager {
        public static List<AmmoModel> playerBullets = new List<AmmoModel>();
        public static List<AmmoModel> enemyBullets = new List<AmmoModel>();

        public static void Add(AmmoModel ammo) {
            if (ammo is PlayerBulletModel p) {
                playerBullets.Add(p);
            }
            if (ammo is SabotRound s) {
                playerBullets.Add(s);
            }
            if (ammo is BulletModel b) {
                enemyBullets.Add(b);
            }
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

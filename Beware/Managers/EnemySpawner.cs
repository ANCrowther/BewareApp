using Beware.Entities;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Managers {
    static class EnemySpawner {
        static Random rand = new Random();
        static float inverseSpawnChance = 90;

        public static void Update() {
            if (PlayerStatus.IsPaused == false && !PlayerModel.Instance.IsExpired && EntityManager.Count < 200) {
                if (rand.Next((int)inverseSpawnChance) == 0) {
                    EntityManager.Add(EntityBuilder.Factory(EntityType.Enemy_Wandering, GetSpawnPosition()));
                }
                if (rand.Next((int)inverseSpawnChance) == 0) {
                    EntityManager.Add(EntityBuilder.Factory(EntityType.Enemy_Seeker, GetSpawnPosition()));
                }
            }

            if (inverseSpawnChance > 30) {
                inverseSpawnChance -= 0.005f;
            }
        }

        private static Vector2 GetSpawnPosition() {
            Vector2 position;

            do {
                position = new Vector2(rand.Next((int)ViewportManager.GameboardView.Width), rand.Next((int)ViewportManager.GameboardView.Height));
            } while (Vector2.DistanceSquared(position, PlayerModel.Instance.Engine.Position) < 250 * 250);

            return position;
        }

        public static void Reset() {
            inverseSpawnChance = 60;
        }
    }
}

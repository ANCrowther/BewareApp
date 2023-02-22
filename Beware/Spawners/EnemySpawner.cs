using Beware.Entities;
using Beware.Enums;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Spawners {
    static class EnemySpawner {
        static readonly Random rand = new Random();
        static float inverseSpawnChance = 90;

        public static void Update() {
            if (PlayerStatus.IsPaused == false && !PlayerModel.Instance.IsExpired && EntityManager.Count < 200) {
                if (rand.Next((int)inverseSpawnChance) == 0) {
                    EntityManager.Add(EnemyBuilder.Factory(EnemyType.Enemy_Wandering, GetSpawnPosition()));
                }
                if (rand.Next((int)inverseSpawnChance) == 0) {
                    EntityManager.Add(EnemyBuilder.Factory(EnemyType.Enemy_Seeker, GetSpawnPosition()));
                }
            }

            if (inverseSpawnChance > 30) {
                inverseSpawnChance -= 0.005f;
            }
        }

        //private static Vector2 GetSpawnPosition() {
        //    Vector2 position;

        //    do {
        //        position = new Vector2(rand.Next((int)ViewportManager.GameboardView.Width), rand.Next((int)ViewportManager.GameboardView.Height));
        //    } while ((Vector2.DistanceSquared(position, PlayerModel.Instance.Engine.Position) < 250 * 250) && (Vector2.DistanceSquared(position, PlayerModel.Instance.Engine.Position) > 150 * 150));

        //    return position;
        //}

        private static Vector2 GetSpawnPosition() {
            Vector2 position;
            int result = rand.Next(0, 3);

            if (result == 0) {
                position = new Vector2(rand.Next((int)ViewportManager.GameboardView.Width), 25);
            } else if (result == 1) {
                position = new Vector2(rand.Next((int)ViewportManager.GameboardView.Width), (int)ViewportManager.GameboardView.Height - 25);
            } else if (result == 2) {
                position = new Vector2(25, rand.Next((int)ViewportManager.GameboardView.Height));
            } else {
                position = new Vector2((int)ViewportManager.GameboardView.Width - 25, rand.Next((int)ViewportManager.GameboardView.Height));
            }

            return position;
        }

        public static void Reset() {
            inverseSpawnChance = 60;
        }
    }
}

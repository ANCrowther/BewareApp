using Beware.Builders;
using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Managers {
    static class ItemDropSpawner {
        static Random rand = new Random();
        static float inverseItemDropChance = 50;

        public static void Update() {
            if (PlayerStatus.IsPaused == false && !PlayerModel.Instance.IsExpired && EntityManager.Count < 200) {
                if (rand.Next((int)inverseItemDropChance) == 0) {
                    EntityManager.Add(ItemDropBuilder.Factory(DroppedItemType.SabotAmmoDrop, GetSpawnPosition(), GetSpawnVelocity()));
                }
            }

            if (inverseItemDropChance > 15) {
                inverseItemDropChance -= 0.005f;
            }
        }

        private static Vector2 GetSpawnPosition() {
            Vector2 position;

            do {
                position = new Vector2(rand.Next((int)ViewportManager.GameboardView.Width), rand.Next((int)ViewportManager.GameboardView.Height));
            } while (Vector2.DistanceSquared(position, PlayerModel.Instance.Engine.Position) < 250 * 250);

            return position;
        }

        private static Vector2 GetSpawnVelocity() {
            float direction = rand.NextFloat(0, MathHelper.TwoPi);
            Vector2 velocity = MathUtil.FromPolar(direction, rand.Next(5,30)*0.1f);

            return velocity;
        }

        public static void Reset() {
            inverseItemDropChance = 60;
        }
    }
}

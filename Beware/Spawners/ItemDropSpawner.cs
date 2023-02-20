using Beware.Builders;
using Beware.Enums;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Spawners {
    static class ItemDropSpawner {
        static readonly Random rand = new Random();

        public static void SpawnItem(Vector2 position) {
            EntityManager.Add(ItemDropBuilder.Factory(DroppedItemType.SabotAmmoDrop, position, GetSpawnVelocity()));
        }

        private static Vector2 GetSpawnVelocity() {
            float direction = rand.NextFloat(0, MathHelper.TwoPi);
            Vector2 velocity = MathUtil.FromPolar(direction, rand.Next(5,30)*0.1f);

            return velocity;
        }
    }
}

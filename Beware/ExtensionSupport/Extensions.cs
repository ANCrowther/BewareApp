using System;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.ExtensionSupport {
    static class Extensions {
        public static float ToAngle(this Vector2 vector) {
            return (float)Math.Atan2(vector.Y, vector.X);
        }

        public static float NextFloat(this Random rand, float minValue, float maxValue) {
            return (float)rand.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static Vector2 ScaleTo(this Vector2 vector, float length) {
            return vector * (length / vector.Length());
        }

        public static float SoundToFloat(this int soundLevel) {
            return soundLevel * 0.05f;
        }

        public static bool Intersects(this HitCircle entity, HitCircle otherEntity) {
            return Vector2.Distance(entity.Position, otherEntity.Position) < (entity.Radius + otherEntity.Radius);
        }

        public static int GetDamage(this Vector2 vector, Vector2 damage, int baseDamage) {
            int result = (int)((vector + damage).Length());
            result = Math.Abs(result);
            return (result >= 1) ? result : baseDamage;
        }
    }
}

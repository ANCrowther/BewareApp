using System;
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
    }
}

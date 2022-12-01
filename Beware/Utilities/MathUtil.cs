using Microsoft.Xna.Framework;
using System;

namespace Beware.Utilities {
    static class MathUtil {
        public static Vector2 FromPolar(float angle, float magnitude) {
            return magnitude * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        public static Vector2 ScaleVector(float x, float y, float baseX, float baseY) {
            return new Vector2(x / baseX, y / baseY);
        }

        public static float Rotation(float degree) {
            return MathHelper.ToRadians(degree);
        }
    }
}

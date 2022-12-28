using Microsoft.Xna.Framework;

namespace Beware.Utilities {
    public class HitCircle {
        public Vector2 Position { get; set; }
        public float Radius { get; set; }

        public HitCircle(Vector2 position, float radius) {
            this.Position = position;
            this.Radius = radius;
        }
    }
}
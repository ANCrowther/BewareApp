using Microsoft.Xna.Framework;
using System;

namespace Beware.Utilities {
    public class HitCircle {
        private Vector2 position;
        public float Radius { get; protected set; }

        public HitCircle(Vector2 position, float radius) {
            this.position = position;
            this.Radius = radius;
        }

        public HitCircle(HitCircle other) {
            this.position = other.position;
            this.Radius = other.Radius;
        }

        public bool Contains(HitCircle other) {
            //float dx = other.position.X - this.position.X;
            //float dy = other.position.Y - this.position.Y;
            return (Vector2.DistanceSquared(this.position, other.position) < (this.Radius + other.Radius));
            //return Math.Sqrt(dx * dx + dy * dy) < this.Radius + other.Radius;
        }
    }
}
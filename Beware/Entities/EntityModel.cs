using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public delegate void Behaviour();

namespace Beware.Entities {
    public abstract class EntityModel {
        public Vector2 Position;
        public Vector2 Velocity;
        public float Orientation;
        public float CollisionRadius = 20.0f;
        public bool IsExpired;
        protected Texture2D image;

        protected List<Behaviour> behaviours;

        public Vector2 Size { get { return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height); } }

        public virtual void Update() {
            foreach (Behaviour item in behaviours) {
                item();
            }
        }

        public virtual void SetBehaviour(Behaviour behaviour) {
            behaviours.Add(behaviour);
        }

        public virtual void Draw() {
            BewareGame.Instance._spriteBatch.Draw(image, Position, null, Color.White, Orientation, Size / 2f, 1.0f, 0, 0);
        }
    }
}

using Beware.Behaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

//public delegate void Behaviour();

namespace Beware.Entities {
    public abstract class EntityModel {
        public Vector2 Position;
        public Vector2 Velocity;
        public float Orientation;
        public float CollisionRadius = 20.0f;
        public bool IsExpired;
        public Texture2D image;
        public Color color = Color.White;

        //protected List<Behaviour> behaviours = new List<Behaviour>();
        protected List<IBehaviour> behaviours = new List<IBehaviour>();

        public Vector2 Size { get { return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height); } }

        public virtual void Update() {
            foreach (IBehaviour item in behaviours) {
                item.Update(this);
            }
        }

        public virtual void SetBehaviour(IBehaviour behaviour) {
            behaviours.Add(behaviour);
        }

        public virtual void Draw() {
            BewareGame.Instance._spriteBatch.Draw(image, Position, null, Color.White, Orientation, Size / 2f, 1.0f, 0, 0);
        }
    }
}

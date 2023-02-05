using Beware.EntityFeatures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    public abstract class EnemyModel : EntityModel {
        private readonly int timeUntilStart = 60;
        public bool IsActive { get { return timeUntilStart <= 60; } }

        public EnemyModel(Texture2D image, Vector2 position, int startingHealth, int startingImpactDamage = 5, Sprite sprite = null) 
            : base(new Engine(position, Vector2.Zero), new Sprite(image, 1.3f), startingHealth, startingImpactDamage) {
            Health.OnHit += delegate { this.Health.ResetHealthBarFramesUntilColorChange(); };
        }

        public void HandleCollision(EntityModel other) {
            var d = Engine.Position - other.Engine.Position;
            Engine.Velocity += 10 * d / (d.LengthSquared() + 1);
        }

        public override void Update() {
            Health.Update();
            base.Update();
        }

        public override void Draw() {
            if (!IsExpired) {
                Vector2 position = new Vector2(Engine.Position.X, Engine.Position.Y + Sprite.Size.Y / 2 + 5);
                Health.Draw(position);

                base.Draw();
            }
        }
    }
}

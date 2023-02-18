using Beware.EntityFeatures;

namespace Beware.Entities {
    class SabotRound : AmmoModel {
        public SabotRound(Engine engine, Sprite sprite, int startingHealth = 100, int startingImpactDamage = 30)
            : base(engine, sprite, startingHealth, startingImpactDamage) { }

        public override void Draw() {
            BewareGame.Instance._spriteBatch.Draw(Sprite.Image, Engine.Position, null, Sprite.color, Engine.Orientation, Sprite.Size / 2f, Sprite.Scale, 0, 0);
        }
    }
}

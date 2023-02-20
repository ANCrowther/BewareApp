using Beware.EntityFeatures;

namespace Beware.Entities {
    public abstract class DroppedItemModel : EntityModel {
        private int frameCountDown = 150;
        private bool drawMe = true;

        public DroppedItemModel(Engine engine, Sprite sprite, int startingHealth, int startingImpactDamage) 
            : base(engine, sprite, startingHealth, startingImpactDamage) { }

        public override void Update() {
            if (frameCountDown-- <= 0) {
                this.Die();
            }
            if (frameCountDown < 40 && frameCountDown % 5 == 0) {
                drawMe = !drawMe;
            }
        }

        public override void Draw() {
            if (drawMe == true) {
                base.Draw();
            }
        }
    }
}

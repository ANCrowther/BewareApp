using Beware.Entities;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.EntityFeatures {
    class PlayerGun : Gun {
        private int framesUntilColorChange = 0;

        public PlayerGun(EntityModel entity) : base(entity, new Sprite(EntityArt.MainGun, 1.3f)) { }

        public override void Update() {
            if (framesUntilColorChange-- <= 0) {
                Sprite.color = Color.White;
            }
        }

        public void UpdateDrawColor() {
            Sprite.color = Color.Red;
            framesUntilColorChange = 10;
        }
    }
}

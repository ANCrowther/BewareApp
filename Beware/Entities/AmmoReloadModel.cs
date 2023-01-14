using Beware.EntityFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beware.Entities {
    class AmmoReloadModel : EntityModel {
        public AmmoReloadModel(int startingHealth = 0, int startingImpactDamage = 0, Sprite sprite = null) : base(startingHealth, startingImpactDamage, sprite) {

        }

        public override void Hit(int damage = 1) {
            this.IsExpired = true;
        }


    }
}

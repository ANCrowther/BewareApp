﻿using Beware.EntityFeatures;
using Beware.Utilities;

namespace Beware.Entities {
    class EnemyFollowerModel : EnemyModel {
        public EnemyFollowerModel(Engine engine, Sprite sprite, int startingHealth, int pointValue, int startingImpactDamage = 5)
            : base(engine, sprite, startingHealth, startingImpactDamage) {
            Health.OnDeath += delegate { this.Die(); ScoreKeeper.AddPoints(pointValue); };
        }
    }
}

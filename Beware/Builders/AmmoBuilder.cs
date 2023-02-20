using Beware.Behaviours;
using Beware.Entities;
using Beware.EntityFeatures;
using Beware.Enums;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Builders {
    public static class AmmoBuilder {
        public static EntityModel Factory(AmmoType selection, Vector2 position, Vector2 velocity) {
            switch (selection) {
                case AmmoType.PlayerBullet:
                    AmmoModel playerBullet = new PlayerBulletModel(position, velocity, new Sprite(EntityArt.YellowBullet));
                    playerBullet.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                    return playerBullet;
                case AmmoType.EnemyBullet:
                    AmmoModel enemyBullet = new BulletModel(position, velocity, new Sprite(EntityArt.Bullet));
                    enemyBullet.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                    return enemyBullet;
                case AmmoType.SabotRound:
                    AmmoModel sabot = new SabotRound(position, velocity, new Sprite(EntityArt.Sabot, 2.0f));
                    sabot.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                    return sabot;
                default:
                    AmmoModel defaultAmmo = new PlayerBulletModel(position, velocity, new Sprite(EntityArt.YellowBullet));
                    defaultAmmo.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                    return defaultAmmo;
            }
        }
    }
}

using Beware.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    public static class EntityArt {
        private static Texture2D Player1 { get; set; }
        private static Texture2D MainGun { get; set; }
        private static Texture2D EnemyWanderer { get; set; }
        private static Texture2D EnemySeeker { get; set; }
        private static Texture2D Bullet { get; set; }
        private static Texture2D YellowBullet { get; set; }
        private static Texture2D Shield { get; set; }
        private static Texture2D Sabot { get; set; }
        private static Texture2D BlueBooster { get; set; }
        private static Texture2D RedBooster { get; set; }
        private static Texture2D AmmoDrop { get; set; }
        private static Texture2D BoostDrop { get; set; }
        private static Texture2D ShieldDrop { get; set; }

        public static void Initialize(ContentManager content) {
            Player1 = content.Load<Texture2D>(@"Sprites\Player2");
            MainGun = content.Load<Texture2D>(@"Sprites\gun");
            EnemyWanderer = content.Load<Texture2D>(@"Sprites\Wanderer");
            EnemySeeker = content.Load<Texture2D>(@"Sprites\Seeker1");
            Bullet = content.Load<Texture2D>(@"Sprites\Bullet");
            YellowBullet = content.Load<Texture2D>(@"Sprites\yellowbullet");
            Shield = content.Load<Texture2D>(@"Sprites\spr_shield");
            Sabot = content.Load<Texture2D>(@"Sprites\SabotRound");
            BlueBooster = content.Load<Texture2D>(@"Sprites\booster_blue");
            RedBooster = content.Load<Texture2D>(@"Sprites\booster_red");
            AmmoDrop = content.Load<Texture2D>(@"Sprites\drop_ammo");
            BoostDrop = content.Load<Texture2D>(@"Sprites\drop_boost");
            ShieldDrop = content.Load<Texture2D>(@"Sprites\drop_shield");
        }

        public static Texture2D GetImage(EntityArtType entityType) {
            return entityType switch {
                EntityArtType.AmmoDrop => AmmoDrop,
                EntityArtType.BlueBooster => BlueBooster,
                EntityArtType.BoostDrop => BoostDrop,
                EntityArtType.Bullet => Bullet,
                EntityArtType.EnemySeeker => EnemySeeker,
                EntityArtType.EnemyWanderer => EnemyWanderer,
                EntityArtType.MainGun => MainGun,
                EntityArtType.Player1 => Player1,
                EntityArtType.RedBooster => RedBooster,
                EntityArtType.Sabot => Sabot,
                EntityArtType.Shield => Shield,
                EntityArtType.ShieldDrop => ShieldDrop,
                EntityArtType.YellowBullet => YellowBullet,
                _ => null
            };
        }

        public static Rectangle GetImageSize(EntityArtType entityType) {
            return entityType switch {
                EntityArtType.AmmoDrop => AmmoDrop.Bounds,
                EntityArtType.BlueBooster => BlueBooster.Bounds,
                EntityArtType.BoostDrop => BoostDrop.Bounds,
                EntityArtType.Bullet => Bullet.Bounds,
                EntityArtType.EnemySeeker => EnemySeeker.Bounds,
                EntityArtType.EnemyWanderer => EnemyWanderer.Bounds,
                EntityArtType.MainGun => MainGun.Bounds,
                EntityArtType.Player1 => Player1.Bounds,
                EntityArtType.RedBooster => RedBooster.Bounds,
                EntityArtType.Sabot => Sabot.Bounds,
                EntityArtType.Shield => Shield.Bounds,
                EntityArtType.ShieldDrop => ShieldDrop.Bounds,
                EntityArtType.YellowBullet => YellowBullet.Bounds,
                _ => Player1.Bounds
            };
        }
    }
}

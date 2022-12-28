﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    public static class EntityArt {
        public static Texture2D Player1 { get; private set; }
        public static Texture2D MainGun { get; private set; }
        public static Texture2D EnemyWanderer { get; private set; }
        public static Texture2D EnemySeeker { get; private set; }
        public static Texture2D Bullet { get; private set; }
        public static Texture2D Shield { get; private set; }
        public static Texture2D Sabot { get; private set; }

        public static void Initialize(ContentManager content) {
            Player1 = content.Load<Texture2D>(@"Sprites\Player1");
            MainGun = content.Load<Texture2D>(@"Sprites\maingun");
            EnemyWanderer = content.Load<Texture2D>(@"Sprites\Wanderer");
            EnemySeeker = content.Load<Texture2D>(@"Sprites\Seeker1");
            Bullet = content.Load<Texture2D>(@"Sprites\Bullet");
            Shield = content.Load<Texture2D>(@"Sprites\spr_shield");
            Sabot = content.Load<Texture2D>(@"Sprites\SabotRound");
        }
    }
}

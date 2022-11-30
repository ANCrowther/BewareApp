using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    class EntityArt {
        public Texture2D Player1 { get; private set; }
        public Texture2D EnemyWanderer { get; private set; }
        public Texture2D EnemySeeker { get; private set; }


        public void Initialize(ContentManager content) {
            Player1 = content.Load<Texture2D>(@"Sprites\Player");
            EnemyWanderer = content.Load<Texture2D>(@"Sprites\Wanderer");
            EnemySeeker = content.Load<Texture2D>(@"Sprites\Seeker");
        }
    }
}

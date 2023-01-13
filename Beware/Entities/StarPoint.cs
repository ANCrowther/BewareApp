using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    class StarPoint {
        private readonly Texture2D image;
        public Color TintColor { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle InitialFrame { get; set; }
        public Rectangle Destination { get { return new Rectangle((int)Location.X, (int)Location.Y, InitialFrame.Width, InitialFrame.Height); } }

        public StarPoint(Vector2 location, Texture2D texture, Rectangle initialFrame) {
            image = texture;
            Location = location;
            InitialFrame = initialFrame;
        }

        public void Update(Vector2 position) {
            Location += position;
        }

        public void Draw() {
            BewareGame.Instance._spriteBatch.Draw(image, Destination, InitialFrame, TintColor);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NewShooter.Utilities
{
    public class SpriteBatchFX : SpriteBatch
    {
        public SpriteBatchFX(GraphicsDevice graphicsDevice) : base(graphicsDevice) { }

        public void PlainText(SpriteFont spriteFont, string text, Vector2 position, Color color) {
            DrawString(spriteFont, text, position, color, 0.0f, Vector2.Zero, 1.0f, 0, 1.0f);
        }

        public void GlowText(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            DrawString(spriteFont, text, new Vector2(position.X + 2, position.Y + 2), Color.White * 0.5f, 0.0f, Vector2.Zero, 1.0f, 0, 1.0f);
            DrawString(spriteFont, text, position, color, 0.0f, Vector2.Zero, 1.0f, 0, 1.0f);
        }
    }
}

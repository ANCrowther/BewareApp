using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class TextModel {
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public TextModel(string text, Vector2 position) {
            Text = text;
            Position = position;
        }
    }
}

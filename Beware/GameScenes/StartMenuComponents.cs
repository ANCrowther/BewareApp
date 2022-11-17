using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Beware.Utilities;

namespace Beware.GameScenes {
    public class StartMenuComponents : DrawableGameComponent {   
        public (string name, Vector2 position) SelectedItem { get; private set; }

        private List<(string name, Vector2 position)> items;

        public StartMenuComponents(Vector2 initialPosition) : base (BewareGame.Instance) {
            items = new List<(string name, Vector2 position)>();
            LoadMenuOptions(initialPosition);
        }

        public override void Update(GameTime gameTime) {
            SelectedItem = Helpers.MoveThroughMenu(items, SelectedItem);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            foreach ((string name, Vector2 position) item in items) {
                Color color = (item == SelectedItem) ? Color.Moccasin : Color.Lime;
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, item.name, item.position, color);
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void LoadMenuOptions(Vector2 position) {
            foreach (string option in Helpers.menuOptions) {
                items.Add((option, position));
                position.Y += 90;
            }
            SelectedItem = items[0];
        }
    }
}

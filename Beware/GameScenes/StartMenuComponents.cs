using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Beware.Utilities;
using Beware.Inputs;

namespace Beware.GameScenes {
    public class StartMenuComponents : DrawableGameComponent {   
        public TextModel SelectedItem { get; private set; }

        private List<TextModel> items;
        private Vector2 position;

        public StartMenuComponents(Vector2 initialPosition) : base (BewareGame.Instance) {
            items = new List<TextModel>();
            position = initialPosition;
            SelectedItem = null;
            LoadMenuOptions();
        }

        public override void Initialize() {
            base.Initialize();
        }

        protected override void LoadContent() {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(Keys.Up) || Input.WasButtonPressed(Buttons.LeftThumbstickUp)) {
                SelectPrevious();
            }
            if (Input.WasKeyPressed(Keys.Down) || Input.WasButtonPressed(Buttons.LeftThumbstickDown)) {
                SelectNext();
            }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            foreach (TextModel item in items) {
                Color color = (item == SelectedItem) ? Color.Moccasin : Color.Lime;
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, item.Text, item.Position, color);
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void LoadMenuOptions() {
            foreach (string option in Helpers.menuOptions) {
                items.Add(new TextModel(option, position));
                position.Y += 90;
            }
            SelectedItem = items[0];
        }

        private void SelectNext() {
            int index = items.IndexOf(SelectedItem);
            if (index < items.Count - 1) {
                SelectedItem = items[index + 1];
            } else {
                SelectedItem = items[0];
            }
        }

        private void SelectPrevious() {
            int index = items.IndexOf(SelectedItem);
            if (index > 0) {
                SelectedItem = items[index - 1];
            } else {
                SelectedItem = items[items.Count - 1];
            }
        }
    }
}

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Beware.GameScenes {
    public class GameScene {
        private List<GameComponent> components;

        public GameScene(params GameComponent[] inputcomponents) {
            components = new List<GameComponent>();
            foreach (GameComponent component in inputcomponents) {
                AddComponent(component);
            }
        }

        private void AddComponent(GameComponent component) {
            components.Add(component);
            if (!BewareGame.Instance.Components.Contains(component)) {
                BewareGame.Instance.Components.Add(component);
            }
        }

        public GameComponent[] ReturnComponents() {
            return components.ToArray();
        }
    }
}

using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class GameboardLogic : DrawableGameComponent {
        BewareGame game;
        private View view;

        public GameboardLogic(BewareGame inputGame, View inputView) : base (inputGame) {
            this.game = inputGame;
            this.view = inputView;
        }
    }
}

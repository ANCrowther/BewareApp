using Beware.Entities;
using Beware.Utilities;

namespace Beware.Commands {
    public class MoveCommand : ICommand {
        PlayerModel player;

        public MoveCommand(PlayerModel inputPlayer) {
            player = inputPlayer;
        }

        public void Execute() {
            player.Position = Helpers.GetDirection(Mode.Move);
        }
    }
}

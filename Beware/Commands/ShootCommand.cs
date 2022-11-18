using Beware.Utilities;

namespace Beware.Commands {
    public class ShootCommand : ICommand {


        public ShootCommand() {

        }

        public void Execute() {
            Helpers.GetDirection(Mode.Shoot);
        }
    }
}

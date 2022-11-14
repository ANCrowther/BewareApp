using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Commands {
    public class ShootCommand : ICommand {
        public Vector2 Execute() {
            return Helpers.GetDirection(Mode.Shoot);
        }
    }
}

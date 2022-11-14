using Microsoft.Xna.Framework;

namespace Beware.Commands {
    interface ICommand {
        Vector2 Execute();
    }
}

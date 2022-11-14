using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Commands {
    public class MoveCommand : ICommand {
        public Vector2 Execute() {
            return Helpers.GetDirection(Mode.Move);
        }
    }
}

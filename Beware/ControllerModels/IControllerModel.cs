using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.ControllerModels {
    public interface IControllerModel {
        void Draw(Vector2 position, Mode mode = Mode.Move, bool isMobile = true, float orientation = 0.0f);
    }
}

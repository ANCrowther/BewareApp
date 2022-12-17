using Beware.Entities;
using Beware.Inputs;
using Beware.Utilities;

namespace Beware.Behaviours {
    class SwitchSpeedBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            if (Input.WasKeyPressed(ControlMap.Slow) || Input.WasButtonPressed(ControlMap.Slow_pad)) {
                PlayerStatus.IsSlow = !PlayerStatus.IsSlow;
            }
        }
    }
}

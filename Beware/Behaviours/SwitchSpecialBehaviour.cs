using Beware.Entities;
using Beware.Inputs;

namespace Beware.Behaviours {
    class SwitchSpecialBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            if (Input.WasButtonPressed(ControlMap.SwitchSpecial)) {
                PlayerInputStates.IsSpecialDefensive = !PlayerInputStates.IsSpecialDefensive;
            }
        }
    }
}

using Beware.Entities;
using Beware.Inputs;

namespace Beware.Behaviours {
    class PlayerSpecialSwitchBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            if (Input.WasButtonPressed(ControlMap.SwitchSpecial_Pad)) {
                PlayerInputStates.IsSpecialDefensive = !PlayerInputStates.IsSpecialDefensive;
            }
        }
    }
}

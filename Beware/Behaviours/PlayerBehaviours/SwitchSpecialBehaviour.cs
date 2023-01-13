using Beware.Entities;
using Beware.Inputs;
using Beware.Utilities;

namespace Beware.Behaviours {
    class SwitchSpecialBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            if (Input.WasButtonPressed(ControlMap.SwitchSpecial)) {
                PlayerStatus.IsSpecialDefensive = !PlayerStatus.IsSpecialDefensive;
            }
        }
    }
}

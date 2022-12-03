using Beware.Entities;
using Beware.Inputs;

namespace Beware.Behaviours {
    class PlayerSlowBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            if (Input.WasKeyPressed(ControlMap.Slow) || Input.WasButtonPressed(ControlMap.Slow_pad)) {
                PlayerModel.Instance.IsSlow = !PlayerModel.Instance.IsSlow;
            }
        }
    }
}

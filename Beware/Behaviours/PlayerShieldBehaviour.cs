using Beware.Entities;
using Beware.Inputs;
using Beware.Utilities;

namespace Beware.Behaviours {
    class PlayerShieldBehaviour : IBehaviour {
        private bool IsNull = true;

        public void Update(EntityModel entity) {
            IsNull = (PlayerModel.Instance.Shield == null) ? true : false;
            if (PlayerInputStates.IsSpecialDefensive == true) {
                if (IsNull == true && Input.WasButtonPressed(ControlMap.Special)) {
                    ShieldModel shield = new ShieldModel();
                    shield.SetBehaviour(BehaviourCategory.Move, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.PlayerShieldMove));
                    PlayerModel.Instance.Shield = shield;
                    IsNull = false;
                }
            }
        }
    }
}

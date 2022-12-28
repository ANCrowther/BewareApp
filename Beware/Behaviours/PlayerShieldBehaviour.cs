using Beware.Entities;
using Beware.Inputs;
using Beware.Utilities;

namespace Beware.Behaviours {
    class PlayerShieldBehaviour : IBehaviour {
        private bool isNull = true;
        private int startTimer = 0;

        public void Update(EntityModel entity) {
            isNull = (entity.Shield == null) ? true : false;
            if (isNull == false) {
                startTimer = TimeKeeper.Seconds;
            }
            
            if (PlayerInputStates.IsSpecialDefensive == true) {
                if (isNull == true && Input.WasButtonPressed(ControlMap.Special)) {
                    if (TimesUp()) {
                        entity.Shield = new PlayerShieldModel();
                    }
                }
            }
        }

        private bool TimesUp() {
            return (TimeKeeper.Seconds - startTimer) >= PlayerStatus.MaxShieldCountdown;
        }
    }
}

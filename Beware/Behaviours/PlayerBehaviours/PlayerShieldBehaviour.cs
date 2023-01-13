using Beware.Entities;
using Beware.EntityFeatures;
using Beware.Inputs;
using Beware.Utilities;

namespace Beware.Behaviours {
    class PlayerShieldBehaviour : IBehaviour {
        private bool isNull = true;
        private int startTimer = 0;

        public void Update(EntityModel entity) {
            isNull = (entity.Shield == null);
            if (isNull == false) {
                startTimer = TimeKeeper.Seconds;
            }
            
            if (Input.WasButtonPressed(ControlMap.Special)
                && PlayerStatus.IsSpecialDefensive == true
                && isNull == true
                && TimesUp()) {
                entity.Shield = new PlayerShield(entity);
            }
        }

        private bool TimesUp() {
            return (TimeKeeper.Seconds - startTimer) >= PlayerStatus.MaxShieldCountdown;
        }
    }
}

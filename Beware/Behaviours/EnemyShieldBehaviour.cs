using Beware.Entities;
using Beware.Utilities;

namespace Beware.Behaviours {
    class EnemyShieldBehaviour : IBehaviour {
        private bool isShieldActive = false;
        private int startTimer = 0;
        private bool isFirstTimeUsed = false;

        public void Update(EntityModel entity) {
            if (isFirstTimeUsed == false) {
                ShieldModel shield = new EnemyShieldModel(20);
                entity.Shield = shield;
                isShieldActive = true;
                isFirstTimeUsed = true;
            }
            if (isShieldActive == false) {
                if (entity.Shield == null && EnoughTimePassed()) {
                    ShieldModel shield = new EnemyShieldModel(20);
                    entity.Shield = shield;
                    isShieldActive = true;
                }
            }
            if (isShieldActive == true) {
                if (entity.Shield == null) {
                    startTimer = TimeKeeper.Seconds;
                    isShieldActive = false;
                }
            }
        }

        private bool EnoughTimePassed() {
            return ((TimeKeeper.Seconds - startTimer) >= 10);
        }
    }
}

using Beware.Entities;
using Beware.Inputs;
using Beware.Utilities;

namespace Beware.Behaviours {

    class PlayerBoostBehaviour : IBehaviour {
        private int startWaitTimer = 0;
        private int startBoostTimer = 0;

        public void Update(EntityModel entity) {
            Update((PlayerModel)entity);
        }

        private void Update(PlayerModel player) {
            if (player.Engine.IsBoosting == true && TimesUp(startBoostTimer)) {
                player.Engine.IsBoosting = false;
                startWaitTimer = TimeKeeper.Seconds;
            }

            if (player.Engine.IsBoosting == false && Input.WasButtonPressed(ControlMap.Boost) && TimesUp(startWaitTimer)) {
                player.Engine.IsBoosting = true;
                startBoostTimer = TimeKeeper.Seconds;
            }
            
        }

        private bool TimesUp(int startTimer) {
            return (TimeKeeper.Seconds - startTimer) >= PlayerStatus.MaxBoostCountdown;
        }
    }
}

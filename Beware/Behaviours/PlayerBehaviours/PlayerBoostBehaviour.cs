using Beware.Entities;
using Beware.Inputs;
using Beware.Utilities;
using System;

namespace Beware.Behaviours {

    class PlayerBoostBehaviour : IBehaviour {
        public event Action OnUse;
        public event Action OnTimesUp;
        private int startWaitTimer = 0;
        private int startBoostTimer = 0;

        public void Update(EntityModel entity) {
            Update((PlayerModel)entity);
        }

        private void Update(PlayerModel player) {
            if (player.Engine.IsBoosting == true && BoostTimesUp()) {
                player.Engine.IsBoosting = false;
                startWaitTimer = TimeKeeper.Seconds;
                OnTimesUp?.Invoke();
            }

            if (player.Engine.IsBoosting == false && Input.WasButtonPressed(ControlMap.Boost) && WaitTimesUp()) {
                player.Engine.IsBoosting = true;
                startBoostTimer = TimeKeeper.Seconds;
                OnUse?.Invoke();
            }
        }

        private bool BoostTimesUp() {
            return (TimeKeeper.Seconds - startBoostTimer) >= PlayerStatus.MaxBoostCountdown;
        }

        private bool WaitTimesUp() {
            return (TimeKeeper.Seconds - startWaitTimer) >= PlayerStatus.MaxBoostWaitCountdown;
        }
    }
}

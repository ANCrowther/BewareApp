﻿using Beware.Entities;
using Beware.Inputs;
using Beware.Utilities;

namespace Beware.Behaviours {
    class SwitchSpeedBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            if (Input.WasButtonPressed(ControlMap.Slow)) {
                entity.Engine.SwitchSpeed();
            }
        }
    }
}

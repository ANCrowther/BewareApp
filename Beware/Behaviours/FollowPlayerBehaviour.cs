using Beware.Entities;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Beware.Behaviours {
    class FollowPlayerBehaviour : IBehaviour {
        private List<IEnumerator<int>> behaviours = new List<IEnumerator<int>>();
        private int timeUntilStart = 60;
        private EntityModel entity;

        public FollowPlayerBehaviour(EntityModel entity) {
            this.entity = entity;
        }

        public void Update() {
            throw new NotImplementedException();
        }

        IEnumerable<int> FollowPlayer(float acceleration = 1.0f) {
            while (true) {
                if (!PlayerModel.Instance.IsDead) {
                    this.entity.Velocity += (PlayerModel.Instance.Position - entity.Position).ScaleTo(acceleration);
                }

                if (this.entity.Velocity != Vector2.Zero) {
                    this.entity.Orientation = this.entity.Velocity.ToAngle();
                }

                yield return 0;
            }
        }
    }
}

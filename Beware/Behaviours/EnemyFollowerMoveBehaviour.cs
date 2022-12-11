using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Beware.Behaviours {
    internal class EnemyFollowerMoveBehaviour : IBehaviour {
        private Random rand = new Random();
        private List<IEnumerator<int>> behaviours = new List<IEnumerator<int>>();

        public void Update(EntityModel entity) {
            if (behaviours.Count == 0) {
                AddBehaviour(FollowPlayer(entity as EnemyFollowerModel));
            }
            ApplyBehaviours();

            entity.Position += entity.Velocity;
            entity.Position = Vector2.Clamp(entity.Position, entity.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - entity.Size / 2);

            entity.Velocity *= 0.8f;
        }

        private void AddBehaviour(IEnumerable<int> behaviour) {
            behaviours.Add(behaviour.GetEnumerator());
        }

        private void ApplyBehaviours() {
            for (int i = 0; i < behaviours.Count; i++) {
                if (!behaviours[i].MoveNext()) {
                    behaviours.RemoveAt(i--);
                }
            }
        }

        IEnumerable<int> FollowPlayer(EnemyFollowerModel entity, float acceleration = 1.0f) {
            while (true) {
                if (!PlayerModel.Instance.IsExpired) {
                    entity.Velocity += (PlayerModel.Instance.Position - entity.Position).ScaleTo(acceleration);
                }

                if (entity.Velocity != Vector2.Zero) {
                    entity.Orientation = entity.Velocity.ToAngle();
                }

                yield return 0;
            }
        }
    }
}
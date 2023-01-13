using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Beware.Behaviours {
    internal class EnemySeekerMoveBehaviour : IBehaviour {
        private readonly List<IEnumerator<int>> behaviours = new List<IEnumerator<int>>();

        public void Update(EntityModel entity) {
            if (behaviours.Count == 0) {
                AddBehaviour(FollowPlayer(entity as EnemyFollowerModel));
            }
            ApplyBehaviours();

            entity.Engine.Position += entity.Engine.Velocity;
            entity.Engine.Position = Vector2.Clamp(entity.Engine.Position, entity.Sprite.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - entity.Sprite.Size / 2);
            entity.Engine.Velocity *= 0.8f;
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
                    entity.Engine.Velocity += (PlayerModel.Instance.Engine.Position - entity.Engine.Position).ScaleTo(acceleration);
                }
                if (entity.Engine.Velocity != Vector2.Zero) {
                    entity.Engine.Orientation = entity.Engine.Velocity.ToAngle();
                }

                yield return 0;
            }
        }
    }
}
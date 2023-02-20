using Beware.Entities;
using Beware.Enums;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Beware.Behaviours {
    class EnemyWandererMoveBehaviour : IBehaviour {
        public static Random random = new Random();
        private readonly List<IEnumerator<int>> behaviours = new List<IEnumerator<int>>();

        public void Update(EntityModel entity) {
            if (behaviours.Count == 0) {
                AddBehaviour(MoveRandomly(entity as EnemyWandererModel));
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

        IEnumerable<int> MoveRandomly(EnemyWandererModel entity) {
            float direction = random.NextFloat(0, MathHelper.TwoPi);

            while (true) {
                direction += random.NextFloat(-0.1f, 0.1f);
                direction = MathHelper.WrapAngle(direction);

                for (int i = 0; i < 6; i++) {
                    entity.Engine.Velocity += MathUtil.FromPolar(direction, 0.4f);
                    entity.Engine.Orientation -= 0.05f;
                    var bounds = ViewportManager.GameboardView.Bounds;
                    bounds.Inflate(-entity.Sprite.Image.Width / 2 - 1, -entity.Sprite.Image.Height / 2 - 1);

                    if (!bounds.Contains(entity.Engine.Position.ToPoint())) {
                        direction = (ViewportManager.GetWindowSize(View.GamePlay) / 2 - entity.Engine.Position).ToAngle() + random.NextFloat(-MathHelper.PiOver2, MathHelper.PiOver2);
                    }

                    yield return 0;
                }
            }
        }
    }
}

using Beware.Entities;

namespace Beware.Behaviours {
    class PlayerShieldMoveBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            entity.Position = PlayerModel.Instance.Position;
        }
    }
}

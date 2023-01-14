using Beware.Behaviours;
using Beware.Utilities;

namespace Beware.Builders {
    public static class ItemDropBehaviourBuilder {
        public static IBehaviour Factory(DroppedItemBehaviourType behaviour) {
            switch (behaviour) {
                case DroppedItemBehaviourType.AmmoDrop:
                    return new AmmoReloadMovementBehaviour();
                default:
                    return null;
            }
        }
    }
}

using Beware.Entities;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Builders {
    public static class ItemDropBuilder {
        public static EntityModel Factory(DroppedItemType selection, Vector2 position, Vector2 velocity) {
            switch (selection) {
                case DroppedItemType.SabotAmmoDrop:
                    DroppedItemModel droppedAmmo = new DroppedItemModel(position, velocity, new EntityFeatures.Sprite(Art.BlueStarBurst, 0.5f));
                    droppedAmmo.SetBehaviour(BehaviourCategory.Move, ItemDropBehaviourBuilder.Factory(DroppedItemBehaviourType.AmmoDrop));
                    return droppedAmmo;
                case DroppedItemType.RegularShieldDrop:

                default:
                    DroppedItemModel defaultDrop = new DroppedItemModel(position, velocity, new EntityFeatures.Sprite(Art.BlueStarBurst));
                    defaultDrop.SetBehaviour(BehaviourCategory.Move, ItemDropBehaviourBuilder.Factory(DroppedItemBehaviourType.AmmoDrop));
                    return defaultDrop;
            }
        }
    }
}

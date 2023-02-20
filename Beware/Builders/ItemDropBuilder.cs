using Beware.Behaviours;
using Beware.Entities;
using Beware.EntityFeatures;
using Beware.Enums;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Builders {
    public static class ItemDropBuilder {
        public static EntityModel Factory(DroppedItemType selection, Vector2 position, Vector2 velocity) {
            switch (selection) {
                case DroppedItemType.SabotAmmoDrop:
                    DroppedItemModel droppedAmmo = new DroppedSabotAmmo(new Engine(position, velocity), new Sprite(EntityArt.AmmoDrop, 0.25f));
                    droppedAmmo.SetBehaviour(BehaviourCategory.Move, new DroppedItemMovementBehaviour());
                    return droppedAmmo;
                case DroppedItemType.RegularShieldDrop:

                default:
                    DroppedItemModel defaultDrop = new DroppedSabotAmmo(new Engine(position, velocity), new Sprite(Art.BlueStarBurst));
                    defaultDrop.SetBehaviour(BehaviourCategory.Move, new DroppedItemMovementBehaviour());
                    return defaultDrop;
            }
        }
    }
}

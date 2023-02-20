using Beware.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beware.Managers {
    static class DroppedItemManager {
        public static List<DroppedItemModel> items = new List<DroppedItemModel>();

        public static void Add(DroppedItemModel item) {
            items.Add(item);
        }

        public static void Update() {
            foreach (var item in items) {
                item.Update();
            }

            items = items.Where(x => x.IsExpired == false).ToList();
        }

        public static void Clear() {
            items.Clear();
        }

        public static void Draw() {
            foreach (var item in items) {
                item.Draw();
            }
        }
    }
}

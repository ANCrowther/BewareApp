using Beware.Entities;

namespace Beware.EntityFeatures {
    public abstract class EntityFeature {
        protected EntityModel Entity;
        protected Sprite Sprite;

        public EntityFeature(EntityModel entity = null, Sprite sprite = null) {
            this.Entity = entity;
            this.Sprite = sprite;
        }

        public abstract void Update();
        public abstract void Draw();
    }
}

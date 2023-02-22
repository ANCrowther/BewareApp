using Beware.Entities;

namespace Beware.EntityFeatures {
    public abstract class EntityFeature {
        protected EntityModel Entity;
        protected Sprite Sprite;

        public EntityFeature(EntityModel entity = null, Sprite sprite = null) {
            this.Entity = entity;
            this.Sprite = sprite;
        }

        public virtual void Update() { }
        public virtual void Draw() {
            Sprite.Draw(Entity.Engine);
        }
    }
}

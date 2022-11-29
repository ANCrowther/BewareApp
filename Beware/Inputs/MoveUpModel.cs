using Microsoft.Xna.Framework.Input;

namespace Beware.Inputs {
    class MoveUpModel : MappingModel<Keys> {
        public override string Heading { get => "Move Up"; }
        public override Keys Name { get => this.Name; set => this.Name = ControlMap.MoveUp; }
    }
}

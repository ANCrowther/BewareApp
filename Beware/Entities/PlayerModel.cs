using System;

namespace Beware.Entities {
    public class PlayerModel : EntityModel {
        private static PlayerModel instance;


        public static PlayerModel Instance {
            get {
                if (instance == null) {
                    instance = new PlayerModel();
                }
                return instance;
            }
        }

        private PlayerModel() {

        }

        public override void Update() {
            throw new NotImplementedException();
        }
    }
}

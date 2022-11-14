using Beware.CardinalModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Beware.Managers {
    public class CardinalMapManager {
        private static CardinalMapManager instance;
        //private Vector2 centerPosition;
        private List<ICardinalModel> compass;
        private Vector2 origin = new Vector2(200, 200) / 2.0f;

        public static CardinalMapManager Instance {
            get {
                if (instance == null) {
                    instance = new CardinalMapManager();
                }
                return instance;
            }
        }

        public CardinalMapManager() {
            compass = new List<ICardinalModel>();
            //origin = new Vector2(200, 200) / 2.0f;
            Initialize();
        }

        private void Initialize() {
            compass.Add(new NModel(origin));
            compass.Add(new NENModel(origin));
            compass.Add(new NEModel(origin));
            compass.Add(new ENEModel(origin));
            compass.Add(new EModel(origin));
            compass.Add(new ESEModel(origin));
            compass.Add(new SEModel(origin));
            compass.Add(new SESModel(origin));
            compass.Add(new SModel(origin));
            compass.Add(new SWSModel(origin));
            compass.Add(new SWModel(origin));
            compass.Add(new WSWModel(origin));
            compass.Add(new WModel(origin));
            compass.Add(new WNWModel(origin));
            compass.Add(new NWModel(origin));
            compass.Add(new NWNModel(origin));
        }

        public void Draw(Texture2D centerPicture, Vector2 centerPosition, Vector2 controlDirection) {
            // Draws the centerpiece to the cardinal compass.
            // Center picture is setup for 200x200 pixal pictures.
            BewareGame.Instance._spriteBatch.Draw(centerPicture, centerPosition, null, Color.White, 0, origin, 1.0f, 0, 0.0f);

            foreach (ICardinalModel item in compass) {
                item.Draw(centerPosition, controlDirection);
            }
        }
    }
}

using Beware.ControllerModels;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Beware.Managers {
    static class ControllerManager {
        private static Vector2 thumbOrigin = new Vector2(ControllerArt.Button_ThumbStationary.Width, ControllerArt.Button_ThumbStationary.Height) / 2.0f;
        private static Vector2 buttonOrigin = new Vector2(ControllerArt.Button_Generic.Width, ControllerArt.Button_Generic.Height) / 2.0f;
        private static List<IControllerModel> buttonList;

        public static void Initialize() {
            buttonList = new List<IControllerModel>();
            buttonList.Add(new ThumbStickModel(thumbOrigin));
            buttonList.Add(new ButtonUpModel(buttonOrigin));
            buttonList.Add(new ButtonDownModel(buttonOrigin));
            buttonList.Add(new ButtonLeftModel(buttonOrigin));
            buttonList.Add(new ButtonRightModel(buttonOrigin));
        }

        public static void Draw(Vector2 centerThumbStickPosition, Vector2 centerButtonPosition, Vector2 controlDirection, Mode mode) {
            bool isMobile = (controlDirection.LengthSquared() > 0);

            foreach (IControllerModel button in buttonList) {
                if (button is ThumbStickModel thumbStick) {
                    thumbStick.Draw(centerThumbStickPosition, mode, isMobile, controlDirection.ToAngle());
                } else {
                    button.Draw(centerButtonPosition, mode);
                }
            }
        }
    }
}

﻿using Beware.Enums;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beware.ControllerModels {
    class ButtonLeftModel : IControllerModel {
        private Vector2 origin;

        public ButtonLeftModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 position, Mode mode, bool isMobile = true, float orientation = 0) {
            bool isActive = false;
            if (mode == Mode.Move) {
                isActive = isActive.CheckIsButtonActive(Buttons.DPadLeft);
            }
            if (mode == Mode.Shoot) {
                isActive = isActive.CheckIsButtonActive(Buttons.X);
            }

            (Texture2D picture, Color color) inputs;
            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                inputs = DrawLayout3(mode, isActive);
            } else {
                inputs = DrawLayout1_2(mode, isActive);
            }

            BewareGame.Instance._spriteBatch.Draw(ControllerArt.Button_Generic, new Vector2(position.X - 75, position.Y), null, Color.White, orientation, this.origin, 0.5f, 0, 0.0f);
            if (mode == Mode.Move) {
                BewareGame.Instance._spriteBatch.Draw(inputs.picture, new Vector2(position.X - 75, position.Y), null, inputs.color, MathHelper.ToRadians(270.0f), new Vector2(inputs.picture.Width, inputs.picture.Height) / 2, 0.5f, 0, 0.0f);
            }
            if (mode == Mode.Shoot) {
                BewareGame.Instance._spriteBatch.Draw(inputs.picture, new Vector2(position.X - 75, position.Y), null, inputs.color, orientation, new Vector2(inputs.picture.Width, inputs.picture.Height) / 2, 0.5f, 0, 0.0f);
            }
        }

        private (Texture2D picture, Color color) DrawLayout1_2(Mode mode, bool isActive) {
            Texture2D picture = (mode == Mode.Move) ? ControllerArt.Arrow : ControllerArt.X;
            Color color = GetColor(mode, isActive);
            return (picture, color);
        }
        
        private (Texture2D picture, Color color) DrawLayout3(Mode mode, bool isActive) {
            Texture2D picture = (mode == Mode.Move) ? ControllerArt.Arrow : ControllerArt.Y;
            Color color = GetColor(Mode.Move, isActive);
            return (picture, color);
        }

        private Color GetColor(Mode mode, bool isActive) {
            return mode switch {
                Mode.Move => (isActive) ? Color.Red : Color.DarkGray,
                Mode.Shoot => (isActive) ? Color.HotPink : Color.Blue,
                _ => Color.White,
            };
        }
    }
}

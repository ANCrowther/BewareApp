﻿using Beware.Entities;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Beware.GameScenes {
    class BackgroundMoving : DrawableGameComponent {
        private Texture2D image;
        private Vector2 position;
        private Vector2 windowSize;
        private View view;

        private List<StarModel> stars = new List<StarModel>();
        private Color[] colors = { Color.White, Color.Yellow, Color.Red, Color.CornflowerBlue };
        private Random random = new Random();

        public BackgroundMoving(Texture2D backgroundImage, View backgroundView) : base(BewareGame.Instance) {
            this.image = backgroundImage;
            position = new Vector2(0, 0);
            windowSize = ViewportManager.GetWindowSize(view);
            view = backgroundView;
            LoadStarBackground();
        }

        private void LoadStarBackground() {
            int maxCount = (view == View.InfoOne || view == View.InfoTwo) ? 150 : 300;

            for (int i = 0; i < maxCount; i++) {
                int size = random.Next(2, 5);
                stars.Add(new StarModel(new Vector2(
                    random.Next(0, (int)windowSize.X),
                    random.Next(0, (int)windowSize.Y)), this.image,  new Rectangle(0, 0, size, size)));
            }
            foreach (StarModel star in stars) {
                star.TintColor = colors[random.Next(0, colors.Length)];
                star.TintColor *= (float)(random.Next(30, 80) / 100f);
            }
        }

        public override void Update(GameTime gameTime) {
            position = Helpers.GetDirection(Mode.Move);

            if ((ViewportManager.CurrentLayout == ViewportLayout.Layout2
                || ViewportManager.CurrentLayout == ViewportLayout.Layout3) && view == View.InfoTwo) {
                position = Helpers.GetDirection(Mode.Shoot);
            }

            position *= 2;

            foreach (StarModel star in stars) {
                star.Update(position);
                if (star.Location.Y < 0)
                    star.Location = new Vector2(star.Location.X, windowSize.Y);
                if (star.Location.Y > windowSize.Y)
                    star.Location = new Vector2(star.Location.X, 0);
                if (star.Location.X < 0)
                    star.Location = new Vector2(windowSize.X, star.Location.Y);
                if (star.Location.X > windowSize.X)
                    star.Location = new Vector2(0, star.Location.Y);
            }
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            ViewportManager.GetView(view);

            foreach (StarModel star in stars) {
                star.Draw();
            }
            
            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

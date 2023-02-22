using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    static class Border {
        public static void CreateBorder(this Texture2D texture, int borderWidth, Color borderColor) {
            Color[] colors = new Color[texture.Width * texture.Height];

            for (int x = 0; x < texture.Width; x++) {
                for (int y = 0; y < texture.Height; y++) {
                    bool colored = false;
                    for (int i = 0; i <= borderWidth; i++) {
                        if (x == i || y == i || x == texture.Width - 1 - i || y == texture.Height - 1 - i) {
                            colors[x + y * texture.Width] = borderColor;
                            colored = true;
                            break;
                        }
                    }

                    if (colored == false)
                        colors[x + y * texture.Width] = Color.Transparent;
                }
            }

            texture.SetData(colors);
        }

        public static void CreateTranslucentBorder(this Texture2D texture, int borderWidth, Color borderColor) {
            Color[] colors = new Color[texture.Width * texture.Height];

            for (int x = 0; x < texture.Width; x++) {
                for (int y = 0; y < texture.Height; y++) {
                    bool colored = false;
                    for (int i = 0; i <= borderWidth; i++) {
                        if (x == i || y == i || x == texture.Width - 1 - i || y == texture.Height - 1 - i) {
                            if (i % 4 == 0)
                                colors[x + y * texture.Width] = borderColor;
                            else
                                colors[x + y * texture.Width] = Color.Transparent;
                            colored = true;
                            break;
                        }
                    }

                    if (colored == false)
                        colors[x + y * texture.Width] = Color.Transparent;
                }
            }

            texture.SetData(colors);
        }

        public static void CreateTranslucentRectangle(this Texture2D texture, Color fillColor) {
            Color[] colors = new Color[texture.Width * texture.Height];

            for (int i = 0; i < colors.Length; i++) {
                if (i % 3 == 0 || i % 3 == 1)
                    colors[i] = Color.Transparent;
                else
                    colors[i] = fillColor;
            }

            texture.SetData(colors);
        }

        public static void CreateHealthBar(this Texture2D texture, Color fillColor) {
            Color[] colors = new Color[texture.Width * texture.Height];

            for (int i = 0; i < colors.Length; i++) {
                colors[i] = fillColor;
            }

            texture.SetData(colors);
        }
    }
}

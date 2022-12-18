using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    static class ScenesArt {
        public static Texture2D SpaceBattleWide { get; private set; }
        public static Texture2D SpacecraftThroughMeteorite { get; private set; }
        public static Texture2D NebulaPlanetRing { get; private set; }
        public static Texture2D StellarSpaceship { get; private set; }
        public static Texture2D RedSky { get; private set; }
        public static Texture2D GenericSpace { get; private set; }
        public static Texture2D SpacePlanetsStars { get; private set; }
        public static Texture2D ArtificialPlanet { get; private set; }
        public static Texture2D BlinkingStar { get; private set; }
        public static Texture2D LeftController { get; private set; }
        public static Texture2D RightController { get; private set; }

        public static void Initialize(ContentManager content) {
            SpaceBattleWide = content.Load<Texture2D>(@"Scenes\Space-Battle-Wide-Desktop-Background");
            SpacecraftThroughMeteorite = content.Load<Texture2D>(@"Scenes\Spacecraft-through-the-meteorite-array-2560x1600");
            NebulaPlanetRing = content.Load<Texture2D>(@"Scenes\Universe-Nebula-Planet-Ring-Light-Purple-Blue-Color-2560X1600");
            StellarSpaceship = content.Load<Texture2D>(@"Scenes\Journey-through-galactic-cosmic-space-stellar-spaceship-1920x1200");
            RedSky = content.Load<Texture2D>(@"Scenes\Space_Red_space_03947-1920x1200");
            ArtificialPlanet = content.Load<Texture2D>(@"Scenes\3d_space_scene_artificial_planet-19375");
            GenericSpace = content.Load<Texture2D>(@"Scenes\generic_space_scene");
            BlinkingStar = content.Load<Texture2D>(@"Scenes\background_star");
            SpacePlanetsStars = content.Load<Texture2D>(@"Scenes\Art-pictures-space-planets-stars-2560x1600");
            LeftController = content.Load<Texture2D>(@"Scenes\background_leftController");
            RightController = content.Load<Texture2D>(@"Scenes\background_rightController");
        }
    }
}

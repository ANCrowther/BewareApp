using Beware.ExtensionSupport;
using Beware.Inputs;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Beware.Managers {
    static class AudioManager {
        private static int tempVolume;
        private static int tempSFXVolume;
        private static int tempMasterVolume;

        private static int cooldownFrames = 60;
        private static int cooldownRemaining = 0;
        private static bool isVolumeChanged = false;

        public static bool IsMuted { get; private set; } = false;
        public static int MusicVolumeLevel { get; private set; } = 5;
        public static int SFXVolumeLevel { get; private set; } = 3;
        public static int MasterVolumeLevel { get; private set; } = 10;

        public static void Update(VolumeType type = VolumeType.Master) {
            if (Input.WasKeyPressed(ControlMap.VolumeUp_key) || Input.WasButtonPressed(ControlMap.VolumeUp)) {
                VolumeUp(type);
                ResetCooldown();
            }
            if (Input.WasKeyPressed(ControlMap.VolumeDown_key) || Input.WasButtonPressed(ControlMap.VolumeDown)) {
                VolumeDown(type);
                ResetCooldown();
            }
            if (Input.WasKeyPressed(ControlMap.Mute_key) || Input.WasButtonPressed(ControlMap.Mute)) {
                Mute();
            }
            if (isVolumeChanged == true) {
                UpdateCountdown();
            }
            
        }

        private static void ResetCooldown() {
            cooldownRemaining = cooldownFrames;
            isVolumeChanged = true;
        }

        private static void UpdateCountdown() {
            if (cooldownRemaining > 0) {
                cooldownRemaining--;
            }
            if (cooldownRemaining <= 0) {
                ResetCooldown();
                isVolumeChanged = false;
            }
        }

        public static void Draw(Vector2 position) {
            if (isVolumeChanged == true) {
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{MasterVolumeLevel}", position, Color.Aquamarine);
            }
        }

        public static void DrawGameSettingsView(Vector2 volumePosition, GameSettings gameSetting, VolumeType volumeType, bool isActive) {
            DrawMasterVolumeLevel(gameSetting, volumeType, isActive, volumePosition);
            volumePosition.Y += 100;
            DrawMusicVolumeLevel(gameSetting, volumeType, isActive, volumePosition);
            volumePosition.Y += 100;
            DrawSFXVolumeLevel(gameSetting, volumeType, isActive, volumePosition);
        }

        private static void DrawMasterVolumeLevel(GameSettings gameSetting, VolumeType volumeType, bool isActive, Vector2 position) {
            Color color = Color.Lime;
            if (gameSetting == GameSettings.Volume && isActive == true) {
                color = (volumeType == VolumeType.Master) ? Color.Moccasin : Color.Lime;
            }

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, "Master volume", position, color);
            position.X += Fonts.NovaSquareMedium.MeasureString("Master volume  ").X;
            position.Y += 50;

            for (int i = 1; i <= 20; i++) {
                Texture2D image = (AudioManager.MasterVolumeLevel >= i) ? Art.BlueSquare : Art.RedSquare;
                BewareGame.Instance._spriteBatch.Draw(image, position, null, Color.White, 0, new Vector2(image.Width, image.Height) / 2.0f, 0.5f, 0, 0.0f);
                position.X += 50;
            }
        }

        private static void DrawMusicVolumeLevel(GameSettings gameSetting, VolumeType volumeType, bool isActive, Vector2 position) {
            Color color = Color.Lime;
            if (gameSetting == GameSettings.Volume && isActive == true) {
                color = (volumeType == VolumeType.Music) ? Color.Moccasin : Color.Lime;
            }

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, "Music volume", position, color);
            position.X += Fonts.NovaSquareMedium.MeasureString("Music volume   ").X;
            position.Y += 50;

            for (int i = 1; i <= 20; i++) {
                Texture2D image = (AudioManager.MusicVolumeLevel >= i) ? Art.BlueSquare : Art.RedSquare;
                BewareGame.Instance._spriteBatch.Draw(image, position, null, Color.White, 0, new Vector2(image.Width, image.Height) / 2.0f, 0.5f, 0, 0.0f);
                position.X += 50;
            }
        }

        private static void DrawSFXVolumeLevel(GameSettings gameSetting, VolumeType volumeType, bool isActive, Vector2 position) {
            Color color = Color.Lime;
            if (gameSetting == GameSettings.Volume && isActive == true) {
                color = (volumeType == VolumeType.SFX) ? Color.Moccasin : Color.Lime;
            }

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, "SFX volume", position, color);
            position.X += Fonts.NovaSquareMedium.MeasureString("SFX volume      ").X;
            position.Y += 50;

            for (int i = 1; i <= 20; i++) {
                Texture2D image = (AudioManager.SFXVolumeLevel >= i) ? Art.BlueSquare : Art.RedSquare;
                BewareGame.Instance._spriteBatch.Draw(image, position, null, Color.White, 0, new Vector2(image.Width, image.Height) / 2.0f, 0.5f, 0, 0.0f);
                position.X += 50;
            }
        }

        private static void VolumeUp(VolumeType type) {
            switch (type) {
                case VolumeType.Master:
                    MasterVolumeUp();
                    break;
                case VolumeType.Music:
                    MusicVolumeUp();
                    break;
                case VolumeType.SFX:
                    SFXVolumeUp();
                    break;
            }
        }

        private static void VolumeDown(VolumeType type) {
            switch (type) {
                case VolumeType.Master:
                    MasterVolumeDown();
                    break;
                case VolumeType.Music:
                    MusicVolumeDown();
                    break;
                case VolumeType.SFX:
                    SFXVolumeDown();
                    break;
            }
        }

        private static void Mute() {
            if (IsMuted) {
                MusicVolumeLevel = tempVolume;
                MediaPlayer.Volume = MusicVolumeLevel.SoundToFloat();
                SFXVolumeLevel = tempSFXVolume;
                MasterVolumeLevel = tempMasterVolume;
                IsMuted = false;
            } else {
                tempVolume = MusicVolumeLevel;
                MusicVolumeLevel = 0;
                MediaPlayer.Volume = 0.0f;
                tempSFXVolume = SFXVolumeLevel;
                SFXVolumeLevel = 0;
                tempMasterVolume = MasterVolumeLevel;
                MasterVolumeLevel = 0;
                IsMuted = true;
            }
        }

        private static void MasterVolumeUp() {
            if (MasterVolumeLevel < 20) {
                MasterVolumeLevel += 1;
            }
            if (MasterVolumeLevel <= 0) {
                MasterVolumeLevel = 0;
            }
        }

        private static void AdjustVolumesToMasterVolume() {
            if (MusicVolumeLevel > MasterVolumeLevel) {
                MusicVolumeLevel = MasterVolumeLevel;
                tempVolume = MasterVolumeLevel;
            }

            if (SFXVolumeLevel > MasterVolumeLevel) {
                SFXVolumeLevel = MasterVolumeLevel;
                tempSFXVolume = MasterVolumeLevel;
            }
        }

        private static void MasterVolumeDown() {
            if (MasterVolumeLevel > 0) {
                MasterVolumeLevel -= 1;
            }
            AdjustVolumesToMasterVolume();
        }

        private static void MusicVolumeUp() {
            if (MusicVolumeLevel < 20 && MusicVolumeLevel < MasterVolumeLevel) {
                MusicVolumeLevel += 1;
                tempVolume = MusicVolumeLevel;
                MediaPlayer.Volume = MusicVolumeLevel.SoundToFloat();
                IsMuted = false;
            }

            if (MusicVolumeLevel <= 0 && MusicVolumeLevel < MasterVolumeLevel) {
                MusicVolumeLevel = 1;
                tempVolume = 1;
                MediaPlayer.Volume = MusicVolumeLevel.SoundToFloat();
                IsMuted = false;
            }
        }

        private static void MusicVolumeDown() {
            if (MusicVolumeLevel > 0) {
                MusicVolumeLevel -= 1;
                tempVolume = MusicVolumeLevel;
                MediaPlayer.Volume = MusicVolumeLevel.SoundToFloat();
            }
        }

        private static void SFXVolumeUp() {
            if (SFXVolumeLevel < 20 && SFXVolumeLevel < MasterVolumeLevel) {
                SFXVolumeLevel += 1;
                tempSFXVolume = SFXVolumeLevel;
                MediaPlayer.Volume = SFXVolumeLevel.SoundToFloat();
                IsMuted = false;
            }
            if (SFXVolumeLevel <= 0 && SFXVolumeLevel < MasterVolumeLevel) {
                SFXVolumeLevel = 1;
                tempSFXVolume = 1;
                MediaPlayer.Volume = SFXVolumeLevel.SoundToFloat();
            }
        }

        private static void SFXVolumeDown() {
            if (SFXVolumeLevel > 0) {
                SFXVolumeLevel -= 1;
                tempSFXVolume = SFXVolumeLevel;
                MediaPlayer.Volume = SFXVolumeLevel.SoundToFloat();
            }
        }
    }
}

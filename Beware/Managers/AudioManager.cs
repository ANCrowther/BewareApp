using Beware.Inputs;
using Beware.Utilities;
using Microsoft.Xna.Framework.Media;

namespace Beware.Managers {
    static class AudioManager {
        private static int tempVolume;
        private static int tempSFXVolume;
        private static int tempMasterVolume;

        public static bool IsMuted { get; private set; } = false;
        public static int MusicVolumeLevel { get; private set; } = 5;
        public static int SFXVolumeLevel { get; private set; } = 3;
        public static int MasterVolumeLevel { get; private set; } = 10;

        public static void Update(VolumeType type = VolumeType.Master) {
            if (Input.WasKeyPressed(ControlMap.VolumeUp)) {
                VolumeUp(type);
            }
            if (Input.WasKeyPressed(ControlMap.VolumeDown)) {
                VolumeDown(type);
            }
            if (Input.WasKeyPressed(ControlMap.Mute) || Input.WasButtonPressed(ControlMap.Mute_pad)) {
                Mute();
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

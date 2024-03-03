using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace FNAF.Game_Engine
{
    internal class SoundInitializer
    {
        string defaultPath;
        WaveFileReader fanBuzzAudio;
        WaveFileReader openingTabletAudio;
        WaveFileReader doorClosingAudio;
        WaveFileReader closingTabletAudio;
        WaveFileReader lightBuzzAudio;
        WaveFileReader blipAudio;
        public SoundInitializer()
        {
            defaultPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..");
            fanBuzzAudio = new WaveFileReader(defaultPath + "\\Sounds\\Office\\FanBuzz.wav");
            openingTabletAudio = new WaveFileReader(defaultPath + "\\Sounds\\Tablet\\OpeningTablet.wav");
            doorClosingAudio = new WaveFileReader(defaultPath + "\\Sounds\\Office\\DoorClosing.wav");
            closingTabletAudio = new WaveFileReader(defaultPath + "\\Sounds\\Tablet\\ClosingTablet.wav");
            lightBuzzAudio = new WaveFileReader(defaultPath + "\\Sounds\\Office\\LightBuzz.wav");
            blipAudio = new WaveFileReader(defaultPath + "\\Sounds\\Tablet\\Blip.wav");
        }

        WaveOutEvent fanBuzzWaveOutEvent;
        private WaveOutEvent openingTabletWaveOutEvent;
        private WaveOutEvent lightBuzzWaveOutEvent;

        public enum audioNames
        {
            fanBuzzAudio,
            openingTabletAudio,
            doorClosingAudio,
            closingTabletAudio,
            lightBuzzAudio,
            blipAudio
        }

        public void PlaySound(audioNames audioNames)
        {
            Task.Run(() =>
            {
                switch (audioNames)
                {
                    case audioNames.fanBuzzAudio:
                        PlaySoundWithLoop(fanBuzzAudio);
                        break;
                    case audioNames.openingTabletAudio:
                        // Stop the previous openingTabletAudio, if it's playing
                        if (openingTabletWaveOutEvent != null)
                        {
                            openingTabletWaveOutEvent.Stop();
                            openingTabletWaveOutEvent.Dispose();
                        }

                        openingTabletWaveOutEvent = new WaveOutEvent();
                        PlaySoundReal(openingTabletAudio, openingTabletWaveOutEvent);
                        break;
                    case audioNames.doorClosingAudio:
                        PlaySoundReal(doorClosingAudio);
                        break;
                    case audioNames.closingTabletAudio:
                        PlaySoundReal(closingTabletAudio);
                        break;
                    case audioNames.lightBuzzAudio:
                        if (lightBuzzWaveOutEvent != null)
                        {
                            lightBuzzWaveOutEvent.Stop();
                            lightBuzzWaveOutEvent.Dispose();
                        }

                        lightBuzzWaveOutEvent = new WaveOutEvent();
                        PlaySoundReal(lightBuzzAudio, lightBuzzWaveOutEvent);
                        break;
                    case audioNames.blipAudio:
                        PlaySoundReal(blipAudio);
                        break;
                    default:
                        break;
                }
            });
        }
        public void StopSound(audioNames audioNames)
        {
            Task.Run(() =>
            {
                switch (audioNames)
                {
                    case audioNames.fanBuzzAudio:
                        fanBuzzWaveOutEvent.Stop();
                        break;
                    case audioNames.openingTabletAudio:
                        openingTabletWaveOutEvent.Stop();
                        break;
                    case audioNames.doorClosingAudio:
                        PlaySoundReal(doorClosingAudio);
                        break;
                    case audioNames.closingTabletAudio:
                        if (true)
                        {

                        }
                        break;
                    case audioNames.lightBuzzAudio:
                        if (lightBuzzWaveOutEvent != null)
                        {
                            lightBuzzWaveOutEvent.Stop();
                            lightBuzzWaveOutEvent.Dispose();
                            lightBuzzWaveOutEvent = null;
                        }
                        break;
                    default:
                        break;
                }
            });
        }

        private void PlaySoundReal(WaveFileReader audioNames, WaveOutEvent waveOutEvent = null)
        {
            audioNames.Position = 0;
            waveOutEvent = waveOutEvent ?? new WaveOutEvent();
            waveOutEvent.Init(audioNames);
            waveOutEvent.Play();
        }

        private void PlaySoundWithLoop(WaveFileReader audio)
        {
            if (fanBuzzWaveOutEvent != null)
            {
                fanBuzzWaveOutEvent.Stop();
                fanBuzzWaveOutEvent.Dispose();
            }

            fanBuzzAudio.Position = 0;
            fanBuzzWaveOutEvent = new WaveOutEvent();
            fanBuzzWaveOutEvent.Init(fanBuzzAudio);
            fanBuzzWaveOutEvent.Play();
        }

        
        //public void StopSound(audioNames soundPlayer)
        //{
        //    if (soundPlayer != null)
        //    {
        //        soundPlayer.Stop();
        //        soundPlayer.Dispose();
        //        soundPlayer = null;
        //    }
        //}
    }
}
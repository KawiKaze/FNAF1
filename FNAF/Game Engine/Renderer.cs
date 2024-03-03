using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace FNAF.Game_Engine
{
    public class Renderer
    {

        async public void BlinkingRecordIcon(bool active)
        {
            bool recordIconVisible = true;
            await Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                do
                {
                    if (active)
                    {
                        if (!recordIconVisible)
                        {
                            Imports.recordingIcon.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            Imports.recordingIcon.Visibility = Visibility.Visible;
                        }
                        await Task.Delay(1000);
                    }
                    else
                    {
                        Imports.recordingIcon.Visibility = Visibility.Hidden;
                    }
                } while (true);
            });
        }

        async public void PlayAnimation(List<BitmapImage> animation, System.Windows.Controls.Image canvas, int delay, bool loop = false, bool reverse = false, bool hideImage = false, bool noise = false)
        {
            await Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                canvas.Visibility = Visibility.Visible;
                do
                {
                    if (!reverse) // Display animation images in a loop
                    {
                        for (int i = 0; i < animation.Count; i++)
                        {
                            canvas.Source = animation[i];

                            await Task.Delay(delay);
                        }
                    }
                    else // Display animation images in reverse order in a loop
                    {
                        for (int i = animation.Count - 1; i >= 0; i--)
                        {
                            canvas.Source = animation[i];
                            await Task.Delay(delay);
                        }
                    }
                } while (loop);
                if (hideImage)
                {
                    canvas.Visibility = Visibility.Hidden;
                }
                if (noise)
                {
                    while (true)
                    {
                        for (int i = 0; i < Imports.noiseImages.Count; i++)
                        {
                            canvas.Source = Imports.noiseImages[i];

                            await Task.Delay(18);
                        }
                    }
                }
            });
        }

        async public void PlayAnimation(BitmapImage Image, System.Windows.Controls.Image Canvas)
        {
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Canvas.Source = Image;
            }));
        }

        async public void StartAnimationLoop(List<BitmapImage> animation, System.Windows.Controls.Image canvas, int delay)
        {
            await Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                do
                {
                    for (int i = animation.Count - 1; i >= 0; i--)
                    {
                        canvas.Source = animation[i];
                        await Task.Delay(delay);
                    }
                } while (true);
            });
        }

        async public void ChangeOpacity(System.Windows.Controls.Image Canvas, double Opacity)
        {
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Canvas.Opacity = Opacity;
            }));
        }

        async public void HideImage(System.Windows.Controls.Image Canvas)
        {
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Canvas.Visibility = Visibility.Hidden;
            }));
        }
        async public void HideImage(System.Windows.Controls.Grid Canvas)
        {
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Canvas.Visibility = Visibility.Hidden;
            }));
        }
        async public void HideImage(System.Windows.Controls.TextBlock Canvas)
        {
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Canvas.Visibility = Visibility.Hidden;
            }));
        }
        async public void ShowImage(System.Windows.Controls.Image Canvas)
        {
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Canvas.Visibility = Visibility.Visible;
            }));
        }
        async public void ShowImage(System.Windows.Controls.Grid Canvas)
        {
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Canvas.Visibility = Visibility.Visible;
            }));
        }

        public async void OpenCamera()
        {
            PlayAnimation(Imports.tabletAnimation, Imports.tabletImage, 10, false, false);
            await Task.Delay(250);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            ShowImage(Imports.noiseImage);
            ShowImage(Imports.cameraImage);
            ShowImage(Imports.cameraBorder);
            ShowImage(Imports.cameraMap);
            ShowImage(Imports.cameraButtons);
            ShowImage(Imports.recordingIcon);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.openingTabletAudio);
        }

        public async void CloseCamera()
        {
            HideImage(Imports.cameraImage);
            HideImage(Imports.cameraBorder);
            HideImage(Imports.cameraMap);
            HideImage(Imports.cameraButtons);
            HideImage(Imports.recordingIcon);
            HideImage(Imports.noiseImage);
            PlayAnimation(Imports.tabletAnimation, Imports.tabletImage, 10, false, true, true);
            Engine_API._SoundPlayer.StopSound(SoundInitializer.audioNames.openingTabletAudio);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.closingTabletAudio);
        }
        public async void HideHUD()
        {
            HideImage(Imports.batteryCells);
            HideImage(Imports.muteCall);
            HideImage(Imports.tabletBar);
            HideImage(Imports.leftDoorButtonImage);
            HideImage(Imports.rightDoorButtonImage);
            HideImage(Imports.powerLeft);
            HideImage(Imports.nightText);
            HideImage(Imports.hourText);
            HideImage(Imports.usageText);
            HideImage(Imports.powerLeftText);
            HideImage(Imports.nightNameText);
            HideImage(Imports.amText);
        }

        public async void NightFinished()
        {
            Application.Current.Dispatcher.Invoke(async () =>
            {
                Imports.clock.Visibility = Visibility.Visible;
                Imports.storyboardFive.Begin();
                Imports.storyboardSix.Begin();
                await Task.Delay(TimeSpan.FromSeconds(4));
                Imports.clock.Visibility = Visibility.Hidden;
                Imports.storyboardFive.Stop();
                Imports.storyboardSix.Stop();
            });
        }
    }
}
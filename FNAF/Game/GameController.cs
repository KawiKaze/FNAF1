using FNAF.Game.Animatronics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNAF.Game_Engine;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.Windows.Threading;

namespace FNAF.Game
{
    internal class GameController : Window
    {
        Random rnd = new Random();
        public bool tabletRaised = false;
        Freddy freddy;
        Bonnie bonnie;
        Chica chica;
        Foxy foxy;
        Battery battery;
        HallwayController leftHallway;
        HallwayController rightHallway;
        public bool leftDoorVisible = false;
        public bool rightDoorVisible = false;
        bool leftLightOn = false;
        bool rightLightOn = false;
        private bool secondImage = false;
        private bool foxyAnimationPlayed = false;
        private int foxyPowerConsumption = 1;
        private bool freddyVisible = false;
        string activeCamera = "Cam1A";

        DispatcherTimer cameraTimer;
        DispatcherTimer foxyTimer;
        DispatcherTimer nightTimer;
        DispatcherTimer blackoutTimer;
        int time = 0;
        int hour = 0;
        int night = 1;

        public GameController()
        {
            freddy = new Freddy(0);
            bonnie = new Bonnie(0);
            chica = new Chica(0);
            foxy = new Foxy(0);

            leftHallway = new HallwayController(0);
            rightHallway = new HallwayController(1);

            battery = new();
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.fanBuzzAudio);

            //foxyTimer = new DispatcherTimer();
            //foxyTimer.Interval = TimeSpan.FromSeconds(0.5);
            //foxyTimer.Tick += foxyTimer_Tick;
            //foxyTimer.Start();

            nightTimer = new DispatcherTimer();
            nightTimer.Interval = TimeSpan.FromSeconds(1);
            nightTimer.Tick += nightTimer_Tick;
            nightTimer.Start();

            cameraTimer = new DispatcherTimer();
            cameraTimer.Interval = TimeSpan.FromMilliseconds(1);
            cameraTimer.Tick += cameraTimer_Tick;
            cameraTimer.Start();

            blackoutTimer = new DispatcherTimer();
            blackoutTimer.Interval = TimeSpan.FromSeconds(0.25);
            blackoutTimer.Tick += blackoutTimer_Tick;
        }

        public void CloseGame()
        {
            Environment.Exit(0);
        }
        #region Office
        public void LeftDoorLightButtonClick()
        {
            leftLightOn = !leftLightOn;

            // Set the office background image based on the state of lights
            if (!leftLightOn && !rightLightOn)
            {
                Engine_API._SoundPlayer.StopSound(SoundInitializer.audioNames.lightBuzzAudio);
                Engine_API._Renderer.PlayAnimation(Imports.officeEmptyImage, Imports.officeImage);

                if (!leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (!leftDoorVisible && rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }

                battery.LowerBatteryActivity();
            }
            else if (!leftLightOn && rightLightOn)
            {

                Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.lightBuzzAudio);
                Engine_API._Renderer.PlayAnimation(Imports.officeRightLightImage, Imports.officeImage);

                if (!leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonLightOnImage, Imports.rightDoorButtonImage);
                }
                else if (!leftDoorVisible && rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonAllOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonAllOnImage, Imports.rightDoorButtonImage);
                }

                battery.LowerBatteryActivity();
            }
            else if (leftLightOn && rightLightOn)
            {
                Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.lightBuzzAudio);
                Engine_API._Renderer.PlayAnimation(Imports.officeLeftLightImage, Imports.officeImage);

                if (!leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonLightOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonAllOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (!leftDoorVisible && rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonLightOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonAllOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }

                rightLightOn = !rightLightOn;
            }
            else
            {
                Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.lightBuzzAudio);
                Engine_API._Renderer.PlayAnimation(Imports.officeLeftLightImage, Imports.officeImage);

                if (!leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonLightOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonAllOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (!leftDoorVisible && rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonLightOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonAllOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }

                battery.RaiseBatteryActivity();
            }
        }
        public void RightDoorLightButtonClick()
        {
            rightLightOn = !rightLightOn;

            // Set the office background image based on the state of lights
            if (!rightLightOn && !leftLightOn)
            {
                Engine_API._SoundPlayer.StopSound(SoundInitializer.audioNames.lightBuzzAudio);
                Engine_API._Renderer.PlayAnimation(Imports.officeEmptyImage, Imports.officeImage);
                if (!leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (!leftDoorVisible && rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }

                battery.LowerBatteryActivity();
            }
            else if (!rightLightOn && leftLightOn)
            {
                Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.lightBuzzAudio);
                Engine_API._Renderer.PlayAnimation(Imports.officeLeftLightImage, Imports.officeImage);

                if (!leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonLightOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonAllOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (!leftDoorVisible && rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonLightOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonAllOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }

                battery.LowerBatteryActivity();
            }
            else if (rightLightOn && leftLightOn)
            {
                Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.lightBuzzAudio);
                Engine_API._Renderer.PlayAnimation(Imports.officeRightLightImage, Imports.officeImage);

                if (!leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonLightOnImage, Imports.rightDoorButtonImage);
                }
                else if (leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
                else if (!leftDoorVisible && rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonAllOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonAllOnImage, Imports.rightDoorButtonImage);
                }

                leftLightOn = !leftLightOn;
            }
            else
            {
                Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.lightBuzzAudio);
                Engine_API._Renderer.PlayAnimation(Imports.officeRightLightImage, Imports.officeImage);

                if (!leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonLightOnImage, Imports.rightDoorButtonImage);
                }
                else if (leftDoorVisible && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonLightOnImage, Imports.rightDoorButtonImage);
                }
                else if (!leftDoorVisible && rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonAllOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonAllOnImage, Imports.rightDoorButtonImage);
                }

                battery.RaiseBatteryActivity();
            }
        }
        public void LeftDoorButtonClick()
        {
            // Toggle the visibility of the left door
            if (!leftDoorVisible)
            {
                ShutLeftDoor();

                if (leftLightOn)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonAllOnImage, Imports.leftDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonDoorOnImage, Imports.leftDoorButtonImage);
                }
            }
            else
            {
                OpenLeftDoor();

                if (leftLightOn)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonLightOnImage, Imports.leftDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
                }
            }



            leftDoorVisible = !leftDoorVisible;
        }
        public void RightDoorButtonClick()
        {
            // Toggle the visibility of the left door
            if (rightDoorVisible == false)
            {
                ShutRightDoor();

                if (rightLightOn)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonAllOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonDoorOnImage, Imports.rightDoorButtonImage);
                }
            }
            else
            {
                OpenRightDoor();

                if (rightLightOn)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonLightOnImage, Imports.rightDoorButtonImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
                }
            }
            rightDoorVisible = !rightDoorVisible;
        }
        public void ShutLeftDoor()
        {
            leftHallway.CloseDoor();
            battery.RaiseBatteryActivity();
        }
        public void ShutRightDoor()
        {
            rightHallway.CloseDoor();
            battery.RaiseBatteryActivity();
        }
        public void OpenLeftDoor()
        {
            leftHallway.OpenDoor();
            battery.LowerBatteryActivity();
        }
        public void OpenRightDoor()
        {
            rightHallway.OpenDoor();
            battery.LowerBatteryActivity();
        }
        #endregion
        public void CloseCall()
        {
            Engine_API._Renderer.HideImage(Imports.muteCall);
        }
        public void OpenCall()
        {
            Engine_API._Renderer.ShowImage(Imports.muteCall);
        }
        public void TabletBarMouseEnter()
        {
            Engine_API._Renderer.StartAnimationLoop(Imports.noiseImages, Imports.noiseImage, 20);
            if (tabletRaised)
            {
                Engine_API._Renderer.CloseCamera();
                battery.LowerBatteryActivity();
                tabletRaised = false;
            }
            else
            {
                Engine_API._Renderer.OpenCamera();
                battery.RaiseBatteryActivity();
                tabletRaised = true;
            }
        }

        private async void cameraTimer_Tick(object sender, EventArgs e)
        {
            switch (activeCamera)
            {
                case "Cam1A":
                    if (bonnie.GetPosition() == 1 && freddy.GetPosition() == 1 && chica.GetPosition() == 1) // Everyone is on stage
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.stageAllStaringImage, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.fullStageImage, Imports.cameraImage);
                        }
                    }
                    else if (bonnie.GetPosition() != 1 && freddy.GetPosition() == 1 && chica.GetPosition() == 1) // No Bonnie
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.stageNoBonnieImage, Imports.cameraImage);
                    }
                    else if (bonnie.GetPosition() != 1 && freddy.GetPosition() == 1 && chica.GetPosition() != 1) // Freddy Only
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.stageFreddyStaringImage, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.stageFreddyOnlyImage, Imports.cameraImage);
                        }
                    }
                    else if (bonnie.GetPosition() == 1 && freddy.GetPosition() == 1 && chica.GetPosition() != 1) // No Chica
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.stageNoChicaImage, Imports.cameraImage);
                    }
                    else if (bonnie.GetPosition() != 1 && freddy.GetPosition() != 1 && chica.GetPosition() != 1) // Empty stage
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.emptyStageImage, Imports.cameraImage);
                    }
                    break;

                case "Cam1B": // Bonnie will hide Freddy if they share a room, and Chica will hide both of them.
                    if (chica.GetPosition() == 2)
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.DinerChicaImage, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.DinerBlackChicaImage, Imports.cameraImage);
                        }
                    }
                    else if (bonnie.GetPosition() == 2 && (chica.GetPosition() != 2 || chica.GetPosition() != 3))
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.DinerBonnieImage, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.DinerBlackBonnieImage, Imports.cameraImage);
                        }
                    }
                    else if (freddy.GetPosition() == 2 && ((chica.GetPosition() != 2 || chica.GetPosition() != 3) && (bonnie.GetPosition() != 2 || bonnie.GetPosition() != 3)))
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.DinerFreddyImage, Imports.cameraImage);
                    }
                    else
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyDinerImage, Imports.cameraImage);
                    }
                    break;

                case "Cam1C":
                    if (foxy.GetPosition() == 1)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyPirateCoveImage, Imports.cameraImage);
                    }
                    else if (foxy.GetPosition() == 2)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.PirateCove1Image, Imports.cameraImage);
                    }
                    else if (foxy.GetPosition() == 3)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.PirateCove2Image, Imports.cameraImage);
                    }
                    else if (foxy.GetPosition() == 4)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.PirateCove3Image, Imports.cameraImage);
                    }
                    break;

                case "Cam2A":
                    if (foxy.GetPosition() == 4 && !foxyAnimationPlayed && tabletRaised)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.foxyRunning, Imports.cameraImage, 20, false, false);
                        foxyAnimationPlayed = true;
                    }
                    else if (bonnie.GetPosition() == 4 && foxy.GetPosition() != 4)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.WestHallBonnieImage, Imports.cameraImage);
                    }
                    else if (bonnie.GetPosition() != 4 && foxy.GetPosition() != 4)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyWestHallImage, Imports.cameraImage);
                    }
                    break;

                case "Cam2B":
                    if (bonnie.GetPosition() == 6)
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.WHallCornerBonnieImage, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.WHallCornerBonnieStareImage, Imports.cameraImage);
                        }
                    }
                    else
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyWHallCornerImage, Imports.cameraImage);
                    }
                    break;

                case "Cam3":
                    if (bonnie.GetPosition() == 5)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.ClosetBonnieImage, Imports.cameraImage);
                    }
                    else
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyClosetImage, Imports.cameraImage);
                    }
                    break;

                case "Cam4A":
                    if (chica.GetPosition() == 5)
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.EastHallChica1Image, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.EastHallChica2Image, Imports.cameraImage);
                        }
                    }
                    else if (chica.GetPosition() != 5 && freddy.GetPosition() == 5)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EastHallFreddyImage, Imports.cameraImage);
                    }
                    else
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyEastHallImage, Imports.cameraImage);
                    }
                    break;

                case "Cam4B":
                    if (chica.GetPosition() == 6)
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.EastHallCornerChicaImage, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.EastHallCornerChicaStareImage, Imports.cameraImage);
                        }
                    }
                    else if (freddy.GetPosition() == 6 && chica.GetPosition() != 6)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EastHallCornerFreddyImage, Imports.cameraImage);
                    }
                    else
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyEastHallCornerImage, Imports.cameraImage);
                    }
                    break;

                case "Cam5":
                    if (bonnie.GetPosition() == 3)
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.BackstageBonnieImage, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.BackstageBonnieStareImage, Imports.cameraImage);
                        }
                    }
                    else
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyBackstageImage, Imports.cameraImage);
                    }
                    break;

                case "Cam6":
                    Engine_API._Renderer.PlayAnimation(Imports.KitchenImage, Imports.cameraImage);
                    Engine_API._Renderer.ShowImage(Imports.audioOnlyText);
                    break;

                case "Cam7":
                    if (chica.GetPosition() == 3)
                    {
                        if (secondImage == false)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.RestroomsChicaImage, Imports.cameraImage);
                        }
                        else
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.RestroomsChica2Image, Imports.cameraImage);
                        }
                    }
                    else if (freddy.GetPosition() == 3 && chica.GetPosition() != 3)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.RestroomsFreddyImage, Imports.cameraImage);
                    }
                    else
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.EmptyRestroomsImage, Imports.cameraImage);
                    }
                    break;
            }
        }

        private async void nightTimer_Tick(object sender, EventArgs e)
        {
            Imports.powerLeft.Text = battery.power.ToString() + "%";

            switch (hour)
            {
                case 0:
                    Imports.hourText.Text = "12";
                    break;
                case 1:
                    Imports.hourText.Text = "1";
                    break;
                case 2:
                    Imports.hourText.Text = "2";
                    break;
                case 3:
                    Imports.hourText.Text = "3";
                    break;
                case 4:
                    Imports.hourText.Text = "4";
                    break;
                case 5:
                    Imports.hourText.Text = "5";
                    break;
                case 6:
                    Imports.hourText.Text = "6";
                    break;
            }

            switch (night)
            {
                case 1:
                    Imports.nightText.Text = "1";
                    break;
                case 2:
                    Imports.nightText.Text = "2";
                    break;
                case 3:
                    Imports.nightText.Text = "3";
                    break;
                case 4:
                    Imports.nightText.Text = "4";
                    break;
                case 5:
                    Imports.nightText.Text = "5";
                    break;
                case 6:
                    Imports.nightText.Text = "6";
                    break;
            }

            time++;


            if (bonnie.GetPosition() == 7 && leftLightOn)
            {
                Engine_API._Renderer.PlayAnimation(Imports.hallwayBonnieImage, Imports.officeImage);
            }

            if (chica.GetPosition() == 7 && rightLightOn)
            {
                Engine_API._Renderer.PlayAnimation(Imports.hallwayChicaImage, Imports.officeImage);
            }

            if (battery.power <= 0)
            {
                OutOfPower();
            }

            if (hour == 0 && time == 90)
            {
                hour++;
                time = 0;

                #region Night 4 Freddy AI-logic
                UpdateRandomAI(0, 4, freddy);
                UpdateRandomAI(2, 4, freddy);
                UpdateRandomAI(3, 4, freddy);
                UpdateRandomAI(4, 4, freddy);
                #endregion
            }
            else if (hour > 0 && time == 89)
            {
                hour++;
                time = 0;

                #region Night 4 Freddy AI-logic
                UpdateRandomAI(0, 4, freddy);
                UpdateRandomAI(2, 4, freddy);
                UpdateRandomAI(3, 4, freddy);
                UpdateRandomAI(4, 4, freddy);
                #endregion
            }

            if (hour >= 6)
            {
                nightTimer.Stop();
                Engine_API._Renderer.NightFinished();
                await Task.Delay(TimeSpan.FromSeconds(3));
                time = 0;
                hour = 0;
                night++;
                ResetPositions();
                nightTimer.Start();
            }

            #region Night AI Logic
            #region Night 1 AI Logic
            if (night == 1)
            {
                //UpdateAI(0, 1, new int[] { 0, 20, 20, 20 }, freddy, bonnie, chica, foxy);
                //UpdateAI(2, 1, new int[] { 0, 20, 20, 20 }, freddy, bonnie, chica, foxy);
                //UpdateAI(3, 1, new int[] { 0, 20, 20, 20 }, freddy, bonnie, chica, foxy);
                //UpdateAI(4, 1, new int[] { 0, 20, 20, 20 }, freddy, bonnie, chica, foxy);

                UpdateAI(0, 1, new int[] { 0, 0, 0, 0 }, freddy, bonnie, chica, foxy);
                UpdateAI(2, 1, new int[] { 0, 1, 0, 0 }, freddy, bonnie, chica, foxy);
                UpdateAI(3, 1, new int[] { 0, 2, 1, 1 }, freddy, bonnie, chica, foxy);
                UpdateAI(4, 1, new int[] { 0, 3, 2, 2 }, freddy, bonnie, chica, foxy);
            }
            #endregion

            if (night == 1 && time % 6 == 0)
            {
                battery.power--;
            }

            #region Night 2 AI Logic
            if (night == 2)
            {
                UpdateAI(0, 2, new int[] { 0, 3, 1, 1 }, freddy, bonnie, chica, foxy);
                UpdateAI(3, 2, new int[] { 0, 4, 2, 2 }, freddy, bonnie, chica, foxy);
                UpdateAI(4, 2, new int[] { 0, 5, 3, 3 }, freddy, bonnie, chica, foxy);
            }
            #endregion

            if (night == 2 && time % 6 == 0)
            {
                battery.power--;
            }

            #region Night 3 AI Logic
            if (night == 3)
            {
                UpdateAI(0, 3, new int[] { 1, 0, 5, 2 }, freddy, bonnie, chica, foxy);
                UpdateAI(2, 3, new int[] { 1, 1, 5, 2 }, freddy, bonnie, chica, foxy);
                UpdateAI(3, 3, new int[] { 1, 2, 6, 3 }, freddy, bonnie, chica, foxy);
                UpdateAI(4, 3, new int[] { 1, 3, 7, 4 }, freddy, bonnie, chica, foxy);
            }
            #endregion

            if (night == 3 && time % 5 == 0)
            {
                battery.power--;
            }

            #region Night 4 AI Logic
            if (night == 4)
            {
                UpdateAI(0, 4, new int[] { 2, 4, 6 }, bonnie, chica, foxy);
                UpdateAI(2, 4, new int[] { 3, 4, 6 }, bonnie, chica, foxy);
                UpdateAI(3, 4, new int[] { 4, 5, 7 }, bonnie, chica, foxy);
                UpdateAI(4, 4, new int[] { 5, 6, 8 }, bonnie, chica, foxy);
            }
            #endregion


            if (night == 4 && time % 4 == 0)
            {
                battery.power--;
            }

            #region Night 5 AI Logic
            if (night == 5)
            {
                UpdateAI(0, 5, new int[] { 3, 5, 7, 5 }, freddy, bonnie, chica, foxy);
                UpdateAI(2, 5, new int[] { 3, 6, 7, 5 }, freddy, bonnie, chica, foxy);
                UpdateAI(3, 5, new int[] { 3, 7, 8, 6 }, freddy, bonnie, chica, foxy);
                UpdateAI(4, 5, new int[] { 3, 8, 9, 7 }, freddy, bonnie, chica, foxy);
            }
            #endregion

            if (night == 5 && time % 3 == 0)
            {
                battery.power--;
            }

            #region Night 6 AI Logic
            if (night == 6)
            {
                UpdateAI(0, 6, new int[] { 4, 10, 12, 16 }, freddy, bonnie, chica, foxy);
                UpdateAI(2, 6, new int[] { 4, 11, 12, 16 }, freddy, bonnie, chica, foxy);
                UpdateAI(3, 6, new int[] { 4, 12, 13, 17 }, freddy, bonnie, chica, foxy);
                UpdateAI(4, 6, new int[] { 4, 13, 14, 18 }, freddy, bonnie, chica, foxy);
            }
            #endregion
            #endregion

            if (rnd.Next(1000) == 0)
            {
                // It's me
            }

            if (rnd.Next(100000) == 0)
            {
                // Activate Golden Freddy
            }

            if (time % 3 == 0)
            {
                switch (freddy.GetPosition())
                {
                    case 1:
                        if (activeCamera != "Cam1A" || !tabletRaised)
                        {
                            freddy.Move();
                        }
                        break;
                    case 2:
                        if (activeCamera != "Cam1B" || !tabletRaised)
                        {
                            freddy.Move();
                        }
                        break;
                    case 3:
                        if (activeCamera != "Cam7" || !tabletRaised)
                        {
                            freddy.Move();
                        }
                        break;
                    case 4:
                        freddy.Move();
                        break;
                    case 5:
                        if (activeCamera != "Cam4A" || !tabletRaised)
                        {
                            freddy.Move();
                        }
                        break;
                    case 6:
                        if (activeCamera != "Cam4B" || (!tabletRaised && !rightDoorVisible))
                        {
                            freddy.Move();
                        }
                        break;
                    case 7:
                        if (!tabletRaised)
                        {
                            Engine_API._Renderer.PlayAnimation(Imports.freddyJumpscare, Imports.jumpscareImage, 20, false, false, false, true);
                            nightTimer.Stop();
                            cameraTimer.Stop();
                            blackoutTimer.Stop();
                        }
                        break;
                }
            }

            if (time % 5 == 0)
            {
                if (chica.GetPosition() == 7 && !rightDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.chicaJumpscare, Imports.jumpscareImage, 20, false, false, false, true);
                    nightTimer.Stop();
                    cameraTimer.Stop();
                    blackoutTimer.Stop();
                }

                if (bonnie.GetPosition() == 7 && !leftDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.bonnieJumpscare, Imports.jumpscareImage, 30, false, false, false, true);
                    nightTimer.Stop();
                    cameraTimer.Stop();
                    blackoutTimer.Stop();
                }

                if (rnd.Next(30) == 0)
                {
                    // Play pipe organ circus
                }

                switch (bonnie.GetPosition())
                {
                    case 1:
                        if (activeCamera != "Cam1A" || !tabletRaised)
                        {
                            bonnie.Move();
                        }
                        break;
                    case 2:
                        if (activeCamera != "Cam1B" || !tabletRaised)
                        {
                            bonnie.Move();
                        }
                        break;
                    case 3:
                        if (activeCamera != "Cam5" || !tabletRaised)
                        {
                            bonnie.Move();
                        }
                        break;
                    case 4:
                        if (activeCamera != "Cam2A" || !tabletRaised)
                        {
                            bonnie.Move();
                        }
                        break;
                    case 5:
                        if (activeCamera != "Cam3" || !tabletRaised)
                        {
                            bonnie.Move();
                        }
                        break;
                    case 6:
                        if (activeCamera != "Cam2B" || !tabletRaised)
                        {
                            bonnie.Move();
                        }
                        break;
                    case 7:
                        bonnie.Move();
                        break;
                }

                switch (chica.GetPosition())
                {
                    case 1:
                        if (activeCamera != "Cam1A" || !tabletRaised)
                        {
                            chica.Move();
                        }
                        break;
                    case 2:
                        if (activeCamera != "Cam1B" || !tabletRaised)
                        {
                            chica.Move();
                        }
                        break;
                    case 3:
                        if (activeCamera != "Cam7" || !tabletRaised)
                        {
                            chica.Move();
                        }
                        break;
                    case 4:
                        chica.Move();
                        break;
                    case 5:
                        if (activeCamera != "Cam4A" || !tabletRaised)
                        {
                            chica.Move();
                        }
                        break;
                    case 6:
                        if (activeCamera != "Cam4B" || !tabletRaised)
                        {
                            chica.Move();
                        }
                        break;
                    case 7:
                        chica.Move();
                        break;
                }
                if (!tabletRaised)
                {
                    foxy.Move();
                }
                if (foxy.GetPosition() == 5 && !leftDoorVisible)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.foxyJumpscare, Imports.jumpscareImage, 20, false, false, false, true);
                    nightTimer.Stop();
                    cameraTimer.Stop();
                    blackoutTimer.Stop();
                }
                else if (foxy.GetPosition() == 5 && leftDoorVisible)
                {
                    battery.power -= foxyPowerConsumption;
                    foxyPowerConsumption += 5;
                    foxy.ResetPosition();
                    foxyAnimationPlayed = false;
                }
            }
        }

        private void blackoutTimer_Tick(object sender, EventArgs e)
        {
            time++;
            if (time % 20 == 0 && !freddyVisible)
            {
                if (rnd.Next(5) == 0)
                {
                    freddyVisible = true;
                }
            }
            else if (time >= 80)
            {
                Engine_API._Renderer.PlayAnimation(Imports.hallwayFreddyImage, Imports.officeImage);
                freddyVisible = true;
            }

            if (freddyVisible)
            {
                if (rnd.Next(3)==0)
                {
                    Engine_API._Renderer.PlayAnimation(Imports.hallwayFreddyImage, Imports.officeImage);
                }
                else
                {
                    Engine_API._Renderer.PlayAnimation(Imports.officeBlackoutImage, Imports.officeImage);
                }

                if (time % 8 == 0)
                {
                    if (rnd.Next(5) == 0)
                    {
                        Engine_API._Renderer.PlayAnimation(Imports.blackoutFreddyJumpscare, Imports.jumpscareImage, 20, false, false, false, true);
                        blackoutTimer.Stop();
                    }
                }
            }
        }

        void OutOfPower()
        {
            nightTimer.Stop();
            time = 0;
            if (tabletRaised)
            {
                Engine_API._Renderer.CloseCamera();
            }
            Engine_API._Renderer.HideHUD();
            ResetPositions();
            Engine_API._Renderer.PlayAnimation(Imports.officeBlackoutImage, Imports.officeImage);
            OpenLeftDoor();
            leftDoorVisible = false;
            OpenRightDoor();
            rightDoorVisible = false;
            leftLightOn = false;
            rightLightOn = false;
            Imports.leftDoorBtn.IsEnabled = false;
            Imports.leftLightBtn.IsEnabled = false;
            Imports.rightDoorBtn.IsEnabled = false;
            Imports.rightLightBtn.IsEnabled = false;
            Engine_API._Renderer.PlayAnimation(Imports.leftButtonOffImage, Imports.leftDoorButtonImage);
            Engine_API._Renderer.PlayAnimation(Imports.rightButtonOffImage, Imports.rightDoorButtonImage);
            
            blackoutTimer.Start();
        }

        void UpdateAI(int currentHour, int currentNight, int[] levels, params Animatronic[] animatronics)
        {
            if (hour == currentHour && night == currentNight)
            {
                for (int i = 0; i < animatronics.Length; i++)
                {
                    animatronics[i].ChangeLevel(levels[i]);
                }
            }
        }

        void UpdateRandomAI(int currentHour, int currentNight, Animatronic animatronic)
        {
            if (hour == currentHour && night == currentNight)
            {
                Random rnd = new Random();
                int rndNum = rnd.Next(2);

                animatronic.ChangeLevel(rndNum);
            }
        }

        public void ImageChanged()
        {
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
        }

        void ResetPositions()
        {
            freddy.ResetPosition();
            bonnie.ResetPosition();
            chica.ResetPosition();
            foxy.ResetPosition();
        }

        #region Cameras
        public void Cam1A()
        {
            activeCamera = "Cam1A";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam1B()
        {
            activeCamera = "Cam1B";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam1C()
        {
            activeCamera = "Cam1C";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam2A()
        {
            activeCamera = "Cam2A";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam2B()
        {
            activeCamera = "Cam2B";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam3()
        {
            activeCamera = "Cam3";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam4A()
        {
            activeCamera = "Cam4A";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam4B()
        {
            activeCamera = "Cam4B";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }
        public void Cam5()
        {
            activeCamera = "Cam5";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam6()
        {
            activeCamera = "Cam6";
            Engine_API._Renderer.ShowImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }

        public void Cam7()
        {
            activeCamera = "Cam7";
            secondImage = rnd.Next(2) == 0 ? false : true;
            Engine_API._Renderer.HideImage(Imports.audioOnlyText);
            Engine_API._Renderer.PlayAnimation(Imports.glitchImages, Imports.glitchImage, 18, false, false, true);
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.blipAudio);
        }
        #endregion
    }
}
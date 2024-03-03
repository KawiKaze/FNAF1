using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using NAudio.Wave;
using System.IO;
using FNAF.Game_Engine;
using FNAF.Game.Animatronics;
using FNAF.Game;
using FNAF;
using System.Threading;

namespace FNAF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void AssignImagesToImport()
        {
            Imports.officeImage = officeImage;
            Imports.leftDoorImage = leftDoorImage;
            Imports.rightDoorImage = rightDoorImage;
            Imports.tabletImage = tabletImage;
            Imports.cameraImage = cameraImage;
            Imports.batteryCells = batteryCells;
            Imports.cameraBorder = cameraBorder;
            Imports.cameraMap = cameraMap;
            Imports.cameraButtons = cameraButtons;
            Imports.muteCall = muteCall;
            Imports.recordingIcon = recordingIcon;
            Imports.tabletBar = tabletBar;
            Imports.noiseImage = noiseImage;
            Imports.leftDoorButtonImage = leftDoorButtonImage;
            Imports.rightDoorButtonImage = rightDoorButtonImage;
            Imports.jumpscareImage = jumpscareImage;
            Imports.glitchImage = glitchImage;
            Imports.powerLeft = powerLeft;
            Imports.nightText = nightText;
            Imports.hourText = hourText;
            Imports.leftLightBtn = leftLightBtn;
            Imports.leftDoorBtn = leftDoorBtn;
            Imports.rightLightBtn = rightLightBtn;
            Imports.rightDoorBtn = rightDoorBtn;
            Imports.audioOnlyText = audioOnlyText;
            Imports.usageText = usageText;
            Imports.powerLeftText = powerLeftText;
            Imports.nightNameText = nightNameText;
            Imports.amText = amText;
            Imports.clock = clock;
            Imports.storyboardFive = (System.Windows.Media.Animation.Storyboard)FindResource("storyboardFive");
            Imports.storyboardSix = (System.Windows.Media.Animation.Storyboard)FindResource("storyboardSix");
            Imports.six = six;
        }

        SoundInitializer soundInitializer = new SoundInitializer();
        GameController fnaf;

        public MainWindow()
        {
            InitializeComponent();

            fnaf = new GameController();

            AssignImagesToImport();

            cameraImage.TargetUpdated += CameraImage_TargetUpdated;
        }

        private void CameraImage_TargetUpdated(object? sender, DataTransferEventArgs e)
        {
            fnaf.ImageChanged();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is the ESC key (Key.Escape)
            if (e.Key == Key.Escape)
            {
                // Close the MainWindow (the game)
                fnaf.CloseGame();
            }
        }
        #region Cam Buttons
        private void Cam_1A_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam1A();
        }
        private void Cam_1B_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam1B();
        }
        private void Cam_5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam5();
        }
        private void Cam_1C_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam1C();
        }
        private void Cam_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam3();
        }
        private void Cam_2A_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam2A();
        }
        private void Cam_2B_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam2B();
        }
        private void Cam_4A_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam4A();
        }
        private void Cam_4B_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam4B();
        }
        private void Cam_6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam6();
        }
        private void Cam_7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fnaf.Cam7();
        }
        #endregion
        private void leftLightBtn_Click(object sender, RoutedEventArgs e)
        {
            fnaf.LeftDoorLightButtonClick();
        }
        private void rightLightBtn_Click(object sender, RoutedEventArgs e)
        {
            fnaf.RightDoorLightButtonClick();
        }
        private void leftDoorBtn_Click(object sender, RoutedEventArgs e)
        {
            fnaf.LeftDoorButtonClick();
        }
        private void rightDoorBtn_Click(object sender, RoutedEventArgs e)
        {
            fnaf.RightDoorButtonClick();
        }
        private void tabletBar_MouseEnter(object sender, MouseEventArgs e)
        {
            fnaf.TabletBarMouseEnter();
        }
        private void muteCall_MouseLeftButtonDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            fnaf.CloseCall();
        }
    }
}
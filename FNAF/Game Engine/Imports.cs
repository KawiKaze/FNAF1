using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FNAF.Game_Engine
{
    public static class Imports
    {
        #region Backgrounds
        // Office
        public static BitmapImage officeEmptyImage = new BitmapImage(new Uri("/Images/Backgrounds/Office Backgrounds/OfficeEmpty.jpg", UriKind.Relative));
        public static BitmapImage officeLeftLightImage = new BitmapImage(new Uri("/Images/Backgrounds/Office Backgrounds/OfficeLeftLight.jpg", UriKind.Relative));
        public static BitmapImage officeRightLightImage = new BitmapImage(new Uri("/Images/Backgrounds/Office Backgrounds/OfficeRightLight.jpg", UriKind.Relative));
        public static BitmapImage officeBlackoutImage = new BitmapImage(new Uri("/Images/Backgrounds/Office Backgrounds/OfficeBlackout.jpg", UriKind.Relative));
        public static BitmapImage officeNoPowerImage = new BitmapImage(new Uri("/Images/Backgrounds/Office Backgrounds/OfficeNoPower.jpg", UriKind.Relative));

        // Hallway
        public static BitmapImage hallwayFreddyImage = new BitmapImage(new Uri("/Images/Backgrounds/Office Backgrounds/Hallway/freddy.png", UriKind.Relative));
        public static BitmapImage hallwayBonnieImage = new BitmapImage(new Uri("/Images/Backgrounds/Office Backgrounds/Hallway/bonnie.png", UriKind.Relative));
        public static BitmapImage hallwayChicaImage = new BitmapImage(new Uri("/Images/Backgrounds/Office Backgrounds/Hallway/chica.png", UriKind.Relative));

        // Cam 1A
        public static BitmapImage fullStageImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1A/FullStage.png", UriKind.Relative));
        public static BitmapImage stageNoBonnieImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1A/StageNoBonnie.png", UriKind.Relative));
        public static BitmapImage stageNoChicaImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1A/StageNoChica.png", UriKind.Relative));
        public static BitmapImage stageFreddyOnlyImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1A/StageFreddyOnly.png", UriKind.Relative));
        public static BitmapImage stageAllStaringImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1A/stageAllStaring.png", UriKind.Relative));
        public static BitmapImage stageFreddyStaringImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1A/StageFreddyStaring.png", UriKind.Relative));
        public static BitmapImage emptyStageImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1A/EmptyStage.png", UriKind.Relative));

        // CAM 1B
        public static BitmapImage EmptyDinerImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1B/EmptyDiner.png", UriKind.Relative));
        public static BitmapImage DinerBonnieImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1B/DinerBonnie.png", UriKind.Relative));
        public static BitmapImage DinerFreddyImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1B/DinerFreddy.png", UriKind.Relative));
        public static BitmapImage DinerChicaImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1B/DinerChica.png", UriKind.Relative));
        public static BitmapImage DinerBlackBonnieImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1B/DinerBlackBonnie.png", UriKind.Relative));
        public static BitmapImage DinerBlackChicaImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1B/DinerBlackChica.png", UriKind.Relative));

        // CAM 1C
        public static BitmapImage EmptyPirateCoveImage = new BitmapImage(new Uri("/Images/Scenes/CAM 1C/EmptyPirateCove.png", UriKind.Relative));
        public static BitmapImage PirateCove1Image = new BitmapImage(new Uri("/Images/Scenes/CAM 1C/PirateCove1.png", UriKind.Relative));
        public static BitmapImage PirateCove2Image = new BitmapImage(new Uri("/Images/Scenes/CAM 1C/PirateCove2.png", UriKind.Relative));
        public static BitmapImage PirateCove3Image = new BitmapImage(new Uri("/Images/Scenes/CAM 1C/PirateCove3.png", UriKind.Relative));

        // CAM 2A
        public static BitmapImage EmptyWestHallImage = new BitmapImage(new Uri("/Images/Scenes/CAM 2A/EmptyWestHall.png", UriKind.Relative));
        public static BitmapImage WestHallBonnieImage = new BitmapImage(new Uri("/Images/Scenes/CAM 2A/WestHallBonnie.png", UriKind.Relative));
        public static List<BitmapImage> foxyRunning = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/10.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/11.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/12.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/13.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/14.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/15.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/16.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/17.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/18.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/19.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/20.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/21.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/22.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/23.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/24.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/25.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/26.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/27.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/28.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/29.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/30.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Scenes/CAM 2A/Foxy Run/31.png", UriKind.Relative))
        };

        // CAM 2B
        public static BitmapImage EmptyWHallCornerImage = new BitmapImage(new Uri("/Images/Scenes/CAM 2B/EmptyWHallCorner.png", UriKind.Relative));
        public static BitmapImage WHallCornerBonnieImage = new BitmapImage(new Uri("/Images/Scenes/CAM 2B/WHallCornerBonnie.png", UriKind.Relative));
        public static BitmapImage WHallCornerBonnieStareImage = new BitmapImage(new Uri("/Images/Scenes/CAM 2B/WHallCornerBonnieStare.png", UriKind.Relative));
        public static BitmapImage WHallCornerGoldenFreddyImage = new BitmapImage(new Uri("/Images/Scenes/CAM 2B/WHallCornerGoldenFreddy.png", UriKind.Relative));

        // CAM 3
        public static BitmapImage EmptyClosetImage = new BitmapImage(new Uri("/Images/Scenes/CAM 3/EmptyCloset.png", UriKind.Relative));
        public static BitmapImage ClosetBonnieImage = new BitmapImage(new Uri("/Images/Scenes/CAM 3/ClosetBonnie.png", UriKind.Relative));

        // CAM 4A
        public static BitmapImage EmptyEastHallImage = new BitmapImage(new Uri("/Images/Scenes/CAM 4A/EmptyEastHall.png", UriKind.Relative));
        public static BitmapImage EastHallChica1Image = new BitmapImage(new Uri("/Images/Scenes/CAM 4A/EastHallChica1.png", UriKind.Relative));
        public static BitmapImage EastHallChica2Image = new BitmapImage(new Uri("/Images/Scenes/CAM 4A/EastHallChica2.png", UriKind.Relative));
        public static BitmapImage EastHallFreddyImage = new BitmapImage(new Uri("/Images/Scenes/CAM 4A/EastHallFreddy.png", UriKind.Relative));
        public static BitmapImage EastHallGoldenFreddyImage = new BitmapImage(new Uri("/Images/Scenes/CAM 4A/EastHallGoldenFreddy.png", UriKind.Relative));

        // CAM 4B
        public static BitmapImage EmptyEastHallCornerImage = new BitmapImage(new Uri("/Images/Scenes/CAM 4B/EmptyEastHallCorner.png", UriKind.Relative));
        public static BitmapImage EastHallCornerChicaImage = new BitmapImage(new Uri("/Images/Scenes/CAM 4B/EastHallCornerChica.png", UriKind.Relative));
        public static BitmapImage EastHallCornerChicaStareImage = new BitmapImage(new Uri("/Images/Scenes/CAM 4B/EastHallCornerChicaStare.png", UriKind.Relative));
        public static BitmapImage EastHallCornerFreddyImage = new BitmapImage(new Uri("/Images/Scenes/CAM 4B/EastHallCornerFreddy.png", UriKind.Relative));

        // CAM 5
        public static BitmapImage EmptyBackstageImage = new BitmapImage(new Uri("/Images/Scenes/CAM 5/EmptyBackstage.png", UriKind.Relative));
        public static BitmapImage BackstageBonnieImage = new BitmapImage(new Uri("/Images/Scenes/CAM 5/BackstageBonnie.png", UriKind.Relative));
        public static BitmapImage BackstageBonnieStareImage = new BitmapImage(new Uri("/Images/Scenes/CAM 5/BackstageBonnieStare.png", UriKind.Relative));
        public static BitmapImage BackstageFreddyImage = new BitmapImage(new Uri("/Images/Scenes/CAM 5/BackstageFreddy.png", UriKind.Relative));
        public static BitmapImage BackstageEndoImage = new BitmapImage(new Uri("/Images/Scenes/CAM 5/BackstageEndo.png", UriKind.Relative));

        // CAM 6
        public static BitmapImage KitchenImage = new BitmapImage(new Uri("/Images/Scenes/CAM 6/1.png", UriKind.Relative));

        // CAM 7
        public static BitmapImage EmptyRestroomsImage = new BitmapImage(new Uri("/Images/Scenes/CAM 7/EmptyRestrooms.png", UriKind.Relative));
        public static BitmapImage RestroomsChicaImage = new BitmapImage(new Uri("/Images/Scenes/CAM 7/RestroomsChica.png", UriKind.Relative));
        public static BitmapImage RestroomsChica2Image = new BitmapImage(new Uri("/Images/Scenes/CAM 7/RestroomsChica2.png", UriKind.Relative));
        public static BitmapImage RestroomsFreddyImage = new BitmapImage(new Uri("/Images/Scenes/CAM 7/RestroomsFreddy.png", UriKind.Relative));
        #endregion

        #region Jumpscares
        public static List<BitmapImage> blackoutFreddyJumpscare = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/10.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/11.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/12.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/13.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/14.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/15.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/16.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/17.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/18.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/19.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/20.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/Blackout/21.png", UriKind.Relative))
        };
        public static List<BitmapImage> freddyJumpscare = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/10.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/11.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/12.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/13.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/14.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/15.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/16.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/17.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/18.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/19.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/20.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/21.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/22.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/23.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/24.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/25.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/26.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/27.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Freddy/28.png", UriKind.Relative))
        };
        public static List<BitmapImage> bonnieJumpscare = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/10.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Bonnie/11.png", UriKind.Relative))
        };
        public static List<BitmapImage> chicaJumpscare = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/10.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/11.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/12.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/13.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/14.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/15.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Chica/16.png", UriKind.Relative))
        };
        public static List<BitmapImage> foxyJumpscare = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/10.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/11.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/12.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/13.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/14.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/15.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/16.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/17.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/18.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/19.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/20.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Jumpscares/Foxy/21.png", UriKind.Relative))
        };
        public static BitmapImage goldenfreddyJumpscare = new BitmapImage(new Uri("Images/Jumpscares/Golden Freddy/1.png", UriKind.Relative));
        #endregion

        #region Glitch
        public static List<BitmapImage> glitchImages = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Glitches/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Glitches/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Glitches/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Glitches/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Glitches/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Glitches/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Glitches/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Glitches/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Glitches/9.png", UriKind.Relative))
        };
        #endregion

        #region Buttons
        // Left
        public static BitmapImage leftButtonOffImage = new BitmapImage(new Uri("/Images/Doors/Buttons/Left/Off.png", UriKind.Relative));
        public static BitmapImage leftButtonLightOnImage = new BitmapImage(new Uri("/Images/Doors/Buttons/Left/LightOn.png", UriKind.Relative));
        public static BitmapImage leftButtonDoorOnImage = new BitmapImage(new Uri("/Images/Doors/Buttons/Left/DoorOn.png", UriKind.Relative));
        public static BitmapImage leftButtonAllOnImage = new BitmapImage(new Uri("/Images/Doors/Buttons/Left/AllOn.png", UriKind.Relative));

        // Right
        public static BitmapImage rightButtonOffImage = new BitmapImage(new Uri("/Images/Doors/Buttons/Right/Off.png", UriKind.Relative));
        public static BitmapImage rightButtonLightOnImage = new BitmapImage(new Uri("/Images/Doors/Buttons/Right/LightOn.png", UriKind.Relative));
        public static BitmapImage rightButtonDoorOnImage = new BitmapImage(new Uri("/Images/Doors/Buttons/Right/DoorOn.png", UriKind.Relative));
        public static BitmapImage rightButtonAllOnImage = new BitmapImage(new Uri("/Images/Doors/Buttons/Right/AllOn.png", UriKind.Relative));
        #endregion

        #region Doors
        public static List<BitmapImage> leftDoor = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Doors/Left/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/10.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/11.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/12.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/13.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/14.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Left/15.png", UriKind.Relative))
        };
        public static List<BitmapImage> rightDoor = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Doors/Right/1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/10.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/11.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/12.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/13.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/14.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Doors/Right/15.png", UriKind.Relative)),
        };
        #endregion

        #region Controls
        public static System.Windows.Controls.Image officeImage;
        public static System.Windows.Controls.Image leftDoorImage;
        public static System.Windows.Controls.Image rightDoorImage;
        public static System.Windows.Controls.Image tabletImage;
        public static System.Windows.Controls.Image cameraImage;
        public static System.Windows.Controls.Image noiseImage;
        public static System.Windows.Controls.Image batteryCells;
        public static System.Windows.Controls.Image cameraBorder;
        public static System.Windows.Controls.Image cameraMap;
        public static System.Windows.Controls.Grid cameraButtons;
        public static System.Windows.Controls.Grid audioOnlyText;
        public static System.Windows.Controls.Image muteCall;
        public static System.Windows.Controls.Image recordingIcon;
        public static System.Windows.Controls.Image tabletBar;
        public static System.Windows.Controls.Image leftDoorButtonImage;
        public static System.Windows.Controls.Image rightDoorButtonImage;
        public static System.Windows.Controls.Image jumpscareImage;
        public static System.Windows.Controls.Image glitchImage;
        public static System.Windows.Controls.TextBlock powerLeft;
        public static System.Windows.Controls.TextBlock nightText;
        public static System.Windows.Controls.TextBlock hourText;
        public static System.Windows.Controls.Button leftLightBtn;
        public static System.Windows.Controls.Button leftDoorBtn;
        public static System.Windows.Controls.Button rightLightBtn;
        public static System.Windows.Controls.Button rightDoorBtn;
        public static System.Windows.Controls.TextBlock usageText;
        public static System.Windows.Controls.TextBlock powerLeftText;
        public static System.Windows.Controls.TextBlock nightNameText;
        public static System.Windows.Controls.TextBlock amText;
        public static System.Windows.Controls.Grid clock;
        public static System.Windows.Media.Animation.Storyboard storyboardFive;
        public static System.Windows.Media.Animation.Storyboard storyboardSix;
        public static System.Windows.Controls.Image six;
        #endregion

        // List to store tablet animation images and an index to keep track of the current image
        public static List<BitmapImage> tabletAnimation = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Tablet/tablet1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet8.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet9.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Tablet/tablet10.png", UriKind.Relative))
        };

        public static List<BitmapImage> batteryImages = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/HUD/battery1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/HUD/battery2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/HUD/battery3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/HUD/battery4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/HUD/battery5.png", UriKind.Relative))
        };

        public static List<BitmapImage> noiseImages = new List<BitmapImage>()
        {
            new BitmapImage(new Uri("/Images/Noise/Noise1.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Noise/Noise2.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Noise/Noise3.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Noise/Noise4.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Noise/Noise5.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Noise/Noise6.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Noise/Noise7.png", UriKind.Relative)),
            new BitmapImage(new Uri("/Images/Noise/Noise8.png", UriKind.Relative))
        };
    }
}

using FNAF.Game_Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAF.Game
{
    internal class HallwayController
    {
        bool LightOn;
        bool LeftDoor;

        public HallwayController(int doorType)
        {
            if (doorType == 0)
            {
                LeftDoor = true;
            }
            else
            {
                LeftDoor = false;
            }
        }

        public void OpenDoor()
        {
            if (LeftDoor)
            {
                Engine_API._Renderer.PlayAnimation(Imports.leftDoor, Imports.leftDoorImage, 10, false, true);
            }
            else
            {
                Engine_API._Renderer.PlayAnimation(Imports.rightDoor, Imports.rightDoorImage, 10, false, true);
            }
        }

        public void CloseDoor()
        {
            if (LeftDoor)
            {
                Engine_API._Renderer.PlayAnimation(Imports.leftDoor, Imports.leftDoorImage, 10, false, false);
            }
            else
            {
                Engine_API._Renderer.PlayAnimation(Imports.rightDoor, Imports.rightDoorImage, 10, false, false);
            }
            Engine_API._SoundPlayer.PlaySound(SoundInitializer.audioNames.doorClosingAudio);
        }
    }
}

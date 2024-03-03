using FNAF.Game_Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAF.Game
{
    internal class Battery
    {
        public int batteryActivity = 1;
        public int power = 99;

        public void RaiseBatteryActivity()
        {
            batteryActivity++;
            Engine_API._Renderer.PlayAnimation(Imports.batteryImages[batteryActivity-1], Imports.batteryCells);
        }

        public void LowerBatteryActivity()
        {
            batteryActivity--;
            Engine_API._Renderer.PlayAnimation(Imports.batteryImages[batteryActivity-1], Imports.batteryCells);
        }
    }
}

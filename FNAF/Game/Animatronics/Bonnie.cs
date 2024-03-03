using FNAF.Game_Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAF.Game.Animatronics
{
    internal class Bonnie : Animatronic
    {
        public Bonnie(int _Level)
        {
            Level = _Level;
        }

        public Bonnie()
        {
            
        }

        public void Move()
        {
            if (AllowedToMove())
            {
                OnPositionChanged();
                switch (Position)
                {
                    case 1: // Move to position 2 or 3
                        Position = (rnd.Next(2) == 0) ? 2 : 3;
                        break;
                    case 2: // Move to position 3 or 4
                        Position = (rnd.Next(2) == 0) ? 3 : 4;
                        break;
                    case 3: // Move to position 2 or 4
                        Position = (rnd.Next(2) == 0) ? 2 : 4;
                        break;
                    case 4: // Move to position 5 or 6
                        Position = (rnd.Next(2) == 0) ? 5 : 6;
                        break;
                    case 5: // Move to position 4 or 7
                        Position = (rnd.Next(2) == 0) ? 4 : 7;
                        break;
                    case 6: // Move to position 5 or 7
                        Position = (rnd.Next(2) == 0) ? 5 : 7;
                        break;
                    case 7:

                        break;
                    default:
                        // Handle unexpected position
                        break;
                }
            }
        }

        protected override bool AllowedToMove()
        {
            int rndNum = rnd.Next(1, 21);
            if (rndNum <= Level)
            {
                return true;
            }
            return false;
        }
    }
}

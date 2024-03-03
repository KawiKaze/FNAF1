using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAF.Game.Animatronics
{
    internal class Chica : Animatronic
    {
        public Chica(int _Level)
        {
            Level = _Level;
        }
        public Chica()
        {
            
        }

        public void Move()
        {
            if (AllowedToMove())
            {
                OnPositionChanged();
                switch (Position)
                {
                    case 1:
                        Position++;
                        break;
                    case 2:
                        Position = (rnd.Next(2) == 0) ? 3 : 4;
                        break;
                    case 3:
                        Position = (rnd.Next(2) == 0) ? 4 : 5;
                        break;
                    case 4:
                        Position = (rnd.Next(2) == 0) ? 3 : 5;
                        break;
                    case 5:
                        Position = (rnd.Next(2) == 0) ? 2 : 6;
                        break;
                    case 6:
                        Position = (rnd.Next(2) == 0) ? 5 : 7;
                        break;
                    case 7:
                        if (rnd.Next(2) == 0)
                        {
                            Position = 6;
                        }
                        else if (false) // Door is open
                        {
                            // Kill
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

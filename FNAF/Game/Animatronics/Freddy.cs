using FNAF.Game_Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAF.Game.Animatronics
{
    internal class Freddy : Animatronic
    {
        public Freddy(int _Level)
        {
            Level = _Level;
        }

        public Freddy()
        {
            
        }

        public void Move()
        {
            if (AllowedToMove())
            {
                OnPositionChanged();
                Position++;
            }
        }

        protected override bool AllowedToMove()
        {
            int rndNum = rnd.Next(1, 20);
            if (rndNum <= Level)
            {
                return true;
            }
            return false;
        }
    }
}

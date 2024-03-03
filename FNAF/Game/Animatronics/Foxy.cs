using FNAF.Game_Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace FNAF.Game.Animatronics
{
    internal class Foxy : Animatronic
    {
        private DispatcherTimer timer;
        private Random rnd = new Random();

        public Foxy(int _Level)
        {
            Level = _Level;
            timer = new();
            timer.Interval = TimeSpan.FromSeconds(0.5);
        }

        public void Move()
        {
            if (AllowedToMove())
            {
                OnPositionChanged();
                Position++;
            }
        }
    }
}

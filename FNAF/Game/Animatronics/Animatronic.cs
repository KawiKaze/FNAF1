using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAF.Game.Animatronics
{
    abstract class Animatronic
    {
        protected Random rnd;
        protected int Position;
        protected int Level;
        public event Action PositionChanged;

        public Animatronic()
        {
            rnd = new Random();
            Position = 1;
            Level = 0;
        }

        virtual protected bool AllowedToMove()
        {
            int rndNum = rnd.Next(1, 21);
            return rndNum <= Level;
        }

        public void ChangeLevel(int level)
        {
            Level = level;
        }

        public void ResetPosition()
        {
            Position = 1;
        }

        public int GetPosition()
        {
            return Position;
        }

        protected virtual void OnPositionChanged()
        {
            PositionChanged?.Invoke();
        }
    }
}

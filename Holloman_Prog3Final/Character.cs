using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holloman_Prog3Final
{
    abstract class Character : Action
    {
        protected Character(string name, string race)
        {
            MakeMove();
        }

        public void MakeMove()
        { }

        public bool diceRoll()
        {
            int roll = 0;
            bool check = false;

            Random rnd = new Random();
            for (int i = 0; i < 1; i++)
            {
                roll = rnd.Next(1, 21);
            }
            if (roll >= 0 && roll <= 5)
            {
                return check;
            } 
            else if (roll >= 6 && roll <= 10)
            {
                return check = true;
            }
            return check;
        }
    }
}

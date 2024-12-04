using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holloman_Prog3Final
{
    abstract class NonPlayable : Character
    {
        public NonPlayable(int health, string name, string race) : base(name, race)
        {
            HealthPool();
            MakeMove();
        }
        public void HealthPool()
        {

        }

        public void MakeMove()
        {

        }
    }    
}

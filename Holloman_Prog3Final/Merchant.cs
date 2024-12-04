using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holloman_Prog3Final
{
    public class Merchant : Character
    {
        private int _discount = 0;
        private int _trust = 0 ;
        private int _reputation;
        

        private string _name;
        private string _race;


        public Merchant(int trust, int rep, int gold, string name, string race)
        {
            _name = name;
            _race = race;
        }

        #region ** property methods **
        public int Reputation
        {
            get { return _reputation; }
            set { _reputation = value; }
        }

        public int Trust
        {
            get { return _trust; }
            set { _trust = value; }
        }

        public int Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        #endregion

        #region ** engine methods **
        public void makeTrade(int trust, int rep)
        {
            xpCount(trust);

            if (trust > 0 && trust < 10)
            {
                if (rep <= 1 || rep == 0)
                {
                    if (trust == 1)
                    {
                        rep = trust;
                        Reputation = rep;
                    }
                }
                else if (rep >= 2)
                {
                    if (trust == 10)
                    {
                        LevelUp(rep);
                        trust = 0;
                        Reputation = rep;
                        Trust = trust;
                    }
                }
            }
        }

        private void LevelUp(int rep)
        {
            rep++;
            Reputation = rep;
        }

        private void doBuisness()
        {
            int discount = 0;
            int trust = Trust;
            int rep = Reputation;


            Random rnd = new Random();
            for (int i = 0; i < 1; i++)
            {
                bool trade = diceRoll();

                if (trade == true)
                {
                    if (rep >= 1 && rep <= 4)
                    {
                        Discount = discount;
                        makeTrade(trust, rep);
                    }
                    else if (rep >= 5 && rep <= 8)
                    {
                        discount = discount + 10;
                        Discount = discount;
                        makeTrade(trust, rep);
                    }
                    else if (rep >= 9 && rep <= 10)
                    {
                        discount = discount + 25;
                        Discount = discount;
                        makeTrade(trust, rep);
                    }
                }
            }
        }

        protected int xpCount(int xpValue)
        {
            int count = 0;

            count++;
            Trust = count;
            return count;
        }

        protected bool diceRoll()
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
        #endregion

        #region ** action methods **
        public void MakeBarter()
        {
            doBuisness();
        }
        #endregion
    }
}

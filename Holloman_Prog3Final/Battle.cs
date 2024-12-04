using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Holloman_Prog3Final
{
    public class Battle : Character
    {
        private int _health;
        private int _threatcheck;
        private int _xp;
        private int _level;
        private int _count;

        private int _damage;

        private string _name;
        private string _race;

        public Battle(int lvl, int opponentHp, int gold, string name, string race)
        {
            int kc = 0;
            int health = 0;

            _name = name;
            _race = race;

            opponentHp = Danger(opponentHp);
            kc = xpCount(opponentHp);
            ExpCalculator(kc, lvl);
            health = HealthPool(lvl);
            Collections(kc, health);
        }

        #region ** property methods **                
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Level
        {
            get { return _level; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Race
        {
            get { return _race; }
        }
        #endregion

        #region ** engine methods **
        public void ExpCalculator(int kc, int lvl)
        {

            if (kc > 0 && kc < 10)
            {
                if (lvl <= 1 || lvl == 0)
                {
                    if (kc == 1)
                    {
                        lvl = kc;
                        _level = lvl;
                    }
                }
                else if (lvl >= 2)
                {
                    if (kc == 10)
                    {
                        LevelUp(lvl);
                        kc = 0;
                        _count = 0;
                        _level = lvl;
                    }
                }
            } 
        }

        private void LevelUp(int lvl)
        {
            lvl++;
            _level = lvl;
        }

        private int DamageBuilder(int lvl, int opponentHp, int dmg)
        {

            Random rnd = new Random();
            for (int i = 0; i < 1; i++)
            {
                bool roll = diceRoll();

                if (roll == true)
                {
                    if (lvl >= 0 && lvl <= 4)
                    {
                        dmg = rnd.Next(1, opponentHp - 5);
                        _damage = dmg;
                        return dmg;
                    }
                    else if (lvl >= 5 && lvl <= 8)
                    {
                        dmg = rnd.Next(1, opponentHp - 3);
                        _damage = dmg;
                        return dmg;
                    }
                    else
                    {
                        dmg = rnd.Next(1, opponentHp - 1);
                        _damage = dmg;
                        return dmg;
                    }
                }
                return dmg;
            }
            return dmg;
        }

        private int Danger(int opponentHp)
        {
            int xpValue = opponentHp;
            _threatcheck = opponentHp;
            return xpValue;
        }

        private void Collections(int xpValue, int health)
        {
            _health = health;
            _count = xpValue;
        }

        public int HealthPool(int lvl)
        {
            int hp = 0;
            if (lvl <= 1 || lvl == 0)
            {
                return hp = 10;
            }
            else if (lvl >= 2)
            {
                return hp = hp + 2;
            }
            return hp;
        }

        protected int xpCount(int xpValue)
        {
            int count = 0;

            if (xpValue == 0)
            {
                count++; ;
                return count;
            }
            return count;
        }

        protected bool diceRoll()
        {
            int roll = 0;
            bool check = false;

            Random rnd = new Random();
            for (int i = 0; i < 1; i++)
            {
                roll = rnd.Next(1, 11);
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
        public void MakeAttack()
        {
            int dmg = 0;
            int lvl = _level;
            int opponentHp = _threatcheck;

            dmg = DamageBuilder(lvl, opponentHp, dmg);
            if (opponentHp > 0)
            {
                opponentHp = opponentHp - dmg;

                if (opponentHp < 0)
                {
                    opponentHp = 0;
                    _threatcheck = opponentHp;

                }
                _threatcheck = opponentHp;

            }
        }
        #endregion
    }
}

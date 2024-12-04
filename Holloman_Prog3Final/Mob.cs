using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holloman_Prog3Final
{
    abstract class Mob : NonPlayable
    {
        private int _health;
        private int _threatcheck;
        private int _xp;
        private int _level;
        private int _kc;

        private string _name;
        private string _race;


        protected Mob(int lvl, int playerHp, string name, string race) : base (playerHp, name, race)
        {
            int kc = 0;
            int health = 0;


            kc = KillCount(playerHp);
            ExpCalculator(kc, lvl);
            HealthPool(lvl);
        }

        private int KillCount(int playerHp)
        {
            int kc = 0;

            if (playerHp == 0)
            {
                kc++;
            }
            return kc;
        }


        private void ExpCalculator(int kc, int lvl)
        {

            if (kc > 0 && kc < 10)
            {
                if (lvl <= 1 || lvl == 0)
                {
                    if (kc == 1)
                    {
                        lvl = kc;
                        _level = lvl;
                        _xp = kc;
                    }
                }
                else if (lvl >= 2)
                {
                    _xp = kc;

                    if (kc == 10)
                    {
                        LevelUp(lvl);
                        kc = 0;
                        _kc = kc;
                    }
                }
            }
        }

        private void HealthPool(int lvl)
        {
            int hp = 0;
            if (lvl <= 1 || lvl == 0)
            {
                hp = 10;
            }
            else if (lvl >= 2)
            {
                hp = hp + 2;
            }
            _health = hp;
        }

        private void LevelUp(int lvl)
        {
            lvl++;
            _level = lvl;
        }

        private int DamageBuilder(int lvl, int playerHp, int dmg)
        {
            
            Random rnd = new Random();
            for (int i = 0; i < 1; i++)
            {
                bool roll = diceRoll();

                if (roll == true)
                {
                    if (lvl >= 1 && lvl <= 4)
                    {
                        return dmg = rnd.Next(1, playerHp - 5);
                    }
                    else if (lvl >= 5 && lvl <= 8)
                    {
                        return dmg = rnd.Next(1, playerHp - 3);
                    }
                    else
                    {
                        return dmg = rnd.Next(1, playerHp - 1);
                    }
                }
                return dmg;
            }
            return dmg;
        }


        public void MakeAttack(int lvl, int playerHp)
        {
            int dmg = 0;

            dmg = DamageBuilder(lvl, playerHp, dmg);
            if (playerHp > 0)
            {
                playerHp = playerHp - dmg;
                if (playerHp < 0)
                {
                    _threatcheck = playerHp;

                }
                _threatcheck = playerHp;
            }
        }

        private int Danger(int playerHp)
        {
            _threatcheck = playerHp;
            return playerHp = _threatcheck;
        }
    }
}

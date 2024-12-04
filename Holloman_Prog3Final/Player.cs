using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Holloman_Prog3Final
{
    abstract class Player : Character
    {
        private int _health;
        private int _threatcheck;
        private int _xp;
        private int _level;
        private int _kc;

        private string _name;
        private string _race;

        public Player(int lvl, int mobHp, string name, string race) : base(name, race)
        {
            int kc = 0;
            int health = 0;

            _name = name;
            _race = race;

            mobHp = Danger(mobHp);
            kc = KillCount(mobHp);
            ExpCalculator(kc, lvl);
            HealthPool(lvl);
        }


        private int KillCount(int mobHp)
        {
            int kc = 0;

            if (mobHp == 0)
            {
                kc++;
                _kc = kc;
                return kc;
            }
            return kc;
        }

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

        public int HealthPool(int lvl)
        {
            int hp = 0;
            if (lvl <= 1 || lvl == 0)
            {
                return hp = 10;
            } else if (lvl >= 2)
            {
                hp = hp + 2; 
            }
            _health = hp;
            return hp;
        }

        private void LevelUp(int lvl)
        {
            lvl++;
            _level = lvl;
        }

        private int DamageBuilder(int lvl, int mobHp, int dmg)
        {

            Random rnd = new Random();
            for (int i = 0; i < 1; i++)
            {
                bool roll = diceRoll();

                if (roll == true)
                {
                    if (lvl >= 1 && lvl <= 4)
                    {
                        return dmg = rnd.Next(1, mobHp - 5);
                    }
                    else if (lvl >= 5 && lvl <= 8)
                    {
                        return dmg = rnd.Next(1, mobHp - 3);
                    }
                    else
                    {
                        return dmg = rnd.Next(1, mobHp - 1);
                    }
                }
                return dmg;
            }
            return dmg;
        }


        public void MakeAttack(int lvl, int mobHp)
        {
            int dmg = 0;

            dmg = DamageBuilder(lvl, mobHp, dmg);
            if (mobHp > 0)
            {
                mobHp = mobHp - dmg;
                if (mobHp < 0)
                {
                    mobHp = 0;
                    _threatcheck = mobHp;

                }
                _threatcheck = mobHp;

            }
        }

        private int Danger(int mobHp)
        {
            _threatcheck = mobHp;
            return mobHp = _threatcheck;
        }

        public void Block()
        {

        }
    }
}

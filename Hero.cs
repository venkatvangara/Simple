using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Hero: Knight
    {
        private int _X, _Y;
        private Weapon _heroWeapon;

        public Hero(string name, DateTime dateOfBirth, string villageOrigin, int height, int weight, string appearance, int strengthOfWeapon, string nameOftheKing, int speedOfHorse, int x,int y) : base(name, dateOfBirth, villageOrigin, height, weight, appearance, strengthOfWeapon, nameOftheKing, speedOfHorse)
        {
            X = x;
            Y = y;
            HeroWeapon = new Weapon("Diamond Sword", 3, 100);
        }

        public int X { get => _X; set => _X = value >= 0 ? value : 0; }
        public int Y { get => _Y; set => _Y = value >= 0 ? value : 0; }
        internal Weapon HeroWeapon { get => _heroWeapon; set => _heroWeapon = value; }
    }

    
}

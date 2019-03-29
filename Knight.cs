using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Knight : Soldier
    {

        private int _speedOfHorse_kmph;
        private Weapon _knightWeapon;

        public int SpeedOfHorse { get => _speedOfHorse_kmph; set => _speedOfHorse_kmph = value; }
        internal Weapon KnightWeapon { get => KnightWeapon1; set => KnightWeapon1 = value; }
        internal Weapon KnightWeapon1 { get => _knightWeapon; set => _knightWeapon = value; }

        public Knight(string name, DateTime dateOfBirth, string villageOrigin, int height, int weight, string appearance, int strengthOfWeapon, string nameOftheKing, int speedOfHorse) : base(name, dateOfBirth, villageOrigin, height, weight, appearance, strengthOfWeapon, nameOftheKing)
        {
            this._speedOfHorse_kmph = speedOfHorse;
            KnightWeapon1 = new Weapon("Diamond Sword", 3, 100);
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine("I have a Horse that can run at " + _speedOfHorse_kmph + " kmph");
        }

        public override void Attack(Person targetPerson)
        {
            base.Attack(targetPerson);
            Random rand = new Random();
            if (rand.Next(1, 101) <= 80)
            {
                Console.WriteLine("Successfully Attacked by knight");
                KnightWeapon1.WeaponState = KnightWeapon1.WeaponState - 5;
                targetPerson.receiveDame(KnightWeapon1.WeaponPower);
            }

        }

        public override void receiveDame(int damage)
        {


            this.HealthPoint = this.HealthPoint - damage;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Soldier : Person
    {

        private int _strengthOfWeapon;
        private String _nameOftheKing;
        private Weapon _soldierWeapon;

        public Soldier(string name, DateTime dateOfBirth, string villageOrigin, int height, int weight, string appearance, int strengthOfWeapon, string nameOftheKing) : base(name, dateOfBirth, villageOrigin, height, weight, appearance)
        {

            this.StrengthOfWeapon = strengthOfWeapon;
            this.NameOftheKing = nameOftheKing;

            if (nameOftheKing.ToUpper().Equals("NIGHT KING") || nameOftheKing.ToUpper().Equals("DAY KING"))
                _nameOftheKing = nameOftheKing.ToUpper();
            else
                nameOftheKing = "UNKNOWN";
            _soldierWeapon = new Weapon("Iron Sword", 1, 100);
        }

        public int StrengthOfWeapon { get => _strengthOfWeapon; set => _strengthOfWeapon = value; }
        public string NameOftheKing { get => _nameOftheKing; set => _nameOftheKing = value; }
        internal Weapon SoldierWeapon { get => _soldierWeapon; set => _soldierWeapon = value; }

        public override void Display()
        {
            base.Display();

            Console.WriteLine("I am a Soldier Serving for the King " +_nameOftheKing);
        }

        public override void Attack(Person targetPerson) {
            base.Attack(targetPerson);
            Random rand = new Random();
            if (rand.Next(1, 101) <= 60) {
                Console.WriteLine("Successfully Attacked by Soldier");
                _soldierWeapon.WeaponState=_soldierWeapon.WeaponState-5;
                targetPerson.receiveDame(SoldierWeapon.WeaponPower);
            }

        }

        public override void receiveDame(int damage)
        {


            this.HealthPoint = this.HealthPoint - damage;
        }
    }


    
}

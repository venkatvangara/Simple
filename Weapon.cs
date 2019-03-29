using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Weapon

    { 

        private String _weaponName;
        private int _weaponPower;
        private int _weaponState=100;

        public string WeaponName { get => _weaponName; set => _weaponName = value; }
        public int WeaponPower { get => _weaponPower; set => _weaponPower = value; }
        public int WeaponState { get => _weaponState; set => _weaponState = value>=50?value:50; }

        public Weapon(string weaponName, int weaponPower, int weaponState)
        {
            _weaponName = weaponName;
            _weaponPower = weaponPower;
            _weaponState = weaponState;
        }
    }
}

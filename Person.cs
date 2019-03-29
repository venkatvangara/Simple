using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Person
    {

        private String _name;
        private DateTime _dateOfBirth;
        private String _villageOrigin;
        private int _height_cm;
        private int _weight_kg;
        private String _appearance;
        private int _healthPoint = 10;

        public string Name { get => _name; set => _name = value; }
       
        public string VillageOrigin { get => _villageOrigin; set => _villageOrigin = value; }
        public int Height { get => _height_cm; set => _height_cm = value; }
        public int Weight { get => _weight_kg; set => _weight_kg = value; }
        public string Appearance { get => _appearance; set => _appearance = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public int HealthPoint { get => _healthPoint; set => _healthPoint = value; }

        public Person(string name, DateTime dateOfBirth, string villageOrigin, int height, int weight, string appearance)
        {
            this._name = name;
            this._dateOfBirth = dateOfBirth;
            this._villageOrigin = villageOrigin;
            this._height_cm = height;
            this._weight_kg = weight;
            this._appearance = appearance;
        }


        private double ComputeBodyMassIndex()
        {
            return _weight_kg / Math.Pow(_height_cm / 100.0f, 2);
        }

        public virtual void Display()
        {
            String figure;
            double BMI = ComputeBodyMassIndex();

            if (BMI > 30)
                figure = "really heavy";
            else if (BMI > 18.5)
                figure = "not so heavy";
            else
                figure = "really thin";

            Console.WriteLine("-------------------");
            Console.WriteLine("A " + figure + " person is approaching, looking " + _appearance);

            int age = DateTime.Now.Year - _dateOfBirth.Year;
            String ageLook;

            if (age < 20)
                ageLook = "really young";
            else if (age < 40)
                ageLook = "young";
            else if (age < 60)
                ageLook = "middle aged";
            else
                ageLook = "quite old";



            Console.WriteLine("This " + ageLook + " person suddenly starts to speak:");
            Console.WriteLine("Hello, my name is " + _name);
            Console.WriteLine("I come from " + _villageOrigin);

        }

        public Boolean isAlive() {
            Boolean flag = true;

            if (_healthPoint <= 0) {
                flag = false;
            }


            return flag;
        }
        public virtual void Attack(Person Target) {
           
        }

        public virtual void receiveDame(int damage) {

           
            this.HealthPoint = this.HealthPoint - damage;
        }

    }
}

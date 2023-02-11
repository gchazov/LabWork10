using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    public class Mammal : Animal
    {
        protected bool isWoolen;
        string[] mammalArray = { "Броненосец", "Слон", "Коала", "Ёж", "Бурый медведь",
            "Муровьед", "Панда", "Заяц-русак", "Носорог", "Амурский тигр", "Капибара" };

       
        public bool IsWoolen
        {
            get { return isWoolen; }
            set { isWoolen = value; }
        }

        //добавление поля "наличие шерсти"
        public Mammal() : base()
        {
            isWoolen = true;
        }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name">название животного</param>
        /// <param name="age">возраст животного</param>
        /// <param name="habitat">естественное место обитания</param>
        /// <param name="isWoolen">покрытие шерстью</param>
        public Mammal(string name, int age, string habitat, bool isWoolen)
            : base(name, age, habitat)
        {
            IsWoolen = isWoolen;
        }

        public override void Init(string name = "млекопитающего")
        {
            this.name = Dialog.EnterString($"Введите название {name}:", false, true);
            this.age = Dialog.EnterNumber($"Введите возраст {name}:", 1, 99);
            this.habitat = Dialog.EnterString($"Введите ареал обитания {name}:", true, true);
            this.isWoolen = Dialog.EnterBool("Покрыто ли животное шерстью?");
        }

        public override void RandomInit()
        {
            this.name = mammalArray[random.Next(mammalArray.Length)];
            this.age = random.Next(1, 20);
            this.habitat = habitatArray[random.Next(habitatArray.Length)];
            this.isWoolen = Convert.ToBoolean(random.Next(0, 2));
        }


        public override bool Equals(object obj)
        {
            if (obj is Mammal mammal)
            {
                return (this.Age == mammal.Age && this.IsWoolen == mammal.IsWoolen
                    && String.Compare(this.Name, mammal.Name) == 0
                    && String.Compare(this.Habitat, mammal.Habitat) == 0);
            }
            else
                return false;
        }

        public new void Print()
        {
            Console.WriteLine($"Млекопитающее: {Name}; Возраст: {Age}; Ареал обитания: {Habitat}; Покрыто шерстью: {isWoolen}");
        }
        public override void Show()
        {
            Console.WriteLine($"Млекопитающее: {Name}; Возраст: {Age}; Ареал обитания: {Habitat}; Покрыто шерстью: {isWoolen}");
        }
    }
}

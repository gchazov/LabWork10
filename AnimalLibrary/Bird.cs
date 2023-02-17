using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    //класс Bird наследуемый от суперкласса Animal
    public class Bird : Animal
    {
        protected bool flyAbility;
        protected string[] birdArray = { "Воробей", "Страус", "Пеликан", "Индюк",
            "Петух", "Тукан", "Соловей", "Альбатрос", "Канарейка", "Коростель", "Попугай какаду"};
        public bool FlyAbility
        {
            get { return flyAbility; }
            set { flyAbility = value; }
        }

        //добавление поля "умение летать" к базовому конструктору
        public Bird() : base()
        {
            flyAbility = true;
        }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name">название животного</param>
        /// <param name="age">возраст</param>
        /// <param name="habitat">место обитания</param>
        /// <param name="flyAbility">умение летать</param>
        public Bird(string name, int age, string habitat, bool flyAbility)
            : base(name, age, habitat)
        {
            FlyAbility = flyAbility;
        }

        /*все последующие методы переопределяются от базового класса
         с помощью ключ. слова override и лексемы base (обращение к
         суперклассу)
        */
        public override void Init(string welcomeString = "Умеет ли птица летать?")
        {
            base.Init("птицы");
            FlyAbility = Dialog.EnterBool(welcomeString);
        }

        public override void RandomInit()
        {
            Name = birdArray[random.Next(birdArray.Length)];
            Age = random.Next(1, 20);
            Habitat = habitatArray[random.Next(habitatArray.Length)];
            FlyAbility = Convert.ToBoolean(random.Next(0, 2));

        }


        public override bool Equals(object obj)
        {
            if (obj is Bird bird)
            {
                return (this.Age == bird.Age && this.FlyAbility == bird.FlyAbility
                    && String.Compare(this.Name, bird.Name) == 0
                    && String.Compare(this.Habitat, bird.Habitat) == 0);
            }
            else
                return false;
        }

        public new void Print()
        {
            Console.WriteLine($"Птица: {Name}; Возраст: {Age}; Ареал обитания: {Habitat}; Умение летать: {FlyAbility}");
        }

        public override void Show()
        {
            Console.WriteLine($"Птица: {Name}; Возраст: {Age}; Ареал обитания: {Habitat}; Умение летать: {FlyAbility}");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    public class Artiodactyl : Mammal
    {

        protected string hornStyle;
        protected string[] artiArray = { "Баран", "Антилопа", "Газель", "Горный козёл", 
            "Лань", "Карликовая свинья", "Зубр", "Олень", "Косуля", "Лось" };

        protected string[] hornStyles = { "Карликовые", "Ветвистые", "Развесистые", "Клинообразные", "Винтообразные"};
        public string HornStyle
        {
            get { return hornStyle; }
            set { hornStyle = value; }
        }

        //конструктор, наследуемый от базового класса
        public Artiodactyl()
            : base()
        {
            hornStyle = "NoStyle";
        }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name">название животного</param>
        /// <param name="age">возраст</param>
        /// <param name="habitat">естественное место обитания</param>
        /// <param name="isWoolen">покрытие шерстью</param>
        /// <param name="hornStyle">вид рогов</param>
        public Artiodactyl(string name, int age, string habitat,
            bool isWoolen, string hornStyle)
            : base(name, age, habitat, isWoolen)
        {
            HornStyle = hornStyle;
        }

        public override void Init(string welcomeString = "Какой вид рогов у животного?")
        {
            base.Init("парнокопытного");
            HornStyle = Dialog.EnterString(welcomeString, false, true);

        }

        public override void RandomInit()
        {
            this.name = artiArray[random.Next(artiArray.Length)];
            this.age = random.Next(1, 20);
            this.habitat = habitatArray[random.Next(habitatArray.Length)];
            this.isWoolen = Convert.ToBoolean(random.Next(0, 2));
            this.hornStyle = hornStyles[random.Next(hornStyles.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj is Artiodactyl art)
            {
                return (this.Age == art.Age && this.IsWoolen == art.IsWoolen
                    && String.Compare(this.Name, art.Name) == 0
                    && String.Compare(this.Habitat, art.Habitat) == 0
                    && String.Compare(this.HornStyle, art.HornStyle) == 0);
            }
            else
                return false;
        }
        
        public new void Print()
        {
            Console.WriteLine($"Парнокопытное: {Name}; Возраст: {Age}; " +
                $"Ареал обитания: {Habitat}; Покрыто шерстью: {isWoolen}; Вид рогов: {HornStyle}");
        }

        public override void Show()
        {
            Console.WriteLine($"Парнокопытное: {Name}; Возраст: {Age}; " +
                $"Ареал обитания: {Habitat}; Покрыто шерстью: {isWoolen}; Вид рогов: {HornStyle}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalLibrary;

namespace TestAnimalLibrary
{
    //тестирование класса Bird
    [TestClass]
    public class BirdTesting
    {
        [TestMethod]
        public void TestBirdEmptyCtor() //тестирование пустого конструктора
        {
            Bird actual = new Bird();
            Bird expected = new Bird("NoName", 1, "NoHabitat", true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBirdCtor1() //тест конструктора с параметрами 1
        {
            Bird expected = new Bird("Bird", 20, "Пермь", false);
            Bird actual = new Bird("Bird", 40, "Пермь", false);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBirdCtor2() //тест конструктора с параметрами 2
        {
            Bird expected = new Bird("Сорока", 1, "Москва", true);
            Bird actual = new Bird("Сорока", -100, "Москва", true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBirdProps() //тест свойств Animal
        {
            Bird expected = new Bird("Ворон", 20, "НИУ ВШЭ Пермь", true);
            Bird actual = new Bird("Коростель", 2, "Чусовой", false);
            actual.Name = "Ворон";
            actual.Age = 777;
            actual.Habitat = "НИУ ВШЭ Пермь";
            actual.FlyAbility = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBirdRandom() //тест ДСЧ генерации
        {
            string[] habitatArray = { "Евразия", "Африка", "Австралия", "Южная Америка", "Антарктида", "Северная Америка" };
            string[] birdArray = { "Воробей", "Страус", "Пеликан", "Индюк",
            "Петух", "Тукан", "Соловей", "Альбатрос", "Канарейка", "Коростель", "Попугай какаду"};
            Bird actual = new Bird();
            actual.RandomInit();
            bool isCorrect = birdArray.Contains(actual.Name)
                && habitatArray.Contains(actual.Habitat)
                && actual.Age > 0
                && actual.Age <= 20;
            Assert.AreEqual(true, isCorrect);
        }

        [TestMethod]
        public void TestBirdShow() //тест вывода с консоли
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("Птица: Страус; Возраст: 2; Ареал обитания: Куба; Умение летать: False"));
            Bird animal = new Bird("Страус", 2, "Куба", false);
            animal.Show();
            Assert.IsTrue(cr.ToString().Contains("Птица: Страус; Возраст: 2; Ареал обитания: Куба; Умение летать: False"));
        }

        [TestMethod]
        public void TestBirdPrint() //тест вывода с консоли
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("Птица: Страус; Возраст: 2; Ареал обитания: Куба; Умение летать: False"));
            Bird animal = new Bird("Страус", 2, "Куба", false);
            animal.Print();
            Assert.IsTrue(cr.ToString().Contains("Птица: Страус; Возраст: 2; Ареал обитания: Куба; Умение летать: False"));
        }

        [TestMethod]
        public void TestBirdNotEquals1()
        {
            Bird bird1 = new Bird("Свирестель", 2, "Антананариву", false);
            Bird bird2 = new Bird("Попугайчик ара", 2, "Айдохья", true);
            Assert.AreNotEqual(bird1, bird2);
        }

        [TestMethod]
        public void TestBirdNotEquals2()
        {
            string bird1 = "Чайник";
            Bird bird2 = new Bird("Синичка", 2, "Пермь", false);
            Assert.IsFalse(bird2.Equals(bird1));
        }
    }
}

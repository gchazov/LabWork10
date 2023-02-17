using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalLibrary;
using LabWork10;

namespace TestAnimalLibrary
{
    //тестирование запросов
    [TestClass]
    public class QueryAndSortTesting
    {
        [TestMethod]
        public void TestBirdCount() //тестирование запроса на кол-во птиц
        {
            int expected = 2;
            Animal[] animals = new Animal[3];
            animals[0] = new Bird("пингвин", 2, "Антарктида", false);
            animals[1] = new Bird("пингвин второй", 3, "Чусовой", true);
            animals[2] = new Mammal("ёжик", 5, "Пермь", false);
            int acutal = AnimalQueryAndSort.BirdCount(animals);
            Assert.AreEqual(expected, acutal);
        }

        [TestMethod]
        public void TestOldestAnimal() //тестирование запроса на старейшее животное
        {
            int expected = 0;
            Animal[] animals = new Animal[3];
            animals[0] = new Bird("синичка", 12, "Пермь", true);
            animals[1] = new Bird("пингвин чусовской", 3, "Чусовой", true);
            animals[2] = new Mammal("капибара", 5, "Верхняя Колва", true);
            int actual = AnimalQueryAndSort.OldestAnimal(animals);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestYoungestHorn() //тест запроса на рога самого молодого парнокопытного
        { //теста на пустой массив нет, т.к. функция принимает не пустой массив изначально!
            int expected = 1;
            Animal[] animals = new Animal[3];
            animals[0] = new Artiodactyl("АКРТИЧЕСКИЙ БАРАН", 10, "Закамск", true, "Ветвистые");
            animals[1] = new Artiodactyl("пожилой бизон", 2, "Лес таёжный", true, "Карликовые");
            animals[2] = new Artiodactyl("пожилая бизониха", 13, "Саванна", true, "Ветвистые");
            int actual = AnimalQueryAndSort.YoungestHorn(animals);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInhabitedArea() //тест запроса на животных из местности
        {
            Animal[] expected = new Animal[2];
            expected[0] = new Animal("бегемот", 2, "Африка");
            expected[1] = new Animal("жираф", 13, "Африка");

            Animal[] animals = new Animal[3];
            animals[0] = new Animal("бегемот", 2, "Африка");
            animals[1] = new Animal("жираф", 13, "Африка");
            animals[2] = new Animal("археоптерикс", 2, "Евразия");

            Animal[] actual = AnimalQueryAndSort.InhabitedArea(animals, "Африка");
            //воспользуемся методом сравнения SequenceEqual для Animal[]
            Assert.IsTrue(expected.SequenceEqual(actual)); //возвращает булевое значение равенства
            //не AreEqual, т.к. виртуальный Equals для Animals[] не переопределён
        }

        [TestMethod]
        public void TestSortByName() //тестирование сортировки по названиям животных
        {
            Animal[] expected = new Animal[3];
            expected[0] = new Animal("археоптерикс", 2, "Евразия");
            expected[1] = new Animal("бегемот", 2, "Африка");
            expected[2] = new Animal("жираф", 13, "Африка");

            Animal[] animals = new Animal[3];
            animals[0] = new Animal("бегемот", 2, "Африка");
            animals[1] = new Animal("археоптерикс", 2, "Евразия");
            animals[2] = new Animal("жираф", 13, "Африка");

            Animal[] actual = AnimalQueryAndSort.SortByName(animals);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestSortByAge() //тестирование сортировки по возрастам животных
        {
            Animal[] expected = new Animal[3];
            expected[0] = new Animal("археоптерикс", 10, "Евразия");
            expected[1] = new Animal("бегемот", 1, "Африка");
            expected[2] = new Animal("жираф", 13, "Африка");

            Animal[] animals = new Animal[3];
            animals[0] = new Animal("бегемот", 1, "Африка");
            animals[1] = new Animal("археоптерикс", 10, "Евразия");
            animals[2] = new Animal("жираф", 13, "Африка");

            Animal[] actual = AnimalQueryAndSort.SortByName(animals);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
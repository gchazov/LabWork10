using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalLibrary;

namespace TestAnimalLibrary
{
    //������������ ������ Animal
    [TestClass]
    public class AnimalTesting
    {
        [TestMethod]
        public void TestAnimalEmptyCtor() //������������ ������� ������������
        {
            Animal actual = new Animal();
            Animal expected = new Animal("NoName", 1, "NoHabitat");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAnimalCtor1() //���� ������������ � ����������� 1
        {
            Animal expected = new Animal("��������", 20, "�����");
            Animal actual = new Animal("��������", 40, "�����");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAnimalCtor2() //���� ������������ � ����������� 2
        {
            Animal expected = new Animal("�����", 1, "������");
            Animal actual = new Animal("�����", -100, "������");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAnimalProps() //���� ������� Animal
        {
            Animal expected = new Animal("�����", 20, "��� ��� �����");
            Animal actual = new Animal("��������", 2, "�������");
            actual.Name = "�����";
            actual.Age = 777;
            actual.Habitat = "��� ��� �����";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAnimalRandom() //���� ��� ���������
        {
            string[] habitatArray = { "�������", "������", "���������", "����� �������", "����������", "�������� �������" };
            string[] animalArray = { "�����", "������", "�������", "��������", "����", "�������", "�������", "�������", "��������" };
            Animal actual = new Animal();
            actual.RandomInit();
            bool isCorrect = animalArray.Contains(actual.Name)
                && habitatArray.Contains(actual.Habitat) 
                && actual.Age > 0 
                && actual.Age <= 20;
            Assert.AreEqual(true, isCorrect);
        }

        [TestMethod]
        public void TestAnimalShow() //���� ������ � �������
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("��������: ��������; �������: 2; ����� ��������: ����"));
            Animal animal = new Animal("��������", 2, "����");
            animal.Show();
            Assert.IsTrue(cr.ToString().Contains("��������: ��������; �������: 2; ����� ��������: ����"));
        }

        [TestMethod]
        public void TestAnimalPrint() //���� ������ � �������
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("��������: ��������; �������: 2; ����� ��������: ����"));
            Animal animal = new Animal("��������", 2, "����");
            animal.Print();
            Assert.IsTrue(cr.ToString().Contains("��������: ��������; �������: 2; ����� ��������: ����"));
        }

        [TestMethod]
        public void TestAnimalNotEquals1()
        {
            Animal animal1 = new Animal("��������", 1, "�������");
            Animal animal2 = new Animal("��������", 2, "�������");
            Assert.AreNotEqual(animal1, animal2);
        }

        [TestMethod]
        public void TestAnimalNotEquals2()
        {
            string animal1 = "��������";
            Animal animal2 = new Animal("��������", 2, "�������");
            Assert.IsFalse(animal2.Equals(animal1));
        }       
    }
}
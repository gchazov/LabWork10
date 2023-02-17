using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalLibrary;
using LabWork10;

namespace TestAnimalLibrary
{
    //������������ ��������
    [TestClass]
    public class QueryAndSortTesting
    {
        [TestMethod]
        public void TestBirdCount() //������������ ������� �� ���-�� ����
        {
            int expected = 2;
            Animal[] animals = new Animal[3];
            animals[0] = new Bird("�������", 2, "����������", false);
            animals[1] = new Bird("������� ������", 3, "�������", true);
            animals[2] = new Mammal("����", 5, "�����", false);
            int acutal = AnimalQueryAndSort.BirdCount(animals);
            Assert.AreEqual(expected, acutal);
        }

        [TestMethod]
        public void TestOldestAnimal() //������������ ������� �� ��������� ��������
        {
            int expected = 0;
            Animal[] animals = new Animal[3];
            animals[0] = new Bird("�������", 12, "�����", true);
            animals[1] = new Bird("������� ���������", 3, "�������", true);
            animals[2] = new Mammal("��������", 5, "������� �����", true);
            int actual = AnimalQueryAndSort.OldestAnimal(animals);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestYoungestHorn() //���� ������� �� ���� ������ �������� ��������������
        { //����� �� ������ ������ ���, �.�. ������� ��������� �� ������ ������ ����������!
            int expected = 1;
            Animal[] animals = new Animal[3];
            animals[0] = new Artiodactyl("����������� �����", 10, "�������", true, "���������");
            animals[1] = new Artiodactyl("������� �����", 2, "��� ������", true, "����������");
            animals[2] = new Artiodactyl("������� ��������", 13, "�������", true, "���������");
            int actual = AnimalQueryAndSort.YoungestHorn(animals);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInhabitedArea() //���� ������� �� �������� �� ���������
        {
            Animal[] expected = new Animal[2];
            expected[0] = new Animal("�������", 2, "������");
            expected[1] = new Animal("�����", 13, "������");

            Animal[] animals = new Animal[3];
            animals[0] = new Animal("�������", 2, "������");
            animals[1] = new Animal("�����", 13, "������");
            animals[2] = new Animal("������������", 2, "�������");

            Animal[] actual = AnimalQueryAndSort.InhabitedArea(animals, "������");
            //������������� ������� ��������� SequenceEqual ��� Animal[]
            Assert.IsTrue(expected.SequenceEqual(actual)); //���������� ������� �������� ���������
            //�� AreEqual, �.�. ����������� Equals ��� Animals[] �� ������������
        }

        [TestMethod]
        public void TestSortByName() //������������ ���������� �� ��������� ��������
        {
            Animal[] expected = new Animal[3];
            expected[0] = new Animal("������������", 2, "�������");
            expected[1] = new Animal("�������", 2, "������");
            expected[2] = new Animal("�����", 13, "������");

            Animal[] animals = new Animal[3];
            animals[0] = new Animal("�������", 2, "������");
            animals[1] = new Animal("������������", 2, "�������");
            animals[2] = new Animal("�����", 13, "������");

            Animal[] actual = AnimalQueryAndSort.SortByName(animals);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestSortByAge() //������������ ���������� �� ��������� ��������
        {
            Animal[] expected = new Animal[3];
            expected[0] = new Animal("������������", 10, "�������");
            expected[1] = new Animal("�������", 1, "������");
            expected[2] = new Animal("�����", 13, "������");

            Animal[] animals = new Animal[3];
            animals[0] = new Animal("�������", 1, "������");
            animals[1] = new Animal("������������", 10, "�������");
            animals[2] = new Animal("�����", 13, "������");

            Animal[] actual = AnimalQueryAndSort.SortByName(animals);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
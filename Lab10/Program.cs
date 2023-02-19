using System;
using System.ComponentModel.DataAnnotations;
using AnimalLibrary;
using System.Globalization;

namespace LabWork10
{
    //лабораторная работа 10, вариант 13
    public class Program
    {
        //главное меню с вариантами работы программы
        public static void MainMenu()
        {
            Dialog.PrintHeader("Лабораторная работа №10");
            Console.WriteLine("1. Создать массив случайных объектов (животных)\n" +
                "2. Просмотреть элементы массива объектов\n" +
                "3. Выполнить запрос\n" +
                "4. Выполнить сортировку массива\n" +
                "5. Работа с массивом IInit\n" +
                "6. Копирование и клонирование объекта Animal\n" +
                "7. Завершить работу программы\n");
        }

        //создания массива с помощью ДСЧ (по заданию)
        public static void CreateArray(ref Animal[] animals)
        {
            
            Dialog.PrintHeader("Создание массива с помощью ДСЧ");
            Random random = new Random();
            int arrayLength = Dialog.EnterNumber("Введите количество животных в будущем зоопарке", 0, 20);
            if (arrayLength == 0)
            {
                animals = new Animal[0]; 
                Dialog.ColorText("Пустой зоопарк успешно открыт", "green");
                Dialog.BackMessage();
                return;
            }
            animals = new Animal[arrayLength];
            Animal[] array = new Animal[arrayLength];
            for (int i = 0; i < animals.Length; i++)
            {
                switch (random.Next(1, 5))
                {
                    case 1:
                        array[i] = new Animal();
                        array[i].RandomInit();
                        break;
                    case 2:
                        array[i] = new Bird();
                        array[i].RandomInit();
                        break;
                    case 3:
                        array[i] = new Mammal();
                        array[i].RandomInit();
                        break;
                    case 4:
                        array[i] = new Artiodactyl();
                        array[i].RandomInit();
                        break;
                }
            }
            Array.Copy(array, animals, array.Length);
            Dialog.ColorText($"\nЗоопарк из {animals.Length} животного(-ых) успешно открыт", "green");
            Dialog.BackMessage();
            return;
        }

        //вывод содержимого массива на экран
        public static void ShowArray(Animal[] animals)
        {
            Dialog.PrintHeader("Содержимое массива");
            if (animals.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Зоопарк на данный момент пустует, животных в нём нет");
                Console.ResetColor();
                Dialog.BackMessage();
                return;
            }
            Dialog.ColorText($"В зоопарке на данный момент обитает(-ют)" +
                $" следующее(-ие) {animals.Length} животное(-ых):\n", "green");
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].Show();
            }
            Dialog.BackMessage();
            return;
        }

        //вывод меню запросов
        public static void RequestMenu(Animal[] animals)
        {
            Dialog.PrintHeader("Выполнение запроса");

            if (animals.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Для пустого зоопарка операции запросов недоступны!");
                Console.ResetColor();
                Dialog.BackMessage();
                return;
            }

            do
            {
                Dialog.PrintHeader("Выполнение запроса");
                Console.WriteLine("1. Самое старшее животное в зоопарке\n" +
                    "2. Количество птиц в зоопарке\n" +
                    "3. Вид рогов самого молодого парнокопытного\n" +
                    "4. Количество животных, прибывших в зоопарк из заданной территории\n" +
                    "5. Вернуться в главное меню\n");
                int choice = Dialog.EnterNumber("Выберите один из запросов:", 1, 5);
                switch (choice)
                {
                    case 1:
                        ShowOldestAnimal(animals);
                        break;
                    case 2:
                        ShowBirdCount(animals);
                        break;
                    case 3:
                        ShowYoungestHorn(animals);
                        break;
                    case 4:
                        ShowInhabitedArea(animals);
                        break;
                    case 5:
                        return;
                }
            } while (true);
        }

        //выполнение запроса на кол-во птиц
        public static void ShowBirdCount(Animal[] animals)
        {
            Dialog.PrintHeader("Количество птиц в зоопарке");
            int birdCounter = AnimalQueryAndSort.BirdCount(animals);
            Console.WriteLine($"Количество птиц, проживающих в зоопарке на данный момент - {birdCounter}, среди них:\n");
            foreach (Animal animal in animals)
            {
                if (animal is Bird)
                {
                    Console.WriteLine($"{animal.Name}, ареал которого - {animal.Habitat}");
                }
            }
            Dialog.BackMessage();
            return;
        }
        
        //выполнение запроса на старейшее живнотое
        public static void ShowOldestAnimal(Animal[] animals)
        {
            Dialog.PrintHeader("Самое старшее животное");
            int oldestIndex = AnimalQueryAndSort.OldestAnimal(animals);
            Console.WriteLine($"Самое старое животное - {animals[oldestIndex].Name}, " +
                $"его среда обитания - {animals[oldestIndex].Habitat}, а возраст равен {animals[oldestIndex].Age}");
            Dialog.BackMessage();
            return;
        }

        //выполнение запроса на рога самого молодого парнокопытного
        public static void ShowYoungestHorn(Animal[] animals)
        {
            Dialog.PrintHeader("Рога самого молодого парнокопытного");
            int youngestIndex = AnimalQueryAndSort.YoungestHorn(animals);
            Artiodactyl? youngestArt = animals[youngestIndex] as Artiodactyl;
            Console.WriteLine($"Самое молодое парнокопытное в зоопарке - {animals[youngestIndex].Name}, " +
                $"его возраст - {animals[youngestIndex].Age}, а рога {youngestArt?.HornStyle}");
            Dialog.BackMessage();
            return;
        }

        //выполнение запроса на животных из одной местности
        public static void ShowInhabitedArea(Animal[] animals)
        {
            Dialog.PrintHeader("Животные из одной местности");
            string[] habitatArray = { "евразия", "африка", "австралия", "южная америка", "антарктида", "северная америка" };
            Console.WriteLine("Места обитания: Евразия, Африка, Австралия, Южная Америка, Антарктида, Северная Америка\n");
            bool isCorrect = false;
            string choice;
            TextInfo capitalized = CultureInfo.CurrentCulture.TextInfo;
            do
            {
                choice = Dialog.EnterString("Введите один из вышеперечисленных ареалов обитания животных:", true);
                if (habitatArray.Contains(choice.ToLower()))
                {
                    isCorrect = true;
                }
                else
                {
                    Dialog.ColorText("В введённой вами местности животные из зоопарка никогда не обитали. Попробуйте ещё раз...", "red");
                }
            } while (!isCorrect);

            Animal[] inhabited = AnimalQueryAndSort.InhabitedArea(animals, choice);

            switch (inhabited.Length)
            {
                case 0:
                    Dialog.ColorText("В зоопарке нет животных из указанной местности", "red");
                    break;
                default:
                    Dialog.ColorText($"\n{capitalized.ToTitleCase(choice.ToLower())} - естественная среда " +
                        $"обитания для {inhabited.Length} животных(-ого):", "green");
                    foreach (object obj in inhabited)
                    {
                        Animal? animal = obj as Animal;
                        if (animal != null)
                        {
                            animal.Show();
                        }
                    }
                    break;
            }
            Dialog.BackMessage();
            return;

        }

        //меню сортировок массива
        public static void SortMenu(ref Animal[] animals)
        {
            Dialog.PrintHeader("Сортировка массива");
            if (animals.Length == 0)
            {
                Dialog.ColorText("Для пустого зоопарка операции сортировки недоступны!");
                Dialog.BackMessage();
                return;
            }
            Console.WriteLine("1. Сортировать по названиям животных\n" +
                "2. Сортировать по возрасту\n" +
                "3. Вернуться назад\n");
            int choice = Dialog.EnterNumber("Выберите вариант сортировки:", 1, 3);
            switch (choice)
            {
                case 1:
                    Dialog.PrintHeader("Сортировка по названиям животных");
                    animals = AnimalQueryAndSort.SortByName(animals); //сортировка по названиям
                    Dialog.ColorText("Массив отсортирован по названиям животных", "green");
                    Dialog.BackMessage();
                    break;
                case 2:
                    Dialog.PrintHeader("Сортировка по возрасту животных");
                    animals = AnimalQueryAndSort.SortByAge(animals); //сортировка по возрастам
                    Dialog.ColorText("Массив отсортирован по возрастам животных", "green");
                    Dialog.BackMessage();
                    break;
                case 3:
                    return;
            }
        }

        //заполнение IInit[] путём ввода с клавиатуры
        public static void KeyBoardIInit(ref IInit[] array)
        {
            Dialog.PrintHeader("Ввод значений с клавиатуры");
            int animalCount = Dialog.EnterNumber("Введите количество объектов типа Animal:", 0, 5);
            int birdCount = Dialog.EnterNumber("Введите количество объектов типа Bird:", 0, 5);
            int mammalCount = Dialog.EnterNumber("Введите количество объектов типа Mammal:", 0, 5);
            int artiodactylCount = Dialog.EnterNumber("Введите количество объектов типа Artiodactyl:", 0, 5);
            int carCount = Dialog.EnterNumber("Введите количество объектов типа Car:", 0, 5);
            array = new IInit[animalCount + birdCount + mammalCount + artiodactylCount + carCount];
            if (array.Length == 0)
            {
                Dialog.PrintHeader("Ввод значений с клавиатуры");
                Dialog.ColorText("Пустой массив успешно создан", "green");
                Dialog.BackMessage();
                return;
            }

            Dialog.PrintHeader("Ввод значений с клавиатуры");
            Console.WriteLine("Поочерёдно вводите параметры объектов типа Animal");
            for (int i = 0; i < animalCount; i++)
            {
                Dialog.ColorText($"\n{i + 1}-й элемент массива", "yellow");
                array[i] = new Animal();
                array[i].Init();
            }

            Dialog.PrintHeader("Ввод значений с клавиатуры");
            Console.WriteLine("Поочерёдно вводите параметры объектов типа Bird");
            for (int i = animalCount; i < animalCount + birdCount; i++)
            {
                Dialog.ColorText($"\n{i + 1}-й элемент массива", "yellow");
                array[i] = new Bird();
                array[i].Init();
            }

            Dialog.PrintHeader("Ввод значений с клавиатуры");
            Console.WriteLine("Поочерёдно вводите параметры объектов типа Mammal");
            for (int i = animalCount + birdCount; i < mammalCount + birdCount + animalCount; i++)
            {
                Dialog.ColorText($"\n{i + 1}-й элемент массива", "yellow");
                array[i] = new Mammal();
                array[i].Init();
            }

            Dialog.PrintHeader("Ввод значений с клавиатуры");
            Console.WriteLine("Поочерёдно вводите параметры объектов типа Artiodactyl");
            for (int i = mammalCount + birdCount + animalCount; i < mammalCount + birdCount + animalCount + artiodactylCount; i++)
            {
                Dialog.ColorText($"\n{i + 1}-й элемент массива", "yellow");
                array[i] = new Artiodactyl();
                array[i].Init();
            }

            Dialog.PrintHeader("Ввод значений с клавиатуры");
            Console.WriteLine("Поочерёдно вводите параметры объектов типа Car");
            for (int i = array.Length - carCount; i < array.Length; i++)
            {
                Dialog.ColorText($"{i + 1}-й элемент массива", "yellow");
                array[i] = new Car();
                array[i].Init();
            }

            Dialog.PrintHeader("Ввод значений с клавиатуры");
            Dialog.ColorText($"Массив из {array.Length} объекта(-ов) успешно создан", "green");
            Dialog.BackMessage();
            return;
        }

        //заполнение IInit[] с помощью ДСЧ
        public static void RandomIInit(ref IInit[] array)
        {
            Dialog.PrintHeader("Генерация объектов с помощью ДСЧ");
            int animalCount = Dialog.EnterNumber("Введите количество объектов типа Animal:", 0, 10);
            int birdCount = Dialog.EnterNumber("Введите количество объектов типа Bird:", 0, 10);
            int mammalCount = Dialog.EnterNumber("Введите количество объектов типа Mammal:", 0, 10);
            int artiodactylCount = Dialog.EnterNumber("Введите количество объектов типа Artiodactyl:", 0, 10);
            int carCount = Dialog.EnterNumber("Введите количество объектов типа Car:", 0, 10);
            array = new IInit[animalCount + birdCount + mammalCount + artiodactylCount + carCount];
            if (array.Length == 0)
            {
                Dialog.PrintHeader("Генерация объектов с помощью ДСЧ");
                Dialog.ColorText("Пустой массив успешно создан", "green");
                Dialog.BackMessage();
                return;
            }

            for (int i = 0; i < animalCount; i++)
            {
                array[i] = new Animal();
                array[i].RandomInit();
            }

            for (int i = animalCount; i < animalCount + birdCount; i++)
            {
                array[i] = new Bird();
                array[i].RandomInit();
            }

            for (int i = animalCount + birdCount; i < mammalCount + birdCount + animalCount; i++)
            {
                array[i] = new Mammal();
                array[i].RandomInit();
            }

            for (int i = mammalCount + birdCount + animalCount; i < mammalCount + birdCount + animalCount + artiodactylCount; i++)
            {
                array[i] = new Artiodactyl();
                array[i].RandomInit();
            }

            for (int i = array.Length - carCount; i < array.Length; i++)
            {
                array[i] = new Car();
                array[i].RandomInit();
            }
            Dialog.PrintHeader("Генерация объектов с помощью ДСЧ");
            Dialog.ColorText($"Массив из {array.Length} объекта(-ов) успешно создан", "green");
            Dialog.BackMessage();
            return;
        }

        //меню создания массива IInit[]
        public static void CreateIInitArrayMenu(ref IInit[] array)
        {
            Dialog.PrintHeader("Создание массива интерфейса IInit");
            Console.WriteLine("1. Ввод параметров объектов с клавиатуры\n" +
                "2. Генерация объектов с помощью ДСЧ\n" +
                "3. Назад\n");
            int choice = Dialog.EnterNumber("Выберите пункт меню:", 1, 3);
            switch (choice)
            {
                case 1:
                    KeyBoardIInit(ref array);
                    break;
                case 2:
                    RandomIInit(ref array);
                    break;
                case 3:
                    return;
            }
        }

        public static void ShowIInitArray(IInit[] array)
        {
            Dialog.PrintHeader("Печать массива на экран");
            if (array.Length == 0)
            {
                Dialog.ColorText("Массив объектов пуст!", "green");
                Dialog.BackMessage();
                return;
            }

            Dialog.ColorText($"Массив состоит из {array.Length} элемента(-ов):\n", "green");
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Show();
            }
            Dialog.BackMessage();
            return;
        }

        //меню для работы с массивом IInit[]
        public static void IInitMenu(ref IInit[] array)
        {
            do
            {
                Dialog.PrintHeader("Работа с массивом интерфейса IInit");
                Console.WriteLine("1. Создать массив\n" +
                    "2. Просмотреть массив\n" +
                    "3. Назад\n");
                int choice = Dialog.EnterNumber("Выберите пункт меню:", 1, 3);
                switch (choice)
                {
                    case 1:
                        CreateIInitArrayMenu(ref array);
                        break;
                    case 2:
                        ShowIInitArray(array);
                        break;
                    case 3:
                        return;
                }
            } while (true);
        }

        //копирование объекта (демонстрация работы)
        public static void CopyMethod()
        {
            Dialog.PrintHeader("Поверхностное копирование");
            Dialog.ColorText("Создание объекта", "yellow");
            Animal animal1 = new Animal();
            animal1.Init();
            Dialog.ColorText("\nПроизводится поверхностное копирование объекта...", "yellow");
            Animal animal2 = (Animal)animal1.ShallowCopy();
            Dialog.ColorText("Копирование произведено успешно\n", "green");

            Dialog.ColorText("Изменение параметра \"ID в зоопарке\" у исходного объекта", "yellow");
            animal1.id.number = Dialog.EnterNumber("Введите новое значение параметра:", 0, 1000);

            Dialog.PrintHeader("Сравнение объектов при поверхностном копировании");
            Dialog.ColorText("Исходный объект:", "yellow");
            animal1.Show();
            Dialog.ColorText("Объект-копия:");
            animal2.Show();

            Dialog.BackMessage();
        }

        //клонирование объекта (демонтрация работы)
        public static void CloneMethod()
        {
            Dialog.PrintHeader("Клонирование");
            Dialog.ColorText("Создание объекта", "yellow");
            Animal a1 = new Animal();
            a1.Init();
            Dialog.ColorText("\nПроизводится клонирование объекта...", "yellow");
            Animal a2 = (Animal)a1.Clone();
            Dialog.ColorText("Клонирование произведено успешно\n", "green");

            Dialog.ColorText("Изменение параметра \"ID в зоопарке\" у исходного объекта", "yellow");
            a1.id.number = Dialog.EnterNumber("Введите новое значение параметра:", 0, 1000);

            Dialog.PrintHeader("Сравнение объектов при клонировании");
            Dialog.ColorText("Исходный объект:", "yellow");
            a1.Show();
            Dialog.ColorText("Объект-клон:");
            a2.Show();

            Dialog.BackMessage();
        }

        //меню для работы с копированием и клонированием
        public static void CopyCloneMenu()
        {
            do
            {
                Dialog.PrintHeader("Копирование и клонирование объекта типа Animal");
                Console.WriteLine("1. Поверхностное копирования объекта\n" +
                    "2. Клонирование объекта\n" +
                    "3. Назад\n");
                int choice = Dialog.EnterNumber("Выберите пункт меню:", 1, 3);
                switch (choice)
                {
                    case 1:
                        CopyMethod();
                        break;
                    case 2:
                        CloneMethod();
                        break;
                    case 3:
                        return;
                }
            }while (true);
        }

        //выполнение функций и вывод менюшек
        public static void Run(Animal[] animals, IInit[] array)
        {
            bool runProg = true;
            do
            {
                MainMenu();
                int choice = Dialog.EnterNumber("Выберите один из пунктов меню:", 1, 7);
                switch (choice)
                {
                    case 1:
                        CreateArray(ref animals);
                        break;
                    case 2:
                        ShowArray(animals);
                        break;
                    case 3:
                        RequestMenu(animals);
                        break;
                    case 4:
                        SortMenu(ref animals);
                        break;
                    case 5:
                        IInitMenu(ref array);
                        break;
                    case 6:
                        CopyCloneMenu();
                        break;
                    case 7:
                        runProg = false;
                        break;
                }
            } while (runProg);
            Dialog.PrintHeader("завершение работы");
            Dialog.ColorText("Программа успешно завершила свою работу. Всего хорошего!", "cyan");

        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 160;
            Animal[] animals = new Animal[0];
            IInit[] array = new IInit[0];
            Run(animals, array);
        }
    }
}
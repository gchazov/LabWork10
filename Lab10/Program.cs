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
            Dialog.PrintHeader("Лабораторная работа №10 (части 1 и 2)");
            Console.WriteLine("1. Создать массив случайных объектов (животных)\n" +
                "2. Просмотреть элементы массива объектов\n" +
                "3. Выполнить запрос\n" +
                "4. Завершить работу программы\n");
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
            Dialog.ColorText($"Зоопарк из {animals.Length} животного(-ых) успешно открыт", "green");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"В зоопарке на данный момент обитает(-ют)" +
                $" следующее(-ие) {animals.Length} животное(-ых):\n");
            Console.ResetColor();
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
            int birdCounter = AnimalQuery.BirdCount(animals);
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
            int oldestIndex = AnimalQuery.OldestAnimal(animals);
            Console.WriteLine($"Самое старое животное - {animals[oldestIndex].Name}, " +
                $"его среда обитания - {animals[oldestIndex].Habitat}, а возраст равен {animals[oldestIndex].Age}");
            Dialog.BackMessage();
            return;
        }

        //выполнение запроса на рога самого молодого парнокопытного
        public static void ShowYoungestHorn(Animal[] animals)
        {
            Dialog.PrintHeader("Рога самого молодого парнокопытного");
            int youngestIndex = AnimalQuery.YoungestHorn(animals);
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
                choice = Dialog.EnterString("Введите один из вышеперечисленных ареалов обитания животных:", false, true);
                if (habitatArray.Contains(choice.ToLower()))
                {
                    isCorrect = true;
                }
                else
                {
                    Dialog.ColorText("В введённой вами местности животные из зоопарка никогда не обитали. Попробуйте ещё раз...", "red");
                }
            } while (!isCorrect);

            Animal[] inhabited = AnimalQuery.InhabitedArea(animals, choice);

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

        //выполнение функций и вывод менюшек
        public static void Run(Animal[] animals)
        {
            bool runProgram = true;
            do
            {
                Console.Clear();
                MainMenu();
                int choice = Dialog.EnterNumber("Выберите один из пунктов меню:", 1, 4);
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
                        runProgram = false;
                        break;

                }
                Console.Clear();
            } while (runProgram);
            Dialog.ColorText("Программа успешно завершила свою работу. Всего хорошего!", "cyan");

        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 140;
            Animal[] animals = new Animal[0];
            Run(animals);
        }
    }
}
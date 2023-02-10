using System;
using System.ComponentModel.DataAnnotations;
using AnimalLibrary;
using System.Globalization;
namespace LabWork10
{
    public class Program
    {
        /// <summary>
        /// Главное меню с выбором функционала программы
        /// </summary>
        public static void MainMenu()
        {
            Dialog.PrintHeader("Лабораторная работа №10 (части 1 и 2)");
            Console.WriteLine("1. Создать массив случайных объектов (животных)\n" +
                "2. Просмотреть элементы массива объектов\n" +
                "3. Выполнить запрос\n" +
                "4. Завершить работу программы\n");
        }

        /// <summary>
        /// Создание массива с помощью ДСЧ (по заданию)
        /// </summary>
        /// <param name="animals">массив с обитателями зоопарка</param>
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

        /// <summary>
        /// Вывод содержимого массива на экран
        /// </summary>
        /// <param name="animals">Здесь и далее - массив объектов типа Animal</param>
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

        /// <summary>
        /// Меню запросов
        /// </summary>
        /// <param name="animals"></param>
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
            bool exit = false;
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
                        OldestAnimal(animals);
                        break;
                    case 2:
                        BirdCount(animals);
                        break;
                    case 3:
                        YoungestHorn(animals);
                        break;
                    case 4:
                        InhabitedArea(animals);
                        break;
                    case 5:
                        exit = true;
                        return;
                }
            } while (!exit);
        }

        /// <summary>
        /// Запрос на количество птиц
        /// </summary>
        /// <param name="animals"></param>
        public static void BirdCount(Animal[] animals)
        {
            Dialog.PrintHeader("Количество птиц в зоопарке");
            int birdCounter = 0;
            foreach(Animal animal in animals)
            {
                if (animal is Bird)
                {
                    birdCounter++;
                }
            }
            if (birdCounter == 0)
            {
                Console.WriteLine("На сегодняшний день в зоопарке нет птиц");
                Dialog.BackMessage();
                return;
            }
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
        
        /// <summary>
        /// Запрос на старейшее животное
        /// </summary>
        /// <param name="animals"></param>
        public static void OldestAnimal(Animal[] animals)
        {
            Dialog.PrintHeader("Самое старшее животное");
            int oldestIndex = -1;
            int maxAge = 0;
            int counter = -1;
            foreach(Animal animal in animals)
            {
                counter++;
                if (animal.Age > maxAge)
                {
                    maxAge = animal.Age;
                    oldestIndex = counter;
                }
            }
            Console.WriteLine($"Самое старое животное - {animals[oldestIndex].Name}, " +
                $"его среда обитания - {animals[oldestIndex].Habitat}, а возраст равен {animals[oldestIndex].Age}");
            Dialog.BackMessage();
            return;
        }

        /// <summary>
        /// Запрос на рога самого молодого парнокопытного
        /// </summary>
        /// <param name="animals"></param>
        public static void YoungestHorn(Animal[] animals)
        {
            Dialog.PrintHeader("Рога самого молодого парнокопытного");
            int youngestAge = 21;
            int youngestIndex = -1;
            int counter = -1;
            Artiodactyl yngstArt = new Artiodactyl();
            foreach (Animal animal in animals)
            {
                counter++;
                Artiodactyl art = animal as Artiodactyl;
                if (art != null && art.Age < youngestAge)
                {
                    youngestAge = art.Age;
                    youngestIndex = counter;
                    yngstArt = art;
                }
            }
            if (youngestAge == 21)
            {
                Console.WriteLine("На сегодняшний день в зоопарке нет парнокопытных");
                Dialog.BackMessage();
                return;
            }

            Console.WriteLine($"Самое молодое парнокопытное в зоопарке - {yngstArt.Name}, " +
                $"его возраст - {youngestAge}, а рога {yngstArt.HornStyle}");
            Dialog.BackMessage();
            return;
        }

        /// <summary>
        /// Запрос на животных из одной местности
        /// </summary>
        /// <param name="animals"></param>
        public static void InhabitedArea(Animal[] animals)
        {
            Dialog.PrintHeader("Животные из одной местности");
            string[] habitatArray = { "евразия", "африка", "австралия", "южная америка", "антарктида", "северная америка" };
            Console.WriteLine("Места обитания: Евразия, Африка, Австралия, Южная Америка, Антарктида, Северная Америка\n");
            bool isCorrect = false;
            int animalCount = 0;
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

            Animal[] animalsHabitat = new Animal[animals.Length];
            for (int i = 0; i < animals.Length; i++)
            {
                if (animals[i].Habitat.ToLower() == choice.ToLower())
                {
                    animalsHabitat[i] = animals[i];
                    animalCount++;
                }
            }

            switch (animalCount)
            {
                case 0:
                    Dialog.ColorText("В зоопарке нет животных из указанной местности", "red");
                    break;
                default:
                    
                    Dialog.ColorText($"\n{capitalized.ToTitleCase(choice.ToLower())} - естественная среда " +
                        $"обитания для {animalCount} животных(-ого):", "green");
                    foreach (object obj in animalsHabitat)
                    {
                        Animal animal = obj as Animal;
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

        /// <summary>
        /// Вполнение работы всех функций
        /// </summary>
        /// <param name="animals"></param>
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
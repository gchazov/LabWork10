using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;

namespace LabWork10
{
    public class AnimalQuery
    {
        //запрос на количество птиц
        public static int BirdCount(Animal[] animals)
        {
            int birdCounter = 0;
            foreach (Animal animal in animals)
            {
                if (animal is Bird)
                {
                    birdCounter++;
                }
            }
            return birdCounter;
        }

        //запрос на старейшее животное (индекс в массиве)
        public static int OldestAnimal(Animal[] animals)
        {
            int oldestIndex = -1;
            int maxAge = 0;
            int counter = -1;
            foreach (Animal animal in animals)
            {
                counter++;
                if (animal.Age > maxAge)
                {
                    maxAge = animal.Age;
                    oldestIndex = counter;
                }
            }
            return oldestIndex;
        }

        //запрос на рога самого молодого парнокопытного (индекс в массиве)
        public static int YoungestHorn(Animal[] animals)
        {
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
            return youngestIndex;
        }

        //запрос на животных из одной местности
        public static Animal[] InhabitedArea(Animal[] animals, string choice)
        {
            int animalCount = 0;
            for (int i = 0; i < animals.Length; i++)
            {
                if (animals[i].Habitat.ToLower() == choice.ToLower())
                {
                    animalCount++;
                }
                
            }
            Animal[] animalsHabitat = new Animal[animalCount];
            for (int i = 0, j = 0; i < animals.Length; i++)
            {
                if (animals[i].Habitat.ToLower() == choice.ToLower())
                {
                    animalsHabitat[j] = animals[i];
                    j++;
                }
            }
            return animalsHabitat;
        }
    }
}

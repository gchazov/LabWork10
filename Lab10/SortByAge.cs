using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;

namespace LabWork10
{
    //класс-компаратор для работы с настройкой сортировки
    public class SortByAge : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Animal? animal1 = x as Animal;
            Animal? animal2 = y as Animal;
            if (animal1.Age < animal2.Age)
            {
                return -1;
            }
            else
                if (animal1.Age == animal2.Age)
                return 0;
            else
                return 1;
        }
    }
}

using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork10
{
    public class AgeComparer : Comparer<Animal>
    {
        public override int Compare(Animal? x, Animal? y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    //интерфейс, реализуемый в программе
    public interface IInit
    {
        void Init();
        void RandomInit();
        void Show();
    }
}

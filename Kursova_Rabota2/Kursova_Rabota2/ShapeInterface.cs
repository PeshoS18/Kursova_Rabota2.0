using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_Rabota2
{
    public interface ShapeInterface
    {
        string GetName();
        void SetName(string name);
        double GetPerimeter();
        double GetArea();
        void ShowInfo();
        string GetInfo();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSub
{
    class Program
    {

        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine($"{rect} has area {Area(rect)}");

            Square sq = new Square();
            //Should also be allowed to upcast to base Rectangle type.
            Rectangle sq2 = new Square();
            sq.Width = 4;
            sq2.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
            Console.WriteLine($"{sq2} has area {Area(sq2)}");

        }
    }
}

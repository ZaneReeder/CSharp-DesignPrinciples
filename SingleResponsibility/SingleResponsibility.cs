using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class SingleResponsibility
    {
        class Demo
        {
            static void demo()
            {
                var j = new Journal();
                j.AddEntry("I cry today...");
                j.AddEntry("I ate a bug.");
                Console.WriteLine(j);

                var p = new Persistence();
                var filename = @"C:\Users\zaner\journal.txt";
                p.SaveToFile(j, filename, true);
                Process.Start(filename);
            }
        }
    }
}

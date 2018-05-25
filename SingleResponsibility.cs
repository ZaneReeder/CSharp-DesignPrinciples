using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class SingleResponsibility
    {
        public class Journal
        {
            private readonly List<string> entries = new List<string>();

            private static int count = 0;

            public int AddEntry(string text)
            {
                entries.Add($"{++count} : {text}");
                return count; //momento
            }

            public void RemoveEntry(int index)
            {
                entries.RemoveAt(index);
            }

            public override string ToString()
            {
                return string.Join(Environment.NewLine, entries);
            }
        }

        public class Persistence
        {
            public void SaveToFile(Journal j, string filename, bool overwrite = false)
            {
                if (overwrite || !File.Exists(filename))
                    File.WriteAllText(filename, j.ToString());
            }
        }

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

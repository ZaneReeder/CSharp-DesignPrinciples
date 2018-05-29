using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

    class OpenClose
    {
        public class Demo
        {
            static void Main(string[] args)
            {
                var apple = new Product("Apple", Color.Green, Size.Small);
                var tree = new Product("Tree", Color.Green, Size.Large);
                var house = new Product("House", Color.Blue, Size.Large);

                Product[] products = { apple, tree, house };

                var pf = new ProductFilter();
                Console.WriteLine("Green Products (old): ");
                foreach (var p in pf.FilterByColor(products, Color.Green))
                {
                    Console.WriteLine($"- {p.Name} is green");
                }

                var bf = new BetterFilter();
                Console.WriteLine("Green Prodcuts (new) : ");
                foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
                {
                    Console.WriteLine($"- {p.Name} is green");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            Gamer user = new Gamer("Игрок1", new DateTime(1992, 8, 23));

            Console.WriteLine(user.Introduce());

            Console.WriteLine(new Vector2D(2, 4));

            Console.ReadKey();
        }
    }
}

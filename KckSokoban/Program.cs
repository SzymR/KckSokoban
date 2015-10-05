using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KckSokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Menu menu = new Menu();
            menu.rysujMenu();
            obecneOknoStaticClass.aktualneOkno = 1;
            Kursor kursor = new Kursor();
            
            while (true)
            {
                ConsoleKeyInfo kb = Console.ReadKey();
                if (kb.Key == ConsoleKey.DownArrow)
                    kursor.ustawKursor(++i);
                if (kb.Key == ConsoleKey.Enter)
                    menu.wyborAkcji(i);
                if (kb.Key == ConsoleKey.UpArrow)
                    kursor.ustawKursor(i=i+2);
            }


            Console.ReadKey();
        }
    }
}

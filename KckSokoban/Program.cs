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
                if (obecneOknoStaticClass.aktualneOkno == 1)
                {
                    if (kb.Key == ConsoleKey.DownArrow)
                        kursor.ustawKursor2(++i);
                    if (kb.Key == ConsoleKey.Enter)
                        menu.wyborAkcji(i);
                    if (kb.Key == ConsoleKey.UpArrow)
                        kursor.ustawKursor2(i = i + 2);
                }
                if (obecneOknoStaticClass.aktualneOkno == 2)
                {
                    if (kb.Key == ConsoleKey.DownArrow)
                        Menu.nowaPlansza2.ruszaj('d');
                    if (kb.Key == ConsoleKey.UpArrow)
                        Menu.nowaPlansza2.ruszaj('g');
                    if (kb.Key == ConsoleKey.LeftArrow)
                        Menu.nowaPlansza2.ruszaj('l');
                    if (kb.Key == ConsoleKey.RightArrow)
                        Menu.nowaPlansza2.ruszaj('p');
                } 
                
            }


            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KckSokoban.Interfejsy;

namespace KckSokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int i = 0;
            IMenu menu = new Menu();
            menu.rysujMenu();
            obecneOknoStaticClass.aktualneOkno = 1;
            IKursor kursor = new Kursor();
            
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
                    if (kb.Key == ConsoleKey.Escape)
                    {
                        int level = obecneOknoStaticClass.level;
                        Menu.nowaPlansza2 = new Plansza(level);
                    }
                    if (kb.Key == ConsoleKey.Backspace)
                    {
                        obecneOknoStaticClass.aktualneOkno = 1;
                        
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        menu.rysujMenu();
                        kursor.ustawKursor2(0);
                    }

                }
                if (obecneOknoStaticClass.aktualneOkno == 3)
                {

                    if (kb.Key == ConsoleKey.D1)
                        ListaDostepnychMap.Instance.wybierzPlansze(1);
                    if (kb.Key == ConsoleKey.D2)
                        ListaDostepnychMap.Instance.wybierzPlansze(2);
                    if (kb.Key == ConsoleKey.D3)
                        ListaDostepnychMap.Instance.wybierzPlansze(3);
                    if (kb.Key == ConsoleKey.D4)
                        ListaDostepnychMap.Instance.wybierzPlansze(4);
                    if (kb.Key == ConsoleKey.D5)
                        ListaDostepnychMap.Instance.wybierzPlansze(5);
                    if (kb.Key == ConsoleKey.D6)
                        ListaDostepnychMap.Instance.wybierzPlansze(6);
                    if (kb.Key == ConsoleKey.D7)
                        ListaDostepnychMap.Instance.wybierzPlansze(7);
                  
                }
                if (obecneOknoStaticClass.aktualneOkno == 4)
                {
                    if (kb.Key == ConsoleKey.Backspace)
                    {
                        Win_Animation.thr.Abort();
                        obecneOknoStaticClass.aktualneOkno = 1;
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        menu.rysujMenu();
                        kursor.ustawKursor2(0);
                    }
                }
                
            }


        }
    }
}

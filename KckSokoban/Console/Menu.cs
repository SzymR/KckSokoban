using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KckSokoban.Interfejsy;

namespace KckSokoban
{
    class Menu : IMenu
    {
        public static IPlansza nowaPlansza2;
        public Menu()
        {
            obecneOknoStaticClass.aktualneOkno = 1;
            Console.CursorVisible = false;
            
            
            // w konstruktorze kolory ktore bedzie dziedziczyl rowniez kursor
        }
        public int pozycjaKursora { get; set; }
        private bool ruchKursora = true;
        public void ustawKursor(int pozycja)
        {         
                pozycjaKursora = pozycja % 3;
        }
        public void rysujMenu()
        {
            Console.WriteLine(@"     _______.  ______    __  ___   ______   .______        ___      .__   __. 
    /       | /  __  \  |  |/  /  /  __  \  |   _  \      /   \     |  \ |  | 
   |   (----`|  |  |  | |  '  /  |  |  |  | |  |_)  |    /  ^  \    |   \|  | 
    \   \    |  |  |  | |    <   |  |  |  | |   _  <    /  /_\  \   |  . `  | 
.----)   |   |  `--'  | |  .  \  |  `--'  | |  |_)  |  /  _____  \  |  |\   | 
|_______/     \______/  |__|\__\  \______/  |______/  /__/     \__\ |__| \__| 
                                                                              ");
            Console.WriteLine();
            Console.WriteLine(@"                             __    ___    __      _  
                            / /`_ | |_)  / /\    | | 
                            \_\_/ |_| \ /_/--\ \_|_| 
");
            Console.WriteLine();
            Console.WriteLine(@"                   _       __   ____  _    _____   __      _  
                  \ \    // /`   / / \ \_/  | |   / /\    | | 
                   \_\/\/ \_\_, /_/_  |_|   |_|  /_/--\ \_|_| 
");
            Console.WriteLine();
            Console.WriteLine(@"                          _       _       _   ___  ____ 
                         \ \    /\ \_/   | | | | \  / / 
                          \_\/\/  |_|  \_|_| |_|_/ /_/_ 
");
            string check = "                            ";
           
            
        }

        public void wyborAkcji(int pozycjaKursora)
        {
            pozycjaKursora = pozycjaKursora % 3;
            switch (pozycjaKursora)
            {
                case 0:
                    Console.Clear();
                    nowaPlansza2 = new Plansza();
                    break;

                case 1:
                    Console.Clear();
                    obecneOknoStaticClass.aktualneOkno = 3;
                
                    break;

                case 2:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }
}

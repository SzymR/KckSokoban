using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KckSokoban
{
    class Kursor:Menu
    {
       

        public Kursor()
        {
            pozycjaKursora = 0;           

            if (obecneOknoStaticClass.aktualneOkno == 1)
            {
                ustawKursor2(0);
            }
        }


       
        
        public void ustawKursor2 (int pozycja)
        {
            
                pozycjaKursora = pozycja % 3;
                rysujKursorMenu();
            
        }
        public void rysujKursorMenu()
        {
            switch (pozycjaKursora)
            {
                case 0:
                    kursor1();
                    break;

                case 1:
                    kursor2();
                    break;

                case 2:
                    kursor3();
                    break;

                default:
                    break;
            }
        }

        private void kursor1()
        {
            skasujKursor1();
            skasujKursor2();
            skasujKursor3();
            Console.SetCursorPosition(26, 7);
            Console.WriteLine("╔══════════════════════════╗");
            Console.SetCursorPosition(26, 8);
            Console.Write("║");
            Console.SetCursorPosition(53, 8);
            Console.Write("║");
            Console.SetCursorPosition(26, 9);
            Console.Write("║");
            Console.SetCursorPosition(53, 9);
            Console.Write("║");
            Console.SetCursorPosition(26, 10);
            Console.Write("║");
            Console.SetCursorPosition(53, 10);
            Console.Write("║");
            Console.SetCursorPosition(26, 11);
            Console.Write("║");
            Console.SetCursorPosition(53, 11);
            Console.Write("║");
            Console.SetCursorPosition(26, 12);
            Console.WriteLine("╚══════════════════════════╝");
        }

        private void kursor2()
        {

            skasujKursor1();
            skasujKursor2();
            skasujKursor3();
            Console.SetCursorPosition(16, 12);
            Console.WriteLine("╔═════════════════════════════════════════════╗");
            Console.SetCursorPosition(16, 13);
            Console.Write("║");
            Console.SetCursorPosition(62, 13);
            Console.Write("║");
            Console.SetCursorPosition(16, 14);
            Console.Write("║");
            Console.SetCursorPosition(62, 14);
            Console.Write("║");
            Console.SetCursorPosition(16, 15);
            Console.Write("║");
            Console.SetCursorPosition(62, 15);
            Console.Write("║");
            Console.SetCursorPosition(16, 16);
            Console.Write("║");
            Console.SetCursorPosition(62, 16);
            Console.Write("║");
            Console.SetCursorPosition(16, 17);
            Console.WriteLine("╚═════════════════════════════════════════════╝");
        }

        private void kursor3()
        {
            skasujKursor1();
            skasujKursor2();
            skasujKursor3();
            Console.SetCursorPosition(23, 17);
            Console.WriteLine("╔════════════════════════════════╗");
            Console.SetCursorPosition(23, 18);
            Console.Write("║");
            Console.SetCursorPosition(56, 18);
            Console.Write("║");
            Console.SetCursorPosition(23, 19);
            Console.Write("║");
            Console.SetCursorPosition(56, 19);
            Console.Write("║");
            Console.SetCursorPosition(23, 20);
            Console.Write("║");
            Console.SetCursorPosition(56, 20);
            Console.Write("║");
            Console.SetCursorPosition(23, 21);
            Console.Write("║");
            Console.SetCursorPosition(56, 21);
            Console.Write("║");
            Console.SetCursorPosition(23, 22);
            Console.WriteLine("╚════════════════════════════════╝");
        }

        private void skasujKursor1()
        {
            Console.SetCursorPosition(26, 7);
            Console.WriteLine("                            ");
            Console.SetCursorPosition(26, 8);
            Console.Write(" ");
            Console.SetCursorPosition(53, 8);
            Console.Write(" ");
            Console.SetCursorPosition(26, 9);
            Console.Write(" ");
            Console.SetCursorPosition(53, 9);
            Console.Write(" ");
            Console.SetCursorPosition(26, 10);
            Console.Write(" ");
            Console.SetCursorPosition(53, 10);
            Console.Write(" ");
            Console.SetCursorPosition(26, 11);
            Console.Write(" ");
            Console.SetCursorPosition(53, 11);
            Console.Write(" ");
            Console.SetCursorPosition(26, 12);
            Console.WriteLine("                            ");
        }

        private void skasujKursor2()
        {            
            Console.SetCursorPosition(16, 12);
            Console.WriteLine("                                               ");
            Console.SetCursorPosition(16, 13);
            Console.Write(" ");
            Console.SetCursorPosition(62, 13);
            Console.Write(" ");
            Console.SetCursorPosition(16, 14);
            Console.Write(" ");
            Console.SetCursorPosition(62, 14);
            Console.Write(" ");
            Console.SetCursorPosition(16, 15);
            Console.Write(" ");
            Console.SetCursorPosition(62, 15);
            Console.Write(" ");
            Console.SetCursorPosition(16, 16);
            Console.Write(" ");
            Console.SetCursorPosition(62, 16);
            Console.Write(" ");
            Console.SetCursorPosition(16, 17);
            Console.WriteLine("                                               ");
        }

        private void skasujKursor3()
        {
            Console.SetCursorPosition(23, 17);
            Console.WriteLine("                                  ");
            Console.SetCursorPosition(23, 18);
            Console.Write(" ");
            Console.SetCursorPosition(56, 18);
            Console.Write(" ");
            Console.SetCursorPosition(23, 19);
            Console.Write(" ");
            Console.SetCursorPosition(56, 19);
            Console.Write(" ");
            Console.SetCursorPosition(23, 20);
            Console.Write(" ");
            Console.SetCursorPosition(56, 20);
            Console.Write(" ");
            Console.SetCursorPosition(23, 21);
            Console.Write(" ");
            Console.SetCursorPosition(56, 21);
            Console.Write(" ");
            Console.SetCursorPosition(23, 22);
            Console.WriteLine("                                  ");
        }
    }
}

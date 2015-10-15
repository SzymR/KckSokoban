using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KckSokoban
{
    public class Plansza
    {
        
        int pozBohateraX;
        int pozBohateraY;
        static int rozmiarX = 12;
        static int rozmiarY = 12;

        obiekty[,] tablica = new obiekty[rozmiarX, rozmiarY];
        obiekty[,] wyjscia = new obiekty[rozmiarX, rozmiarY];
        public Plansza()
        {
            Console.CursorVisible = false;
            obecneOknoStaticClass.aktualneOkno = 2;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("tutaj bedzie plansza");
            wczytajPlansze(1);          
        }
        public void Inicjacja()
        {
            
        }

        public void wczytajPlansze(int level)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("plansza1.txt"))
                {
                    string line;
                    int numerLini =0;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        int dlugoscLini = line.Length;
                        for (int i = 0; i < dlugoscLini; i++)
                        {
                            char c = line[i];
                            if (c == 's')
                            {
                                tablica[i, numerLini] = obiekty.sciana;
                            }
                            if (c == 'H')
                            {
                                tablica[i, numerLini] = obiekty.bohater;
                                pozBohateraX = i;
                                pozBohateraY = numerLini;
                            }
                            if (c == 'O')
                            {
                                tablica[i, numerLini] = obiekty.pole;
                                wyjscia[i, numerLini] = obiekty.cel;
                            }
                            if (c == 'X')
                            {
                                tablica[i, numerLini] = obiekty.skrzynka;
                            }
                            if (c == ' ')
                            {
                                tablica[i, numerLini] = obiekty.pole;
                            }
                        }
                        numerLini++;                            
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            rysujPlansze();
        }

        public void rysujPlansze()
        {
            for (int i = 0; i < rozmiarX; i++)
            {
                for (int j = 0; j < rozmiarY; j++)
                {
                    if (tablica[i, j] == obiekty.sciana)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█");
                    }
                    if (wyjscia[i, j] == obiekty.cel)
                    {
                        
                        Console.SetCursorPosition(i, j);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    if (tablica[i, j] == obiekty.bohater)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Y");
                    }
                    if (tablica[i, j] == obiekty.pole && wyjscia[i,j] != obiekty.cel)
                    {
                        
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    if (tablica[i, j] == obiekty.skrzynka)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("X");
                    }
                }
            }            
        }

        public void ruszaj(char gdzie)
        {
            switch (gdzie)
            {
                case 'l':
                    if(tablica[pozBohateraX-1,pozBohateraY]==obiekty.pole){
                        tablica[pozBohateraX-1,pozBohateraY]=obiekty.bohater;
                        tablica[pozBohateraX,pozBohateraY]=obiekty.pole;
                        odswierz(pozBohateraX-1, pozBohateraY);
                        pozBohateraX--;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("Y");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                        
                    }
                    else if(tablica[pozBohateraX-1,pozBohateraY]==obiekty.skrzynka && tablica[pozBohateraX-2,pozBohateraY]==obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        tablica[pozBohateraX - 1, pozBohateraY] = obiekty.bohater;
                        Console.SetCursorPosition(pozBohateraX - 1, pozBohateraY);
                        Console.Write("Y");
                        tablica[pozBohateraX - 2, pozBohateraY] = obiekty.skrzynka;
                        
                        Console.SetCursorPosition(pozBohateraX - 2, pozBohateraY);
                        Console.Write("X");
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                        Console.Write(" ");
                        Console.SetCursorPosition(50, 10);
                        Console.Write(" ");
                        pozBohateraX--;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("Y");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                            if ((tablica[pozBohateraX + 1, pozBohateraY] == obiekty.pole) && (wyjscia[pozBohateraX + 1, pozBohateraY] == obiekty.cel))
                            {
                                Console.SetCursorPosition(pozBohateraX + 1, pozBohateraY);
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(" ");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(50, 10);
                            }
                        }
                        if ((tablica[pozBohateraX - 1, pozBohateraY] == obiekty.skrzynka) && (wyjscia[pozBohateraX - 1, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX - 1, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("X");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }

                    }                    
                    break;
                case'p':
                                            
                    if(tablica[pozBohateraX+1,pozBohateraY]==obiekty.pole){
                        tablica[pozBohateraX+1,pozBohateraY]=obiekty.bohater;
                        tablica[pozBohateraX,pozBohateraY]=obiekty.pole;
                        odswierz(pozBohateraX+1, pozBohateraY);
                        pozBohateraX++;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("Y");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                        
                    }
                    else if (tablica[pozBohateraX + 1, pozBohateraY] == obiekty.skrzynka && tablica[pozBohateraX + 2, pozBohateraY] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        tablica[pozBohateraX + 1, pozBohateraY] = obiekty.bohater;
                        Console.SetCursorPosition(pozBohateraX + 1, pozBohateraY);
                        Console.Write("Y");
                        tablica[pozBohateraX + 2, pozBohateraY] = obiekty.skrzynka;

                        Console.SetCursorPosition(pozBohateraX + 2, pozBohateraY);
                        Console.Write("X");
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                        if(wyjscia[pozBohateraX,pozBohateraY] != obiekty.cel)
                        Console.Write(" ");
                        
                        Console.SetCursorPosition(50, 10);
                        Console.Write(" ");
                        pozBohateraX++;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("Y");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                            if ((tablica[pozBohateraX-1, pozBohateraY] == obiekty.pole) && (wyjscia[pozBohateraX-1, pozBohateraY] == obiekty.cel))
                            {
                                Console.SetCursorPosition(pozBohateraX-1, pozBohateraY);
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(" ");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(50, 10);
                            }
                        }
                        if ((tablica[pozBohateraX+1, pozBohateraY] == obiekty.skrzynka) && (wyjscia[pozBohateraX+1, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX+1, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("X");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                    }
                    break;
                case 'g':
                    if (tablica[pozBohateraX, pozBohateraY-1] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY-1] = obiekty.bohater;
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        odswierz(pozBohateraX, pozBohateraY - 1);
                        pozBohateraY--;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("Y");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                    }
                    else if (tablica[pozBohateraX, pozBohateraY-1] == obiekty.skrzynka && tablica[pozBohateraX, pozBohateraY-2] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        tablica[pozBohateraX, pozBohateraY-1] = obiekty.bohater;
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY-1);
                        Console.Write("Y");
                        tablica[pozBohateraX, pozBohateraY-2] = obiekty.skrzynka;

                        Console.SetCursorPosition(pozBohateraX, pozBohateraY-2);
                        Console.Write("X");
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                        Console.Write(" ");
                        Console.SetCursorPosition(50, 10);
                        Console.Write(" ");
                        pozBohateraY--;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("Y");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.skrzynka) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("X");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                    }
                    break;
                case 'd':
                    if (tablica[pozBohateraX, pozBohateraY + 1] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY + 1] = obiekty.bohater;
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        odswierz(pozBohateraX, pozBohateraY + 1);
                        pozBohateraY++;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("Y");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                      
                    }
                    else if (tablica[pozBohateraX, pozBohateraY + 1] == obiekty.skrzynka && tablica[pozBohateraX, pozBohateraY + 2] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        tablica[pozBohateraX, pozBohateraY + 1] = obiekty.bohater;
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY + 1);
                        Console.Write("Y");
                        tablica[pozBohateraX, pozBohateraY + 2] = obiekty.skrzynka;

                        Console.SetCursorPosition(pozBohateraX, pozBohateraY + 2);
                        Console.Write("X");
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                        Console.Write(" ");
                        Console.SetCursorPosition(50, 10);
                        Console.Write(" ");
                        pozBohateraY++;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("Y");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.skrzynka) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("X");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, 10);
                        }
                    }

                    break;
            }
        }
        public void odswierz(int pozX, int pozY)
        {

            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
            if (wyjscia[pozBohateraX, pozBohateraY] != obiekty.cel)
            {
                Console.Write(' ');
                Console.SetCursorPosition(pozX, pozY);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(' ');
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(pozX, pozY);
            }
            
            Console.Write("Y");
         //   if(tablica[pozBohateraX+1,pozBohateraY] == obiekty.sciana){
         //       Console.SetCursorPosition(pozBohateraX + 1, pozBohateraY);
          //      Console.Write("█");
                
         //   }
            Console.SetCursorPosition(50, 10);  // wyrzucenie kursora jest konieczne aby zapobiedz usuwaniu nastepnego pola
        }

    }
    
    public enum obiekty{
        skrzynka = 1, cel = 2, bohater = 3, sciana = 4, pole = 5
    }
}

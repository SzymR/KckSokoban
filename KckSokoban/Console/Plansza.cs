﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KckSokoban.Interfejsy;

namespace KckSokoban
{
    public  class Plansza : IPlansza
    {
        int ilosc_skrzynek;
        int pozBohateraX;
        int pozBohateraY;
        static int rozmiarX = 12;
        static int rozmiarY = 12;

        obiekty[,] tablica = new obiekty[rozmiarX, rozmiarY];
        obiekty[,] wyjscia = new obiekty[rozmiarX, rozmiarY];

        public Plansza(int level=1)
        {
            Console.CursorVisible = false;
            obecneOknoStaticClass.aktualneOkno = 2;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            wczytajPlansze(level);          
        }
        public void Inicjacja()
        {
            
        }
        
      
        public   void wczytajPlansze(int level)
        {
            obecneOknoStaticClass.level = level;
            ilosc_skrzynek = 0;
            
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("plansza" + level + ".txt"))
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
                                ilosc_skrzynek++;
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
                rysujPlansze();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.Clear();
                Console.WriteLine("Przeszedles całą gre. Gratulacje!!!");
              //  Console.WriteLine(e.Message);
            }
            
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

                        Console.SetCursorPosition( i, j);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    if (tablica[i, j] == obiekty.bohater)
                    {
                        Console.SetCursorPosition(i,  j);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Y");
                    }
                    if (tablica[i, j] == obiekty.pole && wyjscia[i,j] != obiekty.cel)
                    {

                        Console.SetCursorPosition( i,  j);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    if (tablica[i, j] == obiekty.skrzynka)
                    {
                        Console.SetCursorPosition( i,  j);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
                }
            }            
        }
        public void odswierzCele() // metoda odswieze cele aby nie były nadpisane przez przyslaniajace je obiekty (X/Y na niebieskim tle)
        {
            
            int ilosc_celi = 0;
            for (int i = 0; i < rozmiarX; i++)
            {
                for (int j = 0; j < rozmiarY; j++)
                {
                    if ((wyjscia[i, j] == obiekty.cel) && tablica[i, j] == obiekty.bohater)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Y");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(50, 10);
                    }
                    if ((wyjscia[i, j] == obiekty.cel) && tablica[i, j] == obiekty.skrzynka)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(50, 10);
                        ilosc_celi++;
                    }
                    if ((wyjscia[i, j] == obiekty.cel) && tablica[i, j] == obiekty.pole)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(50, 10);
                    }
                }
            }
            if (ilosc_celi == ilosc_skrzynek)
            {
               (this as IPlansza).koniecGry();
            }
        }

 
        public void ruszaj(char gdzie)
        {
            switch (gdzie)
            {
                case 'l': // lewo
                    if(tablica[pozBohateraX-1,pozBohateraY]==obiekty.pole){
                        tablica[pozBohateraX-1,pozBohateraY]=obiekty.bohater;
                        tablica[pozBohateraX,pozBohateraY]=obiekty.pole;
                        odswierz(pozBohateraX-1, pozBohateraY);
                        pozBohateraX--;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Green;
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Y");
                        tablica[pozBohateraX - 2, pozBohateraY] = obiekty.skrzynka;
                        
                        Console.SetCursorPosition(pozBohateraX - 2, pozBohateraY);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                        Console.Write(" ");
                        Console.SetCursorPosition(50, 10);
                        Console.Write(" ");
                        pozBohateraX--;
                        

                    }
                    odswierzCele();
                    break;
                case'p': // prawo
                    if(tablica[pozBohateraX+1,pozBohateraY]==obiekty.pole){
                        tablica[pozBohateraX+1,pozBohateraY]=obiekty.bohater;
                        tablica[pozBohateraX,pozBohateraY]=obiekty.pole;
                        odswierz(pozBohateraX+1, pozBohateraY);
                        pozBohateraX++;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Green;
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Y");
                        tablica[pozBohateraX + 2, pozBohateraY] = obiekty.skrzynka;

                        Console.SetCursorPosition(pozBohateraX + 2, pozBohateraY);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                        Console.Write(" ");
                        Console.SetCursorPosition(50, 10);
                        Console.Write(" ");
                        pozBohateraX++;
                        
                    }
                    odswierzCele();
                    break;
                case 'g': // gora
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
                            Console.ForegroundColor = ConsoleColor.Green;
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Y");
                        tablica[pozBohateraX, pozBohateraY-2] = obiekty.skrzynka;

                        Console.SetCursorPosition(pozBohateraX, pozBohateraY-2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                        Console.Write(" ");
                        Console.SetCursorPosition(50, 10);
                        Console.Write(" ");
                        pozBohateraY--;
                        
                    }
                    odswierzCele();
                    break;
                case 'd': // dol
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Y");
                        tablica[pozBohateraX, pozBohateraY + 2] = obiekty.skrzynka;

                        Console.SetCursorPosition(pozBohateraX, pozBohateraY + 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.SetCursorPosition(pozBohateraX, pozBohateraY);
                        Console.Write(" ");
                        Console.SetCursorPosition(50, 10);
                        Console.Write(" ");
                        pozBohateraY++;
                        
                    }
                    odswierzCele();
                    break;
            }
        }
        public void odswierz(int pozX, int pozY) // zamalowanie poprzedniego ruchu
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y");
         //   if(tablica[pozBohateraX+1,pozBohateraY] == obiekty.sciana){
         //       Console.SetCursorPosition(pozBohateraX + 1, pozBohateraY);
          //      Console.Write("█");
                
         //   }
            Console.SetCursorPosition(50, 10);  // wyrzucenie kursora jest konieczne aby zapobiedz usuwaniu nastepnego pola
        }



        void IPlansza.koniecGry()
        {
            obecneOknoStaticClass.level++;
            ListaDostepnychMap.Instance.wybierzPlansze(obecneOknoStaticClass.level);
        }
    }
    
    public enum obiekty{
        skrzynka = 1, cel = 2, bohater = 3, sciana = 4, pole = 5
    }
}

using KckSokoban.Interfejsy;
using KckSokoban_WPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace KckSokoban.UI
{
    public class Plansza : IPlansza
    {
        MainWindow oknoGry = new MainWindow();
        int ilosc_skrzynek;
        int pozBohateraX;
        int pozBohateraY;
        static int rozmiarX = 20;
        static int rozmiarY = 20;
        int przesuniecie = 5;
        int przesuniecieX = 30;
        obiekty[,] tablica = new obiekty[rozmiarX, rozmiarY];
        obiekty[,] wyjscia = new obiekty[rozmiarX, rozmiarY];

        public void Inicjalizuj() {
            //for (int i = 0; i < oknoGry.grid.Width / oknoGry.Size; i++)
            //{
            //    ColumnDefinition columnDefinitions = new ColumnDefinition();
            //    columnDefinitions.Width = new GridLength(oknoGry.Size);
            //    oknoGry.grid.ColumnDefinitions.Add(columnDefinitions);
            //}
            //for (int j = 0; j < oknoGry.grid.Height / oknoGry.Size; j++)
            //{
            //    RowDefinition rowDefinition = new RowDefinition();
            //    rowDefinition.Height = new GridLength(oknoGry.Size);
            //    oknoGry.grid.RowDefinitions.Add(rowDefinition);
            //}
        }
        public void wczytajPlansze(int level)
        {

            obecneOknoStaticClass.level = level;
            ilosc_skrzynek = 0;
            int maxLegnthX = 0;
            int maxLengthY = 0;
            int temp = 0;

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("plansza" + level + ".txt"))
                {
                    string line;
                    int numerLini = 0;
                    // Read and display lines from the file until the end of 
                    // the file is reached.

                    while ((line = sr.ReadLine()) != null)
                    {
                        temp = 0;
                        maxLengthY++;

                        int dlugoscLini = line.Length;
                        for (int i = 0; i < dlugoscLini; i++)
                        {
                            temp++;

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
                        if (maxLegnthX < temp)
                        {
                            maxLegnthX = temp;
                        }
                        numerLini++;
                    }
                }
                przesuniecieX = Convert.ToInt32(40 - (0.5 * maxLegnthX));
                przesuniecie = Convert.ToInt32(12 - (0.5 * maxLengthY));
                rysujPlansze();
            }
            catch (Exception e)
            {
                throw new Exception();
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


                        Console.SetCursorPosition(i + przesuniecieX, j + przesuniecie);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█");
                    }
                    if (wyjscia[i, j] == obiekty.cel)
                    {

                        Console.SetCursorPosition(i + przesuniecieX, j + przesuniecie);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    if (tablica[i, j] == obiekty.bohater)
                    {
                        Console.SetCursorPosition(i + przesuniecieX, j + przesuniecie);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Y");
                    }
                    if (tablica[i, j] == obiekty.pole && wyjscia[i, j] != obiekty.cel)
                    {

                        Console.SetCursorPosition(i + przesuniecieX, j + przesuniecie);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    if (tablica[i, j] == obiekty.skrzynka)
                    {
                        Console.SetCursorPosition(i + przesuniecieX, j + przesuniecie);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
                }
            }
        }

        public void odswierzCele()
        {
            throw new NotImplementedException();
        }

        public void koniecGry()
        {
            throw new NotImplementedException();
        }

        public void ruszaj(char gdzie)
        {
            throw new NotImplementedException();
        }

        public void odswierz(int pozX, int pozY)
        {
            throw new NotImplementedException();
        }
        public enum obiekty
        {
            skrzynka = 1, cel = 2, bohater = 3, sciana = 4, pole = 5
        }
    }
}

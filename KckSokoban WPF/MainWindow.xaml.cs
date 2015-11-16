using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KckSokoban.Interfejsy;
using System.IO;
using KckSokoban_WPF.Pionki;
using KckSokoban_WPF.UI;
using System.Windows.Media.Animation;

namespace KckSokoban_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IPlansza
    {
        int ilosc_skrzynek;
        int pozBohateraX;
        int pozBohateraY;
        static int rozmiarX = 20;
        static int rozmiarY = 20;
        int przesuniecie = 5;
        int przesuniecieX = 30;
        obiekty[,] tablica = new obiekty[rozmiarX, rozmiarY];
        obiekty[,] wyjscia = new obiekty[rozmiarX, rozmiarY];
        public readonly int Size=25;
        public int level = 1;

        public int currentWindow = 0; ///0-menu, 1 - gra, 2-wybierz level
        public int positionMenu = 0;
        public MenuButton mb;
        public MenuChooseLevel mChL;


        public MainWindow()
        {
            InitializeComponent();
            PierwszaInicjalizacja();
            ColorChooseMenu(0, 1);
           // wczytajPlansze(level);
            CreateAnimationHead();
            var item = mb.CollectionMenuButtonImage[0];
            item.MouseDown += new MouseButtonEventHandler(start_click);
            var item2 = mb.CollectionMenuButtonImage[1];
            item2.MouseDown += new MouseButtonEventHandler(wczytaj_click);
            var item3 = mb.CollectionMenuButtonImage[2];
            item3.MouseDown += new MouseButtonEventHandler(exit_click);
            item.MouseEnter += new MouseEventHandler(start_pos);
            item2.MouseEnter += new MouseEventHandler(wczytaj_pos);
            item3.MouseEnter += new MouseEventHandler(exit_pos);
        }
        private void start_pos(object sender, MouseEventArgs e)
        {
            var item = mb.CollectionMenuButtonImage[0];
            var item2 = mb.CollectionMenuButtonImage[1];
            var item3 = mb.CollectionMenuButtonImage[2];
            item.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(@"tlo.png", UriKind.Relative))
            };
            item2.Fill = Brushes.Aqua;
            item3.Fill = Brushes.Aqua;
        }

        public void CreateAnimationHead()
        {
           // VisualTreeHelper.GetOffset
            var target = Head;
    //var top = VisualTreeHelper.GetOffset(target);
    //var left = VisualTreeHelper.GetOffset(target);
    //TranslateTransform trans = new TranslateTransform();
    //Head.RenderTransform = trans;
    //DoubleAnimation anim1 = new DoubleAnimation(3,10, TimeSpan.FromSeconds(10));
    //DoubleAnimation anim2 = new DoubleAnimation(3, 10, TimeSpan.FromSeconds(10));
    //Head.BeginAnimation(TranslateTransform.XProperty, anim1);
    //Head.BeginAnimation(TranslateTransform.YProperty, anim2);

    DoubleAnimation myDoubleAnimation = new DoubleAnimation();
    myDoubleAnimation.From = -550;
    myDoubleAnimation.To = 0.0;

    myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
    myDoubleAnimation.AutoReverse = true;
    myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
    //  myStoryboard = new Storyboard();
    // myStoryboard.Children.Add(myDoubleAnimation);

    Head.BeginAnimation(TranslateTransform.XProperty, myDoubleAnimation);
        }
        private void wczytaj_pos(object sender, MouseEventArgs e)
        {
            var item = mb.CollectionMenuButtonImage[0];
            var item2 = mb.CollectionMenuButtonImage[1];
            var item3 = mb.CollectionMenuButtonImage[2];
            item.Fill = Brushes.Aqua;
            item2.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(@"tlo.png", UriKind.Relative))
            };
            item3.Fill = Brushes.Aqua;
        }
        private void exit_pos(object sender, MouseEventArgs e)
        {
            var item = mb.CollectionMenuButtonImage[0];
            var item2 = mb.CollectionMenuButtonImage[1];
            var item3 = mb.CollectionMenuButtonImage[2];
            item.Fill = Brushes.Aqua;
            item2.Fill = Brushes.Aqua;
            item3.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(@"tlo.png", UriKind.Relative))
            };
        }

        private void exit_click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("exit");
        }

        private void wczytaj_click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("wczytaj");
        }

        private void start_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("start");
        }
        

        public void clearTablice()
        {
            for (int i = 0; i < rozmiarX; i++)
            {
                for (int j = 0; j < rozmiarY; j++)
                {
                    tablica[i, j] = obiekty.pole;
                    wyjscia[i, j] = obiekty.pole;
                    
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IPlansza pla = new KckSokoban.UI.Plansza();
            
            MessageBox.Show("akdhs");

        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentWindow == 1)
            {
                if (e.Key == Key.Left)
                {
                    if (tablica[pozBohateraX - 1, pozBohateraY] == obiekty.pole)
                    {
                        tablica[pozBohateraX - 1, pozBohateraY] = obiekty.bohater;
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        odswierz(pozBohateraX - 1, pozBohateraY);
                        pozBohateraX--;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            rysujBohatera(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie); // bohater stojacy na celu
                        }

                    }
                    else if (tablica[pozBohateraX - 1, pozBohateraY] == obiekty.skrzynka && tablica[pozBohateraX - 2, pozBohateraY] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        tablica[pozBohateraX - 1, pozBohateraY] = obiekty.bohater;
                        rysujBohatera(pozBohateraX - 1 + przesuniecieX, pozBohateraY + przesuniecie);
                        tablica[pozBohateraX - 2, pozBohateraY] = obiekty.skrzynka;

                        rysujSkrzynie(pozBohateraX - 2 + przesuniecieX, pozBohateraY + przesuniecie);
                        rysujPustePole(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie);
                        pozBohateraX--;


                    }
                    odswierzCele();
                }

                if (e.Key == Key.Right)
                {
                    if (tablica[pozBohateraX + 1, pozBohateraY] == obiekty.pole)
                    {
                        tablica[pozBohateraX + 1, pozBohateraY] = obiekty.bohater;
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        odswierz(pozBohateraX + 1, pozBohateraY);
                        pozBohateraX++;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            rysujBohatera(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie); // bohater na celu
                        }
                    }
                    else if (tablica[pozBohateraX + 1, pozBohateraY] == obiekty.skrzynka && tablica[pozBohateraX + 2, pozBohateraY] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        tablica[pozBohateraX + 1, pozBohateraY] = obiekty.bohater;
                        rysujBohatera(pozBohateraX + 1 + przesuniecieX, pozBohateraY + przesuniecie);
                        tablica[pozBohateraX + 2, pozBohateraY] = obiekty.skrzynka;

                        rysujSkrzynie(pozBohateraX + 2 + przesuniecieX, pozBohateraY + przesuniecie);
                        rysujPustePole(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie);
                        pozBohateraX++;

                    }
                    odswierzCele();
                }

                if (e.Key == Key.Up)
                {
                    if (tablica[pozBohateraX, pozBohateraY - 1] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY - 1] = obiekty.bohater;
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        odswierz(pozBohateraX, pozBohateraY - 1);
                        pozBohateraY--;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            rysujBohatera(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie); // bohater na celu
                        }
                    }
                    else if (tablica[pozBohateraX, pozBohateraY - 1] == obiekty.skrzynka && tablica[pozBohateraX, pozBohateraY - 2] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        tablica[pozBohateraX, pozBohateraY - 1] = obiekty.bohater;
                        rysujBohatera(pozBohateraX + przesuniecieX, pozBohateraY - 1 + przesuniecie);
                        tablica[pozBohateraX, pozBohateraY - 2] = obiekty.skrzynka;

                        rysujSkrzynie(pozBohateraX + przesuniecieX, pozBohateraY - 2 + przesuniecie);
                        rysujPustePole(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie);
                        pozBohateraY--;

                    }
                    odswierzCele();
                }

                if (e.Key == Key.Down)
                {
                    if (tablica[pozBohateraX, pozBohateraY + 1] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY + 1] = obiekty.bohater;
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        odswierz(pozBohateraX, pozBohateraY + 1);
                        pozBohateraY++;
                        if ((tablica[pozBohateraX, pozBohateraY] == obiekty.bohater) && (wyjscia[pozBohateraX, pozBohateraY] == obiekty.cel))
                        {
                            //Console.SetCursorPosition(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie);
                            //Console.BackgroundColor = ConsoleColor.Blue;
                            //Console.Write("Y");
                            //Console.BackgroundColor = ConsoleColor.White;
                            //Console.SetCursorPosition(1, 1);
                        }

                    }
                    else if (tablica[pozBohateraX, pozBohateraY + 1] == obiekty.skrzynka && tablica[pozBohateraX, pozBohateraY + 2] == obiekty.pole)
                    {
                        tablica[pozBohateraX, pozBohateraY] = obiekty.pole;
                        tablica[pozBohateraX, pozBohateraY + 1] = obiekty.bohater;
                        rysujBohatera(pozBohateraX + przesuniecieX, pozBohateraY + 1 + przesuniecie);
                        tablica[pozBohateraX, pozBohateraY + 2] = obiekty.skrzynka;

                        rysujSkrzynie(pozBohateraX + przesuniecieX, pozBohateraY + 2 + przesuniecie);
                        rysujPustePole(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie);
                        pozBohateraY++;

                    }
                    odswierzCele();
                }
                if (e.Key == Key.Back)
                {
                    level--;
                    koniecGry();
                }
                if (e.Key == Key.Escape)
                {
                    PowrotDoMenu();

                }
            }
            else if( currentWindow==0)
            {
                if (e.Key == Key.Down)
                {
                    var prev = positionMenu;
               
                    positionMenu++;
                    positionMenu = positionMenu % 3;
                    ColorChooseMenu(positionMenu, prev);


                   
                }

                if(e.Key == Key.Up)
                {
                    var prev = positionMenu;

                    positionMenu--;
                    if (positionMenu == -1 || positionMenu == -2)
                    {
                        prev = 0;
                        positionMenu = 2;
                    }

                    ColorChooseMenu(positionMenu, prev);


                }
                if(e.Key==Key.Enter)
                {
                    switch(positionMenu)
                    {
                        case 0:
                            currentWindow = 1;
                            positionMenu = 0;
                            level = 1;
                            wczytajPlansze(level);
                            gridMenuMain.Visibility = System.Windows.Visibility.Hidden;
                            grid.Visibility= System.Windows.Visibility.Visible;

                            break;


                        case 1:
                            currentWindow = 2;
                            positionMenu = 0;
                            gridMenuChooseLevel.Visibility = Visibility.Visible;
                            gridMenu.Visibility = System.Windows.Visibility.Hidden;
                            grid.Visibility= System.Windows.Visibility.Hidden;
                            ColorChooseLevel(0, 1);

                            break;
                        case 2:
                            break;


                            

                    }
                }
              
            }

            else if( currentWindow==2)
            {
                if (e.Key == Key.Escape)
                {
                    PowrotDoMenu();

                }
                if (e.Key == Key.Down)
                {
                    var prev = positionMenu;

                    positionMenu++;
                    positionMenu = positionMenu % 7;
                    ColorChooseLevel(positionMenu, prev);



                }

                if (e.Key == Key.Up)
                {
                    var prev = positionMenu;

                    positionMenu--;
                    if (positionMenu == -1 || positionMenu == -2)
                    {
                        prev = 0;
                        positionMenu = 6;
                    }

                    ColorChooseLevel(positionMenu, prev);


                }
                if (e.Key == Key.Enter)
                {
                    level = positionMenu + 1;
                    wczytajPlansze(level);
                   
                    positionMenu = 0;
                    currentWindow = 1;
                    gridMenuMain.Visibility = System.Windows.Visibility.Hidden;
                    grid.Visibility = System.Windows.Visibility.Visible;
                 
                }
            }

          //  _obiekt.odswierzRysowanie();
        }

        public void ColorChooseMenu(int current,int previous)
        {
            ClearColorMenu();
            var item = mb.CollectionMenuButtonImage[current];
            var previousItem = mb.CollectionMenuButtonImage[previous];

           // item.Fill = Brushes.Purple;
            item.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(@"tlo.png", UriKind.Relative))
            };
            previousItem.Fill = Brushes.Aqua;
           
        }

        public void ColorChooseLevel(int current, int previous)
        {
            ClearColorChooseLevel();
            var item = mChL.CollectionMenuButtonImage[current];
            var previousItem = mChL.CollectionMenuButtonImage[previous];

            item.Fill = Brushes.Purple;
            previousItem.Fill = Brushes.Aqua;

        }
        public void ClearColorChooseLevel()
        {
            foreach (var item in mChL.CollectionMenuButtonImage)
            {
                item.Fill = Brushes.Aqua;
            }
         
           

        }
        public void ClearColorMenu()
        {
            foreach (var item in mb.CollectionMenuButtonImage)
            {
                item.Fill = Brushes.Aqua;
            }

           

        }

        public void wczytajPlansze(int level)
        {
            Inicjalizuj();
            ilosc_skrzynek = 0;
            int maxLegnthX = 0;
            int maxLengthY = 0;
            int temp = 0;
            clearTablice();
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
               przesuniecieX = Convert.ToInt32(((grid.Width/2)/Size) - (0.5 * maxLegnthX));
               przesuniecie = Convert.ToInt32(((grid.Width/2) / Size) - (0.5 * maxLengthY));
               rysujPlansze();
            }
            catch (Exception e)
            {
                ///throw new Exception(e.ToString());
                MessageBox.Show("Przeszedles greeeee");
                PowrotDoMenu();
                
            }
        }

        public void PowrotDoMenu()
        {
            currentWindow = 0;
            positionMenu = 0;
            ClearColorMenu();
            ColorChooseMenu(0, 1);
            gridMenuMain.Visibility = System.Windows.Visibility.Visible;
            grid.Visibility = System.Windows.Visibility.Hidden;
            gridMenuChooseLevel.Visibility = Visibility.Hidden;
            gridMenu.Visibility = Visibility.Visible;
        }


        public void rysujSciane(int x, int y)
        {
            Sciana sciana= new Sciana(x,y,Size);
           grid.Children.Add(sciana.Rect);
        }
        public void rysujBohatera(int x, int y)
        {
            Gracz bohater = new Gracz(x, y,Size);
            grid.Children.Add(bohater.Rect);
        }
        public void rysujSkrzynie(int x, int y)
        {
            Skrzynia skrzynia = new Skrzynia(x, y,true,Size);
           grid.Children.Add(skrzynia.Rect);
        }
        public void rysujSkrzynieNaPolu(int x, int y)
        {
            Skrzynia skrzynia = new Skrzynia(x, y, false,Size);
           grid.Children.Add(skrzynia.Rect);
        }
        public void rysujPustePole(int x, int y)
        {
            PustePole pustePole = new PustePole(x, y,Size);
           grid.Children.Add(pustePole.Rect);
        }
        public void rysujCel(int x, int y)
        {
            Cel cel = new Cel(x, y,Size);
            grid.Children.Add(cel.Rect);
        }
        public void rysujPlansze()
        {
            for (int i = 0; i < rozmiarX; i++)
            {
                for (int j = 0; j < rozmiarY; j++)
                {
                    if (tablica[i, j] == obiekty.sciana)
                    {
                        rysujSciane(i + przesuniecieX, j + przesuniecie);
                    }
                    if (wyjscia[i, j] == obiekty.cel)
                    {
                        rysujCel(i + przesuniecieX, j + przesuniecie);
                    }
                    if (tablica[i, j] == obiekty.bohater)
                    {
                        rysujBohatera(i + przesuniecieX, j + przesuniecie);
                    }
                    if (tablica[i, j] == obiekty.skrzynka)
                    {
                        rysujSkrzynie(i + przesuniecieX, j + przesuniecie);
                    }
                }
            }
        }

        public void odswierzCele()
        {
            int ilosc_celi = 0;
            for (int i = 0; i < rozmiarX; i++)
            {
                for (int j = 0; j < rozmiarY; j++)
                {
                    if ((wyjscia[i, j] == obiekty.cel) && tablica[i, j] == obiekty.bohater)
                    {
                        rysujBohatera(i + przesuniecieX, j + przesuniecie);
                    }
                    if ((wyjscia[i, j] == obiekty.cel) && tablica[i, j] == obiekty.skrzynka)
                    {
                        rysujSkrzynieNaPolu(i + przesuniecieX, j + przesuniecie);
                        ilosc_celi++;
                    }
                    if ((wyjscia[i, j] == obiekty.cel) && tablica[i, j] == obiekty.pole)
                    {
                        rysujCel(i + przesuniecieX, j + przesuniecie);
                    }
                }
            }
            if (ilosc_celi == ilosc_skrzynek)
            {
                (this as IPlansza).koniecGry();
            }
        }

        public void koniecGry()
        {
            
            level++;
            grid.Children.Clear();

            tablica = new obiekty[rozmiarX, rozmiarY];
            wyjscia = new obiekty[rozmiarX, rozmiarY];
          
            wczytajPlansze(level);
            
        }

        public void ruszaj(char gdzie)
        {
            throw new NotImplementedException();
        }

        public void odswierz(int pozX, int pozY)
        {

            if (wyjscia[pozBohateraX, pozBohateraY] != obiekty.cel)
            {
                rysujPustePole(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie);
                rysujBohatera(pozX + przesuniecieX, pozY + przesuniecie);
            }
            else
            {
                rysujCel(pozBohateraX + przesuniecieX, pozBohateraY + przesuniecie);
                rysujBohatera(pozX + przesuniecieX, pozY + przesuniecie);
            }
            
        }

        public void PierwszaInicjalizacja ()
        {
            for (int i = 0; i < grid.Width / Size; i++)
            {
                ColumnDefinition columnDefinitions = new ColumnDefinition();
                columnDefinitions.Width = new GridLength(Size);
                grid.ColumnDefinitions.Add(columnDefinitions);
            }
            for (int j = 0; j < grid.Height / Size; j++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(Size);
                grid.RowDefinitions.Add(rowDefinition);
            }
            for (int i = 0; i < grid.Width / Size; i++)
            {
                for (int j = 0; j < grid.Width / Size; j++)
                {
                    rysujPustePole(i, j);
                }
            }

            grid.Visibility = Visibility.Hidden;


            mb = new MenuButton(gridMenu.Height, gridMenu.Width);
            header.Children.Add(mb.Header);

            for (int i = 0; i < mb.CollectionMenuButton.Count; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();

                rowDefinition.Height = new GridLength(1, GridUnitType.Star);

                gridMenu.RowDefinitions.Add(rowDefinition);

                Grid item = mb.CollectionMenuButton[i];

                gridMenu.Children.Add(item);
                Grid.SetRow(item, i);


            }


            mChL = new MenuChooseLevel(gridMenu.Height, gridMenu.Width);


            for (int i = 0; i < mChL.CollectionMenuButton.Count; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();

                rowDefinition.Height = new GridLength(1, GridUnitType.Star);

                gridMenuChooseLevel.RowDefinitions.Add(rowDefinition);

                Grid item = mChL.CollectionMenuButton[i];

                gridMenuChooseLevel.Children.Add(item);
                Grid.SetRow(item, i);


            }

            gridMenuChooseLevel.Visibility = Visibility.Hidden;

        }
        public void Inicjalizuj()
        {
            grid.Children.Clear();
            for (int i = 0; i < grid.Width / Size; i++)
            {
                ColumnDefinition columnDefinitions = new ColumnDefinition();
                columnDefinitions.Width = new GridLength(Size);
                grid.ColumnDefinitions.Add(columnDefinitions);
            }
            for (int j = 0; j < grid.Height / Size; j++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(Size);
                grid.RowDefinitions.Add(rowDefinition);
            }
            for (int i = 0; i < grid.Width / Size; i++)
            {
                for (int j = 0; j < grid.Width / Size; j++)
                {
                    rysujPustePole(i, j);
                }
            }

             
       

        }
      

        public enum obiekty
        {
            skrzynka = 1, cel = 2, bohater = 3, sciana = 4, pole = 5
        }
    }
}

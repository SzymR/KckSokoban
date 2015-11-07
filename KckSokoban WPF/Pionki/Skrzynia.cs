using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KckSokoban_WPF.Pionki
{
    class Skrzynia
        {
            
        
        public int GetX { get; set; }
        public int GetY { get; set; }
        public Rectangle Rect { get; private set; }
        public Skrzynia(int x, int y, bool naPolu, int size)
        {
            BitmapImage bmi;
            ImageBrush ib = new ImageBrush();
            if (!naPolu)
            {
                bmi = new BitmapImage(new Uri(@"skrzynia2.png", UriKind.Relative));
            }
            else
            {
                bmi = new BitmapImage(new Uri(@"skrzynia.png", UriKind.Relative));
            }
            ib.ImageSource = bmi;
            this.GetX = x;
            this.GetY = y;
            Rect = new Rectangle();
            Rect.Width = Rect.Height = size;
            Rect.Fill = ib;
            this.odswierzRysowanie();            
        }

        public void odswierzRysowanie(){
            Grid.SetColumn(this.Rect, this.GetX);
            Grid.SetRow(this.Rect, this.GetY);
        }

    }
}

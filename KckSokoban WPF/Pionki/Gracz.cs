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
    class Gracz
        {                    
        public int GetX { get; set; }
        public int GetY { get; set; }
        public Rectangle Rect { get; private set; }
        public Gracz(int x, int y, int size)
        {
            ImageBrush ib = new ImageBrush();
            BitmapImage bmi = new BitmapImage(new Uri(@"bohater.png", UriKind.Relative));
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

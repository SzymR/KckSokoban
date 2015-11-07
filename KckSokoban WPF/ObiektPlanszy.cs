using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KckSokoban_WPF
{
    class ObiektPlanszy
    {
        
        public int GetX { get; set; }
        public int GetY { get; set; }
        public Rectangle Rect { get; private set; }
        public ObiektPlanszy(int x, int y)
        {
            this.GetX = x;
            this.GetY = y;
            Rect = new Rectangle();
            Rect.Width = Rect.Height = 24;
            Rect.Fill = Brushes.Black;
            this.odswierzRysowanie();
            //grid.Children.Add(this.Rect);
            
            
        }

        public void odswierzRysowanie(){
            Grid.SetColumn(this.Rect, this.GetX);
            Grid.SetRow(this.Rect, this.GetY);
        }

    }
}

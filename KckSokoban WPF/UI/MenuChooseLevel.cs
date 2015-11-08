using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KckSokoban_WPF.UI
{
    public class MenuChooseLevel
    {
        public List<Grid> CollectionMenuButton{ set; get; }
        public List<Rectangle> CollectionMenuButtonImage { set; get; }

        public MenuChooseLevel(double height, double width)
        {
            CollectionMenuButtonImage = new List<Rectangle>();
            CollectionMenuButton = new List<Grid>();


            for( int k=1;k<8;k++)
            {
                string text = k.ToString();
                var grid  = new Grid();
                grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                grid.Margin = new System.Windows.Thickness(1);
                var item = createButton(height / 7, width);
                grid.Children.Add(item);
                grid.Children.Add(createButtonText(text));

                CollectionMenuButtonImage.Add(item);
                CollectionMenuButton.Add(grid);

            }
           

            

        


        }
        public Rectangle createButton(double height, double width)
        {
            Rectangle button = new Rectangle();
            button.Fill = Brushes.Aqua;
            button.Height = 0.5 * height;
            button.Width = 0.5 * width;

            return button;
        }
       
        public TextBlock createButtonText(string content)
        {
            TextBlock text = new TextBlock();
            text.FontSize = 15;
            text.FontFamily = new FontFamily("Comic Sans");
            text.Text = content;
            text.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            text.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            return text;
        }

    }
}

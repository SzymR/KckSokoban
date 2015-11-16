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
        public List<TextBlock> CollectionMenuButton{ set; get; }
        public List<Rectangle> CollectionMenuButtonImage { set; get; }

        public TextBlock Level { set; get; }
        public MenuChooseLevel(double height, double width, Grid grid)
        {
            CollectionMenuButtonImage = new List<Rectangle>();
            CollectionMenuButton = new List<TextBlock>();


            ///for( int k=1;k<8;k++)
           /// {
               // string text = k.ToString();
               // var grid  = new Grid();
                grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                grid.Margin = new System.Windows.Thickness(1);
                var item = createButton(height / 1, width / 3 );



                var buttonUp = createButton(height / 1, width / 3);
                var buttonDown = createButton(height / 1, width / 3);

                ///grid.Children.Add(item);
               // grid.Children.Add(buttonUp);
                //grid.Children.Add(item);



                TextBlock left = new TextBlock();
                left.FontSize = 35;
                left.Background = new SolidColorBrush(Colors.Beige);
                left.Padding = new System.Windows.Thickness(5, 5, 5, 5);
                left.FontFamily = new FontFamily("Comic Sans");
                left.Text = "<-";
                left.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                left.VerticalAlignment = System.Windows.VerticalAlignment.Center;
          
                TextBlock text = new TextBlock();
                text.FontSize = 35;
                text.Background = new SolidColorBrush(Colors.Coral);
                text.Padding = new System.Windows.Thickness(5, 5, 5, 5);
                text.FontFamily = new FontFamily("Comic Sans");
                text.Text = "1";
                text.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                text.VerticalAlignment = System.Windows.VerticalAlignment.Center;

             TextBlock right = new TextBlock();
             right.FontSize = 35;
             right.Background = new SolidColorBrush(Colors.Beige);
             right.Padding = new System.Windows.Thickness(5, 5, 5, 5);
             right.FontFamily = new FontFamily("Comic Sans");
             right.Text = "->";
             right.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
             right.VerticalAlignment = System.Windows.VerticalAlignment.Center;

             CollectionMenuButton.Add(left);
             CollectionMenuButton.Add(text);
             CollectionMenuButton.Add(right);
             

                //CollectionMenuButtonImage.Add(item);
                //CollectionMenuButton.Add(grid);

          //  }
           

            

        


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

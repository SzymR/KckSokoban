using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace KckSokoban_WPF.UI
{
    public class MenuButton
    {

        public Grid Naglowek { get; private set; }
        public Grid Start { get; private set; }
        public Grid WybierzPlansze { get; private set; }
        public Grid Header { get; private set; }
        public Grid Wyjdz { get; private set; }
       
        public List<Grid> CollectionMenuButton { set; get; }
        public List<Rectangle> CollectionMenuButtonImage { set; get; }
        public Storyboard myStoryboard { set; get; }

        public MenuButton(double height, double width)
        {
                CollectionMenuButton = new List<Grid>();
                CollectionMenuButtonImage = new List<Rectangle>();
                CreateHeader();
                //CollectionMenuButton.Add(Header);


             


                string text1 = "Start";
          
                Start = new Grid();
                Start.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                Start.Margin = new System.Windows.Thickness(1);
                
                CollectionMenuButton.Add(Start);
                var item=createButton(height / 3, width);
                CollectionMenuButtonImage.Add(item);

                Start.Children.Add(item);
                Start.Children.Add(createButtonText(text1));
             
        

            
                string text2 = "Wybierz Plansze";
           
                WybierzPlansze = new Grid();
                WybierzPlansze.Margin = new System.Windows.Thickness(1);
       
                CollectionMenuButton.Add(WybierzPlansze);
           
                var item2=createButton(height / 3, width);
                CollectionMenuButtonImage.Add(item2);

                WybierzPlansze.Children.Add(item2);
                WybierzPlansze.Children.Add(createButtonText(text2));
            
                string text3 = "Wyjdz";
           
                Wyjdz = new Grid();
                Wyjdz.Margin = new System.Windows.Thickness(1);
             
        
                CollectionMenuButton.Add(Wyjdz);
                var item3=createButton(height / 3, width);
                CollectionMenuButtonImage.Add(item3);

                Wyjdz.Children.Add(item3);
                Wyjdz.Children.Add(createButtonText(text3));

         


        }

        public void CreateHeader()
        {
//            string header = @" __       _         _                 
/// _\ ___ | | _____ | |__   __ _ _ __  
//\ \ / _ \| |/ / _ \| '_ \ / _` | '_ \ 
//_\ \ (_) |   < (_) | |_) | (_| | | | |
//\__/\___/|_|\_\___/|_.__/ \__,_|_| |_|";

               string header = "SOKOBAN";


            Header = new Grid();
         
            TextBlock text = new TextBlock();
            text.Text = header;
            text.FontSize = 30;
            text.FontFamily = new FontFamily("Comic Sans");
            text.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            text.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            Header.Children.Add(text);

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
          //  myStoryboard = new Storyboard();
           // myStoryboard.Children.Add(myDoubleAnimation);

            Header.BeginAnimation(UIElement.OpacityProperty, myDoubleAnimation);
            //Storyboard.SetTargetName(myDoubleAnimation, Header.Opacity);
            //////myStoryboard.Begin();




        }

        public Rectangle createButton(double height, double width)
        {
            Rectangle button = new Rectangle();
            button.Fill = Brushes.Aqua;
            button.Height = 0.5* height;
            button.Width = 0.5* width;

            return button;
        }
        public Rectangle createHeader(double height, double width)
        {
            Rectangle button = new Rectangle();
       //     button.Fill = Brushes.Aqua;
            button.Height =  height;
            button.Width =  width;

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

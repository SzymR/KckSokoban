using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;

namespace KckSokoban
{
    public static class Win_Animation
    {
        static public Thread thr;
        static public void watek()
        {
            thr = new Thread(animation);
        }   
        static public void animation(){
                    Image image = Image.FromFile(@"1.gif");
            FrameDimension dimension = new FrameDimension(
                               image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);
            StringBuilder sb;

            // Remember cursor position
            int left = Console.WindowLeft, top = Console.WindowTop;

            char[] chars = { '#', '#', '@', '%', '=', '+', 
                         '*', ':', '-', '.', ' ' };
            for (int i = 0; ; i = (i + 1) % frameCount)
            {
                sb = new StringBuilder();
                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.G + cl.B) / 3;
                        int index = (gray * (chars.Length - 1)) / 255;

                        sb.Append(chars[index]);
                    }
                    sb.Append('\n');
                }

                Console.SetCursorPosition(left, top);
                Console.Write(sb.ToString());
                Console.SetCursorPosition(20, 11);
                Console.Write("Gratulacje przeszedles wszystkie mapy!!!");
                Console.SetCursorPosition(left, top);

                System.Threading.Thread.Sleep(100);
            

            }
        }
    }
}

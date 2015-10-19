using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KckSokoban.Interfejsy;

namespace KckSokoban
{
    public class ListaDostepnychMap : IListaDostepnychMap
    {
        private static ListaDostepnychMap _instance ;
        public static ListaDostepnychMap Instance
        {
            get {
                if (_instance == null)
                    _instance = new ListaDostepnychMap();
                return _instance;
            }
        }
        
        public ListaDostepnychMap()
        {
            obecneOknoStaticClass.aktualneOkno = 3;
     
            
        }

        public void init()
        {
            Console.Write("Wcisnij numer aby wybrac planszę ");
            Console.WriteLine();
            Console.Write(" 1 ");
            Console.Write("  2 ");
            Console.Write("  3 ");
            Console.Write("  4 ");
            Console.Write("  5 ");
            Console.Write("  6 ");
            Console.Write("  7 ");
        }


        public void wybierzPlansze(int level)
        {
           Menu.nowaPlansza2 = new Plansza(level);


        }

    
    }
}

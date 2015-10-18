using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KckSokoban
{
    public class ListaDostepnychMap : Interfejsy.ListaDostepnychMap
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
            Console.SetCursorPosition(10, 1);
            Console.WriteLine("  1 ");
            Console.Write("  2 ");
            Console.Write("  3 ");
            Console.Write("  4 ");
            
        }

        public void ruch(char gdzie)
        {

        }


        public void wybierzPlansze(int level)
        {
            Plansza plansza = new Plansza(level);
        }

        public void wybierzPlansze()
        {
            throw new NotImplementedException();
        }
    }
}

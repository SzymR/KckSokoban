using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KckSokoban.Interfejsy
{
    public interface IPlansza
    {
      
        void wczytajPlansze(int level);
    
         void rysujPlansze();
   
         void odswierzCele();
        

         void koniecGry();
    
         void ruszaj(char gdzie);
        
         void odswierz(int pozX, int pozY);
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KckSokoban.Interfejsy
{
    interface IMenu
    {
         void ustawKursor(int pozycja);

         void rysujMenu();


         void wyborAkcji(int pozycjaKursora);
        
    }
}

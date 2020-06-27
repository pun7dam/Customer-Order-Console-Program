using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITECH7201Assignment1
{
    public interface IAction 
    {
        void HeaderInfo();
        void InitLoad();
        void CalculateOrder();
        void CalculateAmount();
        void Display();
    }
}

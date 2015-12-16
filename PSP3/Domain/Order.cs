using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP3.Domain
{
    public class Order : ObservableOrder
    {
        public Order(string destination)
        {
            Destination = destination;
        }
    }
}

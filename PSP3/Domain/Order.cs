using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSP3.DomainService;

namespace PSP3.Domain
{
    public class Order : ObservableOrder
    {
        public Order(int destination)
        {
            _destination = destination;
        }
    }
}

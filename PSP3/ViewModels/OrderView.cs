using System;
using PSP3.Domain;

namespace PSP3.ViewModels
{
    public class OrderView : IOrderObserver, IOrderView
    {
        protected int _id;

        public OrderView(int id)
        {
            _id = id;
        }

        public void UpdateAfterOrderChanged(ObservableOrder order)
        {
            Console.Clear();
            Display();
        }

        public virtual void Display()
        {
            Console.WriteLine("Order --------- {0}", _id);
        }
    }
}
using System;
using PSP3.Domain;

namespace PSP3.ViewModels
{
    public abstract class OrderView : IOrderObserver, IOrderView
    {
        protected int _id;

        protected OrderView(int id)
        {
            _id = id;
        }

        public void UpdateAfterOrderChanged(ObservableOrder order)
        {
            Update(order);
        }

        protected abstract void Update(ObservableOrder order);
        public abstract void Display();
    }
}
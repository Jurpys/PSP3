using System;
using PSP3.Domain;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public abstract class OrderListView : IOrderObserver, IOrderView
    {
        protected OrderRepository _repository;

        protected OrderListView(OrderRepository repository)
        {
            _repository = repository;
        }

        public void UpdateAfterOrderChanged(ObservableOrder order)
        {
            UpdateFields();
        }

        protected abstract void UpdateFields();
        public abstract void Display();
    }
}
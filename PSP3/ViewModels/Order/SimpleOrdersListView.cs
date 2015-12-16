using System.Collections.Generic;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class SimpleOrdersListView : IOrderView
    {
        private List<SimpleOrderListItemView> list;
        private OrderRepository _repository;

        public SimpleOrdersListView(OrderRepository repository)
        {
            _repository = repository;
        }

        public void Display()
        {
            var orders = _repository.FindAll();

            list = new List<SimpleOrderListItemView>();

            foreach (var observableOrder in orders)
            {
                list.Add(new SimpleOrderListItemView(observableOrder.Id, _repository));
            }

            foreach (var simpleOrderListItemView in list)
            {
                simpleOrderListItemView.Display();
            }
        }
    }
}
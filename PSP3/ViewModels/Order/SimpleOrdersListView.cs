using System.Collections.Generic;
using PSP3.DomainService;
using PSP3.UIService;

namespace PSP3.ViewModels
{
    public class SimpleOrdersListView : IViewModel
    {
        private List<SimpleOrderListItemView> list;
        private IOrderRepository _repository;

        public SimpleOrdersListView(IOrderRepository repository)
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
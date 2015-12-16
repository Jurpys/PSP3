using PSP3.Domain;
using PSP3.Repositories;
using PSP3.ViewModels;
using PSP3.Views;

namespace PSP3.Controllers
{
    public class OrderMonitoringController
    {
        private OrderRepository _orderRepository;
        private OrderMonitoring _view;
        public OrderMonitoringController(OrderMonitoring view, OrderRepository orderRepository)
        {
            _view = view;
            _orderRepository = orderRepository;
        }

        public void InitializeView()
        {
            _view.Initialize(this);
        }

        public IOrderView GetAllOrders()
        {
            return new FreeOrdersListView(_orderRepository);
        }

        public IOrderView GetAllTakenOrders()
        {
            return new TakenOrdersListView(_orderRepository);
        }

        public IOrderView GetAllFreeOrders()
        {
            return new FreeOrdersListView(_orderRepository);
        }

        public IOrderView GetAllFinishedOrders()
        {
            return new FinishedOrdersListView(_orderRepository);
        }
    }
}
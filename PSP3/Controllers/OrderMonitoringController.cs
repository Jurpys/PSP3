using PSP3.Commands;
using PSP3.Domain;
using PSP3.Repositories;
using PSP3.ViewModels;
using PSP3.Views;

namespace PSP3.Controllers
{
    public class OrderMonitoringController
    {
        private IObservableTaxiCompanyFactory _factory;
        private OrderRepository _orderRepository;
        private OrderMonitoring _view;
        private CommandProcessor _commandProcessor = new CommandProcessor();

        public OrderMonitoringController(OrderMonitoring view, OrderRepository orderRepository, SimpleTaxiCompanyFactory factory)
        {
            _view = view;
            _orderRepository = orderRepository;
            _factory = factory;
        }

        public void InitializeView()
        {
            _view.Initialize(this);
        }

        public void NewOrder(string destination)
        {
            var command = new CreateNewOrderCommand(destination, _factory, _orderRepository);

            _commandProcessor.Execute(command);
        }

        public IOrderView GetOrderDetailsById(int id)
        {
            return new SimpleOrderView(id, _orderRepository);
        }

        public void DeleteOrderById(int id)
        {
            _commandProcessor.Execute(new DeleteOrderCommand(id, _orderRepository));
        }

        public void UndoLastOperation()
        {
            _commandProcessor.UndoLast();
        }

        public void UpdateOrderDestination(int id, string newDest)
        {
            _commandProcessor.Execute(new UpdateOrderDestinationCommand(id, newDest, _orderRepository));
        }

        public IOrderView GetOrdersList()
        {
            return new SimpleOrdersListView(_orderRepository);
        }
    }
}
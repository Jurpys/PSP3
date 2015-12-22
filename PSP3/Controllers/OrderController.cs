using PSP3.Commands;
using PSP3.CommandsService;
using PSP3.DomainService;
using PSP3.UIService;
using PSP3.ViewModels;
using PSP3.Views;

namespace PSP3.Controllers
{
    public class OrderController : IController
    {
        private IObservableTaxiCompanyFactory _factory;
        private IOrderRepository _IOrderRepository;
        private OrderUIView _view = new OrderUIView();
        private ICommandProcessor _commandProcessor;
        private ITaxiRepository _orderRepository;

        public OrderController(ITaxiRepository orderRepository, IOrderRepository IOrderRepository, IObservableTaxiCompanyFactory factory, ICommandProcessor commandProcessor)
        {
            _IOrderRepository = IOrderRepository;
            _factory = factory;
            _commandProcessor = commandProcessor;
            _orderRepository = orderRepository;
        }

        public void InitializeView()
        {
            _view.Initialize(this);
        }

        public void NewOrder(int destination)
        {
            var command = new CreateNewOrderCommand(destination, _factory, _IOrderRepository);

            _commandProcessor.Execute(command);
        }

        public IViewModel GetOrderDetailsById(int id)
        {
            return new SimpleOrderView(id, _IOrderRepository);
        }

        public void DeleteOrderById(int id)
        {
            _commandProcessor.Execute(new DeleteOrderCommand(id, _IOrderRepository));
        }

        public void UndoLastOperation()
        {
            _commandProcessor.UndoLast();
        }

        public void UpdateOrderDestination(int id, int newDest)
        {
            _commandProcessor.Execute(new UpdateOrderDestinationCommand(id, newDest, _IOrderRepository));
        }

        public IViewModel GetOrdersList()
        {
            return new SimpleOrdersListView(_IOrderRepository);
        }
    }
}
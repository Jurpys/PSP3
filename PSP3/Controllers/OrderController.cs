using PSP3.Commands;
using PSP3.Controllers.Interfaces;
using PSP3.Domain;
using PSP3.Repositories;
using PSP3.ViewModels;
using PSP3.Views;

namespace PSP3.Controllers
{
    public class OrderController : IController
    {
        private IObservableTaxiCompanyFactory _factory;
        private IOrderRepository _IOrderRepository;
        private OrderUIView _view;
        private ICommandProcessor _commandProcessor;

        public OrderController(OrderUIView view, IOrderRepository IOrderRepository, IObservableTaxiCompanyFactory factory, ICommandProcessor commandProcessor)
        {
            _view = view;
            _IOrderRepository = IOrderRepository;
            _factory = factory;
            _commandProcessor = commandProcessor;
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

        public IOrderView GetOrderDetailsById(int id)
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

        public IOrderView GetOrdersList()
        {
            return new SimpleOrdersListView(_IOrderRepository);
        }
    }
}
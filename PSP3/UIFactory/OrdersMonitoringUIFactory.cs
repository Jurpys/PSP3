using PSP3.CommandsService;
using PSP3.Controllers;
using PSP3.DomainService;
using PSP3.UIService;

namespace PSP3.UIFactory
{
    public class OrdersMonitoringUIFactory : IUIFactory
    {
        public IController CreateController(ITaxiRepository taxiRepository, IOrderRepository orderRepository, IObservableTaxiCompanyFactory factory, ICommandProcessor commandProcessor)
        {
            return new OrderController(taxiRepository, orderRepository, factory, commandProcessor);
        }
    }
}
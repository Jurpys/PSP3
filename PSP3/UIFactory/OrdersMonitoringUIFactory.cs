using PSP3.Commands;
using PSP3.Controllers;
using PSP3.Controllers.Interfaces;
using PSP3.DomainFactory;
using PSP3.Repositories;
using PSP3.Views;

namespace PSP3.UIFactory
{
    public class OrdersMonitoringUIFactory
    {
        public IController CreateController(IOrderRepository IOrderRepository, IObservableTaxiCompanyFactory factory, ICommandProcessor commandProcessor)
        {
            return new OrderController(new OrderUIView(), IOrderRepository, factory, commandProcessor);
        }
    }
}
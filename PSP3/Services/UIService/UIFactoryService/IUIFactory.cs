using PSP3.CommandsService;
using PSP3.DomainService;

namespace PSP3.UIService
{
    public interface IUIFactory
    {
        IController CreateController(ITaxiRepository TaxiRepository, IOrderRepository orderRepository, IObservableTaxiCompanyFactory factory,
            ICommandProcessor commandProcessor);
    }
}
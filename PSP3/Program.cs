using PSP3.Commands;
using PSP3.CommandsService;
using PSP3.DomainFactory;
using PSP3.DomainService;
using PSP3.Repositories;
using PSP3.UIFactory;
using PSP3.UIService;

namespace PSP3
{
    public class Program
    {
        public static void Main()
        {
            IUIFactory uiFactory = new OrdersMonitoringUIFactory();

            ITaxiRepository taxi = new SimpleTaxiRepository();
            IOrderRepository ord = new SimpleOrderRepository();
            ICommandProcessor cmdProcessor = new SimpleCommandProcessor();
            IObservableTaxiCompanyFactory domain = new SimpleTaxiCompanyFactory();

            IController controller = uiFactory.CreateController(taxi, ord, domain, cmdProcessor);
            
            controller.InitializeView();
        }
    }
}
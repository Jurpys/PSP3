using PSP3.Commands;
using PSP3.DomainFactory;
using PSP3.Repositories;
using PSP3.UIFactory;

namespace PSP3
{
    public class Program
    {
        public static void Main()
        {
            var uiFactory = new OrdersMonitoringUIFactory();

            ITaxiRepository fact = new SimpleTaxiRepository();
            IOrderRepository repo = new SimpleOrderRepository();
            ICommandProcessor cmdProcessor = new SimpleCommandProcessor();
            IObservableTaxiCompanyFactory domain = new SimpleTaxiCompanyFactory();

            var controller = uiFactory.CreateController(repo, domain, cmdProcessor);
            
            controller.InitializeView();
        }
    }
}
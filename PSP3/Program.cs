using System.Windows.Forms;
using PSP3.Commands;
using PSP3.Controllers;
using PSP3.Domain;
using PSP3.Repositories;
using PSP3.UIFactory;
using PSP3.ViewModels;
using PSP3.Views;

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
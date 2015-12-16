using System.Windows.Forms;
using PSP3.Controllers;
using PSP3.Domain;
using PSP3.Repositories;
using PSP3.ViewModels;
using PSP3.Views;

namespace PSP3
{
    public class Program
    {
        public static void Main()
        {
            var cont = new OrderMonitoringController(new OrderMonitoring(), new OrderRepository(), new SimpleTaxiCompanyFactory());
            cont.InitializeView();
        }
    }
}
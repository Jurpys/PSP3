using PSP3.DomainService;

namespace PSP3.ViewModels
{
    public class OrderViewAdapter
    {
        public string GetOrderIsTaken(ObservableOrder order)
        {
            return order.IsTaken ? "Yes" : "No";
        }
    }
}
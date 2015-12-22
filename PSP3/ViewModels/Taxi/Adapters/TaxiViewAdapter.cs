using PSP3.Domain;
using PSP3.DomainService;

namespace PSP3.ViewModels
{
    public class TaxiViewAdapter
    {
        public string GetOrderId(ObservableTaxi taxi)
        {
            return taxi.IsBusy? taxi.OrderId.ToString() : "None";
        } 
    }
}
using PSP3.Domain;

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
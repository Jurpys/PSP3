using PSP3.Domain;
using PSP3.DomainService;

namespace PSP3.DomainFactory
{
    public class CheapTaxiComanyFactory : IObservableTaxiCompanyFactory
    {
        public ObservableTaxi CreateTaxi()
        {
            return new DiscountedTaxi(1.20);
        }

        public ObservableOrder CreateOrder(int destination)
        {
            return new FreeOrder(destination);
        }
    }
}
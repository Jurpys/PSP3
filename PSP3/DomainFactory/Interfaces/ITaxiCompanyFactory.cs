using PSP3.Domain;

namespace PSP3.DomainFactory
{
    public interface IObservableTaxiCompanyFactory
    {
        ObservableTaxi CreateTaxi();
        ObservableOrder CreateOrder(int destination);
    }
}
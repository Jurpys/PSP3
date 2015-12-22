using PSP3.DomainService;

namespace PSP3.DomainService
{
    public interface ITaxiObserver
    {
        void UpdateAfterTaxiChanged(ObservableTaxi order);
    }
}
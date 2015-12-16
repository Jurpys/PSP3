namespace PSP3.Domain
{
    public interface ITaxiObserver
    {
        void UpdateAfterTaxiChanged(ObservableTaxi order);
    }
}
namespace PSP3.Domain
{
    public interface IOrderObserver
    {
        void UpdateAfterOrderChanged(ObservableOrder order);
    }
}
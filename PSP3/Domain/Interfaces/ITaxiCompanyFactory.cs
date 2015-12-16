namespace PSP3.Domain
{
    public interface ITaxiCompanyFactory
    {
        ITaxi CreateTaxi();
        IOrder CreateOrder();

        Dispatcher CreateDispatcher();
    }
}
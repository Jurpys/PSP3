namespace PSP3.Domain
{
    public class SimpleTaxiCompanyFactory : ITaxiCompanyFactory
    {
        public ITaxi CreateTaxi()
        {
            return new Taxi();
        }

        public IOrder CreateOrder()
        {
            return new Order();
        }

        public Dispatcher CreateDispatcher()
        {
            return Dispatcher.Instance();
        }
    }
}
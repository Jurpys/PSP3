namespace PSP3.Domain
{
    public class SimpleTaxiCompanyFactory : IObservableTaxiCompanyFactory
    {
        public ObservableTaxi CreateTaxi()
        {
            return new Taxi();
        }

        public ObservableOrder CreateOrder(string destination)
        {
            return new Order(destination);
        }

        public Dispatcher CreateDispatcher()
        {
            return Dispatcher.Instance();
        }
    }
}
namespace PSP3.Domain
{
    public class SimpleTaxiCompanyFactory : IObservableTaxiCompanyFactory
    {
        public ObservableTaxi CreateTaxi()
        {
            return new Taxi(1.20);
        }

        public ObservableOrder CreateOrder(int destination)
        {
            return new Order(destination);
        }
    }
}
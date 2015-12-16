namespace PSP3.Domain
{
    public class Dispatcher : IOrderObserver, ITaxiObserver
    {
        private static Dispatcher _instance;

        protected Dispatcher()
        {
        }

        public static Dispatcher Instance()
        {
            if (_instance == null)
            {
                _instance = new Dispatcher();
            }

            return _instance;
        }

        public void UpdateAfterOrderChanged(ObservableOrder order)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAfterTaxiChanged(ObservableTaxi taxi)
        {
            throw new System.NotImplementedException();
        }
    }
}
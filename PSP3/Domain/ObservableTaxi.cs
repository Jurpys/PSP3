using System.Collections.Generic;

namespace PSP3.Domain
{
    public abstract class ObservableTaxi : ITaxi
    {
        private List<ITaxiObserver> _observers;
        private IOrder _order;

        public int Id { get; set; }

        public string DriverName { get; set; }

        protected ObservableTaxi()
        {
        }

        public void AttachObserver(ITaxiObserver observer)
        {
            _observers.Add(observer);
        }

        public void DetachObserver(ITaxiObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateAfterTaxiChanged(this);
            }
        }

        public IOrder Order
        {
            set
            {
                if (_order == null)
                {
                    _order = value;
                    Notify();
                }
            }
            get { return _order; }
        }

        public void CompleteOrder()
        {
            _order = null;
            Notify();
        }
    }
}
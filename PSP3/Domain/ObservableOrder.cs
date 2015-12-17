using System.Collections.Generic;

namespace PSP3.Domain
{
    public abstract class ObservableOrder : ITaxiObserver
    {
        private List<IOrderObserver> _observers = new List<IOrderObserver>();
        private bool _isTaken;
        private double? _price;
        public int _destination;

        public int Id { get; set; }

        public int Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                Notify();
            }
        }

        public bool IsTaken
        {
            get { return _isTaken; }
            set
            {
                _isTaken = value;
                Notify();
            }
        }

        public double? Price
        {
            get { return _price; }
            set
            {
                _price = value;
                Notify();
            }
        }

        public ObservableOrder()
        {
        }

        public void AttachObserver(IOrderObserver observer)
        {
            _observers.Add(observer);
        }

        public void DetachObserver(IOrderObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateAfterOrderChanged(this);
            }
        }

        public void UpdateAfterTaxiChanged(ObservableTaxi taxi)
        {
            _price = taxi.CalculateCurrentOrderPrice();
            taxi.DetachObserver(this);
        }
    }
}
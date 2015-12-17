using System;
using System.Collections.Generic;

namespace PSP3.Domain
{
    public abstract class ObservableTaxi : IOrderObserver
    {
        private List<ITaxiObserver> _observers;
        private int? _orderId;
        private int _lastOrderDestination;
        private readonly double _tariff;
        private int _currentLocation;
        public int Id { get; set; }

        public string DriverName { get; set; }

        public bool IsBusy { get; set; }

        public double Tariff => _tariff;

        public int CurrentLocation => _currentLocation;

        protected ObservableTaxi(double tariff)
        {
            _tariff = tariff;
        }

        public int? OrderId => _orderId;

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

        public void SetOrder(ObservableOrder order)
        {
            _orderId = order.Id;
            order.IsTaken = true;
            _lastOrderDestination = order.Destination;//TODO pridėti logiką
            Notify();
            order.AttachObserver(this);
        }

        public void CompleteOrder()
        {
            _orderId = null;
            var price = CalculateCurrentOrderPrice();
            Notify();
            _currentLocation = _lastOrderDestination;
        }

        public void UpdateAfterOrderChanged(ObservableOrder order)
        {
            _lastOrderDestination = order.Destination;
        }

        public double CalculateCurrentOrderPrice()
        {
            return Math.Round(_tariff*Math.Abs(_lastOrderDestination - _currentLocation), 2);
        }
    }
}
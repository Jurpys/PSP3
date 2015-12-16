using System;
using PSP3.Domain;

namespace PSP3.ViewModels
{
    public abstract class TaxiView : ITaxiObserver, ITaxiView
    {
        protected int _id;

        protected TaxiView(int id)
        {
            _id = id;
        }

        public void UpdateAfterTaxiChanged(ObservableTaxi order)
        {
            Update(order);
        }

        public abstract void Display();
        protected abstract void Update(ObservableTaxi order);
    }
}
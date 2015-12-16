using System;
using PSP3.Domain;

namespace PSP3.ViewModels
{
    public class TaxiView : ITaxiObserver, ITaxiView
    {
        protected int _id;

        public TaxiView(int id)
        {
            _id = id;
        }

        public void UpdateAfterTaxiChanged(ObservableTaxi order)
        {
            Console.Clear();
            Display();
        }

        public virtual void Display()
        {
            Console.WriteLine("Taxi --------- {0}", _id);
        }
    }
}
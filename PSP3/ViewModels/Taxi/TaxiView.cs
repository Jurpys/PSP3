using PSP3.DomainService;
using PSP3.UIService;

namespace PSP3.ViewModels
{
    public abstract class TaxiView : ITaxiObserver, IViewModel
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
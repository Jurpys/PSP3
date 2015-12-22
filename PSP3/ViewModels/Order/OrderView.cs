using PSP3.DomainService;
using PSP3.UIService;

namespace PSP3.ViewModels
{
    public abstract class OrderView : IOrderObserver, IViewModel
    {
        protected int _id;

        protected OrderView(int id)
        {
            _id = id;
        }

        public void UpdateAfterOrderChanged(ObservableOrder order)
        {
            Update(order);
        }

        protected abstract void Update(ObservableOrder order);
        public abstract void Display();
    }
}
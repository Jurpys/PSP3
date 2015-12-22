using PSP3.Domain;
using PSP3.DomainService;

namespace PSP3.DomainService
{
    public interface IOrderObserver
    {
        void UpdateAfterOrderChanged(ObservableOrder order);
    }
}
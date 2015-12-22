using System.Collections.Generic;
using PSP3.Domain;
using PSP3.DomainService;

namespace PSP3.DomainService
{
    public interface IOrderRepository
    {
        void Save(ObservableOrder order);
        ObservableOrder Find(int orderId);
        ICollection<ObservableOrder> FindAll();
        void Delete(int orderId);
    }
}
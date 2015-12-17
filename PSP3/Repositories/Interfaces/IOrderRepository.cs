using System.Collections.Generic;
using PSP3.Domain;

namespace PSP3.Repositories
{
    public interface IOrderRepository
    {
        void Save(ObservableOrder order);
        ObservableOrder Find(int orderId);
        ICollection<ObservableOrder> FindAll();
        void Delete(int orderId);
    }
}
using System.Collections.Generic;
using PSP3.Domain;
using PSP3.DomainService;

namespace PSP3.DomainService
{
    public interface ITaxiRepository
    {
        void Save(ObservableTaxi taxi);
        ObservableTaxi Find(int taxiId);
        ICollection<ObservableTaxi> FindAll();
        void Delete(int taxiId);
    }
}
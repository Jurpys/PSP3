using System.Collections.Generic;
using PSP3.Domain;

namespace PSP3.Repositories
{
    public interface ITaxiRepository
    {
        void Save(ObservableTaxi taxi);
        ObservableTaxi Find(int taxiId);
        ICollection<ObservableTaxi> FindAll();
        void Delete(int taxiId);
    }
}
using System.Collections;
using System.Collections.Generic;
using PSP3.Domain;

namespace PSP3.Repositories
{
    public class TaxiRepository
    {
        private int lastId = 1;

        private Dictionary<int, ITaxi> taxis = new Dictionary<int, ITaxi>();

        public void Save(ITaxi taxi)
        {
            if (taxi.Id == 0)
            {
                taxi.Id = lastId++;
            }

            taxis.Add(taxi.Id, taxi);
        }

        public ITaxi Find(int taxiId)
        {
            return taxis[taxiId];
        }

        public ICollection<ITaxi> FindAll()
        {
            return taxis.Values;
        }

        public void Delete(int taxiId)
        {
            taxis.Remove(taxiId);
        }
    }
}
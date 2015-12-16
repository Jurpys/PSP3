using System.Collections;
using System.Collections.Generic;
using PSP3.Domain;

namespace PSP3.Repositories
{
    public class ObservableTaxiRepository
    {
        private int lastId = 1;

        private Dictionary<int, ObservableTaxi> taxis = new Dictionary<int, ObservableTaxi>();

        public void Save(ObservableTaxi taxi)
        {
            if (taxi.Id == 0)
            {
                taxi.Id = lastId++;
            }

            taxis.Add(taxi.Id, taxi);
        }

        public ObservableTaxi Find(int taxiId)
        {
            return taxis[taxiId];
        }

        public Dictionary<int, ObservableTaxi>.ValueCollection FindAll()
        {
            return taxis.Values;
        }

        public void Delete(int taxiId)
        {
            taxis.Remove(taxiId);
        }
    }
}
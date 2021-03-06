﻿using PSP3.Domain;
using PSP3.DomainService;

namespace PSP3.DomainFactory
{
    public class SimpleTaxiCompanyFactory : IObservableTaxiCompanyFactory
    {
        public ObservableTaxi CreateTaxi()
        {
            return new Taxi(1.20);
        }

        public ObservableOrder CreateOrder(int destination)
        {
            return new Order(destination);
        }
    }
}
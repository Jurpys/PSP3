using System;
using PSP3.Domain;
using PSP3.DomainService;

namespace PSP3.DomainService
{
    public interface IObservableTaxiCompanyFactory
    {
        ObservableTaxi CreateTaxi();
        ObservableOrder CreateOrder(int destination);
    }
}
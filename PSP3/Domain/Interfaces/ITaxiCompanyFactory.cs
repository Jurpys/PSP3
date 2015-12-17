﻿namespace PSP3.Domain
{
    public interface IObservableTaxiCompanyFactory
    {
        ObservableTaxi CreateTaxi();
        ObservableOrder CreateOrder(int destination);
    }
}
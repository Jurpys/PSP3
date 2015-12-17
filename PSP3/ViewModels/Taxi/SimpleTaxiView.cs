using System;
using PSP3.Domain;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class SimpleTaxiView : TaxiView
    {
        private string DriverName;
        private int CurrentLocation;
        private double Tariff;
        private string OrderId;

        private TaxiViewAdapter adapter = new TaxiViewAdapter();

        ObservableTaxiRepository _taxiRepository;
        public SimpleTaxiView(int id, ObservableTaxiRepository taxiRepository) : base(id)
        {
            _taxiRepository = taxiRepository;
            Initialize();
        }

        public override void Display()
        {
            Console.WriteLine("Taxi {0}:", _id);
            Console.WriteLine("Driver's name: {0}", DriverName);
            Console.WriteLine($"Tariff: {Tariff}");
            Console.WriteLine($"OrderId: {OrderId}");
        }

        protected override void Update(ObservableTaxi taxi)
        {
            DriverName = taxi.DriverName;
            CurrentLocation = taxi.CurrentLocation;
            Tariff = taxi.Tariff;
            OrderId = adapter.GetOrderId(taxi);
        }

        private void Initialize()
        {
            var taxi = _taxiRepository.Find(_id);
            taxi.AttachObserver(this);

            Update(taxi);
        }
    }
}
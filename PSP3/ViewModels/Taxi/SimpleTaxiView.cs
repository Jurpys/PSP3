using System;
using PSP3.Domain;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class SimpleTaxiView : TaxiView
    {
        private string DriverName;

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
        }

        protected override void Update(ObservableTaxi taxi)
        {
            DriverName = taxi.DriverName;
        }

        private void Initialize()
        {
            var taxi = _taxiRepository.Find(_id);
            taxi.AttachObserver(this);

            Update(taxi);
        }
    }
}
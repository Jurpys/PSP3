using System;
using PSP3.Repositories;

namespace PSP3.ViewModels
{
    public class SimpleTaxiView : TaxiView
    {
        TaxiRepository _taxiRepository;
        public SimpleTaxiView(int id, TaxiRepository taxiRepository) : base(id)
        {
            _taxiRepository = taxiRepository;
        }

        public override void Display()
        {
            base.Display();
            var taxi = _taxiRepository.Find(_id);
            Console.WriteLine(taxi.DriverName);
        }
    }
}
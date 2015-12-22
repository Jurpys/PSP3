using System;
using PSP3.DomainService;

namespace PSP3.Domain
{
    public class DiscountedTaxi : ObservableTaxi
    {
        public DiscountedTaxi(double tariff) : base(tariff)
        {
        }

        public override double CalculateCurrentOrderPrice()
        {
            return Math.Round(_tariff * Math.Abs(_lastOrderDestination - _currentLocation) * 0.8, 2);
        }
    }
}
using PSP3.DomainService;

namespace PSP3.Domain
{
    public class Taxi : ObservableTaxi
    {
        public Taxi(double tariff) : base(tariff)
        {
        }
    }
}
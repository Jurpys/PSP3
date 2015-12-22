using PSP3.Controllers;

namespace PSP3.Views
{
    public class TaxiUIView
    {
        TaxiController _controller;
        public void Initialize(TaxiController controller)
        {
            controller = _controller;
        }
    }
}
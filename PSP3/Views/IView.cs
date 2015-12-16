using System.Security.Cryptography.X509Certificates;

namespace PSP3.Views
{
    public interface IView
    {
        void Update();
        void Initialize();
    }
}
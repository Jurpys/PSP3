using PSP3.Domain;
using PSP3.Repositories;

namespace PSP3.Commands
{
    public class CreateNewOrderCommand : ICommand
    {
        private readonly IObservableTaxiCompanyFactory _factory;
        private int _id;
        private readonly OrderRepository _repository;
        private readonly string _destination;

        public CreateNewOrderCommand(string destination, IObservableTaxiCompanyFactory factory, OrderRepository repository)
        {
            _destination = destination;
            _factory = factory;
            _repository = repository;
        }

        public void Execute()
        {
            var newOrder = _factory.CreateOrder(_destination);
            _repository.Save(newOrder);
            _id = newOrder.Id;
        }

        public void Undo()
        {
            _repository.Delete(_id);
        }
    }
}
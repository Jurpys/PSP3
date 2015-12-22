using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PSP3.CommandsService;
using PSP3.DomainService;

namespace PSP3.Commands
{
    public class CreateNewOrderCommand : ICommand
    {
        private readonly IObservableTaxiCompanyFactory _factory;
        private int _id;
        private readonly IOrderRepository _repository;
        private readonly int _destination;

        public CreateNewOrderCommand(int destination, IObservableTaxiCompanyFactory factory, IOrderRepository repository)
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

        public ICommand Clone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (CreateNewOrderCommand) formatter.Deserialize(ms);
            }
        }
    }
}
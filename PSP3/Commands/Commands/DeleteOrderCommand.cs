using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PSP3.CommandsService;
using PSP3.DomainService;

namespace PSP3.Commands
{
    public class DeleteOrderCommand : ICommand
    {
        private int _id;
        private readonly IOrderRepository _repository;
        private readonly ObservableOrder _order;

        public DeleteOrderCommand(int id, IOrderRepository repository)
        {
            _repository = repository;
            _id = id;
            _order = repository.Find(id);
        }

        public void Execute()
        {
            _repository.Delete(_id);
        }

        public void Undo()
        {
            _repository.Save(_order);
        }

        public ICommand Clone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (DeleteOrderCommand)formatter.Deserialize(ms);
            }
        }
    }
}
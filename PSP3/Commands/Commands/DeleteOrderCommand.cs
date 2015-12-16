using PSP3.Domain;
using PSP3.Repositories;

namespace PSP3.Commands
{
    public class DeleteOrderCommand : ICommand
    {
        private int _id;
        private readonly OrderRepository _repository;
        private readonly ObservableOrder _order;

        public DeleteOrderCommand(int id, OrderRepository repository)
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
    }
}
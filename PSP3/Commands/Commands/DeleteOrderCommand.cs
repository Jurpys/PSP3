using PSP3.Domain;
using PSP3.Repositories;

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
    }
}
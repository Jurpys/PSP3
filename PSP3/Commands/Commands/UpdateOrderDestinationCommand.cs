using PSP3.Repositories;

namespace PSP3.Commands
{
    public class UpdateOrderDestinationCommand : ICommand
    {
        OrderRepository _repository;
        int _id;
        int _oldDest;
        int _newDest;

        public UpdateOrderDestinationCommand(int id, int newDest, OrderRepository orderRepository)
        {
            _repository = orderRepository;
            _id = id;
            _newDest = newDest;
            _oldDest = orderRepository.Find(id).Destination;
        }

        public void Execute()
        {
            _repository.Find(_id).Destination = _newDest;
        }

        public void Undo()
        {
            _repository.Find(_id).Destination = _oldDest;
        }
    }
}
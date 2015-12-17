using PSP3.Repositories;

namespace PSP3.Commands
{
    public class UpdateOrderDestinationCommand : ICommand
    {
        IOrderRepository _repository;
        int _id;
        int _oldDest;
        int _newDest;

        public UpdateOrderDestinationCommand(int id, int newDest, IOrderRepository IOrderRepository)
        {
            _repository = IOrderRepository;
            _id = id;
            _newDest = newDest;
            _oldDest = IOrderRepository.Find(id).Destination;
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
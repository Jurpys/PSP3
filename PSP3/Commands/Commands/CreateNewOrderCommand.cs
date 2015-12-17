﻿using PSP3.DomainFactory;
using PSP3.Repositories;

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
    }
}
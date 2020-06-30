using Flunt.Notifications;
using ToDo.Domain.Commands;
using ToDo.Domain.Commands.Contracts;
using ToDo.Domain.Entities;
using ToDo.Domain.Handlers.Contracts;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Handlers
{
    public class ToDoHandler : 
        Notifiable, 
        IHandler<CreateToDoCommand>,
        IHandler<UpdateToDoCommand>,
        IHandler<MarkToDoAsDoneCommand>,
        IHandler<MarkToDoAsUndoneCommand>

    {
        private readonly IToDoRepository _repository;

        public ToDoHandler (IToDoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateToDoCommand command)
        {
            //Fast Fail Validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Sua tarefa está incorreta!", command.Notifications);

            //Gera o ToDoItem
            var item = new ToDoItem(command.Title, command.User, command.Date);

            //Persiste no DB
            _repository.Create(item);

            return new GenericCommandResult(true, "Tarefa salva", item);
        }

        public ICommandResult Handle(UpdateToDoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Sua tarefa está incorreta!", command.Notifications);

            //Gera o ToDoItem
            var item = _repository.GetById(command.Id, command.User);

            //Altera titulo
            item.UpdateTitle(command.Title);

            //Persiste no DB
            _repository.Update(item);

            return new GenericCommandResult(true, "Tarefa atualizada", item);
        }

        public ICommandResult Handle(MarkToDoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Sua tarefa está incorreta!", command.Notifications);

            var ToDo = _repository.GetById(command.Id, command.User);

            ToDo.MarkAsDone();

            _repository.Update(ToDo);

            return new GenericCommandResult(true, "Tarefa Salva", ToDo.Date);

        }

        public ICommandResult Handle(MarkToDoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Sua tarefa está incorreta!", command.Notifications);

            var ToDo = _repository.GetById(command.Id, command.User);

            ToDo.MarkAUndone();

            _repository.Update(ToDo);

            return new GenericCommandResult(true, "Tarefa Salva", ToDo.Date);
        }
    }
}
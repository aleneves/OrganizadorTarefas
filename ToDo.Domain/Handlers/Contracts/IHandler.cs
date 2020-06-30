using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle (T command);
    }
}
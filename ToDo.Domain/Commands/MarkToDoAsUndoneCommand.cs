using System;
using ToDo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ToDo.Domain.Commands
{
    public class MarkToDoAsUndoneCommand : Notifiable, ICommand
    {
        public MarkToDoAsUndoneCommand() { }

        public MarkToDoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User, 4, "User", "Informe um usuário com pelo menos 4 caracteres.")
            );
        }
    }
}
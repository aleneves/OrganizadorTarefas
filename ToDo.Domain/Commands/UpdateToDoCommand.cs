using System;
using ToDo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ToDo.Domain.Commands
{
    public class UpdateToDoCommand : Notifiable, ICommand
    {
        public UpdateToDoCommand() { }

        public UpdateToDoCommand(Guid id, string user, string title)
        {
            Id = id;
            User = user;
            Title = title;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public string Title { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User, 4, "User", "Informe um usuário com pelo menos 4 caracteres.")
                    .HasMinLen(Title, 4, "Title", "Informe um título com pelo menos 4 caracteres.")
            );
        }
    }
}
using System;
using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands
{
    public class CreateToDoCommand : Notifiable, ICommand
    {
        public string Title { get; set; }        
        public DateTime Date { get; set; }
        public string User { get; set; }

        public CreateToDoCommand() {}

        public CreateToDoCommand(string title, string user, DateTime date)
        {
            Title = title;
            Date = date;
            User = user;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 4, "Title", "Informe um título com pelo menos 3 caracteres.")
                    .HasMinLen(User, 4, "User", "Informe um usuário com pelo menos 4 caracteres.")                    
            );
        }
    }
}
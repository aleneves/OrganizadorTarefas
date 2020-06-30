using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Commands;
using ToDo.Domain.Entities;
using ToDo.Domain.Handlers;
using ToDo.Domain.Repositories;

namespace ToDo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<ToDoItem> GetAll(
            [FromServices]IToDoRepository repository
        )
        {
            return repository.GetAll("alexandreneves");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<ToDoItem> GetAllDone(
            [FromServices] IToDoRepository repository
        )
        {
            return repository.GetAllDone("alexandreneves");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<ToDoItem> GetAllUndone(
            [FromServices] IToDoRepository repository
        )
        {
            return repository.GetAllUndone("alexandreneves");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<ToDoItem> GetDoneForToday(
            [FromServices] IToDoRepository repository
        )
        {
            return repository.GetByPeriod(
                "alexandreneves",
                DateTime.Now.Date,
                true
                );
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<ToDoItem> GetUndoneForTomorrow(
            [FromServices] IToDoRepository repository
        )
        {
            return repository.GetByPeriod(
                "alexandreneves",
                DateTime.Now.Date.AddDays(1),
                false
                );
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<ToDoItem> GetDoneForTomorrow(
            [FromServices] IToDoRepository repository
        )
        {
            return repository.GetByPeriod(
                "alexandreneves",
                DateTime.Now.Date.AddDays(1),
                true
                );
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<ToDoItem> GetUndoneForToday(
            [FromServices] IToDoRepository repository
        )
        {
            return repository.GetByPeriod(
                "alexandreneves",
                DateTime.Now.Date,
                false
                );
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody]CreateToDoCommand command,
            [FromServices]ToDoHandler handler
        )
        {
            command.User = "alexandreneves";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateToDoCommand command,
            [FromServices] ToDoHandler handler
        )
        {
            command.User = "alexandreneves";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkToDoAsDoneCommand command,
            [FromServices] ToDoHandler handler
        )
        {
            command.User = "alexandreneves";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] MarkToDoAsUndoneCommand command,
            [FromServices] ToDoHandler handler
        )
        {
            command.User = "alexandreneves";
            return (GenericCommandResult)handler.Handle(command);
        }

    }

}
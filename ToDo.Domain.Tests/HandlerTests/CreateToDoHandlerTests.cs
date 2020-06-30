using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Commands;
using ToDo.Domain.Handlers;
using ToDo.Domain.Tests.Repositories;

namespace ToDo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateToDoHandlerTests
    {
        private readonly CreateToDoCommand _invalidCommand = new CreateToDoCommand("", "", DateTime.Now);

        private readonly CreateToDoCommand _validCommand = new CreateToDoCommand("Titulo da tarefa", "Usuario", DateTime.Now);

        private readonly ToDoHandler _handler = new ToDoHandler(new FakeToDoRepository());

        private GenericCommandResult _genericResult = new GenericCommandResult();

        public CreateToDoHandlerTests()
        {
            
        }

        [TestMethod]
        public void Dado_Um_Comando_Invalido_Deve_Parar_Execucao()
        {
            _genericResult = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_genericResult.Sucess, false);
        }

        [TestMethod]
        public void Dado_Um_Comando_Valido_Deve_Criar_Tarefa()
        {
            _genericResult = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_genericResult.Sucess, true);
        }
    }
}

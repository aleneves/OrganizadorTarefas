using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Commands;

namespace ToDo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateToDoCommandTests
    {
        private readonly CreateToDoCommand _invalidCommand = new CreateToDoCommand("", "", DateTime.Now);

        private readonly CreateToDoCommand _validCommand = new CreateToDoCommand("Titulo da tarefa", "Usuario", DateTime.Now);

        public CreateToDoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Comando_Invalido_Test()
        {
            Assert.AreEqual(_invalidCommand.Invalid, true);
        }

        [TestMethod]
        public void Comando_Valido_Test()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}

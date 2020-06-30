using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Tests.CommandTests
{
    [TestClass]
    public class ToDoItemTests
    {
        private readonly ToDoItem _validToDo = new ToDoItem("Titulo Aqui", "alexandreneves", DateTime.Now);

        [TestMethod]
        public void Data_um_novo_toDo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_validToDo.Done, false);
        }
    }

}
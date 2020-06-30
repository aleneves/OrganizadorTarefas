using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Entities;
using ToDo.Domain.Queries;

namespace ToDo.Domain.Tests.QueryTests
{
    [TestClass]
    public class ToDoQueriesTests
    {
        private List<ToDoItem> _items;

        public ToDoQueriesTests()
        {
            _items = new List<ToDoItem>();
            _items.Add(new ToDoItem("Tarefa 1", "Cecilia Jardim", Convert.ToDateTime("2019-10-01")));
            _items.Add(new ToDoItem("Tarefa 2", "Cecilia Jardim", Convert.ToDateTime("2019-11-01")));
            _items.Add(new ToDoItem("Tarefa 3", "Alexandre Neves",Convert.ToDateTime("2019-12-01")));
            _items.Add(new ToDoItem("Tarefa 4", "Alexandre Neves", Convert.ToDateTime("2019-12-01")));
            _items.Add(new ToDoItem("Tarefa 5", "Cecilia Jardim", Convert.ToDateTime("2019-10-01")));
            _items.Add(new ToDoItem("Tarefa 6", "Cecilia Jardim",Convert.ToDateTime("2019-10-01")));
        }


        [TestMethod]
        public void Deve_retornar_todas_as_tarefas_de_um_usuario()
        {
            var result = _items.AsQueryable().Where(ToDoQueries.GetAll("Alexandre Neves"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_todas_as_tarefas_concluidas_de_um_usuario()
        {            
            var result = _items.AsQueryable().Where(ToDoQueries.GetAllDone("Alexandre Neves"));           
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_todas_as_tarefas_em_endamento_de_um_usuario()
        {
            var result = _items.AsQueryable().Where(ToDoQueries.GetAllUndone("Alexandre Neves"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_todas_as_tarefas_de_uma_data_para_um_usuario()
        {
            var result = _items.AsQueryable().Where(ToDoQueries.GetByPeriod("Alexandre Neves",Convert.ToDateTime("2019-12-01"), false));
            Assert.AreEqual(2, result.Count());
        }
    }
}
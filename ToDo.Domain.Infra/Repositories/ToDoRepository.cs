using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Infra.Contexts;
using ToDo.Domain.Queries;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Infra.Repositories
{

    public class ToDoRepository : IToDoRepository
    {

        private readonly DataContext _context;

        public ToDoRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Create(ToDoItem todo)
        {
            _context.ToDos.Add(todo); //adiciona item no contexto
            _context.SaveChanges(); //persistindo no BD
        }

        public IEnumerable<ToDoItem> GetAll(string user)
        {
            return _context.ToDos
                .AsNoTracking()
                .Where(ToDoQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<ToDoItem> GetAllDone(string user)
        {
            return _context.ToDos
                .AsNoTracking()
                .Where(ToDoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<ToDoItem> GetAllUndone(string user)
        {
            return _context.ToDos
                .AsNoTracking()
                .Where(ToDoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public ToDoItem GetById(Guid id, string user)
        {
            return _context.ToDos
                .FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public IEnumerable<ToDoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.ToDos
                .AsNoTracking()
                .Where(ToDoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(ToDoItem todo)
        {
            //dizendo ao contexto que houve alteração no item
            _context.Entry(todo).State = EntityState.Modified;
            //persistindo no BD
            _context.SaveChanges(); 
        }
    }
}
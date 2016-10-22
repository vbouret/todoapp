using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DataAccess.Model;

namespace TodoApp.DataAccess.Repository
{
    /// <summary>
    /// Tentative SqlServer Repository which implements the same interface, could be use for future change of persistency layer.
    /// </summary>
    public class TodoItemSqlRepository : BaseRepository, IRepository<TodoItem, string>
    {
        public TodoItemSqlRepository(string dataSourceConnectionString, string databaseName) : base(dataSourceConnectionString, databaseName)
        {
        }

        public IEnumerable<TodoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            await Task.Delay(0); //To remove warning
            throw new NotImplementedException();
        }

        public TodoItem GetItem(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DataAccess.Model;

namespace TodoApp.DataAccess.Service
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetAllItemsAsync();
        IEnumerable<TodoItem> GetAllItems();
        TodoItem GetItem(string itemId);
        TodoItem CreateItem(TodoItem item);
        TodoItem UpdateItem(TodoItem item);
        void DeleteItem(string itemId);
        TodoItem ToggleTodoItemCompletionStatus(string itemId);
    }
}

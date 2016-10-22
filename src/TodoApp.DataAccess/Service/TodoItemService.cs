using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DataAccess.Model;
using TodoApp.DataAccess.Repository;

namespace TodoApp.DataAccess.Service
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IRepository<TodoItem, string> todoItemRepository;

        public TodoItemService(IRepository<TodoItem, string> todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllItemsAsync()
        {
            return await todoItemRepository.GetAllAsync();
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            return todoItemRepository.GetAll();
        }

        public TodoItem GetItem(string itemId)
        {
            return todoItemRepository.GetItem(itemId);
        }

        //Utility method for setting the completion status
        public TodoItem ToggleTodoItemCompletionStatus(string itemId)
        {
            var item = todoItemRepository.GetItem(itemId);

            if (item == null)
            {
                throw new Exception("Unable to find item " + itemId + " in the respository.");
            }

            //Toggle the status
            item.IsCompleted = !item.IsCompleted;
            if (item.IsCompleted)
            {
                item.CompletionDate = DateTime.Now;
            }
            UpdateItem(item);

            return item;
        }

        public TodoItem CreateItem(TodoItem item)
        {
            item.CreationDate = DateTime.Now;
            item.LastUpdateDate = DateTime.Now; //Force creation and update date
            item.Id = Guid.NewGuid().ToString();
            todoItemRepository.Add(item);

            return item;
        }

        public void DeleteItem(string itemId)
        {
            todoItemRepository.Delete(itemId);
        }

        public TodoItem UpdateItem(TodoItem item)
        {
            //Force the modification date
            item.LastUpdateDate = DateTime.Now;
            todoItemRepository.Update(item);

            return item;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DataAccess.Model;
using TodoApp.DataAccess.Repository;
using TodoApp.DataAccess.Service;
using Xunit;

namespace TodoApp.Test
{
    public class TodoItemServiceTest
    {
        private string connectionString = "mongodb://user:password@ds044989.mlab.com:44989/cbctodoapp";
        private string databaseName = "cbctodoapp";

        [Fact]
        public void When_AddWithoutGuid_Then_CanGetSameItem()
        {
            var description = "ItemAdded";
            var service = new TodoItemService(new TodoItemMongoRepository(connectionString, databaseName)); //It would be better to use Autofac in the same way in the unit tests

            var itemCreated = service.CreateItem(new TodoItem() { Description = description, DueDate = new DateTime(2016, 10, 31), IsCompleted = false, CompletionDate = new DateTime(0001, 01, 01) });
            var itemFetched = service.GetItem(itemCreated.Id);

            Assert.Equal(itemFetched.Id, itemCreated.Id);
        }

    }
}

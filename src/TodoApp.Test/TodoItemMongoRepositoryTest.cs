using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DataAccess.Model;
using TodoApp.DataAccess.Repository;
using Xunit;

namespace TodoApp.Test
{
    public class TodoItemMongoRepositoryTest
    {
        [Fact]
        public void When_GetAll_ReturnsMultipleObjects()
        {
            var repo = new TodoItemMongoRepository();

            var result = repo.All;

            Assert.NotEmpty(result);
        }

        [Fact]
        public void When_Add_Then_OneItemMore()
        {
            var repo = new TodoItemMongoRepository();

            var countBefore = repo.All.Count();
            repo.Add(new TodoItem() { Id = Guid.NewGuid().ToString(), Description = "Item2", DueDate = new DateTime(2016, 10, 31), IsCompleted = false, CompletionDate = new DateTime(0001, 01, 01) });
            var countAfter = repo.All.Count();

            Assert.Equal(countBefore, countAfter - 1);
        }

        [Fact]
        public void When_Add_Then_CanGetSameItem()
        {
            var guid = Guid.NewGuid().ToString();
            var description = "ItemAdded " + guid.ToString();
            var repo = new TodoItemMongoRepository();

            repo.Add(new TodoItem() { Id = guid, Description = description, DueDate = new DateTime(2016, 10, 31), IsCompleted = false, CompletionDate = new DateTime(0001, 01, 01) });
            var item = repo.GetItem(guid);

            Assert.Equal(item.Description, description);
        }
    }
}

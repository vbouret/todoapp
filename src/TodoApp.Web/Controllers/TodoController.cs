using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.DataAccess.Service;
using TodoApp.DataAccess.Model;

namespace TodoApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoItemService todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }

        // GET: api/todo/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await todoItemService.GetAllItemsAsync();
                return Ok(items);
            }
            catch (Exception)
            {
                //TODO: Log something at this point or have a better error handling strategy (something global)
                return BadRequest();
            }

        }

        // GET: api/todo/{guid}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var item = todoItemService.GetItem(id);
                return Ok(item);
            }
            catch (Exception)
            {
                //TODO: Log something at this point or have a better error handling strategy (something global)
                return BadRequest();
            }
        }

        // POST: api/todo
        [HttpPost]
        public IActionResult Post([FromBody]TodoItem item)
        {
            try
            {
                todoItemService.CreateItem(item);

                return Ok("Item was added successfully");
            }
            catch (Exception)
            {
                //TODO: Log something at this point or have a better error handling strategy (something global)
                return BadRequest(); //Have a better return code (500)
            }
        }

        // PUT: api/todo/{guid}
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]TodoItem item)
        {
            try
            {
                todoItemService.UpdateItem(item);

                return Ok("Item was updated successfully");
            }
            catch (Exception)
            {
                //TODO: Log something at this point or have a better error handling strategy (something global)
                return BadRequest(); //Have a better return code (500)
            }
        }

        // DELETE: api/todo/{guid}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                todoItemService.DeleteItem(id);

                return Ok("Item was deleted successfully");
            }
            catch (Exception)
            {
                //TODO: Log something at this point or have a better error handling strategy (something global)
                return BadRequest(); //Have a better return code (500)
            }
        }

        // POST: api/todo/toggleStatus/{guid}
        [HttpPost("toggleStatus/{id}")]
        public IActionResult ToggleStatus(string id)
        {
            try
            {
                todoItemService.ToggleTodoItemCompletionStatus(id);
                                
                return Ok("Item was toggled sucessfully");
            }
            catch (Exception)
            {
                //TODO: Log something at this point or have a better error handling strategy (something global)
                return BadRequest(); //Have a better return code (500)
            }
        }

    }
}

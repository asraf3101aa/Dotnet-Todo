using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo_list.Data;
using Todo_list.Models;
using Todo_list.Models.Domain;

namespace Todo_list.Controllers
{
    [Authorize]
    public class TodosController : Controller
    {
        private readonly MVCTodoDbContext mvcTodoDbContext;

        public TodosController(MVCTodoDbContext mvcTodoDbContext)
        {
            this.mvcTodoDbContext = mvcTodoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todos = await mvcTodoDbContext.Todos.ToListAsync();
            return View(todos);

        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTodoViewModel addTodoRequest) 
        {
            var todo = new Todo()
            {
                Id = Guid.NewGuid(),
                Task = addTodoRequest.Task,
                Date = addTodoRequest.Date.ToUniversalTime(),
                Description = addTodoRequest.Description,
            };

            await mvcTodoDbContext.Todos.AddAsync(todo);
            await mvcTodoDbContext.SaveChangesAsync(); 
            return RedirectToAction("Add");
        
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
            var todo = await mvcTodoDbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo != null)
            {
                var viewModel = new UpdateTodoViewModel()
                {
                    Id = todo.Id,
                    Task = todo.Task,
                    Date = todo.Date.ToUniversalTime(),
                    Description = todo.Description,
                };
                return await Task.Run(() => View("View",viewModel));

            }
            
            return RedirectToAction("Index"); 
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateTodoViewModel model)
        {
            var todo = await mvcTodoDbContext.Todos.FindAsync(model.Id);
            if (todo != null)
            {
                todo.Task = model.Task;
                todo.Date = model.Date.ToUniversalTime();
                todo.Description = model.Description;
                await mvcTodoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateTodoViewModel model)
        {
            var todo = await mvcTodoDbContext.Todos.FindAsync(model.Id);
            if(todo != null)
            {
                mvcTodoDbContext.Todos.Remove(todo);
                await mvcTodoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

    }
}

using CleanProgMgt.Application;
using CleanProgMgt.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanProgMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService tasksService;

        public TasksController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public ActionResult<List<Tasks>> Get()
        {
            var tasksFromService = tasksService.GetAllTasks();
            return Ok(tasksFromService);
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}", Name = "GetTaskById")]
        public ActionResult<Tasks> Get(int id)
        {
            var tasksFromService = tasksService.GetTaskById(id);

            return Ok(tasksFromService);
        }

        // POST api/<TasksController>
        [HttpPost]
        public ActionResult<Tasks> Post(Tasks task)
        {
            var Task = tasksService.CreateTask(task);
            //return Ok(Task);
            //return CreatedAtRoute("Get", new { Id = Task.Id }, Task);
            return CreatedAtRoute(nameof(Get), new { Id = Task.Id }, Task);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

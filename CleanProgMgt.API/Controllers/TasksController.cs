using AutoMapper;
using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Application.Services.Task;
using CleanProgMgt.Application.Services.Users;
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
        private readonly IMapper mapper;

        public TasksController(ITasksService tasksService, IMapper mapper)
        {
            this.tasksService = tasksService;
            this.mapper = mapper;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public ActionResult<List<TaskReadDto>> Get()
        {
            var tasksFromService = tasksService.GetAllTasks();
            return Ok(mapper.Map<IEnumerable<TaskReadDto>>(tasksFromService));
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}", Name = "GetTaskById")]
        public ActionResult<TaskReadDto> GetTaskById(int id)
        {
            var tasksFromService = tasksService.GetTaskById(id);

            return Ok(mapper.Map<TaskReadDto>(tasksFromService));
        }

        // POST api/<TasksController>
        [HttpPost]
        public ActionResult<TaskReadDto> Post(TaskCreateDto task)
        {
            
            var taskModel = mapper.Map<Tasks>(task);
            var serviceTask = tasksService.CreateTask(taskModel);

            var taskDto = mapper.Map<TaskReadDto>(serviceTask);

            return CreatedAtRoute(nameof(GetTaskById), new { Id = taskDto.Id }, taskDto);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public ActionResult<Task> Put(int id, TaskCreateDto taskChanges)
        {
            //var task = tasksService.GetTaskById(id);
            //if (task != null)
            //{
            //    tasksService.Update(taskChanges);
            //}

            return NoContent();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Tasks task = tasksService.GetTaskById(id);
            if (task != null)
            {
                tasksService.Delete(id);
            }

            return NoContent();
        }
    }
}

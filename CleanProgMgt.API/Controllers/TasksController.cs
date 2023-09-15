using AutoMapper;
using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Application.Services.Notifications;
using CleanProgMgt.Application.Services.Task;
using CleanProgMgt.Application.Services.Users;
using CleanProgMgt.Domain;
using CleanProgMgt.Domain.Enums;
using Hangfire;
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
        private readonly IBackgroundJobClient backgroundJobClient;
        private readonly INotificationsService notificationService;

        public TasksController(ITasksService tasksService, IMapper mapper, 
                IBackgroundJobClient backgroundJobClient, INotificationsService notificationService)
        {
            this.tasksService = tasksService;
            this.mapper = mapper;
            this.backgroundJobClient = backgroundJobClient;
            this.notificationService = notificationService;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public ActionResult<List<TaskReadDto>> Get()
        {
            //var due = tasksService.GetTasksDueWithin48Hours();

            var tasksFromService = tasksService.GetAllTasks();
            if(tasksFromService == null){
                    return NotFound("Task not found.");
                }
            return Ok(mapper.Map<IEnumerable<TaskReadDto>>(tasksFromService));
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}", Name = "GetTaskById")]
        public ActionResult<TaskReadDto> GetTaskById(int id)
        {
            var tasksFromService = tasksService.GetTaskById(id);
             if(tasksFromService == null){
                    return NotFound("Task not found.");
                }
                
            return Ok(mapper.Map<TaskReadDto>(tasksFromService));
        }

        // POST api/<TasksController>
        [HttpPost]
        public ActionResult<TaskReadDto> Post(TaskCreateDto task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
               
                var taskModel = mapper.Map<Tasks>(task);
                var serviceTask = tasksService.CreateTask(taskModel);

                var taskDto = mapper.Map<TaskReadDto>(serviceTask);

                var notification = new Notification {
                    Due_date = DateTime.Now,
                    Message = "New task assigned",
                    Type = NotificationTypes.new_task,
                    Status = NotificationStatus.Unread,
                    UserId = 1
                };

                backgroundJobClient.Enqueue<INotificationsService>(notificationService =>
                notificationService.AddNotification(notification)
                );

                //var personName = "kc";
                //backgroundJobClient.Schedule(() => 
                //    Console.WriteLine("The name is " + personName),
                //    TimeSpan.FromSeconds(5));

                return CreatedAtRoute(nameof(GetTaskById), new { Id = taskDto.Id }, taskDto);
            }
            return Ok();
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public ActionResult<Task> Put(int id, TaskCreateDto taskChanges)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                var task = tasksService.GetTaskById(id);
                if (task != null)
                {
                    var serviceTask = tasksService.Update(id,taskChanges);
                    var taskDto = mapper.Map<TaskReadDto>(serviceTask);

                    if(taskChanges.status == Status.Completed){
                        var notification = new Notification {
                        Due_date = DateTime.Now,
                        Message = "Task is Completed",
                        Type = NotificationTypes.status_update,
                        Status = NotificationStatus.Read,
                        UserId = 1
                        
                        };

                        backgroundJobClient.Enqueue<INotificationsService>(notificationService =>
                        notificationService.AddNotification(notification)
                        );
                    }
                }
                 else{
                    return NotFound("Task not found.");
                }
            }

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
             else{
                    return NotFound("Task not found.");
                }
            

            return NoContent();
        }

         [HttpGet("GetTasksByStatusOrPriority", Name = "GetTasksByStatusOrPriority")]
        public ActionResult<IEnumerable<TaskReadDto>> GetTasksByStatusOrPriority([FromQuery] string ? status, [FromQuery] string ? priority)
        {
            if(status == null && priority ==null){
                return NotFound("No tasks found.");
            }

            var tasks = tasksService.GetTasksByStatusOrPriority(status, priority);

            if (tasks == null || tasks.Count == 0)
            {
                return NotFound("No tasks found.");
            }

            return Ok(tasks);
        }

        [HttpGet("due-this-week")]
        public ActionResult<IEnumerable<TaskReadDto>> GetTasksDueThisWeek()
        {
            var currentWeekTasks = tasksService.GetTasksDueThisWeek();

            if (currentWeekTasks == null || currentWeekTasks.Count == 0)
            {
                return NotFound("No tasks due this week.");
            }

            return Ok(currentWeekTasks);
        }

        [HttpGet("change-task-status")]
        public ActionResult<IEnumerable<TaskReadDto>> ChangeTaskStatus(string id, string status)
        {
             var tasks = tasksService.ChangeTaskStatus(id, status);

            if (tasks == null)
            {
                return NotFound("Failed to change status");
            }

            return NoContent();
        }

    }
}

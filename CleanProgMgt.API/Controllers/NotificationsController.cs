using AutoMapper;
using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Application.Services.Notifications;
using CleanProgMgt.Application.Services.Task;
using CleanProgMgt.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanProgMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService notificationsService;
        private readonly IMapper mapper;

        public NotificationsController(INotificationsService notificationsService, IMapper mapper)
        {
            this.notificationsService = notificationsService;
            this.mapper = mapper;
        }
        // NotificationsController.cs
        [HttpPut("{notificationId}/mark-read")]
        public IActionResult MarkNotificationAsRead(int notificationId)
        {
            if (notificationsService.MarkNotification(notificationId, true))
                return Ok();

            return NotFound();
        }

        [HttpPut("{notificationId}/mark-unread")]
        public IActionResult MarkNotificationAsUnread(int notificationId)
        {
            if (notificationsService.MarkNotification(notificationId, false))
                return Ok();

            return NotFound();
        }
        //GET: api/<NotificationsController>
        [HttpGet]

        public ActionResult<List<NotificationReadDto>> Get()
        {
            var notificationFromService = notificationsService.GetAllNotifications();
            return Ok(mapper.Map<IEnumerable<NotificationReadDto>>(notificationFromService));
        }

        // GET api/<NotificationsController>/5
        [HttpGet("{id}", Name = "GetNotificationById")]
        public ActionResult<NotificationReadDto> GetNotificationById(int id)
        {
            var notificationFromService = notificationsService.GetNotificationById(id);

            return Ok(mapper.Map<NotificationReadDto>(notificationFromService));
        }

        //POST api/<NotificationsController>
        [HttpPost]
        public ActionResult<NotificationReadDto> Post(NotificationCreateDto notification)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                var notificationModel = mapper.Map<Notification>(notification);
                var servicenotification = notificationsService.AddNotification(notificationModel);

                var notificationDto = mapper.Map<NotificationReadDto>(servicenotification);
                return CreatedAtRoute(nameof(GetNotificationById), new { Id = notificationDto.Id }, notificationDto);
            }
            return Ok();
           
        }


        // PUT api/<NotificationsController>/5
        [HttpPut("{id}")]
        public ActionResult<NotificationReadDto> Put(int id, NotificationCreateDto notificationChanges)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                var notification = notificationsService.GetNotificationById(id);
                if (notification != null)
                {
                    var serviceNotification = notificationsService.Update(id, notificationChanges);
                    var taskDto = mapper.Map<NotificationReadDto>(serviceNotification);
                }
                 else{
                    return NotFound("Notification not found.");
                }
            }

            return NoContent();
        }

        //DELETE api/<NotificationsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Notification notification = notificationsService.GetNotificationById(id);
            if (notification != null)
            {
                notificationsService.Delete(id);
            }
             else{
                    return NotFound("Notification not found.");
                }

            return NoContent();
        }
    }
}

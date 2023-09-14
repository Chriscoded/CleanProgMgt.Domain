using CleanProgMgt.Application.Services.Task;
using CleanProgMgt.Application.Services.Users;
using CleanProgMgt.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using CleanProgMgt.Application.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanProgMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUserService userService,IMapper mapper, ILogger<UsersController> logger)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.logger = logger;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<UserReadDto> Get()
        {
            //IEnumerable<
            
            var usersFromService = userService.GetAllUsers();
            return Ok(mapper.Map<IEnumerable<UserReadDto>>(usersFromService));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}",  Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var userFromService = userService.GetUserById(id);

            return Ok(mapper.Map<UserReadDto>(userFromService));
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<UserReadDto> Post(UserCreateDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                //logger.LogError($"iji{user}");
                var userModel = mapper.Map<User>(user);
                var serviceUser = userService.CreateUser(userModel);
                var userDto = mapper.Map<UserReadDto>(serviceUser);
                 return CreatedAtRoute(nameof(GetUserById), new { Id = userDto.Id }, userDto);
            }
           return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<TaskReadDto> Put(int id, UserCreateDto userChanges)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                var serviceUser = userService.Update(id,userChanges);
                if(serviceUser != null){
                    var userDto = mapper.Map<UserReadDto>(serviceUser);
                }
                 else{
                    return NotFound("User not found.");
                }
                

            }

            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            User user = userService.GetUserById(id);
            if (user != null)
            {
                userService.Delete(id);
            }
             else{
                    return NotFound("User not found.");
                }

            return NoContent();
        }
    }
}

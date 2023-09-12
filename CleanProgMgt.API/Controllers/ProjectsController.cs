using AutoMapper;
using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Application.Services.Projects;
using CleanProgMgt.Application.Services.Task;
using CleanProgMgt.Application.Services.Users;
using CleanProgMgt.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanProgMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly IMapper mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            this.projectService = projectService;
            this.mapper = mapper;
        }
        // GET: api/<ProjectsController>
        [HttpGet]
        public ActionResult<List<ProjectReadDto>> Get()
        {
            var projectFromService = projectService.GetAllProjects();
            return Ok(mapper.Map<IEnumerable<ProjectReadDto>>(projectFromService));
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}", Name = "GetProjectById")]
        public ActionResult<ProjectReadDto> GetProjectById(int id)
        {
            var projectFromService = projectService.GetProjectById(id);

            return Ok(mapper.Map<ProjectReadDto>(projectFromService));
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public ActionResult<ProjectReadDto> Post(ProjectCreateDto project)
        {
            var projectModel = mapper.Map<Project>(project);
            var proj = projectService.CreateProject(projectModel);

            var projectDto = mapper.Map<ProjectReadDto>(proj);
            //return Ok(Task);
            //return CreatedAtRoute("Get", new { Id = Task.Id }, Task);
            return CreatedAtRoute(nameof(GetProjectById), new { Id = projectDto.Id }, projectDto);
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public ActionResult<ProjectReadDto> Put(int id, ProjectCreateDto projectChanges)
        {
            Project project = projectService.GetProjectById(id);
            if (project != null)
            {
                var projectModel = mapper.Map<Project>(projectChanges);
                var serviceProject = projectService.Update(projectModel);
                var userDto = mapper.Map<UserReadDto>(serviceProject);

                //projectService.Update(projectChanges);
            }

            return NoContent();
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //Project project = projectService.GetProjectById(id);
            //if (project != null)
            //{
            //    projectService.Delete(id);
            //}

            return NoContent();
        }
    }
}

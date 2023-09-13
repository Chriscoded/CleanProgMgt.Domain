using AutoMapper;
using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            //Project is source while projectReadDto is target
            CreateMap<Project, ProjectReadDto>();
            CreateMap<ProjectCreateDto, Project>();

            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();

            CreateMap<Tasks, TaskReadDto>();
            CreateMap<TaskCreateDto, Tasks>();

            CreateMap<Notification, NotificationReadDto>();
            CreateMap<NotificationCreateDto, Notification>();
        }
    }
}

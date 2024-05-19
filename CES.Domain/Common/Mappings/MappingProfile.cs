using AutoMapper;
using CES.Application.DTOs;
using CES.Application.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CreatCourseDTO>();
            CreateMap<CourseType, CreatCorseTypeDTO>();
            CreateMap<Department, CreatDepartmentDTO>();
            CreateMap<Level, CreatLevelDTO>();
            CreateMap<Instructor, CreatInstructorDTO>();
            CreateMap<Student, CreatStudentDto>();
            CreateMap<StudentCourse, StudentCourseDTO>();
            
        }
    }
}

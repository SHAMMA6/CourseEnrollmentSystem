using CES.Application.DTOs;
using CES.Application.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Application.Interfaces
{
    public interface IStudentCourseService
    {
        Task EnrollStudentInCourseAsync(StudentCourseDTO studentCourseDTO);
        Task<List<Student>> GetStudentsEnrolledInCourseAsync(int courseId);
        Task<List<Course>> GetCoursesEnrolledByStudentAsync(int studentId);
    }
}

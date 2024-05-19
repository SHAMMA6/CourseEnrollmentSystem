using AutoMapper;
using CES.Application.DTOs;
using CES.Application.Entitys;
using CES.Application.Interfaces;
using CES.Infrastructur.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Infrastructur.Features.StudentOP
{
    public class CreatStudent : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreatStudent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> RegisterStudentAsync(CreatStudentDto creatStudentDto)
        {
            // Check if the level and department exist
            var level = await _context.Levels.FindAsync(creatStudentDto.levelId);
            var department = await _context.Departments.FindAsync(creatStudentDto.departmentId);

            if (level == null || department == null)
            {
                throw new InvalidOperationException("Invalid level or department.");
            }

            // Create a new student
            var newStudent = _mapper.Map<Student>(creatStudentDto);

            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            // Automatically enroll the student in all Required courses for the level

            var requiredCourses = await _context.Courses
                .Where(c => c.LevelId == creatStudentDto.levelId && c.DepartmentId == creatStudentDto.departmentId && c.CourseTypeId == 1)
                .ToListAsync();

            foreach (var course in requiredCourses)
            {
                var studentCourse = new StudentCourse
                {
                    StudentId = newStudent.Id,
                    CourseId = course.Id
                };
                _context.StudentCourses.Add(studentCourse);
            }

            await _context.SaveChangesAsync();

            return newStudent.Id;
        }
    }
}

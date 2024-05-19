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

namespace CES.Infrastructur.Features.CourseOP
{
    public class CreatCourse : ICourseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreatCourse(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateCourseAsync(CreatCourseDTO creatCourseDTO)
        {
            // Check if the department, instructor, and level exist
            var department = await _context.Departments.FindAsync(creatCourseDTO.departmentId);
            var instructor = await _context.Instructors.FindAsync(creatCourseDTO.instructorId);
            var level = await _context.Levels.FindAsync(creatCourseDTO.levelId);

            if (department == null || instructor == null || level == null)
            {
                throw new InvalidOperationException("Invalid department, instructor, or level.");
            }

            // Check if a course with the same name already exists in the department
            var existingCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Name == creatCourseDTO.courseName && c.DepartmentId == creatCourseDTO.departmentId);
            if (existingCourse != null)
            {
                throw new InvalidOperationException("A course with the same name already exists in the department.");
            }

            // Create a new course

            //Course course = new Course()
            //{
            //    Name = creatCourseDTO.courseName,
            //    Description = creatCourseDTO.courseDescription,
            //    CreditHours = creatCourseDTO.CreditHours,
            //    LevelId = creatCourseDTO.levelId,
            //    DepartmentId = creatCourseDTO.departmentId,
            //    InstructorId = creatCourseDTO.instructorId,
            //    CourseTypeId = creatCourseDTO.CourseTypeId
            //};

            var newCourse = _mapper.Map<Course>(creatCourseDTO);


            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();

            return newCourse.Id;
        }


        public async Task UpdateCourseDescriptionAsync(UpdateCourseDTO updateCourseDTO)
        {
            var course = await _context.Courses.FindAsync(updateCourseDTO.courseId);
            if (course == null)
            {
                throw new InvalidOperationException("Course not found.");
            }

            course.Description = updateCourseDTO.newDescription;
            await _context.SaveChangesAsync();
        }

    }
}

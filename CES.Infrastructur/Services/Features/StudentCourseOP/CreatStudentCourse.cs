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

namespace CES.Infrastructur.Features.StudentCourseOP
{
    public class CreatStudentCourse : IStudentCourseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreatStudentCourse(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task EnrollStudentInCourseAsync(StudentCourseDTO studentCourseDTO)
        {
            var student = await _context.Students.FindAsync(studentCourseDTO.studentId);
            if (student == null)
            {
                throw new InvalidOperationException("Student not found.");
            }

            var course = await _context.Courses.FindAsync(studentCourseDTO.courseId);
            if (course == null)
            {
                throw new InvalidOperationException("Course not found.");
            }

            // Check if enrolling in this course will exceed the level's maximum credit hours or less the level's minimum credit hours

            var totalCredits = await _context.StudentCourses
            .Where(sc => sc.StudentId == studentCourseDTO.studentId)
            .Join(_context.Courses, sc => sc.CourseId, c => c.Id, (sc, c) => c.CreditHours)
            .SumAsync();

            var level = await _context.Levels.FindAsync(student.LevelId);

            if (totalCredits + course.CreditHours > level.MaxCredits && totalCredits + course.CreditHours < level.MinCredits)
            {
                throw new InvalidOperationException("Enrolling in this course exceeds the level's maximum credit hours or less the level's minimum credit hours");
            }


            // Enroll the student in the course
            var studentCourse = _mapper.Map<StudentCourse>(studentCourseDTO);

            _context.StudentCourses.Add(studentCourse);
            await _context.SaveChangesAsync();
        }


        // retrieve enrolled students in a specific course and courses


        public async Task<List<Student>> GetStudentsEnrolledInCourseAsync(int courseId)
        {
            return await _context.StudentCourses
                .Where(sc => sc.CourseId == courseId)
                .Select(sc => sc.Student)
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesEnrolledByStudentAsync(int studentId)
        {
            return await _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.Course)
                .ToListAsync();
        }
    }
}

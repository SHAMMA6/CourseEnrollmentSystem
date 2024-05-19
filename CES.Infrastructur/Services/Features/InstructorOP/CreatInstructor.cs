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

namespace CES.Infrastructur.Features.InstructorOP
{
    public class CreatInstructor : IInstructorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreatInstructor(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> RegisterInstructorAsync(CreatInstructorDTO creatInstructorDTO)
        {
            // Check if the department exists
            var department = await _context.Departments.FindAsync(creatInstructorDTO.departmentId);
            if (department == null)
            {
                throw new InvalidOperationException("Department does not exist.");
            }

            // Create a new instructor
            var newInstructor = _mapper.Map<Instructor>(creatInstructorDTO);

            _context.Instructors.Add(newInstructor);
            await _context.SaveChangesAsync();

            return newInstructor.Id;
        }
    }
}

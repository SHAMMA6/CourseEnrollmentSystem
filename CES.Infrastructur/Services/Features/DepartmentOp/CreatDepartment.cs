using AutoMapper;
using CES.Application.DTOs;
using CES.Application.Entitys;
using CES.Application.Interfaces;
using CES.Infrastructur.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CES.Infrastructur.Features.DepartmentOP
{
    public class CreatDepartment : IDepartmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreatDepartment(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> RegisterDepartmentAsync(CreatDepartmentDTO creatDepartmentDTO)
        {
            // Check if department with the same name already exists
            var existingDepartment = await _context.Departments.FirstOrDefaultAsync(d => d.Name == creatDepartmentDTO.departmentName);
            if (existingDepartment != null)
            {
                throw new InvalidOperationException("Department with the same name already exists.");
            }

            // Create a new department
            var newDepartment = _mapper.Map<Department>(creatDepartmentDTO);

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            return newDepartment.Id;
        }
    }
}

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

namespace CES.Infrastructur.Features.CourseTypeOP
{
    public class CraetCourseType : ICoursTypeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CraetCourseType(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> RegisterCourseTypeAsync(CreatCorseTypeDTO creatCorseTypeDTO)
        {
            // Check if CourseType with the same name already exists
            var existingCourseTypes = await _context.CourseTypes.FirstOrDefaultAsync(d => d.Name == creatCorseTypeDTO.coursetypename);
            if (existingCourseTypes != null)
            {
                throw new InvalidOperationException("CourseTypes with the same name already exists.");
            }

            // Create a new CourseType
            var newCourseType = _mapper.Map<CourseType>(creatCorseTypeDTO);
            

            _context.CourseTypes.Add(newCourseType);
            await _context.SaveChangesAsync();

            return newCourseType.Id;
        }
    }
}

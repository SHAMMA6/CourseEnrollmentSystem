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

namespace CES.Infrastructur.Features.LevelOP
{
    public class CreatLevel : ILevelService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreatLevel(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> RegisterLevelAsync(CreatLevelDTO creatLevelDTO)
        {
            // Check if the department exists
            var department = await _context.Departments.FindAsync(creatLevelDTO.departmentId);
            if (department == null)
            {
                throw new InvalidOperationException("Department does not exist.");
            }

            // Check if minCredits is less than maxCredits
            if (creatLevelDTO.minCredits >= creatLevelDTO.maxCredits)
            {
                throw new InvalidOperationException("Minimum credits must be less than maximum credits.");
            }

            // Create a new level
            var newLevel = _mapper.Map<Level>(creatLevelDTO);

            _context.Levels.Add(newLevel);
            await _context.SaveChangesAsync();

            return newLevel.Id;
        }
    }
}

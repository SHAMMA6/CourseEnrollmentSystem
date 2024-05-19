using CES.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Application.Interfaces
{
    public interface ICourseService
    {
        Task<int>CreateCourseAsync(CreatCourseDTO creatCourseDTO);
        Task UpdateCourseDescriptionAsync(UpdateCourseDTO updateCourseDTO);

    }
}

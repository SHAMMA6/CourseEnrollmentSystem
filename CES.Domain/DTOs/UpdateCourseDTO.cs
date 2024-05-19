using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Application.DTOs
{
    public class UpdateCourseDTO
    {
       public int courseId {  get; set; }
       public string newDescription { get; set; }
    }
}

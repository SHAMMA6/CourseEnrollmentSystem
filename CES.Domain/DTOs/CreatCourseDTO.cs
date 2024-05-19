using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Application.DTOs
{
    public class CreatCourseDTO
    {
        public string courseName {  get; set; }
        public string courseDescription { get; set; }
        public int CreditHours { get; set; }
        public int CourseTypeId { get; set; }
        public int instructorId { get; set; }
        public int levelId { get; set; }
        public int departmentId { get; set; }
    }
}

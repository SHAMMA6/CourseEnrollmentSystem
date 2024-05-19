using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Application.DTOs
{
    public class CreatLevelDTO
    {
        public string levelName { get; set; }
        public int minCredits { get; set; }
        public int maxCredits { get; set; }
        public int departmentId { get; set; }
    }
}

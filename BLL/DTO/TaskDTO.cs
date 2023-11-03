using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int AuthorId { get; set; }
        public int AssigneeId { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
    }
}

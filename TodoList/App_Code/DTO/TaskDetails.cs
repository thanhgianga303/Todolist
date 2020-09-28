using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.App_Code.DTO
{
    public class TaskDetails
    {
        public int StaffId { get; set; }
        public int TaskId { get; set; }
        public int isOwner { get; set; }
        public TaskDetails()
        {

        }
        public TaskDetails(int StaffId, int TaskId,int isOwner)
        {
            this.StaffId = StaffId;
            this.TaskId = TaskId;
            this.isOwner = isOwner;
        }
    }
    
}
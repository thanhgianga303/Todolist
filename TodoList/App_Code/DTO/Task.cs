using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.App_Code.DTO
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Public { get; set; }
        public string Status { get; set; }
        public string Files { get; set; }
        public Task()
        {

        }
        public Task(int id,string Title, DateTime StartDate, DateTime EndDate, bool Public, string Status, string Files)
        {
            this.Id = id;
            this.Title = Title;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Public = Public;
            this.Status = Status;
            this.Files = Files;
        }
        public Task(string Title, DateTime StartDate, DateTime EndDate, bool Public, string Status,string Files)
        {
            this.Title = Title;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Public = Public;
            this.Status = Status;
            this.Files = Files;
        }
    }
}
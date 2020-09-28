using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TodoList.App_Code.DAL;
using TodoList.App_Code.DTO;

namespace TodoList.App_Code.BLL
{
    public class TaskBLL
    {
        public TaskBLL()
        {

        }
        public List<Task> getAllTask()
        {
            return TaskDAL.getAllTask();
        }
        public Task getTask(int taskId)
        {
            return TaskDAL.getTask(taskId);
        }
        public List<Task> getAllTaskByStaffId(int staffId)
        {
            return TaskDAL.getAllTaskByStaffId(staffId);
        }
        public void Insert(Task task, List<int> staffList, int ownerId)
        {
            TaskDAL.Insert(task, staffList, ownerId);
        }
        public void Update(Task task, List<int> staffIdList)
        {
            TaskDAL.Update(task, staffIdList);
        }
        public void Delete(Task task)
        {
            TaskDAL.Delete(task);
        }
        //Comment
        public DataTable getAllCommentByTaskId(int taskId)
        {
            return TaskDAL.getAllCommentByTaskId(taskId);
        }
        public void insertComment(int taskId, int staffId,string staffName, string content)
        {
            TaskDAL.insertComment(taskId,staffId, staffName,content);
        }
    }
}
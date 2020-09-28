using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoList.App_Code.DTO;

namespace TodoList.App_Code.DAL
{
    public class TaskDAL
    {
        public TaskDAL()
        {

        }
        public static List<Task> getAllTask()
        {
            List<Task> taskList = new List<Task>();
            string sQuery = @"Select * from tb_task";

            DAL.connectDB();
            SqlCommand cmd = new SqlCommand(sQuery, DAL.con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Task task = new Task();
                    task.Id = reader.GetInt32(0);
                    task.Title = reader.GetString(1);
                    task.StartDate =reader.GetDateTime(2);
                    task.EndDate = reader.GetDateTime(3);
                    task.Public = Convert.ToBoolean(reader.GetValue(4));
                    task.Status = reader.GetString(5);
                    task.Files = reader.GetString(6);
                    
                    taskList.Add(task);
                }
                reader.NextResult();
            }
            DAL.closeDB();
            return taskList;
        }
        
        public static List<Task> getAllTaskByStaffId(int staffId)
        {
            List<Task> taskList = new List<Task>();
            string sQuery = @"Select * 
                            from tb_task
                            where task_id in (select task_id
                                              from tb_taskdetails
                                              where staff_id=@staff_id)
                            or task_public=1";

            
            DAL.connectDB();
            SqlCommand cmd = new SqlCommand(sQuery, DAL.con);
            cmd.Parameters.AddWithValue("@staff_id", staffId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Task task = new Task();
                    task.Id = reader.GetInt32(0);
                    task.Title = reader.GetString(1);
                    task.StartDate = reader.GetDateTime(2);
                    task.EndDate = reader.GetDateTime(3);
                    task.Public = Convert.ToBoolean(reader.GetValue(4));
                    task.Status = reader.GetString(5);
                    task.Files = reader.GetString(6);

                    taskList.Add(task);
                }
                reader.NextResult();
            }
            DAL.closeDB();
            return taskList;
        }
        public static void Insert(Task task, List<int> staffList,int ownerId)
        {
            DAL.connectDB();

            string sql = @"Insert into tb_task(task_title,
                task_startdate,
                task_enddate,
                task_public,
                task_status,
                task_files)
                values(@task_title,@task_startdate,@task_enddate, @task_public, @task_status, @task_files)
                ;select Max(task_id) from tb_task";


            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@task_title", task.Title);
            cmd.Parameters.AddWithValue("@task_startdate", task.StartDate);
            cmd.Parameters.AddWithValue("@task_enddate", task.EndDate);
            cmd.Parameters.AddWithValue("@task_public", task.Public);
            cmd.Parameters.AddWithValue("@task_status", task.Status);
            if (task.Files!= null)
            {
                cmd.Parameters.AddWithValue("@task_files", task.Files);
            }
            Int32 lastestId = (Int32)cmd.ExecuteScalar();
            for (int i = 0; i < staffList.Count; i++)
            {
                sql = @"insert into tb_taskdetails(task_id,staff_id,isowner)
                        values (@task_id,@staff_id, 0)";
                cmd = new SqlCommand(sql, DAL.con);
                cmd.Parameters.AddWithValue("@staff_id", staffList[i]);
                cmd.Parameters.AddWithValue("@task_id", lastestId);
                cmd.ExecuteNonQuery();
            }

            sql = @"insert into tb_taskdetails(task_id,staff_id,isowner)
                        values (@task_id,@staff_id, 1)";
            cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@staff_id", ownerId);
            cmd.Parameters.AddWithValue("@task_id", lastestId);
            cmd.ExecuteNonQuery();

            DAL.closeDB();
        }
        public static void Update(Task task, List<int> staffIdList)
        {
            
            int ownerId = getOwnerIdByTaskId(task.Id);

            DAL.connectDB();
            string sql = "Update tb_task set task_title=@task_title,task_startdate=@task_startdate,task_enddate=@task_enddate, task_public=@task_public, task_status=@task_status,task_files=@task_files where task_id=@task_id";

            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@task_id", task.Id);
            cmd.Parameters.AddWithValue("@task_title", task.Title);
            cmd.Parameters.AddWithValue("@task_startdate", task.StartDate);
            cmd.Parameters.AddWithValue("@task_enddate", task.EndDate);
            cmd.Parameters.AddWithValue("@task_public", task.Public);
            cmd.Parameters.AddWithValue("@task_status", task.Status);
            cmd.Parameters.AddWithValue("@task_files", task.Files);
            cmd.ExecuteNonQuery();

            //delete all task by task_id
            sql = @"delete from tb_taskdetails where task_id=@task_id";
            cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@task_id", task.Id);
            cmd.ExecuteNonQuery();

            //add staff with ownerid
            sql = @"insert into tb_taskdetails(task_id,staff_id,isowner)
                        values (@task_id,@staff_id, 1)";
            cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@staff_id", ownerId);
            cmd.Parameters.AddWithValue("@task_id", task.Id);
            cmd.ExecuteNonQuery();

            //remove staffList with ownerId
            staffIdList.Remove(ownerId);

            //Add range staff
            for (int i = 0; i < staffIdList.Count; i++)
            {
                sql = @"insert into tb_taskdetails(task_id,staff_id,isowner)
                        values (@task_id,@staff_id, 0)";
                cmd = new SqlCommand(sql, DAL.con);
                cmd.Parameters.AddWithValue("@staff_id", staffIdList[i]);
                cmd.Parameters.AddWithValue("@task_id", task.Id);
                cmd.ExecuteNonQuery();
            }


            DAL.closeDB();
        }
        public static int getOwnerIdByTaskId(int taskId)
        {
            DAL.connectDB();

            string sql = "Select * from tb_taskdetails where task_id= @task_id and isowner=1";
            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@task_id", taskId);

            SqlDataReader reader = cmd.ExecuteReader();
            int id = -1;
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["staff_id"]);
            }
            DAL.closeDB();
            return id;
        }
        
        public static void Delete(Task task)
        {

            DeleteTaskDetails(task.Id);
            DAL.connectDB();

            string sql = "Delete tb_task where task_id= @task_id";
            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@task_id", task.Id);

            cmd.ExecuteNonQuery();
            DAL.closeDB();
        }
        public static void DeleteTaskDetails(int taskId)
        {
            DAL.connectDB();

            string sql = "Delete tb_taskdetails where task_id= @task_id";
            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@task_id", taskId);

            cmd.ExecuteNonQuery();
        }
        public static Task getTask(int taskId)
        {
            DAL.connectDB();

            string sql = "Select * from tb_task where task_id= @task_id";
            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@task_id", taskId);

            SqlDataReader reader = cmd.ExecuteReader();
            Task task = null;
            while (reader.Read())
            {
                task = new Task();
                task.Id = reader.GetInt32(0);
                task.Title = reader.GetString(1);
                task.StartDate = reader.GetDateTime(2);
                task.EndDate = reader.GetDateTime(3);
                task.Public = Convert.ToBoolean(reader.GetValue(4));
                task.Status = reader.GetString(5);
                task.Files = reader.GetString(6);
            }
            DAL.closeDB();
            return task;
        }

        //Comment
        public static DataTable getAllCommentByTaskId(int taskId)
        {
            DAL.connectDB();

            string sql = @"Select * from tb_comment where cmt_taskid=@cmt_taskid";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = DAL.con.CreateCommand();
            cmd.Parameters.AddWithValue("@cmt_taskid", taskId);

            cmd.CommandText = sql;
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);
            DAL.closeDB();
            return ds.Tables[0];
        }
        public static void insertComment(int taskId, int staffId,string staffName, string content)
        {
            DAL.connectDB();
            string sql = @"Insert into tb_comment(cmt_taskid,cmt_staffid,cmt_staffname,cmt_content)
                        values (@cmt_taskid,@cmt_staffid,@cmt_staffname,@cmt_content)";
            SqlCommand cmd = new SqlCommand(sql,DAL.con);
            cmd.Parameters.AddWithValue("@cmt_taskid", taskId);
            cmd.Parameters.AddWithValue("@cmt_staffid", staffId);
            cmd.Parameters.AddWithValue("@cmt_content", content);
            cmd.Parameters.AddWithValue("@cmt_staffname", staffName);
            cmd.ExecuteNonQuery();
            DAL.closeDB();
        }
        public static void deleteComment(int commentId)
        {
            DAL.connectDB();

            string sql = @"Delete from tb_comment where cmt_id=@cmt_id";
            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@cmt_id", commentId);

            cmd.ExecuteNonQuery();
            DAL.closeDB();
        }

        public static void deleteCommentByTaskId(int taskId)
        {
            DAL.connectDB();

            string sql = @"Delete from tb_comment where cmt_taskid=@cmt_taskid";
            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@cmt_taskid", taskId);

            cmd.ExecuteNonQuery();
            DAL.closeDB();
        }
    }
}
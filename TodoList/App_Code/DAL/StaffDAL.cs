using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoList.App_Code.BLL;
using TodoList.App_Code.DTO;

namespace TodoList.App_Code.DAL
{
    public class StaffDAL
    {
        public StaffDAL()
        {

        }
        public static List<Staff> getAllStaff()
        {
            List<Staff> staffList = new List<Staff>();
            string sQuery = @"Select * from tb_staff";

            DAL.connectDB();
            SqlCommand cmd = new SqlCommand(sQuery, DAL.con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Staff staff = new Staff();
                    staff.Id = reader.GetInt32(0);
                    staff.Name = reader.GetString(1);
                    staff.Email = reader.GetString(2);
                    staff.Password = reader.GetString(3);
                    staff.Phone= reader.GetString(4);
                    staff.Role = reader.GetString(5);
   
                    staffList.Add(staff);
                }
                reader.NextResult();
            }
            DAL.closeDB();
            return staffList;
        }
        public static Staff getStaff(int StaffId)
        {
            DAL.connectDB();
            string sql = "Select * from tb_staff where staff_id= @staff_id ";
            SqlCommand cmd = new SqlCommand(sql,DAL.con);
            cmd.Parameters.AddWithValue("@staff_id", StaffId);
            SqlDataReader reader = cmd.ExecuteReader();
            Staff staff = null;
            while (reader.Read())
            {
                staff = new Staff()
                {
                    Id = Int32.Parse(reader["staff_id"].ToString()),
                    Name = reader["staff_name"].ToString(),
                    Email = reader["staff_email"].ToString(),
                    Password = reader["staff_password"].ToString(),
                    Phone = reader["staff_phone"].ToString(),
                    Role = reader["staff_role"].ToString()

                 };
            }
            DAL.closeDB();
            return staff;
        }
        public static void Insert(Staff staff)
        {
            DAL.connectDB();

            string sql = "Insert into tb_staff(staff_name,staff_email,staff_password,staff_phone,staff_role) values(@staff_name,@staff_email,@staff_password,@staff_phone,@staff_role)";

            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@staff_name", staff.Name);
            cmd.Parameters.AddWithValue("@staff_email", staff.Email);
            cmd.Parameters.AddWithValue("@staff_password", staff.Password);
            cmd.Parameters.AddWithValue("@staff_phone", staff.Phone);
            cmd.Parameters.AddWithValue("@staff_role", staff.Role);
            cmd.ExecuteNonQuery();

            DAL.closeDB();
        }
        public static void Update(Staff staff)
        {
            DAL.connectDB();

            string sql = "Update tb_staff set staff_name = @staff_name, staff_email = @staff_email ,staff_password = @staff_password, staff_phone=@staff_phone, staff_role=@staff_role where staff_id=@staff_id";

            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@staff_id", staff.Id);
            cmd.Parameters.AddWithValue("@staff_name", staff.Name);
            cmd.Parameters.AddWithValue("@staff_email", staff.Email);
            cmd.Parameters.AddWithValue("@staff_password", staff.Password);
            cmd.Parameters.AddWithValue("@staff_phone", staff.Phone);
            cmd.Parameters.AddWithValue("@staff_role", staff.Role);

            cmd.ExecuteNonQuery();

            DAL.closeDB();
        }
        public static void Delete(Staff staff)
        {
            DAL.connectDB();

            string sql = "Delete tb_staff where staff_id= @staff_id";
            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@staff_id", staff.Id);

            cmd.ExecuteNonQuery();

            DAL.closeDB();

        }
        public static Staff Login(string username, string password)
        {
            DAL.connectDB();

            string sql = "Select * from tb_staff where staff_email= @staff_email and staff_password=@staff_password";
            SqlCommand cmd = new SqlCommand(sql, DAL.con);
            cmd.Parameters.AddWithValue("@staff_email", username);
            cmd.Parameters.AddWithValue("@staff_password", password);

            SqlDataReader reader = cmd.ExecuteReader();
            Staff staff = null;
            while (reader.Read())
            {
                staff = new Staff
                {
                    Id = Int32.Parse(reader["staff_id"].ToString()),
                    Name = reader["staff_name"].ToString(),
                    Email = reader["staff_email"].ToString(),
                    Password = reader["staff_password"].ToString(),
                    Phone = reader["staff_phone"].ToString(),
                    Role = reader["staff_role"].ToString()
                };
            }
            DAL.closeDB();
            return staff;
        }
        public static List<Staff> getListIdPartnerByTaskId(int taskId)
        {
            List<Staff> partnerList = new List<Staff>();
            string sQuery = @"
                            Select staff_id,staff_name
                            from tb_staff
                            where staff_id in (Select staff_id 
                                            from tb_taskdetails
                                            where task_id=@task_id)";


            DAL.connectDB();
            SqlCommand cmd = new SqlCommand(sQuery, DAL.con);
            cmd.Parameters.AddWithValue("@task_id", taskId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Staff staff = new Staff
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    partnerList.Add(staff);
                }
                reader.NextResult();
            }
            DAL.closeDB();
            return partnerList;
        }
    }
}
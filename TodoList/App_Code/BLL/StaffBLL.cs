using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.App_Code.DAL;
using TodoList.App_Code.DTO;

namespace TodoList.App_Code.BLL
{
    public class StaffBLL
    {
        public StaffBLL()
        {

        }
        public List<Staff> getAllStaff()
        {
            //NhanVienDAL nvDAL = new NhanVienDAL();
            return StaffDAL.getAllStaff();
        }
        public Staff getStaff(int staffId)
        {
            return StaffDAL.getStaff(staffId);
        }
        public void Insert(Staff staff)
        {
            StaffDAL.Insert(staff);
        }
        public void Delete(Staff staff)
        {
            StaffDAL.Delete(staff);
        }
        public void Update(Staff staff)
        {
            StaffDAL.Update(staff);
        }
        public Staff Login(string username, string password)
        {
            return StaffDAL.Login(username, password);
        }
        public List<Staff> getListIdPartnerByTaskId(int taskId)
        {
            return StaffDAL.getListIdPartnerByTaskId(taskId);
        }
    }
}
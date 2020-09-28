using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.App_Code.DTO
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public Staff()
        {

        }
        public Staff(string Name, string Email, string Password, string Phone, string Role)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Phone = Phone;
            this.Role = Role;
        }
        public Staff(int Id,string Name, string Email, string Password, string Phone, string Role)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Phone = Phone;
            this.Role = Role;
        }
    }
}
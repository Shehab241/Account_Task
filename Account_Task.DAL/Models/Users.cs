using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.DAL.Models
{
    public class users
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Server_DateTime is required !! ")]
        public DateTime Server_DateTime { get; set; }
        [Required(ErrorMessage = "DateTime_UTC is required !! ")]
        public DateTime DateTime_UTC { get; set; }
        [Required(ErrorMessage = "Update_DateTime_UTC is required !! ")]
        public DateTime Update_DateTime_UTC { get; set; }

        [Required(ErrorMessage = "Username is required !! ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is required !! ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "First_Name is required !! ")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Last_Name is required !! ")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Status is required !! ")]
        public int Status { get; set; }
        [Required(ErrorMessage = "Gender is required !! ")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "Date_Of_Birth is required !! ")]
        public DateTime Date_Of_Birth { get; set; }

    }
}
/*
  ID, int identity
 Server_DateTime, datetime required
 DateTime_UTC, datetime required
 Update_DateTime_UTC, datetime required
 Username, VARCHAR required
 Email, NVARCHAR required
 First_Name, NVARCHAR required
 Last_Name, NVARCHAR required
 Status, int required
 Gender, int required
 Date_Of_Birth, datetime required
 */
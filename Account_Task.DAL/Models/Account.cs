using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.DAL.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int User_ID { get; set; }
        public users Users { get; set; }
        [Required(ErrorMessage = "Server_DateTime is required !! ")]
        public DateTime Server_DateTime { get; set; }
        [Required(ErrorMessage = "DateTime_UTC is required !! ")]
        public DateTime DateTime_UTC { get; set; }
        [Required(ErrorMessage = "Update_DateTime_UTC is required !! ")]
        public DateTime Update_DateTime_UTC { get; set; }

        [Required(ErrorMessage = "Account_Number is required !! ")]
        public string Account_Number { get; set; }
        [Required(ErrorMessage = "Balance is required !! ")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        [Required(ErrorMessage = "Currency is required !! ")]
        public string Currency { get; set; }
        [Required(ErrorMessage = "Status is required !! ")]
        public int Status { get; set; }

    }
}
/*
  ID, int identity
 User_ID, int
 Server_DateTime, datetime required
 DateTime_UTC, datetime required
 Update_DateTime_UTC, datetime required
 Account_Number, VARCHAR required
 Balance, money required
 Currency, VARCHAR required
 Status, int required
 */
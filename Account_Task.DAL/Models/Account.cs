using Account_Task.DAL.Enums;
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
        public int? UsersId { get; set; }
        public users Users { get; set; }
        public DateTime Server_DateTime { get; set; } = DateTime.Now;
        [Required]
        public DateTime DateTime_UTC { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime Update_DateTime_UTC { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Account_Number is required !! ")]
        public string Account_Number { get; set; }
        [Required(ErrorMessage = "Balance is required !! ")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        [Required(ErrorMessage = "Currency is required !! ")]
        public Currency Currency { get; set; }
        [Required(ErrorMessage = "Status is required !! ")]
        public Status Status { get; set; }

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
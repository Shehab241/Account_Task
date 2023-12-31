﻿using Account_Task.DAL.Enums;
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
        [Required]
        public DateTime Server_DateTime { get; set; } = DateTime.Now;
        [Required]
        public DateTime DateTime_UTC { get; set; }= DateTime.UtcNow;
        [Required]
        public DateTime Update_DateTime_UTC { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Username is required !! ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is required !! ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "First_Name is required !! ")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Last_Name is required !! ")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Status is required !! ")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "Gender is required !! ")]
        public Genders Gender { get; set; }
        [Required(ErrorMessage = "Date_Of_Birth is required !! ")]
        public DateTime Date_Of_Birth { get; set; }

    }
}

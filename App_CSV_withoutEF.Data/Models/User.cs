﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CSV_withoutEF.Data.Models
{
    public class User : IDisposable
    {
        public int UserId { get; set; }

        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")] 
        public string UserLastname { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")] 
        public string UserSurname { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")] 
        public DateTime BirthDate { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")] 
        public string PassportSerial { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string PassportNumber { get; set; }
        
        public int UserOrganizationId { get; set; }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}

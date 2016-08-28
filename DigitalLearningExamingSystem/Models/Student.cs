using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalLearningExamingSystem.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "學生索引")]
        public string Id { get; set; }

        [Display(Name = "學生帳號")]
        [DataType(DataType.EmailAddress)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "班級ID")]
        public string ClassID { get; set; }
    }
}
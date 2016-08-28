using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalLearningExamingSystem.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name = "老師索引")]
        public string Id { get; set; }

        [Display(Name = "帳號")]
        [DataType(DataType.EmailAddress)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "班級ID")]
        public ICollection<string> ClassID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalLearningExamingSystem.Models
{
    public class StudentClass
    {
        [Key]
        public string ID { get; set; }

        [Display(Name = "老師ID")]
        public ICollection<string> TeacherID { get; set; }
    }
}
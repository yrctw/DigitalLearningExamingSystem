using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalLearningExamingSystem.Models
{
    public class SolveRecord
    {
        [Key]
        [Display(Name = "索引")]
        public string Id { get; set; }

        [Display(Name = "學生ID")]
        public string StudentID { get; set; }

        [Display(Name = "考卷ID")]
        public string PaperID { get; set; }

        [Display(Name = "學生答案")]
        public ICollection<string> StudentAns { get; set; }

        [Display(Name = "正確答案")]
        public ICollection<bool> Correct { get; set; }
    }
}
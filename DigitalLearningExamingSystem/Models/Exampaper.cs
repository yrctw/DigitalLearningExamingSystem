using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalLearningExamingSystem.Models
{
    public class Exampaper
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "考卷名稱")]
        public string ExampapaerName { get; set; }

        [Display(Name = "出題老師")]
        public string TeacherId { get; set; }

        [Display(Name = "科目")]
        public string Subject { get; set; }

        [Display(Name = "作答人數")]
        public int Num { get; set; }

        [Display(Name = "平均分數")]
        public float MeanGrade { get; set; }

        //[Display(Name = "題目")]
        //public virtual ICollection<Exam> Questions { get; set; }

        [Display(Name = "題目")]
        public string QuestionIds { get; set; }

        

    }

}
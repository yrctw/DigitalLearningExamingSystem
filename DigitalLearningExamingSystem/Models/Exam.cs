using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DigitalLearningExamingSystem.Models
{
    public class Exam
    {

        [Key]       
        [Display(Name = "題目編號")]
        public string Id { get; set; }

        [Display(Name = "題目")]
        public string Question { get; set; }

        //[Display(Name ="題目類型")]
        //public string QTyoe { get; set; }
        [Display(Name = "出題老師")]
        public string FromTeacher { get; set; }

        [Display(Name ="題目答案")]
        public int Answer { get; set; }

        [Display(Name = "答案選項1")]
        public string Choice1 { get; set; }

        [Display(Name = "答案選項2")]
        public string Choice2 { get; set; }

        [Display(Name = "答案選項3")]
        public string Choice3 { get; set; }

        [Display(Name = "答案選項4")]
        public string Choice4 { get; set; }

        [Display(Name = "解題次數")]
        public int SolveTimes { get; set; }

        [Display(Name = "答對次數")]
        public int CorrectTimes { get; set; }

        [Display(Name = "答題率")]
        public float CoreectRate { get; set; }

        [Display(Name = "科目")]
        public string Subject { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalLearningExamingSystem.Models
{
    public class ExamPaperDistribution
    {
        [Key]
        [Display(Name = "考卷分配索引")]
        public string Id { get; set; }

        [Display(Name = "考卷ID")]
        public string PaperID { get; set; }

        [Display(Name = "班級ID")]
        public string ClassID { get; set; }

        [Display(Name = "啟用與否")]
        public bool Active { get; set; }

        [Display(Name = "答題人數")]
        public int Num { get; set; }

        [Display(Name = "平均分數")]
        public float MeanGrade { get; set; }
    }
}
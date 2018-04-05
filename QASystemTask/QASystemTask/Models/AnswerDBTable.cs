using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QASystemTask.Models
{
    public partial class AnswerDBTable
    {
        public int ID { get; set; }

        [Required]
        public string AnswerString { get; set; }

        [Required]
        public int QuestionID { get; set; }
    
        public virtual QuestionDBTable QuestionDBTable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QASystemTask.Models
{   
    public partial class QuestionDBTable
    {
        public QuestionDBTable()
        {
            this.AnswerDBTables = new HashSet<AnswerDBTable>();
        } 
        public int ID { get; set; }

        [Required]
        public string QuestionString { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<AnswerDBTable> AnswerDBTables { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}

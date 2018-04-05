using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QASystemTask.Models;

namespace QASystemTask.ViewModels
{
    public class QuestionAnswerViewModel
    {
        public QuestionDBTable Question { get; set; }
        public List<AnswerDBTable> Answers { get; set; }
    }
}
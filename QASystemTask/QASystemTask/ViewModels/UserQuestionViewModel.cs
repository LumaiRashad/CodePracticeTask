using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QASystemTask.Models;

namespace QASystemTask.ViewModels
{
    public class UserQuestionViewModel
    {
        public List<QuestionDBTable> Questions { get; set; }
        public List<string> Users { get; set; }
    }
}
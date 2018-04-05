using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QASystemTask.MetaDataModels
{
    [MetadataType(typeof(AnswerMetaData))]
    public partial class AnswerDBTable
    {
    }

     public class AnswerMetaData
     {
         [Required]
         public string AnswerString { get; set; }

         [Required]
         public int QuestionID { get; set; }
     }
}
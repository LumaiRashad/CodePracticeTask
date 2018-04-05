using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QASystemTask.CostumeValidations;

namespace QASystemTask.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            this.QuestionDBTables = new HashSet<QuestionDBTable>();
        }

        [Required]
        [Display(Name = "User name")]
        [UserNameCostumeValidations]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [EmailCostumeValidations]
        public string Email { get; set; }
    
        public virtual ICollection<QuestionDBTable> QuestionDBTables { get; set; }
    }
}

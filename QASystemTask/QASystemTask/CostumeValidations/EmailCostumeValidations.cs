using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QASystemTask.Models;


namespace QASystemTask.CostumeValidations
{
    public class EmailCostumeValidations: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var User = (UserTable)validationContext.ObjectInstance;
            DBEntities DBContext = new DBEntities();
            UserTable Obj = DBContext.UserTables.Where(x => Equals(x.Email, User.Email)).FirstOrDefault();
            if (Obj == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Already Registered with this E-mail");

        }
    }
}
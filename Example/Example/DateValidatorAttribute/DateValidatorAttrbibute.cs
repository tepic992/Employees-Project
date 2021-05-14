using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Example.DateValidatorAttribute
{
    public class DateValidatorAttrbibute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        try
        {
            string strValue = value.ToString();
            var dateTime = DateTime.Parse(strValue);
            string pattern = @"(^(((0[1-9]|1[0-9]|2[0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)";
            Match match = Regex.Match(strValue, pattern);
            if (match.Success)
            {
                var property = validationContext.ObjectType.GetProperty("JoiningDate");
                if (property == null)
                    return new ValidationResult(string.Format("Property '{0}' is Null", "JoiningDate"));
                var objJoiningDate = property.GetValue(validationContext.ObjectInstance, null);
                string strJoiningDate = objJoiningDate == null ? "" : objJoiningDate.ToString();
                Match matchJoiningDate = Regex.Match(strJoiningDate, pattern);
                if (matchJoiningDate.Success)
                {
                    var joiningDate = DateTime.Parse(strJoiningDate);
                    if (dateTime > joiningDate)
                        return new ValidationResult("Date of Birth can not be greater than Joining date");
                    if (dateTime > DateTime.Now)
                        return new ValidationResult("Date of Birth can not be greater todays date");
                }
            }
            else
                return new ValidationResult("Invalid date format");
            return ValidationResult.Success;
        }
        catch (Exception)
        {
            return new ValidationResult("Invalid date format");
        }
    }
    }

}


using System;
using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Validation
{
    public class SsnValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is string))
            {
                return false;
            }
            var ssnString = value.ToString();
            return ssnString.Length == 9 && IsStringInt(ssnString);
        }

        private static bool IsStringInt(string value)
        {
            try
            {
                var valueAsInt = int.Parse(value);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

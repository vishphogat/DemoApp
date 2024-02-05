using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoApp
{
    public class CustomValidationRule : ValidationRule
    {
        public string ControlNameFromTag { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //check here if from backend which type of validation rule are we getting and call respective case
            //this way we can handle mandatory and non mandatory also
            switch (ControlNameFromTag)
            {
                case "vNumberTxtBox":
                    return AlphaNumericValidation(value);
                case "vColorTxtBox":
                    return CharacterValidation(value);
                case "vMakeTxtBox":
                    return YearValidation(value);
                default:
                    break;
            }
            return ValidationResult.ValidResult;
        }
        public ValidationResult AlphaNumericValidation(object value)
        {
            if (value as string != null && Regex.IsMatch(value as string, "^[a-zA-Z0-9]+$"))
            { return ValidationResult.ValidResult; }
            return new ValidationResult(false, "Fix error!");
        }
        public ValidationResult YearValidation(object value)
        {
            if (int.TryParse(value as string, out int year))
            {
                int currentYear = DateTime.Now.Year;
                if (year >= 1 && year <= currentYear)
                { return ValidationResult.ValidResult; }
            }
            return new ValidationResult(false, "Fix error!");
        }
        public ValidationResult CharacterValidation(object value)
        {
            if (value as string != null && Regex.IsMatch(value as string, "^[a-zA-Z]+$"))
            { return ValidationResult.ValidResult; }
            return new ValidationResult(false, "Fix error!");
        }
    }
}

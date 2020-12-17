using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace Presentation.ViewModel.AdditionalInterfaces
{
   public class StringValidation : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value cannot be coverted to string.");
            bool canConvert = false;
            /*switch (ValidationType.Name)
            {
                case "Boolean":
                    bool boolVal = false;
                    canConvert = bool.TryParse(strValue, out boolVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of boolean");
                case "String30":*/
                    canConvert =(strValue.Length<30);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of string and less then 30 characters");
            // case "Int32":*/
                    //int intVal = 0;
                    //canConvert = int.TryParse(strValue, out intVal);
                    //return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Int32");
               // default:
                 //   throw new InvalidCastException($"{ValidationType.Name} is not supported");
           // }
        }
    }
}

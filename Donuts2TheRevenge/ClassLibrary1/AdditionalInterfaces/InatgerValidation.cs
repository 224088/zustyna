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
    public class IntagerValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value cannot be coverted to string.");
            bool canConvert = false;         
            int intVal = 0;
            canConvert = int.TryParse(strValue, out intVal);
            return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be a number");
           
        }
    }
}

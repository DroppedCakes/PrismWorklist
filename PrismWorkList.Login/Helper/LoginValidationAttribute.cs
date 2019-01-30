using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList.Login.Helper
{
    public class LoginValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)=>
            String.IsNullOrWhiteSpace(value.ToString());
    }
}

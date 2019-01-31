using System;
using System.ComponentModel.DataAnnotations;

namespace PrismWorkList.Login.Helper
{
    public class LoginValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)=>
            String.IsNullOrWhiteSpace(value.ToString());
    }
}

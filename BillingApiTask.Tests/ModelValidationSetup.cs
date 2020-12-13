using NSubstitute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BillingApiTask.Tests
{
    public class ModelValidationSetup
    {
        public List<ValidationResult> Validate<T>(T model)
        {
            var validationResults = new List<ValidationResult>();
            ValidationContext ctx = GetValidationContext(model);
            Validator.TryValidateObject(model, ctx, validationResults, true);

            return validationResults;
        }

        public List<string> ValidateMesssages<T>(T model)
        {
            var validationResults = new List<ValidationResult>();
            ValidationContext ctx = GetValidationContext(model);
            Validator.TryValidateObject(model, ctx, validationResults, true);

            return validationResults.Select(x => x.ErrorMessage).ToList();
        }

        public  ValidationContext GetValidationContext<T>(T model)
        {

            return new ValidationContext(model);
        }
    }
}

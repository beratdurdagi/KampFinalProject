 using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var ctx = new ValidationContext<object>(entity);
            ValidationResult result = validator.Validate(ctx); 
            bool success = result.IsValid;
            if (!success)
            {
                throw new ValidationException(result.Errors);

            }
        }

    }
}

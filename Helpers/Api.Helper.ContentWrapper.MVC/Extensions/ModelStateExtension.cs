using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Api.Helper.ContentWrapper.MVC.Wrappers;

namespace Api.Helper.ContentWrapper.MVC.Extensions
{
    public static class ModelStateExtension
    {
        public static IEnumerable<ValidationError> AllErrors(this ModelStateDictionary modelState)
        {
            var result = new List<ValidationError>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key.Split('.').Count() > 1 ? string.Join(".", erroneousField.Key.Split('.').Skip(1)) : erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                                   .Select(error => new ValidationError(fieldKey, error.ErrorMessage));
                result.AddRange(fieldErrors);
            }

            return result;
        }
    }
}

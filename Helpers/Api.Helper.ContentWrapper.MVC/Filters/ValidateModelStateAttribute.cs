using System.Web.Http.Filters;

namespace Api.Helper.ContentWrapper.MVC.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var modelState = actionExecutedContext.ActionContext.ModelState;
            if (!modelState.IsValid)
            {
                throw new Api.Helper.ContentWrapper.MVC.Wrappers.ApiException("Your request is not valid", 400, Api.Helper.ContentWrapper.MVC.Extensions.ModelStateExtension.AllErrors(modelState));
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}

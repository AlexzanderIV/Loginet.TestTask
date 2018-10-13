using Microsoft.AspNetCore.Mvc.Filters;

namespace Loginet.TestTask.Attributes
{
    public class SessionAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authToken = filterContext.HttpContext.Request.Headers["Authentication"];

            Utils.SecurityUtils.Authenticate(filterContext.HttpContext.Session, authToken);
        }
    }
}

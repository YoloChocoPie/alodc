using System.Web.Mvc;

namespace WebCanteen.Areas.User.Middleware
{
    public class LoginVerification : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["user-id"] == null)
            {
                filterContext.Result = new RedirectResult("~/User/Auth/Login");
                return;
            }
        }

    }
}
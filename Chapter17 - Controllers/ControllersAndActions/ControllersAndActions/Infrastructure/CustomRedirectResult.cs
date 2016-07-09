using System.Web.Mvc;

namespace ControllersAndActions.Infrastructure
{
    public class CustomRedirectResult : ActionResult
    {
        private readonly string url;

        public CustomRedirectResult(string url)
        {
            this.url = url;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            string fullUrl = UrlHelper.GenerateContentUrl(url, context.HttpContext);
            context.HttpContext.Response.Redirect(fullUrl);
        }
    }
}

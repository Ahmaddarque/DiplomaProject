using System.Web;

namespace Olympiads.WEB.Helpers
{
    public static class RequestContextExtension
    {
        public static string GetPreviousAction(this HttpRequestBase request) =>
           (string)request.RequestContext.RouteData.Values["action"];
        public static string GetPreviousController(this HttpRequestBase request) =>
               (string)request.RequestContext.RouteData.Values["controller"];
    }
}
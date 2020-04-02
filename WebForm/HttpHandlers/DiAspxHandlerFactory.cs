using System.Web;
using System.Web.UI;
using WebForm.DI;

namespace WebForm.HttpHandlers
{
    public class DiAspxHandlerFactory : PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context,
                                                string requestType,
                                                string virtualPath,
                                                string path)
        {
            var httpHandler = base.GetHandler(context, requestType, virtualPath, path);
            if (httpHandler != null)
            {
                var container = context?.Application["DiContainer"] as IDiFactory;
                container?.DiPropetiesForWebForm(httpHandler, container);
            }

            return httpHandler;
        }
    }
}
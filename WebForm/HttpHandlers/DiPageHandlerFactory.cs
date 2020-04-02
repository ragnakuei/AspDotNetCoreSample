using System.Web;
using System.Web.UI;
using WebForm.DI;

namespace WebForm.HttpHandlers
{
    public class DiPageHandlerFactory : PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context,
                                                string requestType,
                                                string virtualPath,
                                                string path)
        {
            Page page = base.GetHandler(context, requestType, virtualPath, path) as Page;
            if (page != null)
            {
                var container = context?.Application["DiContainer"] as IDiFactory;
                container?.DiPropetiesForWebForm(page, container);
            }

            return page;
        }
    }
}
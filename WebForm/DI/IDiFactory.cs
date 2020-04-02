using System;
using System.Web;

namespace WebForm.DI
{
    public interface IDiFactory
    {
        T GetService<T>();
        
        object GetService(Type propPropertyType);
        
        void DiPropetiesForWebForm(IHttpHandler page, IDiFactory container);
    }
}
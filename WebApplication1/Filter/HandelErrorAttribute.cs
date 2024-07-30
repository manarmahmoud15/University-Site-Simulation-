using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filter
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult result = new ContentResult();
            //result.Content = context.Exception.Message;
            ViewResult result = new ViewResult();
            result.ViewName = "Error";
           // result.Model = context.Exception;
            context.Result = result;
        }
    }
}

namespace TinyERP.Common.Attributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Net;
    using TinyERP.Common.Data;
    using TinyERP.Common.Enums;
    using TinyERP.Common.Exceptions;

    public class ResponseWrapper : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ResponseData response = new ResponseData();
            if (context.Exception != null && context.Exception is IValidationException)
            {
                response.SetErrors(((IValidationException)context.Exception).Errors);
                response.StatusCode = HttpStatusCode.OK;
                context.Exception = null;
                context.Result = new OkObjectResult(response);
                return;
            }
            if(context.Exception != null)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                return;
            }

            var resultType = context.Result.GetType();

            if (resultType.Name == ApplicationActionResultType.EmptyResult)
            {
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                ObjectResult dataContent = (ObjectResult)context.Result;
                response.Data = dataContent.Value;
                response.StatusCode = HttpStatusCode.OK;
            }
            context.Result = new ObjectResult(response);
        }
    }
}

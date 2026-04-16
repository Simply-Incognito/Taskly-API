using TaskCoreAPI.Exceptions;

namespace TaskCoreAPI.Middlewares
{
    public class GlobaExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobaExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

         public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }  catch(Exception ex)
            {
                await HandleException(context, ex);
            }
        } 

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            // Set Response Content Type
            context.Response.ContentType = "application/json";


            // Set Status Code
            context.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            // Format and Send Response
            object response = new
            {
                message = ex.Message,
                statusCode = context.Response.StatusCode
            };

            await context.Response.WriteAsJsonAsync(response);


        }
    }
}

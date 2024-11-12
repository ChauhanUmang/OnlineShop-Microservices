using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Exceptions.Handler;


// Initially, we can't find IExceptionHanlder. So where is this class? Do we have to install a specific nuget?
// On checking the documentation for IExceptionHandler, we can see that it comes from Microsoft.AspNetCore.Diagnostics
// i.e. we need to refer AspNetCore package, but AspNetCore packages are deprecated.
// they are directly available in the NET SDK, but since this is a class library project, they are not accessible here.

// One approach to fix this is to install FluentValidation nugets (specially FluentValidation.AspNetCore)
// as they include the ASP.NET libraries.
public class CustomExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

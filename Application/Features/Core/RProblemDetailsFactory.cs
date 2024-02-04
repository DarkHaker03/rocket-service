using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Features.Host;

public class RProblemDetailsFactory(IMapper mapper) : ProblemDetailsFactory
{
    private readonly IMapper _mapper = mapper;
    
    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null,
        string title = null,
        string type = null, string detail = null, string instance = null)
    {
        var context = httpContext.Features.Get<IExceptionHandlerFeature>();
        var problem = _mapper.Map<ProblemDetails>(context.Error);

        return problem;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext,
        ModelStateDictionary modelStateDictionary, int? statusCode = null, string title = null, string type = null,
        string detail = null, string instance = null)
    {
        return new ValidationProblemDetails(modelStateDictionary)
        {
            Status = 400,

        };
    }
}
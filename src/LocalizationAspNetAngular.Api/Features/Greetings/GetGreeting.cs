using LocalizationAspNetAngular.Api.Resources;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LocalizationAspNetAngular.Api.Features
{
    public class GetGreeting
    {
        public class Request: IRequest<Response> {
            public string Name { get; set; }
        }

        public class Response
        {
            public string Greeting { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IStringLocalizer<Messages> _localizer;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public Handler(IStringLocalizer<Messages> localizer, IHttpContextAccessor httpContextAccessor)
            {
                _localizer = localizer;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var httpContext = _httpContextAccessor.HttpContext;

                var acceptLanguageHeaderValue = httpContext.Request.Headers["Accept-Language"];

                var localizedString = _localizer["Greeting"];

                return new()
                {
                    Greeting = String.Format(localizedString.Value, request.Name)
                };
            }
            
        }
    }
}

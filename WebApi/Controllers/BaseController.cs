using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        private ISender _sender;
        private ILogger<T> _loggerInstance;
        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
        protected ILogger<T> Logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}

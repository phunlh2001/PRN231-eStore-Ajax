using Microsoft.AspNetCore.Mvc;

namespace eStoreApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApi : ControllerBase
    {
    }
}

using HotelProject.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null) { StatusCode = response.StatusCode, };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}

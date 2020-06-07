using Cw13.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw13.Controllers
{
    [Route("api/klient")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IKlientDbService _service;

        public ClientsController(IKlientDbService service)
        {
            _service = service;
        }

        [HttpGet("orders")]
        public IActionResult GetZamowienia(string surname)
        {
            if (string.IsNullOrEmpty(surname))
                return Ok(_service.GetClientsOrders());

            if (_service.CheckIfClientExists(surname))
                return Ok(_service.GetClientOrders(surname));
            else
                return NotFound("Klient o podanym nazwisku nie istnieje w bazie danych!");
        }
    }
}
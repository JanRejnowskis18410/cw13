using Cw13.DTOs.Requests;
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

        [HttpPost("{id}/orders")]
        public IActionResult CreateNewOrder(CreateNewOrderRequest request, int id)
        {
            if (!_service.CheckIfClientExists(id))
            {
                return NotFound("Klient o podanym id nie istnieje w bazie danych!");
            }

            if (!_service.CheckIfEmployeeExists(request.idPracownika))
            {
                return NotFound("Pracownik o podanym id nie istnieje w bazie danych!");
            }

            string s = _service.CheckIfProductsExistst(request);
            if (!string.IsNullOrEmpty(s))
            {
                return NotFound("Produkt " + s + " nie istnieje w bazie danych!");
            }

            _service.AddNewOrder(request, id);

            return Ok("Dodano nowe zamównienie do bazy danych!");
        }
    }
}
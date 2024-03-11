using Finance.Domain.Aggregates.LoanAggregate.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FinancesController : ControllerBase
  {
    [HttpPost]
    public IActionResult LoanRequest()
    {

      return Ok();

    }
  }
}

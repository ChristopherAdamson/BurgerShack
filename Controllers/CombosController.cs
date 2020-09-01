using System;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class CombosController : ControllerBase
  {
    private readonly CombosService _combosService;
    public CombosController(CombosService combosService)
    {
      _combosService = combosService;
    }
    [HttpPost]
    public ActionResult<Combo> Post([FromBody] Combo newCombo)
    {
      try
      {
        return Ok(_combosService.Create(newCombo));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}
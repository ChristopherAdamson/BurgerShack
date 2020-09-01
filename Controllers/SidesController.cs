using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SidesController : ControllerBase
  {
    private readonly SidesService _sidesService;
    public SidesController(SidesService sidesService)
    {
      _sidesService = sidesService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
      try
      {
        IEnumerable<Side> sides = _sidesService.Get();
        return Ok(sides);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Side> Get(int id)
    {
      try
      {
        Side sides = _sidesService.Get(id);
        return Ok(sides);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpPost]
    public ActionResult<Side> Post([FromBody] Side newSide)
    {
      try
      {
        Side sides = _sidesService.Create(newSide);
        return Ok(sides);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Side> Delete(int id)
    {
      try
      {
        return Ok(_sidesService.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Side> Edit([FromBody] Side newSide, int id)
    {
      try
      {
        return Ok(_sidesService.Edit(newSide, id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}
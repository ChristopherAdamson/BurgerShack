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
  public class BurgersController : ControllerBase
  {
    private readonly BurgersService _burgerService;
    private readonly CombosService _comboService;
    public BurgersController(BurgersService burgersService, CombosService comboService)
    {
      _burgerService = burgersService;
      _comboService = comboService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      try
      {
        IEnumerable<Burger> burgers = _burgerService.Get();
        return Ok(burgers);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      try
      {
        Burger burgers = _burgerService.Get(id);
        return Ok(burgers);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}/combos")]
    public ActionResult<ComboViewModel> GetComboByBurgerId(int burgerId)
    {
      try
      {
        return Ok(_comboService.getComboByBurgerId(burgerId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Burger> Post([FromBody] Burger newBurger)
    {
      try
      {
        Burger burgers = _burgerService.Create(newBurger);
        return Ok(burgers);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Burger> Delete(int id)
    {
      try
      {
        return Ok(_burgerService.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Burger> Edit([FromBody] Burger newBurger, int id)
    {
      try
      {
        return Ok(_burgerService.Edit(newBurger, id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}
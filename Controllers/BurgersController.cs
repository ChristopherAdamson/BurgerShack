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
    public BurgersController(BurgersService burgersService)
    {
      _burgerService = burgersService;
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
  }
}
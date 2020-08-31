using System;
using System.Collections.Generic;
using BurgerShack.BurgersRepositories;
using BurgerShack.Models;

namespace BurgerShack.Services
{
  public class BurgersService
  {
    private readonly BlogsRepository _repo;
    public BurgersService(BlogsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Burger> GetBurgers()
    {
      throw new NotImplementedException();
    }
  }
}
using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgersShack.Repositories;

namespace BurgerShack.Services
{
  public class BurgersService
  {
    private readonly BurgersRepository _repo;
    public BurgersService(BurgersRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Burger> Get()
    {
      return _repo.Get();
    }
  }
}
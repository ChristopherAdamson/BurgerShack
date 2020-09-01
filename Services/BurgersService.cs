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
    public Burger Get(int id)
    {
      Burger burger = _repo.Get(id);
      if (burger == null)
      {
        throw new Exception("Burger not found");
      }
      return burger;
    }

    public Burger Create(Burger newBurger)
    {
      int id = _repo.Create(newBurger);
      newBurger.Id = id;
      return newBurger;

    }
  }
}
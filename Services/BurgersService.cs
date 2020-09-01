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

    internal Burger Delete(int id)
    {
      Burger exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public Burger Edit(Burger newBurger, int id)
    {
      Burger original = Get(id);
      original.Title = newBurger.Title == null ? original.Title : newBurger.Title;
      original.Ingredients = newBurger.Ingredients == null ? original.Ingredients : newBurger.Ingredients;
      original.Price = newBurger.Price > 0 ? newBurger.Price : original.Price;
      return _repo.Edit(original);

    }
  }
}
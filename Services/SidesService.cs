using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgersShack.Repositories;

namespace BurgerShack.Services
{
  public class SidesService
  {
    private readonly SidesRepository _repo;
    public SidesService(SidesRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Side> Get()
    {
      return _repo.Get();
    }
    public Side Get(int id)
    {
      Side burger = _repo.Get(id);
      if (burger == null)
      {
        throw new Exception("Side not found");
      }
      return burger;
    }

    public Side Create(Side newSide)
    {
      int id = _repo.Create(newSide);
      newSide.Id = id;
      return newSide;

    }

    internal Side Delete(int id)
    {
      Side exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public Side Edit(Side newSide, int id)
    {
      Side original = Get(id);
      original.Title = newSide.Title == null ? original.Title : newSide.Title;
      original.Price = newSide.Price > 0 ? newSide.Price : original.Price;
      return _repo.Edit(original);

    }
  }
}
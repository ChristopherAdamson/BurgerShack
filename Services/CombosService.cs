using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{

  public class CombosService
  {
    private readonly CombosRepository _repo;

    public CombosService(CombosRepository repo)
    {
      _repo = repo;
    }

    public Combo Create(Combo newCombo)
    {
      int id = _repo.Create(newCombo);
      newCombo.Id = id;
      return newCombo;
    }

    public IEnumerable<ComboViewModel> getComboByBurgerId(int burgerId)
    {
      return _repo.GetComboByBurgerId(burgerId);
    }
  }
}
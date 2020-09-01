using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class CombosRepository
  {
    private readonly IDbConnection _db;

    public CombosRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(Combo newCombo)
    {
      string sql = @"
      INSERT INTO combos
      (burgerId, sideId)
      VALUES
      (@BurgerId, @SideId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newCombo);
    }
    internal Combo GetById(int id)
    {
      string sql = "SELECT * FROM combos WHERE id = @Id";
      return _db.QueryFirstOrDefault<Combo>(sql, new { id });
    }
    public IEnumerable<ComboViewModel> GetComboByBurgerId(int burgerId)
    {
      string sql = @"
        SELECT 
            co.*,
            s.title as sideTitle,
            b.title as burgerTitle
        FROM combos co
        INNER JOIN sides s ON s.id = co.sideId 
        INNER JOIN burgers b on b.id = co.burgerId
        WHERE(co.burgerId = @burgerId)";
      return _db.Query<ComboViewModel>(sql, new { burgerId });
    }
  }
}
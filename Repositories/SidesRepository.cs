using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgersShack.Repositories
{
  public class SidesRepository
  {
    private readonly IDbConnection _db;
    public SidesRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Side> Get()
    {
      string sql = "SELECT * FROM sides";
      return _db.Query<Side>(sql);
    }

    public Side Get(int id)
    {
      string sql = "SELECT * FROM sides WHERE id = @id";
      return _db.QueryFirstOrDefault<Side>(sql, new { id });
    }

    public int Create(Side newSide)
    {
      string sql = @"iNSERT INTO sides 
      (title, ingredients, price)
      VALUES
      (@Title, @Ingredients, @Price);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newSide);
    }

    public void Delete(int id)
    {
      string sql = @"DELETE FROM sides WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    public Side Edit(Side original)
    {
      string sql = @"
     UPDATE sides
     SET
        title = @Title,
        ingredients = @Ingredients,
        price = @Price
      Where id = @Id;
     SELECT * FROM sides WHERE id = @id;";
      return _db.QueryFirstOrDefault<Side>(sql, original);

    }
  }
}
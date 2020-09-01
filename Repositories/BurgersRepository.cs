using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgersShack.Repositories
{
  public class BurgersRepository
  {
    private readonly IDbConnection _db;
    public BurgersRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Burger> Get()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }

    public Burger Get(int id)
    {
      string sql = "SELECT * FROM burgers WHERE id = @id";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    public int Create(Burger newBurger)
    {
      string sql = @"iNSERT INTO burgers 
      (title, ingredients, price)
      VALUES
      (@Title, @Ingredients, @Price);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBurger);
    }

    public void Delete(int id)
    {
      string sql = @"DELETE FROM burgers WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    public Burger Edit(Burger original)
    {
      string sql = @"
     UPDATE burgers
     SET
        title = @Title,
        ingredients = @Ingredients,
        price = @Price
      Where id = @Id;
     SELECT * FROM burgers WHERE id = @id;";
      return _db.QueryFirstOrDefault<Burger>(sql, original);

    }
  }
}
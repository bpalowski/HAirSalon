using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
      private int _styId;
      private string _stylistName;

  public Stylist(string StylistName, int StyId = 0)
  {
    _stylistName = StylistName;
    _styId = StyId;
  }

  public override bool Equals(System.Object otherStylist)
{
if(!(otherStylist is Stylist))
{
  return false;
}
else
{
  Stylist newStylist = (Stylist) otherStylist;
  bool idEquality = (this.GetStyId() == newStylist.GetStyId());
  bool nameEquality = (this.GetStylistName() == newStylist.GetStylistName());
  return(idEquality && nameEquality);
}
}
public override int GetHashCode()
{
return this.GetStyId().GetHashCode();
}
        public int GetStyId()
    {
      return _styId;
    }
    public string GetStylistName()
    {
      return _stylistName;
    }
        public void Save()
        {
          MySqlConnection conn = DB.Connection();
  conn.Open();

  var cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"INSERT INTO stylists (Name) VALUES (@name);";

  cmd.Parameters.Add(new MySqlParameter("@name", _stylistName));

  cmd.ExecuteNonQuery();
  _styId = (int) cmd.LastInsertedId;
  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
            }

        }
        public static List<Stylist> GetAll()
        {
          List<Stylist> allStylists = new List<Stylist> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM stylists;";
    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
      int StyId = rdr.GetInt32(0);
      string StylistName = rdr.GetString(1);
      Stylist newStylist = new Stylist(StylistName, StyId);
      allStylists.Add(newStylist);
    }
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
            return allStylists;
        }


        public static Stylist Find(int id)
     {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"SELECT * FROM stylists WHERE Id = (@searchId);";

       MySqlParameter searchId = new MySqlParameter();
       searchId.ParameterName = "@searchId";
       searchId.Value = id;
       cmd.Parameters.Add(searchId);

       var rdr = cmd.ExecuteReader() as MySqlDataReader;
       int StyId = 0;
       string StylistName = "";

       while(rdr.Read())
       {
         StyId = rdr.GetInt32(0);
         StylistName = rdr.GetString(1);
       }
       Stylist newStylist = new Stylist(StylistName, StyId);
       conn.Close();
       if (conn != null)
       {
           conn.Dispose();
       }
       
       return newStylist; 
      }
      public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET Name = @newName WHERE Id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _styId));
      cmd.Parameters.Add(new MySqlParameter("@newName", newName));

      cmd.ExecuteNonQuery();
      _stylistName = newName;

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @thisId;";

      cmd.Parameters.Add(new MySqlParameter("@thisID", _styId));

      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public static void DeleteAll()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"DELETE FROM stylists;";
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
  }
    }
}

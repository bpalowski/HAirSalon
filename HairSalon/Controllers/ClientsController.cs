using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clis")]
    public ActionResult List()
    {
      List<Client> allClients = Client.GetAll();
      // return new EmptyResult(); //Test 1 will fail
      // return View(0); //Test 2 will fail
      return View(allClients);  //Test will pass
    }
    [HttpGet("/clis/prevent")]
    public ActionResult Prevent()
    {
      // return new EmptyResult(); //Test 1 will fail
      // return View(0); //Test 2 will fail
      return View();  //Test will pass
    }
    [HttpGet("/clis/new")]
    public ActionResult CreateForm()
    {
      List<Stylist> listStylists = Stylist.GetAll();
      if(listStylists.Count > 0)
      {
        // return new EmptyResult(); //Test 1 will fail
        // return View(0); //Test 2 will fail
        return View(listStylists); //Test will pass
      }
      else
      {
        return RedirectToAction("Prevent");
      }

    }

    [HttpPost("/clis")]
    public ActionResult Create()
    {
      Client newClient = new Client(Request.Form["newClient"],int.Parse(Request.Form["StylistId"]));
      newClient.Save();
      List<Client> allClients = Client.GetAll();
      return View("List",allClients);
    }
    [HttpGet("/clis/{id}/update")]
   public ActionResult Up(int id)
   {
       Client thisClient = Client.Find(id);
       return View(thisClient);
   }
   [HttpPost("/clis/{id}/update")]
        public ActionResult UpDate(int id)
        {
          Client thisClient = Client.Find(id);
          thisClient.Edit(Request.Form["newClient"]);
          return RedirectToAction("List");
        }
     [HttpPost("/clis/{id}/delete")]
      public ActionResult Remove(int id)
      {
          Client thisClient = Client.Find(id);
          thisClient.Delete();
          return RedirectToAction("Remove");
      }

}
}

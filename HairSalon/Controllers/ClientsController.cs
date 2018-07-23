using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult List()
    {
        List<Client> allClients = Client.GetAll();
        return View(allClients);
    }

    [HttpGet("/clients/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

    // [HttpPost("/clients")]
    // public ActionResult Create()
    // {
    //   Client newClient = new Client(Request.Form["newClient"],int.Parse(Request.Form["stylistId"]));
    //   newClient.Save();
    //   List<Client> allClients = Client.GetAll();
    //   return View("List", allClients);
    // }

}
}

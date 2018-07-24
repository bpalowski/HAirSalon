using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stys")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }
        [HttpGet("/stys/new")]
        public ActionResult CStylist()
        {
            return View();
        }
        [HttpPost("/stylist/{id}/clients")]
        public ActionResult Create()
        {
            Stylist newStylist = new Stylist(Request.Form["newStylist"]);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index");
        }
        [HttpGet("/stylist/{id}/info")]
          public ActionResult Info(int id)
        {
          Stylist thisStylist = Stylist.Find(id);
          return View(thisStylist);
        }





      }
    }

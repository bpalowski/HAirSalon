using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/Stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/Stylists/new")]
        public ActionResult CStylist()
        {
            return View();
        }

        [HttpPost("/Stylists")]
        public ActionResult Create()
        {
            Stylist newStylist = new Stylist(Request.Form["newStylist"]);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }




      }
    }

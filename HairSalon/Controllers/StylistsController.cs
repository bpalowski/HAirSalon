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
        [HttpPost("/stys")]
          public ActionResult Create()
          {
            Stylist newStylist = new Stylist (Request.Form["newStylist"]);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
          }
          [HttpGet("/stys/{id}/update")]
         public ActionResult New(int id)
         {
             Stylist thisStylist = Stylist.Find(id);
             return View(thisStylist);
         }
         [HttpPost("/stys/{id}/update")]
              public ActionResult UpDate(int id)
              {
                Stylist thisStylist = Stylist.Find(id);
                thisStylist.Edit(Request.Form["upd"]);
                return RedirectToAction("Index");
              }
          [HttpGet("/stys/{id}/delete")]
          public ActionResult DStylist(int id)
          {
              Stylist thisStylist = Stylist.Find(id);
              thisStylist.Delete();
              return View("DStylist");
          }
          [HttpGet("/stys/{id}")]
          public ActionResult Details(int id)
          {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Client> selectedClients = Client.GetClientsById(id);
            List<Client> allClients = Client.GetAll();
            model.Add("allClients", allClients);
            model.Add("selectedClients", selectedClients);
            // model.Add("selectedStylist", selectedStylist);
            // return new EmptyResult(); //Test 1 will fail
            // return View(0); //Test 2 will fail
            return View(model); //Test will pass
    }





      }
    }

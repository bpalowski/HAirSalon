using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class SpecialityController : Controller
  {
    [HttpGet("/special")]
    public ActionResult First()
    {
       List<Speciality> allSpecialties = Speciality.GetAll();
      return View(allSpecialties);
    }
    [HttpGet("/special/new")]
    public ActionResult Show()
      {
        return View();
      }
    [HttpPost("/special")]
    public ActionResult Create()
    {
      Speciality newSpeciality = new Speciality(Request.Form["newDescription"]);
      newSpeciality.Save();
      List<Speciality> allSpecialties = Speciality.GetAll();
      return RedirectToAction("First",allSpecialties);
    }
    [HttpGet("/special/{id}/view")]
    public ActionResult View(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Speciality selectedSpecialty = Speciality.Find(id);
      List<Stylist> specialtiesStylists = selectedSpecialty.GetStylist();

      model.Add("specialty", selectedSpecialty);
      model.Add("stylists", specialtiesStylists);
      return View(model);
    }
    [HttpPost("/stys/{id}/addStys")]
    public ActionResult AddStylist(int id, int newstylistid)
    {
      Speciality selectedSpeciality = Speciality.Find(id);
      Stylist selectedStylist = Stylist.Find(newstylistid);

      selectedSpeciality.AddStylist(selectedStylist);

      return View("Yess", selectedSpeciality);
    }


   //  [HttpGet("/special/{id}/update")]
   // public ActionResult Up(int id)
   // {
   //     Client thisClient = Client.Find(id);
   //     return View(thisClient);
   // }
   // [HttpPost("/special/{id}/update")]
   //      public ActionResult UpDate(int id)
   //      {
   //        Client thisClient = Client.Find(id);
   //        thisClient.Edit(Request.Form["newClient"]);
   //        return RedirectToAction("List");
   //      }
  }
}

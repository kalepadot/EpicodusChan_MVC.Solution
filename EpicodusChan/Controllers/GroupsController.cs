using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EpicodusChan.Models;

namespace EpicodusChan.Controllers
{
  public class GroupsController : Controller
  {
    public IActionResult Index()
    {
      var allGroups = Group.GetGroups();
      return View(allGroups);
    }

    [HttpPost]
    public IActionResult Index(Group group)
    {
      Group.Post(group);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var group = Group.GetDetails(id);
      return View(group);
    }

    public IActionResult Edit(int id)
    {
      var group = Group.GetDetails(id);
      return View(group);
    }

    [HttpPost]
    public IActionResult Details(int id, Group group)
    {
      group.GroupId = id;
      Group.Put(group);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Group.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
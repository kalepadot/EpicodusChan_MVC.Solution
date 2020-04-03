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
    public IActionResult Details(int id)
    {
      var group = Group.GetDetails(id);
      return View(group);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Group group)
    {
      Group.Post(group);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var group = Group.GetDetails(id);
      return View(group);
    }

    [HttpPost]
    public IActionResult Edit(Group group)
    {
      Group.Put(group);
      return RedirectToAction("Details", "Groups", new { id = group.GroupId });
    }
    public IActionResult Delete(int id)
    {
      var thisGroup = Group.GetDetails(id);
      return View(thisGroup);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      Group.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
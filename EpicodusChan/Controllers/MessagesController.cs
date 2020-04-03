using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EpicodusChan.Models;

namespace EpicodusChan.Controllers
{
  public class MessagesController : Controller
  {
    public IActionResult Index()
    {
      var allMessages = Message.GetMessages();
      return View();
    }

  // [HttpGet("/groups/{groupId}/messages/details/{messageId}")]
    public IActionResult Details(int groupId, int messageId)
    {
      var message = Message.GetDetails(groupId, messageId);
      return View(message);
    }

    public IActionResult Create(int groupId)
    {
      ViewBag.groupId = groupId;
      return View();
    }

    [HttpPost]
    public IActionResult Create(int groupId, Message message)
    {
      // message.MessageId = Id;
      Message.CreateMessage(groupId, message);
      return RedirectToAction("Details", "Groups", new { id = groupId});
    }
    public IActionResult Edit(int groupId, int messageId)
    {
      ViewBag.GroupId = groupId;
      var message = Message.GetDetails(groupId, messageId);
      return View(message);
    }

    [HttpPost]
    public ActionResult Edit(int groupId, Message message)
    {
      Message.PutMessage(groupId, message);
      return RedirectToAction("Index");
    }
    public IActionResult Delete(int groupId, int messageId)
    {
      var thisMessage = Message.GetDetails(groupId, messageId);
      return View(thisMessage);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int groupId, int messageId)
    {
      Message.DeleteMessage(groupId, messageId);
      return RedirectToAction("Details", "Groups", new { id = groupId });
    }
  }
}
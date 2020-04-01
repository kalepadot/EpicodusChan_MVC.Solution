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
      return View(allMessages);
    }

    [HttpPost]
    public IActionResult Index(Message message)
    {
      Message.Post(message);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var message = Message.GetDetails(id);
      return View(message);
    }

    public IActionResult Edit(int id)
    {
      var message = Message.GetDetails(id);
      return View(message);
    }

    [HttpPost]
    public IActionResult Details(int id, Message message)
    {
      message.MessageId = id;
      Message.Put(message);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Message.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
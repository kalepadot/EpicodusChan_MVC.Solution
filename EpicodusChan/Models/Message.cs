using System.Collections.Generic;
// using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace EpicodusChan.Models
{
   public class Message
  {
    public int MessageId { get; set; }
    public int GroupId { get; set; }
    public string Title { get; set; }
    public string UserName { get; set; }
    public string Entry { get; set; }
    public string Date { get; set; }
  
  public static List<Message> GetMessages()
  {
    var apiCallTask = ApiHelper.GetAll();
    var result = apiCallTask.Result; 

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

    return messageList; 
  }
  public static Message GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

      return message;
    }
      public static void Post(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      var apiCallTask = ApiHelper.Post(jsonMessage);
    }

    public static void Put(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      var apiCallTask = ApiHelper.Put(message.MessageId, jsonMessage);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }

  }
}
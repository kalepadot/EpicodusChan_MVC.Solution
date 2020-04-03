using System.Collections.Generic;
using System;
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
    var apiCallTask = ApiHelper.GetAll("Messages");
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

    return messageList;
  }
  public static Message GetDetails(int groupId, int messageId)
    {
      var apiCallTask = ApiHelper.GetMessage(groupId, messageId);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

      return message;
    }
      public static void CreateMessage(int groupId, Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      var apiCallTask = ApiHelper.CreateMessage(groupId, jsonMessage);
    }

    public static void PutMessage(int groupId, Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      var apiCallTask = ApiHelper.PutMessage(groupId, message.MessageId, jsonMessage);
    }

    public static void DeleteMessage(int groupId, int messageid)
    {
      var apiCallTask = ApiHelper.DeleteMessage(groupId, messageid);
    }
  }
}
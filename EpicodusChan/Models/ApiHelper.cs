using System.Threading.Tasks;
using RestSharp;

namespace EpicodusChan.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll(string controller)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"{controller}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
      public static async Task<string> GetMessage(int groupId, int messageId)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"groups/{groupId}/messages/{messageId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
       public static async Task CreateMessage(int groupId, string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"groups/{groupId}/messages", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      var response = await client.ExecuteTaskAsync(request);
      
    }

    public static async Task PutMessage(int groupId, int messageId, string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"groups/{groupId}/messages/{messageId}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteMessage(int groupId, int messageId)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"groups/{groupId}/messages/{messageId}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    // Methods for Groups: 

    public static async Task<string> GetGroup(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"groups/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task CreateGroup(string newGroup)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"groups", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGroup);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PutGroup(int id, string newGroup)
    {
        RestClient client = new RestClient("http://localhost:5000/api/");
        RestRequest request = new RestRequest($"groups/{id}", Method.PUT);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(newGroup);
        var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteGroup(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"groups/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}
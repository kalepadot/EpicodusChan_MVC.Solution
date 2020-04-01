using System.Threading.Tasks;
using RestSharp;

namespace EpicodusChan.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
      public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
       public static async Task Post(string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    // Methods for Groups: 


    public static async Task PutGroup(int id, string newGroup)
    {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"groups/{id}", Method.PUT);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(newGroup);
        var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task<string> GetAllGroups()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

      public static async Task<string> GetGroup(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
       public static async Task PostGroup(string newGroup)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGroup);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task DeleteGroup(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}
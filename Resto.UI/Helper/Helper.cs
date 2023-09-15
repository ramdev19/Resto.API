namespace Resto.UI.Helper
{
    public class OrderAPI
    {
        public HttpClient Initial()
        {
            //https://localhost:7160;http://localhost:5039
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7160/");  
            return Client;
        }
    }
}

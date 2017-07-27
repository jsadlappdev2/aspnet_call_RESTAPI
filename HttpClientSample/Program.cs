using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HttpClientSample.Models;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace HttpClientSample
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowProduct(Product product)
        {
            Console.WriteLine($"Name: {product.Name}\tPrice: {product.Price}\tCategory: {product.Category}");
        }


        static void ShowTodo(TodoItem alltodo)
        {
            Console.WriteLine($"Description: {alltodo.Description}\tDueDate: {alltodo.DueDate}\tisDone: {alltodo.isDone}");
        }


        static async Task<Uri> CreateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }

        static async Task<Product> UpdateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<Product>();
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/products/{id}");
            return response.StatusCode;
        }


        static async Task<List<TodoItem>> GetTodoItemsAsync(string path)
        {

            // TodoItem allto = null;
            var response = await client.GetStringAsync(path);

            var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(response);
           return todoItems;

          
        }

        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {

          //  List<TodoItem> items;
            // client.BaseAddress = new Uri("http://localhost:55268/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                // Product product = new Product { Name = "Gizmo", Price = 100, Category = "Widgets" };

            //    TodoItem items = new TodoItem();

                //  var url = await CreateProductAsync(product);
                //  Console.WriteLine($"Created at {url}");

                // Get the product
                // product = await GetProductAsync(url.PathAndQuery);
                //  ShowProduct(product);

                //Get todo lists
               List<TodoItem> items ;
                items = await GetTodoItemsAsync("http://localhost:60761/api/todos/QueryAll2");
             //  Console.WriteLine(items.);


              
              //  Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
              //  Console.WriteLine($"Description: {itmes.IndexOf()}\tDueDate: {alltodo.DueDate}\tisDone: {alltodo.isDone}");
              //  Console.WriteLine(items.OrderBy(item => item.isDone).ThenBy(item => item.id).ToList());


                // Update the product
                // Console.WriteLine("Updating price...");
                // product.Price = 80;
                // await UpdateProductAsync(product);

                // Get the updated product
                //product = await GetProductAsync(url.PathAndQuery);
                // ShowProduct(product);

                // Delete the product
                //   var statusCode = await DeleteProductAsync(product.Id);
                //  Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}

using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProductModel : PageModel
{
    private readonly HttpClient client;

    public ProductModel(HttpClient client)
    {
        this.client = client;
    }

    public List<Product> Products {get; set;} = new();

    public async Task OnGetAsync()
    {
        Products = await client.GetFromJsonAsync<List<Product>>
            ("https://fakestoreapi.com/products/");
    }
}
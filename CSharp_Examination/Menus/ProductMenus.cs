using CSharp_Examination.Models;
using CSharp_Examination.Services;

namespace CSharp_Examination.Menus;

internal class ProductMenus : StartUpMenu
{
    private readonly ProductService _productService = new ProductService();

    public void AddProductMenu()
    {
        var product = new Product();

        Console.Clear();
        Console.WriteLine("-- ADD PRODUCT --\n");

        Console.WriteLine("Please write your products name: ");
        product.ProductName = Console.ReadLine() ?? "";

        Console.WriteLine("Please enter the price of your product");
        product.ProductPrice = Console.ReadLine() ?? "";

        var response = _productService.AddProductToList(product);

        switch (response)
        {
            case Response.Success:
                Console.WriteLine("\nCustomer was created successfully.");
                break;

            case Response.Failed:
                Console.WriteLine("\nCustomer with same email already exist.");
                break;

            case Response.Exists:
                Console.WriteLine("\nSomething went wrong, try again.");
                break;

            case Response.SuccessWithErrors:
                Console.WriteLine("\nCustomer was created successfully. But customer list was not saved.");
                break;
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    public void ListAllProducts()
    {
        Console.Clear();
        Console.WriteLine("-- LIST OF PRODUCTS --\n");

        var products = _productService.GetAllProducts();
        if (products != null)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product name: {product.ProductName} \nProduct price: {product.ProductPrice} \nProduct ID: {product.Id}\n");
            }
        }
        else
        {
            Console.WriteLine("Product list is empty.");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    public void ExitChoiceMenu()
    {
        Console.Write("Are you sure you want to exit? (y/n) ");
        var answer = Console.ReadLine()?.ToLower() == "n";
        if (!answer)
            Environment.Exit(0);
    }
}

using CSharp_Examination.Models;
using CSharp_Examination.Services;

namespace CSharp_Examination.Tests;

public class MainTests
{
    [Fact]
    public void AddProductToList__ShouldAddNewProductToProductList__ReturnResultSuccess()
    {
        ProductService productService = new ProductService();
        var product = new Product { ProductName = "Stol", ProductPrice = "299" };

        var result = productService.AddProductToList(product);
        var productList = productService.GetAllProducts();

        Assert.Equal(Response.Success, result);
        Assert.Single(productList);
    }
}

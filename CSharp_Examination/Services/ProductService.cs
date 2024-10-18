using CSharp_Examination.Models;
using Newtonsoft.Json;

namespace CSharp_Examination.Services;

public class ProductService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "products.json");
    private readonly FileService _fileService = new FileService(_filePath);
    private List<Product> _productList = new List<Product>();

    public Response AddProductToList(Product product)
    {
        try
        {
            GetProductFromFile();

            if (_productList.Any(x => x.ProductName == product.ProductName))
            {
                return Response.Exists;
            }

            _productList.Add(product);

            var json = JsonConvert.SerializeObject(_productList);
            var result = _fileService.SaveToFile(json);
            if (result)
            {
                return Response.Success;
            }
            return Response.SuccessWithErrors;
        }
        catch
        {
            return Response.Failed;
        }
    }

    public IEnumerable<Product> GetAllProducts()
    {
        GetProductFromFile();
        return _productList;
    }

    public void GetProductFromFile()
    {
        try
        {
            var content = _fileService.GetFromFile();

            if (!string.IsNullOrEmpty(content))
                _productList = JsonConvert.DeserializeObject<List<Product>>(content)!;
        }
        catch { }
    }

}

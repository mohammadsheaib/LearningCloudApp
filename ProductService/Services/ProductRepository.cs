using MongoDB.Driver;
using ProductService.Models;

namespace ProductService.Services;

public class ProductRepository
{
    private readonly IMongoCollection<Product> _products;

    public ProductRepository(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDb:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDb:Database"]);
        _products = database.GetCollection<Product>("Products");
    }

    public async Task<List<Product>> GetAll() =>
        await _products.Find(_ => true).ToListAsync();

    public async Task<Product> GetById(string id) =>
        await _products.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task Create(Product product) =>
        await _products.InsertOneAsync(product);

    public async Task Update(string id, Product product) =>
        await _products.ReplaceOneAsync(p => p.Id == id, product);

    public async Task Delete(string id) =>
        await _products.DeleteOneAsync(p => p.Id == id);
}

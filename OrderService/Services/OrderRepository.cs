using MongoDB.Driver;
using OrderService.Models;

namespace OrderService.Services;

public class OrderRepository
{
    private readonly IMongoCollection<Order> _orders;

    public OrderRepository(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDb:ConnectionString"]);
        var db = client.GetDatabase(config["MongoDb:Database"]);
        _orders = db.GetCollection<Order>("Orders");
    }

    public async Task<List<Order>> GetAll() =>
        await _orders.Find(_ => true).ToListAsync();

    public async Task<Order> GetById(string id) =>
        await _orders.Find(o => o.Id == id).FirstOrDefaultAsync();

    public async Task Create(Order order) =>
        await _orders.InsertOneAsync(order);

    public async Task Delete(string id) =>
        await _orders.DeleteOneAsync(o => o.Id == id);
}

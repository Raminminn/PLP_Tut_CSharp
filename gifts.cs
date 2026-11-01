#:package Microsoft.EntityFrameworkCore.Sqlite@10.0.0
#:property PublishAot=false
#:property NuGetAudit=false
using Microsoft.EntityFrameworkCore;

var gifts = new List<ChristmasGift>
{
    new() { Name = "Anna",        Age = 7,   Present = "Toy",    Price = 20 },
    new() { Name = "Bob",         Age = 9,   Present = "Book",   Price = 20 },
    new() { Name = "Andrew",      Age = 24,  Present = "PS5",    Price = 500 },
    new() { Name = "Bella",       Age = 20,  Present = "Laptop", Price = 500 },
    new() { Name = "The Martian", Age = 200, Present = "Pea",    Price = 1 },
};

// Part 1: LINQ on the list
// TODO: filter children's presents (method syntax)
// TODO: query syntax
// TODO: top 3 presents by price
// TODO: budget for kids vs. budget for adults

// Part 2: database
// copies gifts into a small database file
using var db = GiftDb.CreateWith(gifts);
// TODO: filter children's presents

class GiftDb : DbContext
{
    public DbSet<ChristmasGift> Gifts => Set<ChristmasGift>();

    protected override void OnConfiguring(DbContextOptionsBuilder o)
        => o.UseSqlite("Data Source=gifts.db");

    public static GiftDb CreateWith(IEnumerable<ChristmasGift> gifts)
    {
        var db = new GiftDb();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.Gifts.AddRange(gifts);
        db.SaveChanges();
        return db;
    }
}

class ChristmasGift
{
    public int Id { get; set; }   // the database needs an Id for each row
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string Present { get; set; } = "";
    public double Price { get; set; }
}
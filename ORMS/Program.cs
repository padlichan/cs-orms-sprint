using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ORMS;

var toys = Utils.DeserializeFromFile<List<Toy>>("./Resources/Toys.json");
var dogs = Utils.DeserializeFromFile<List<Dog>>("./Resources/Dogs.json");
//var parks = Utils.DeserializeFromFile<List<Park>>("./Resources/Parks.json");
//var dogParkVisits = Utils.DeserializeFromFile<List<DogPark>>("./Resources/DogPark.json");

using (MyDBContext db = new MyDBContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    foreach (var dog in dogs)
    {
        db.Dogs.Add(dog);
    }
    foreach (var toy in toys)
    {
        db.Toys.Add(toy);
    }
    db.SaveChanges();


    //List toys and the dog they belong to
    //var toyQuery = db.Toys.Include(t => t.Dog).ToList();
    //Console.WriteLine($"{"Toy",-20} {"Owner",-20}");
    //Console.WriteLine(new string('=', 41));
    //toyQuery.ForEach(toy => Console.WriteLine($"{toy.Name,-20} {toy.Dog.Name,-20}"));

    var dogQuery = db.Dogs.Include(d => d.Toys);
    Console.WriteLine($"{"Dog",-20} {"Toys",-50}");
    Console.WriteLine(new string('=', 71));
    foreach (var dog in dogs)
    {
        string dogToys = dog.Toys.IsNullOrEmpty() ? "NULL" : string.Join(", ", dog.Toys.Select(t => t.Name));
        Console.WriteLine($"{dog.Name,-20} {dogToys,-50}");
    }
}
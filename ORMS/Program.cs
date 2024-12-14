using Microsoft.EntityFrameworkCore;
using ORMS;

var toys = Utils.DeserializeFromFile<List<Toy>>("./Resources/Toys.json");
var dogs = Utils.DeserializeFromFile<List<Dog>>("./Resources/Dogs.json");
//var parks = Utils.DeserializeFromFile<List<Park>>("./Resources/Parks.json");
//var dogParkVisits = Utils.DeserializeFromFile<List<DogPark>>("./Resources/DogPark.json");

using (MyDBContext db = new MyDBContext())
{
    //db.Database.EnsureDeleted();
    //db.Database.EnsureCreated();

    //foreach (var dog in dogs)
    //{
    //    db.Dogs.Add(dog);
    //}
    //foreach (var toy in toys)
    //{
    //    db.Toys.Add(toy);
    //}
    //db.SaveChanges();

    var toyQuery = db.Toys.Include(t => t.Dog).ToList();
    Console.WriteLine($"{"Toy",-20} {"Owner",-20}");
    Console.WriteLine(new string('=', 41));
    toyQuery.ForEach(toy => Console.WriteLine($"{toy.Name,-20} {toy.Dog.Name,-20}"));
}
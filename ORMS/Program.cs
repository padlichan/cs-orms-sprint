using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ORMS;
using ORMS.Migrations;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;

//var toys = Utils.DeserializeFromFile<List<Toy>>("./Resources/Toys.json");
//var dogs = Utils.DeserializeFromFile<List<Dog>>("./Resources/Dogs.json");
//var parks = Utils.DeserializeFromFile<List<Park>>("./Resources/Parks.json");
//var dogParkVisits = Utils.DeserializeFromFile<List<DogPark>>("./Resources/DogPark.json");

using (MyDBContext db = new())
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
    //foreach (var park in parks)
    //{
    //    db.Parks.Add(park);
    //}
    //db.SaveChanges();

    //foreach (var dogPark in dogParkVisits)
    //{
    //    db.DogParks.Add(dogPark);
    //}
    //db.SaveChanges();

    ////List parks
    //var parkQuery = db.Parks.ToList();
    //Console.WriteLine($"{"Park name",-20}{"Rating",-10}");
    //Console.WriteLine(new string('=',30));
    //parkQuery.ForEach(p => Console.WriteLine($"{p.Name,-20}{p.RatingOutOf10,-10}"));


    //db.Toys.RemoveRange(db.Toys.Where(t => t.Name == "NEWTOY"));
    //db.Dogs.RemoveRange(db.Dogs.Where(t => t.Name == "MYNEWDOG"));
    //db.SaveChanges();

    ////List toys and the dog they belong to
    //var toyQuery = db.Toys.Include(t => t.Dog).ToList();
    //Console.WriteLine($"{"Toy",-20} {"Owner",-20}");
    //Console.WriteLine(new string('=', 41));
    //toyQuery.ForEach(toy => Console.WriteLine($"{toy.Name,-20} {(toy.Dog == null? "NULL" : toy.Dog.Name),-20}"));
    //Console.WriteLine();

    //Add new dog to db and assign new toy
    //db.Dogs.Add(new Dog("MYNEWDOG", "SOMEDOGBREED", "THINGDOGSLOVE"));
    //db.Toys.Add(new Toy("NEWTOY", true));
    //db.SaveChanges();
    //db.Toys.Where(t => t.Name == "NEWTOY").First().DogId = db.Dogs.Where(d => d.Name == "MYNEWDOG").First().Id;
    //db.SaveChanges();

    //List dogs and their toys
    //var dogQuery = db.Dogs.Include(d => d.Toys);
    //Console.WriteLine($"{"Dog",-20} {"Toys",-50}");
    //Console.WriteLine(new string('=', 71));
    //foreach (var dog in dogQuery)
    //{
    //    string dogToys = dog.Toys.IsNullOrEmpty() ? "NULL" : string.Join(", ", dog.Toys.Select(t => t.Name));
    //    Console.WriteLine($"{dog.Name,-20} {dogToys,-50}");
    //}

    //var parkQuery = db.Parks.Include(p => p.DogParkVisits)
    //                        .ThenInclude(dp => dp.Dog)
    //                        .ToList();

    //Console.WriteLine("PARKS");
    //foreach (var park in parkQuery)
    //{
    //    var dogsAttended = String.Join(", ", park.DogParkVisits.Select(dp => dp.Dog.Name));
    //    Console.WriteLine($"Id: {park.Id} | Name: {park.Name} | Rating: {park.RatingOutOf10} | DogsAttended: {dogsAttended}");
    //}

    //Console.WriteLine();

    //var ownerQuery = db.Owners.ToList();

    //Console.WriteLine("OWNERS");
    //foreach (var owner in ownerQuery)
    //{
    //    Console.WriteLine($"Id: {owner.Id} | FirstName: {owner.FirstName} | LastName: {owner.LastName}");
    //}

    //LINQ Queries

    //1. Get a list of dogs that have visited "Alexandra Park"

    var dogQuery = db.Dogs.Include(d => d.DogParkVisits).ThenInclude(dp => dp.Park).ToList();
    var alexandraParkDogs = dogQuery.Where(d => d.DogParkVisits.Select(dp => dp.Park).Any(p => p.Name == "Alexandra Park"));
    Console.WriteLine("A list of dogs that have visited \"Alexandra Park\":");
    foreach(Dog dog in alexandraParkDogs)
    {
        Console.WriteLine($"Id: {dog.Id} | Name: {dog.Name}");
    }

    //2. Get a list of all the toys owned by all the dogs that have visited "Heaton Park"
    var toyQuery = db.Toys.Include(t => t.Dog).ThenInclude(d => d.DogParkVisits).ThenInclude(dp => dp.Park).ToList();
    var toysDogsHeatonPark = toyQuery.Where(t => t.Dog.DogParkVisits.Select(dp => dp.Park).Any(p => p.Name == "Heaton Park"));
    Console.WriteLine("A list of all the toys owned by all the dogs that have visited \"Heaton Park:");
    foreach (var toy in toysDogsHeatonPark)
    {
        Console.WriteLine($"Id: {toy.Id} | Name: {toy.Name} | Dog: {toy.Dog.Name?? "NULL"}");
    }

    //3. Get the park that has had the most visitors
    var parkQuery = db.Parks.Include(p => p.DogParkVisits).ToList();
    var parkWithMostVisitors = parkQuery.OrderByDescending(p => p.DogParkVisits.Count).First();
    Console.WriteLine("The park that has had the most visitors:");
    Console.WriteLine($"Id: {parkWithMostVisitors.Id} | {parkWithMostVisitors.Name} | Number of visitors: {parkWithMostVisitors.DogParkVisits.Count}");

    //4. Get all parks that have had no visitors.

    var parksWithNoVisitors = parkQuery.Where(p => p.DogParkVisits.Count == 0);
    foreach(Park park in parksWithNoVisitors)
    {
        Console.WriteLine($"Id: {park.Id} | Name: {park.Name} | Visitors: {park.DogParkVisits.Count}");
    }
}
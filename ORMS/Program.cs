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
}
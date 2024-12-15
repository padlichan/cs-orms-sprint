using Microsoft.Identity.Client;
using System.ComponentModel;

namespace ORMS;

internal class Dog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public string Loves { get; set; }

    //Navigation properties
    public List<Toy> Toys { get; set; }
    public List<DogPark> DogParkVisits { get; set; }

    public Dog(string name, string breed, string loves)
    {
        Name = name;
        Breed = breed;
        Loves = loves;
        Toys = [];
        DogParkVisits = [];
    }
}

internal class Owner(string firstName, string lastName)
{
    public int Id { get; set; }
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
}
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

    public Dog(int id, string name, string breed, string loves)
    {
        Id = id;
        Name = name;
        Breed = breed;
        Loves = loves;
        Toys = [];
    }

}

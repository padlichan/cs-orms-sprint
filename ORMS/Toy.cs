namespace ORMS;

internal class Toy(int id, string name, bool squeaks, int dogId)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public bool Squeaks { get; set; } = squeaks;
    public int DogId { get; set; } = dogId;

    //Reference properties

    public Dog Dog { get; set; }
}



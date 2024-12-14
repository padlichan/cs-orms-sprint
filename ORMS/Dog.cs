namespace ORMS;

internal class Dog(int id, string name, string breed, string loves)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Breed { get; set; } = breed;
    public string Loves { get; set; } = loves;
}

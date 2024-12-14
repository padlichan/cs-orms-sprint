using System.ComponentModel.DataAnnotations;

namespace ORMS;

internal class Toy(string name, bool squeaks, int? dogId = null)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public bool Squeaks { get; set; } = squeaks;
    public int? DogId { get; set; } = dogId;

    //Reference properties

    public Dog Dog { get; set; }
}

internal class Park(string name, int? ratingOutOf10 = null)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;

    [Range(1,10)]
    public int? RatingOutOf10{ get; set; } = ratingOutOf10;
}





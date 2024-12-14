using System.ComponentModel.DataAnnotations;

namespace ORMS;

internal class Park(string name, int? ratingOutOf10 = null)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;

    [Range(1,10)]
    public int? RatingOutOf10{ get; set; } = ratingOutOf10;
    public List<Dog> DogsVisited { get; set; } = [];

}





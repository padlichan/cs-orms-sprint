﻿namespace ORMS;

internal class DogPark
{
    public int Id { get; set; }
    public int DogId { get; set; }
    public int ParkId { get; set; }

    //Navigation properties
    public Dog Dog { get; set; }
    public Park Park { get; set; }
}



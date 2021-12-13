using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Rooms : BaseEntity
{   
    [Key]
    public int roomId { get; set; }
    public string room { get; set; }
    public string price{ get; set; }
    public int apartmentId { get; set; }
}


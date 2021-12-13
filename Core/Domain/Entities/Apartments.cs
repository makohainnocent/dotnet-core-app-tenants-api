using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Apartments : BaseEntity
{   
    [Key]
    public int apartmentId { get; set; }
    public string Name { get; set; }
    public int  userId { get; set; }
}


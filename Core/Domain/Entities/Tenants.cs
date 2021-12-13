using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Tenants : BaseEntity
{   [Key]
    public int tenantId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string phone { get; set; }
    public int roomId { get; set; }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Users : BaseEntity
{   [Key]
    public int userId { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
}


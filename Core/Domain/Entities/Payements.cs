using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Payements : BaseEntity
{   
    [Key]
    public int payementId { get; set; }
    public int Paid { get; set; }
    public int roomId { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
   
}


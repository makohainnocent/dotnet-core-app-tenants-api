using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public  class PayementsRoomsTenants
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string phone { get; set; }
    public string room { get; set; }
    public string price { get; set; }
    public int paid { get; set; }
}
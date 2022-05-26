using System;
using System.ComponentModel.DataAnnotations;

namespace QuintrixMVC.Models;

public class ValuableThing : IThing
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public decimal Value { get; set; }

    public ValuableThing()
    {
        Value = (decimal)1000000;
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace QuintrixMVC.Models;

public class PiddlyThing : IThing
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; } = "A piddly thing of no value whatsoever.";

    public PiddlyThing()
    {
    }
}

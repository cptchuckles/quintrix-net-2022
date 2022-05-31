using System;
using System.ComponentModel.DataAnnotations;

namespace QuintrixMVC.Models;

sealed public class PiddlyThing : IThing
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    private string _description = "A piddly thing of no value whatsoever.";
    public string Description { get => _description; set {} }

    public PiddlyThing()
    {
    }
}

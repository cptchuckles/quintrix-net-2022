using System;
using System.ComponentModel.DataAnnotations;

namespace QuintrixMVC.Models;

public interface IThing
{
    [Key]
    Guid Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
}

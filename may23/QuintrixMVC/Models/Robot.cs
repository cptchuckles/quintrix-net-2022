using System;
using System.ComponentModel.DataAnnotations;

namespace QuintrixMVC.Models
{
    public class Robot
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public uint PowerLevel { get; set; }
    }
}

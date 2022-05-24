using System;
using System.ComponentModel.DataAnnotations;

namespace QuintrixMVC.Models
{
    public class Robot
    {
        [Key]
        public Guid Id { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value.ToUpper().Replace(' ', '_');
        }

        private uint _powerLevel;
        public uint PowerLevel
        {
            get => _powerLevel;
            set
            {
                if (value < 9000)
                    throw new Exception("Your power level is too MEASLEY");

                _powerLevel = value;
            }
        }
    }
}

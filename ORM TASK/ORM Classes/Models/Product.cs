using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Classes.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }

        public Product(int id, string name, string description, double weight, double height, double width, double length)
        {
            Id = id;
            Name = name;
            Description = description;
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;
        }
    }
}

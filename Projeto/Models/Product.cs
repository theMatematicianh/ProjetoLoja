using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Projeto.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DescriptionP { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public DateTime ManufactoringDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        //navigation property: configure one-t0-many relationship with Photo 
        public List<Photo> Photos { get; set; } = new List<Photo>();
        [FromForm]
        [NotMapped]
        public IFormFileCollection Files { get; set; } 

        public Product()
        {
        }

        public Product(int id, string descriptionP, decimal price, int size, DateTime manufactoringDate, DateTime expirationDate)
        {
            Id = id;
            DescriptionP = descriptionP;
            Price = price;
            Size = size;
            ManufactoringDate = manufactoringDate;
            ExpirationDate = expirationDate;
        }
    }
}

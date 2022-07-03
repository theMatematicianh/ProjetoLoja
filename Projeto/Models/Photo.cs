using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public byte[] Bytes { get; set; }
        public string DescriptionF { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public Photo()
        {
        }

        public Photo(int id, byte[] bytes, string descriptionF, string fileExtension, decimal size, int productId)
        {
            Id = id;
            Bytes = bytes;
            DescriptionF = descriptionF;
            FileExtension = fileExtension;
            Size = size;
            ProductId = productId;
        }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Practice.Model.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, DisplayName("Product Image URL")]
        public string Url { get; set; }

        [Required]
        public string Author { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required, DisplayName("Price 0 - 50")]
        public double Price {  get; set; }

        [Required, DisplayName("Price 50 - 100")]
        public double Price50_100 { get; set; }

        [Required, DisplayName("Price 100 - 150")]
        public double Price100_150 { get; set; }

        [Required, DisplayName("Price More-Than 150")]
        public double Price150 { get; set; }
    }
}

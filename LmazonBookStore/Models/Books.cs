using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LmazonBookStore.Models
{
    public partial class Books
    {
        [Key]
        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter author name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter publisher name")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Please enter ISBN number")]
        public string Isbn { get; set; }

        [Required(ErrorMessage = "Please enter classisficaiton")]
        public string Classification { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter page number")]
        public int PageCount { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [DefaultValue("getutcdate()")]
        public DateTime? DateAdded { get; set; } = DateTime.Now;

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public MovieDto()
        {
            DateAdded = DateTime.UtcNow; //NAO FUNCIONA ESSA BOSTA
        }
    }
}
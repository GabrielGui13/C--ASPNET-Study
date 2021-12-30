using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie { //Criado a model para os filmes
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("Genre")]
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [DefaultValue("getutcdate()")]
        public DateTime? DateAdded { get; set; } = DateTime.Now;

        [Display(Name = "Number in Stock")]
        [Required]
        public int NumberInStock { get; set; }

        public Movie()
        {
            DateAdded = DateTime.UtcNow; //NAO FUNCIONA ESSA BOSTA
        }
    }
}
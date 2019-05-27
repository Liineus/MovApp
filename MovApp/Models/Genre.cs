using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.Models
{
    public class Genre
    {
        [Key]
        public short GenreId { get; set; }
        public string GenreName { get; set; }

        // references to the associated objects
        // virtual property to store the list of all MoviesGenre records
        // virtual - loading the data only if we need them

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
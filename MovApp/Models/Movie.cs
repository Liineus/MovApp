using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Name_org { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Premiere { get; set; }
        public string Description { get; set; }
        /*public List<string> Genre_list { get; set; }
        public string Director_list { get; set; }
        public string Star_list { get; set; }
        public string Writer_list { get; set; }
        */

        // references to the associated objects         
        // virtual property to store the list of all MoviesGenre records         
        // virtual - loading the data only if we need them          

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<MovieCreatorProfession> MovieCreatorProfessions { get; set; }
    }
}
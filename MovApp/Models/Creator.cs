using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.Models
{
    public class Creator
    {
        [Key]
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<MovieCreatorProfession> MovieCreatorProfessions { get; set; }
    }
}
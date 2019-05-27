using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.Models
{
    public class Profession
    {
        [Key]
        public int ProfessionId { get; set; }
        public string Name { get; set; }

        public int ProfessionTypeId { get; set; }

        public virtual ICollection<MovieCreatorProfession> MovieCreatorProfessions { get; set; }
        public virtual ProfessionType ProfessionType { get; set; }
    }
}
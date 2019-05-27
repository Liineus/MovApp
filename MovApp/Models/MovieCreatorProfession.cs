using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.Models
{
    public class MovieCreatorProfession
    {
        [Key]
        public int MovieCreatorProfessionId { get; set; }
        public int MovieId { get; set; }
        public int CreatorId { get; set; }
        public int ProfessionId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Creator Creator { get; set; }
        public virtual Profession Profession { get; set; }
    }
}
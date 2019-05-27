using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.Models
{
    public class ProfessionType
    {
        [Key]
        public int ProfessionTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Profession> Professions { get; set; }
    }
}
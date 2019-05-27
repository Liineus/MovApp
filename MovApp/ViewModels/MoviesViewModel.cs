using MovApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.ViewModels
{
    public class MoviesViewModel
    {
        [Key]
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Name_org { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Premiere { get; set; }
        public string Description { get; set; }

        public virtual List<MovieCheckBoxViewModel> Genres { get; set; }
        public virtual List<Creator> Creators { get; set; }
        public virtual List<Profession> Professions { get; set; }
        public virtual List<ProfessionType> ProfessionTypes { get; set; }
    }
}
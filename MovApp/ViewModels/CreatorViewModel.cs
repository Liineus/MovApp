using MovApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.ViewModels
{
    public class CreatorViewModel
    {
        [Key]
        public int CreatorVievModelId { get; set; }
        public MovieCreatorProfession MovieCreatorProfessions { get; set; }

    }
}
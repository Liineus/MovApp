﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovApp.Models
{
    public class MovieGenre
    {
        [Key]
        public int MovieGenreId { get; set; }
        public int MovieId { get; set; }
        public short GenreId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
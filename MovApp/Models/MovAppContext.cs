using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovApp.Models
{
    public class MovAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MovAppContext() : base("name=MovAppContext")
        {
        }

        public System.Data.Entity.DbSet<MovApp.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MovApp.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<MovApp.Models.MovieGenre> MovieGenres { get; set; }

        public System.Data.Entity.DbSet<MovApp.ViewModels.MoviesViewModel> MoviesViewModels { get; set; }

        public System.Data.Entity.DbSet<MovApp.Models.ProfessionType> ProfessionTypes { get; set; }

        public System.Data.Entity.DbSet<MovApp.Models.Profession> Professions { get; set; }

        public System.Data.Entity.DbSet<MovApp.Models.MovieCreatorProfession> MovieCreatorProfessions { get; set; }

        public System.Data.Entity.DbSet<MovApp.Models.Creator> Creators { get; set; }
    }
}

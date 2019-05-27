namespace MovApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Creators> Creators { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<MovieCheckBoxViewModels> MovieCheckBoxViewModels { get; set; }
        public virtual DbSet<MovieCreatorProfessions> MovieCreatorProfessions { get; set; }
        public virtual DbSet<MovieGenres> MovieGenres { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<MoviesViewModels> MoviesViewModels { get; set; }
        public virtual DbSet<Professions> Professions { get; set; }
        public virtual DbSet<ProfessionTypes> ProfessionTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesViewModels>()
                .HasMany(e => e.Creators)
                .WithOptional(e => e.MoviesViewModels)
                .HasForeignKey(e => e.MoviesViewModel_MovieId);

            modelBuilder.Entity<MoviesViewModels>()
                .HasMany(e => e.MovieCheckBoxViewModels)
                .WithOptional(e => e.MoviesViewModels)
                .HasForeignKey(e => e.MoviesViewModel_MovieId);

            modelBuilder.Entity<MoviesViewModels>()
                .HasMany(e => e.Professions)
                .WithOptional(e => e.MoviesViewModels)
                .HasForeignKey(e => e.MoviesViewModel_MovieId);

            modelBuilder.Entity<MoviesViewModels>()
                .HasMany(e => e.ProfessionTypes)
                .WithOptional(e => e.MoviesViewModels)
                .HasForeignKey(e => e.MoviesViewModel_MovieId);
        }
    }
}

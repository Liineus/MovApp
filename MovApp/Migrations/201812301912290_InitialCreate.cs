namespace MovApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Name_org = c.String(),
                        Premiere = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieCreatorProfessions",
                c => new
                    {
                        MovieCreatorProfessionId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        CreatorProfessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieCreatorProfessionId)
                .ForeignKey("dbo.CreatorProfessions", t => t.CreatorProfessionId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CreatorProfessionId);
            
            CreateTable(
                "dbo.CreatorProfessions",
                c => new
                    {
                        CreatorProfessionId = c.Int(nullable: false, identity: true),
                        CreatorId = c.Int(nullable: false),
                        ProfessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreatorProfessionId)
                .ForeignKey("dbo.Creators", t => t.CreatorId, cascadeDelete: true)
                .ForeignKey("dbo.Professions", t => t.ProfessionId, cascadeDelete: true)
                .Index(t => t.CreatorId)
                .Index(t => t.ProfessionId);
            
            CreateTable(
                "dbo.Creators",
                c => new
                    {
                        CreatorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CreatorId);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        ProfessionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProfessionId);
            
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        MovieGenreId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.MovieGenreId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Short(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieGenres", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieCreatorProfessions", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CreatorProfessions", "ProfessionId", "dbo.Professions");
            DropForeignKey("dbo.MovieCreatorProfessions", "CreatorProfessionId", "dbo.CreatorProfessions");
            DropForeignKey("dbo.CreatorProfessions", "CreatorId", "dbo.Creators");
            DropIndex("dbo.MovieGenres", new[] { "GenreId" });
            DropIndex("dbo.MovieGenres", new[] { "MovieId" });
            DropIndex("dbo.CreatorProfessions", new[] { "ProfessionId" });
            DropIndex("dbo.CreatorProfessions", new[] { "CreatorId" });
            DropIndex("dbo.MovieCreatorProfessions", new[] { "CreatorProfessionId" });
            DropIndex("dbo.MovieCreatorProfessions", new[] { "MovieId" });
            DropTable("dbo.Genres");
            DropTable("dbo.MovieGenres");
            DropTable("dbo.Professions");
            DropTable("dbo.Creators");
            DropTable("dbo.CreatorProfessions");
            DropTable("dbo.MovieCreatorProfessions");
            DropTable("dbo.Movies");
        }
    }
}

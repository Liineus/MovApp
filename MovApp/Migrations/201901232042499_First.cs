namespace MovApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreatorProfessions", "CreatorId", "dbo.Creators");
            DropForeignKey("dbo.MovieCreatorProfessions", "CreatorProfessionId", "dbo.CreatorProfessions");
            DropForeignKey("dbo.CreatorProfessions", "ProfessionId", "dbo.Professions");
            DropIndex("dbo.MovieCreatorProfessions", new[] { "CreatorProfessionId" });
            DropIndex("dbo.CreatorProfessions", new[] { "CreatorId" });
            DropIndex("dbo.CreatorProfessions", new[] { "ProfessionId" });
            CreateTable(
                "dbo.ProfessionTypes",
                c => new
                    {
                        ProfessionTypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        MoviesViewModel_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfessionTypeId)
                .ForeignKey("dbo.MoviesViewModels", t => t.MoviesViewModel_MovieId)
                .Index(t => t.MoviesViewModel_MovieId);
            
            CreateTable(
                "dbo.MoviesViewModels",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Name_org = c.String(),
                        Premiere = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieCheckBoxViewModels",
                c => new
                    {
                        CheckBoxId = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Checked = c.Boolean(nullable: false),
                        MoviesViewModel_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.CheckBoxId)
                .ForeignKey("dbo.MoviesViewModels", t => t.MoviesViewModel_MovieId)
                .Index(t => t.MoviesViewModel_MovieId);
            
            AddColumn("dbo.MovieCreatorProfessions", "CreatorId", c => c.Int(nullable: false));
            AddColumn("dbo.MovieCreatorProfessions", "ProfessionId", c => c.Int(nullable: false));
            AddColumn("dbo.Creators", "MoviesViewModel_MovieId", c => c.Int());
            AddColumn("dbo.Professions", "ProfessionTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Professions", "MoviesViewModel_MovieId", c => c.Int());
            CreateIndex("dbo.Creators", "MoviesViewModel_MovieId");
            CreateIndex("dbo.MovieCreatorProfessions", "CreatorId");
            CreateIndex("dbo.MovieCreatorProfessions", "ProfessionId");
            CreateIndex("dbo.Professions", "ProfessionTypeId");
            CreateIndex("dbo.Professions", "MoviesViewModel_MovieId");
            AddForeignKey("dbo.MovieCreatorProfessions", "CreatorId", "dbo.Creators", "CreatorId", cascadeDelete: true);
            AddForeignKey("dbo.MovieCreatorProfessions", "ProfessionId", "dbo.Professions", "ProfessionId", cascadeDelete: true);
            AddForeignKey("dbo.Professions", "ProfessionTypeId", "dbo.ProfessionTypes", "ProfessionTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Creators", "MoviesViewModel_MovieId", "dbo.MoviesViewModels", "MovieId");
            AddForeignKey("dbo.Professions", "MoviesViewModel_MovieId", "dbo.MoviesViewModels", "MovieId");
            DropColumn("dbo.MovieCreatorProfessions", "CreatorProfessionId");
            DropTable("dbo.CreatorProfessions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CreatorProfessions",
                c => new
                    {
                        CreatorProfessionId = c.Int(nullable: false, identity: true),
                        CreatorId = c.Int(nullable: false),
                        ProfessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreatorProfessionId);
            
            AddColumn("dbo.MovieCreatorProfessions", "CreatorProfessionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProfessionTypes", "MoviesViewModel_MovieId", "dbo.MoviesViewModels");
            DropForeignKey("dbo.Professions", "MoviesViewModel_MovieId", "dbo.MoviesViewModels");
            DropForeignKey("dbo.MovieCheckBoxViewModels", "MoviesViewModel_MovieId", "dbo.MoviesViewModels");
            DropForeignKey("dbo.Creators", "MoviesViewModel_MovieId", "dbo.MoviesViewModels");
            DropForeignKey("dbo.Professions", "ProfessionTypeId", "dbo.ProfessionTypes");
            DropForeignKey("dbo.MovieCreatorProfessions", "ProfessionId", "dbo.Professions");
            DropForeignKey("dbo.MovieCreatorProfessions", "CreatorId", "dbo.Creators");
            DropIndex("dbo.MovieCheckBoxViewModels", new[] { "MoviesViewModel_MovieId" });
            DropIndex("dbo.ProfessionTypes", new[] { "MoviesViewModel_MovieId" });
            DropIndex("dbo.Professions", new[] { "MoviesViewModel_MovieId" });
            DropIndex("dbo.Professions", new[] { "ProfessionTypeId" });
            DropIndex("dbo.MovieCreatorProfessions", new[] { "ProfessionId" });
            DropIndex("dbo.MovieCreatorProfessions", new[] { "CreatorId" });
            DropIndex("dbo.Creators", new[] { "MoviesViewModel_MovieId" });
            DropColumn("dbo.Professions", "MoviesViewModel_MovieId");
            DropColumn("dbo.Professions", "ProfessionTypeId");
            DropColumn("dbo.Creators", "MoviesViewModel_MovieId");
            DropColumn("dbo.MovieCreatorProfessions", "ProfessionId");
            DropColumn("dbo.MovieCreatorProfessions", "CreatorId");
            DropTable("dbo.MovieCheckBoxViewModels");
            DropTable("dbo.MoviesViewModels");
            DropTable("dbo.ProfessionTypes");
            CreateIndex("dbo.CreatorProfessions", "ProfessionId");
            CreateIndex("dbo.CreatorProfessions", "CreatorId");
            CreateIndex("dbo.MovieCreatorProfessions", "CreatorProfessionId");
            AddForeignKey("dbo.CreatorProfessions", "ProfessionId", "dbo.Professions", "ProfessionId", cascadeDelete: true);
            AddForeignKey("dbo.MovieCreatorProfessions", "CreatorProfessionId", "dbo.CreatorProfessions", "CreatorProfessionId", cascadeDelete: true);
            AddForeignKey("dbo.CreatorProfessions", "CreatorId", "dbo.Creators", "CreatorId", cascadeDelete: true);
        }
    }
}

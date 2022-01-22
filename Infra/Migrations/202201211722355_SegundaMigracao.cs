namespace MeuDioSeries.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        GeneroId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.Serie",
                c => new
                    {
                        SerieId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        AnoLancamento = c.Int(nullable: false),
                        Excluida = c.Boolean(nullable: false),
                        GeneroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerieId)
                .ForeignKey("dbo.Genero", t => t.GeneroId)
                .Index(t => t.GeneroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Serie", "GeneroId", "dbo.Genero");
            DropIndex("dbo.Serie", new[] { "GeneroId" });
            DropTable("dbo.Serie");
            DropTable("dbo.Genero");
        }
    }
}

namespace Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Serie",
                c => new
                    {
                        SerieId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        AnoLancamento = c.Int(nullable: false),
                        Excluida = c.Boolean(nullable: false),
                        Genero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Serie");
        }
    }
}

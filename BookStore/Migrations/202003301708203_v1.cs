namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Livro_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livroes", t => t.Livro_Id)
                .Index(t => t.Livro_Id);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        ISBN = c.String(nullable: false, maxLength: 30),
                        DataLancamento = c.DateTime(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livroes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Autors", "Livro_Id", "dbo.Livroes");
            DropIndex("dbo.Livroes", new[] { "CategoriaId" });
            DropIndex("dbo.Autors", new[] { "Livro_Id" });
            DropTable("dbo.Livroes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Autors");
        }
    }
}

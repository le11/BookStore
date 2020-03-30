namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Autors", "Livro_Id", "dbo.Livroes");
            DropIndex("dbo.Autors", new[] { "Livro_Id" });
            CreateTable(
                "dbo.LivroAutors",
                c => new
                    {
                        Livro_Id = c.Int(nullable: false),
                        Autor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Livro_Id, t.Autor_Id })
                .ForeignKey("dbo.Livroes", t => t.Livro_Id, cascadeDelete: true)
                .ForeignKey("dbo.Autors", t => t.Autor_Id, cascadeDelete: true)
                .Index(t => t.Livro_Id)
                .Index(t => t.Autor_Id);
            
            DropColumn("dbo.Autors", "Livro_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Autors", "Livro_Id", c => c.Int());
            DropForeignKey("dbo.LivroAutors", "Autor_Id", "dbo.Autors");
            DropForeignKey("dbo.LivroAutors", "Livro_Id", "dbo.Livroes");
            DropIndex("dbo.LivroAutors", new[] { "Autor_Id" });
            DropIndex("dbo.LivroAutors", new[] { "Livro_Id" });
            DropTable("dbo.LivroAutors");
            CreateIndex("dbo.Autors", "Livro_Id");
            AddForeignKey("dbo.Autors", "Livro_Id", "dbo.Livroes", "Id");
        }
    }
}

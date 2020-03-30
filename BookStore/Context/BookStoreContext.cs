using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
           :base("BookStoreConnectionString")
        { 
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
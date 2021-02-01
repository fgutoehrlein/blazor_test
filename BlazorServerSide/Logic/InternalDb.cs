using BlazorServerSide.Database;
using BlazorServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSide.Logic
{
    public static class InternalDb
    {
        public static List<Book> GetBooks(InMemoryContext dbInMemoryContext)
        {
            return dbInMemoryContext.Books.ToList();
        }
        public static async Task LoadBook(InMemoryContext dbInMemoryContext)
        {
            Book book_0 = new Book() { Id = "0", Author = "RandomDude", Title = "SomeBook" };
            await dbInMemoryContext.Books.AddAsync(book_0);
            var book_1 = new Book() { Id = "1", Author = "RandomDude", Title = "SomeOtherBook" };
            await dbInMemoryContext.Books.AddAsync(book_1);
            await dbInMemoryContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

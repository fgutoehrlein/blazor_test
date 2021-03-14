using BlazorServerSide.Database;
using BlazorServerSide.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSide.Logic
{
    public static class InternalDb
    {
        public static async Task<List<Book>> LoadBooks(InMemoryContext dbInMemoryContext)
        {
            return await dbInMemoryContext.Books.ToListAsync();
        }
        public static async Task LoadBook(InMemoryContext dbInMemoryContext)
        {
            Book book_0 = new Book() { Author = "RandomDude", Title = "SomeBook" };
            await dbInMemoryContext.Books.AddAsync(book_0);
            var book_1 = new Book() { Author = "RandomDude", Title = "SomeOtherBook" };
            await dbInMemoryContext.Books.AddAsync(book_1);
            await dbInMemoryContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

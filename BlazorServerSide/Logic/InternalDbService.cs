using BlazorServerSide.Database;
using BlazorServerSide.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSide.Logic
{
    public class InternalDbService
    {
        public InMemoryContext _DbInMemoryContext { get; set; }
        public InternalDbService()
        {
            var optionBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("InMemoryDb"); ;
            _DbInMemoryContext = new InMemoryContext(optionBuilder.Options);
        }
        public async Task<List<Book>> LoadBooks()
        {
            return await _DbInMemoryContext.Books.ToListAsync();
        }
        public async Task InsertNewBook(string newBookTitle, string newBookAuthor)
        {
            var newBook = new Book();

            newBook.Title = newBookTitle;
            newBook.Author = newBookAuthor;
            newBook.BorrowDate = DateTime.UtcNow;

            await _DbInMemoryContext.Books.AddAsync(newBook);
            await _DbInMemoryContext.SaveChangesAsync();
        }
        public static async Task SeedBooks(InMemoryContext dbInMemoryContext)
        {
            Book book_0 = new Book() { Author = "RandomDude", Title = "SomeBook" };
            await dbInMemoryContext.Books.AddAsync(book_0);
            var book_1 = new Book() { Author = "RandomDude", Title = "SomeOtherBook" };
            await dbInMemoryContext.Books.AddAsync(book_1);
            await dbInMemoryContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

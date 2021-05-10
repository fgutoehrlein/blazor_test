using BlazorServerSide.Database;
using BlazorServerSide.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class InternalDbServiceTest
    {
        public InMemoryContext DbContext { get; set; }

        [TestInitialize]
        public void Inititalize()
        {
            var optionBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("InMemoryDb"); ;
            DbContext = new InMemoryContext(optionBuilder.Options);
        }
        [TestMethod]
        public async Task InternalDbSeedBooks_Test()
        {
            DbContext.Books.RemoveRange(DbContext.Books.AsEnumerable());
            await DbContext.SaveChangesAsync();
            await InternalDbService.SeedBooks(DbContext);

            Assert.IsTrue(DbContext.Books.Count() == 2);
        }
        [TestMethod]
        public async Task InternalDbInsertNewBook_Test()
        {
            DbContext.Books.RemoveRange(DbContext.Books.AsEnumerable());
            await DbContext.SaveChangesAsync();
            DbContext.Books.RemoveRange(DbContext.Books.AsEnumerable());
            await DbContext.SaveChangesAsync();

            var internalDbService = new InternalDbService();
            await internalDbService.InsertNewBook("TestBook", "TestAuthor");

            var addedBook = DbContext.Books.FirstOrDefault();

            Assert.IsTrue(
                DbContext.Books.Count() == 1 
                && addedBook.Title == "TestBook" 
                && addedBook.Author == "TestAuthor"
                );
        }
        [TestMethod]
        public async Task LoadBooks_Test()
        {
            DbContext.Books.RemoveRange(DbContext.Books.AsEnumerable());
            await DbContext.SaveChangesAsync();
            await InternalDbService.SeedBooks(DbContext);
            var internalDbService = new InternalDbService();

            var bookList = await internalDbService.LoadBooks();
            Assert.IsTrue(bookList.Count() == 2);
        }
    }
}

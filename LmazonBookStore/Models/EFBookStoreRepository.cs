using System;
using System.Linq;

namespace LmazonBookStore.Models
{
    public class EFBookStoreRepository : IBookStoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookStoreRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Books> Books => context.Books;

        public void CreateProduct(Books b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteProduct(Books b)
        {
            context.Remove(b);
            context.SaveChanges();
        }

        public void SaveProduct(Books b)
        {
            context.SaveChanges();
        }
    }
}

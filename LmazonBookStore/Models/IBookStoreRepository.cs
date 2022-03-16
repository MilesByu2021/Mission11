using System;
using System.Linq;

namespace LmazonBookStore.Models
{
    public interface IBookStoreRepository
    {
        IQueryable<Books> Books { get; }

        void SaveProduct(Books b);

        void CreateProduct(Books b);

        void DeleteProduct(Books b);
    }
}

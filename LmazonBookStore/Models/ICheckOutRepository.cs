using System;
using System.Linq;

namespace LmazonBookStore.Models
{
    public interface ICheckOutRepository
    {
        public IQueryable<CheckOut> CheckOut { get; }

        public void SaveCheckOut(CheckOut checkout);

    }
}

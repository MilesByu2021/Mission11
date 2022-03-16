using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LmazonBookStore.Models
{
    public class EFCheckOutRepository : ICheckOutRepository
    {
        private BookstoreContext context;

        public EFCheckOutRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<CheckOut> CheckOut => context.CheckOut
            .Include(x => x.Lines)
            .ThenInclude(x => x.Books);

        public void SaveCheckOut(CheckOut checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Books));

            if (checkout.CheckoutId == 0)
            {
                context.CheckOut.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}

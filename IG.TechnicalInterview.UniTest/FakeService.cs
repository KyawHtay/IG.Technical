using IG.TechnicalInterview.Data.Context;
using IG.TechnicalInterview.Domain;
using IG.TechnicalInterview.Model.Supplier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.TechnicalInterview.UniTest
{
    class FakeService : ISupplierService
    {
        private readonly SupplierContext _context;

        public FakeService(SupplierContext context)
        {
            _context = context;
        }
        public Task<Supplier> DeleteSupplier(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Supplier> GetSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.Where(s => s.Id == id)
                                                    .Select(x => new { title = x.Title, firstName = x.FirstName, lastName = x.LastName, Id = x.Id, phone = "", Emails = "" })
                                                    .FirstOrDefaultAsync();


            return new Supplier { Id = supplier.Id, Title = supplier.title, FirstName = supplier.firstName, LastName = supplier.lastName };
        }

        public Task<List<Supplier>> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public Task InsertSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}

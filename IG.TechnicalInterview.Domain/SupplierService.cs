using IG.TechnicalInterview.Data.Context;
using IG.TechnicalInterview.Model.Extensions;
using IG.TechnicalInterview.Model.Supplier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IG.TechnicalInterview.Domain
{
    public class SupplierService : ISupplierService
    {
        private readonly SupplierContext _context;

        public SupplierService(SupplierContext context)
        {
            _context = context;
        }

        public async Task<Supplier> GetSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.Where(s => s.Id == id)
                                                    .Select(x=>new { title=x.Title,firstName=x.FirstName,lastName=x.LastName,Id= x.Id,phone ="", Emails=""})
                                                    .FirstOrDefaultAsync();
                                      

            return new Supplier {Id= supplier.Id, Title=supplier.title,FirstName= supplier.firstName, LastName=supplier.lastName };
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task InsertSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(new Supplier { Id = supplier.Id, Title = supplier.Title, FirstName = supplier.FirstName, LastName = supplier.LastName });
            await _context.SaveChangesAsync();
        }

        public async Task<Supplier> DeleteSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                if (supplier.IsActive())
                {
                    throw new Exception($"Supplier {id} is active, can't be deleted");
                }

                _context.Suppliers.Remove(supplier);
            }

            return supplier;
        }
    }
}

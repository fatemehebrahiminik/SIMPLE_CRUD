using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.DBContext;
using DataLayer.Entities;

namespace CURD.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.DBContext.CRUD_DBContext _context;

        public IndexModel(DataLayer.DBContext.CRUD_DBContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers
                .Include(c => c.Nation).ToListAsync();
        }
    }
}

using AutoMapper;
using DataLayer.DBContext;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Servises.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Services
{
    public class CustomerService
    {
        #region Property
        private readonly CRUD_DBContext _crudDb;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CustomerService(CRUD_DBContext crudDb, IMapper mapper)
        {
            _crudDb = crudDb;
            _mapper = mapper;
        }
        #endregion

        #region Get List of Customers
        public async Task<List<CustomerModel>> GetAllCustomersAsync()
        {
            var Customers = await _crudDb.Customers.ToListAsync();
            return _mapper.Map<List<CustomerModel>>(Customers);
        }
        #endregion

        #region Insert Customer
        public async Task<bool> InsertCustomerAsync(Customer Customer)
        {
            await _crudDb.Customers.AddAsync(Customer);
            await _crudDb.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Customer by Id
        public async Task<Customer> GetCustomerAsync(int Id)
        {
            Customer Customer = await _crudDb.Customers.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return Customer;
        }
        #endregion

        #region Update Customer
        public async Task<bool> UpdateCustomerAsync(Customer Customer)
        {
            _crudDb.Customers.Update(Customer);
            await _crudDb.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteCustomer
        public async Task<bool> DeleteCustomerAsync(Customer Customer)
        {
            _crudDb.Remove(Customer);
            await _crudDb.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}

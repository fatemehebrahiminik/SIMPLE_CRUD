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
  public  class NationService
    {
        #region Property
        private readonly CRUD_DBContext _crudDb;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public NationService(CRUD_DBContext crudDb, IMapper mapper)
        {
            _crudDb = crudDb;
            _mapper = mapper;
        }
        #endregion

        #region Get List of Nations
        public async Task<List<NationModel>> GetAllNationsAsync()
        {
            var Nations = await _crudDb.Nations.ToListAsync();
            return _mapper.Map<List<NationModel>>(Nations);
        }
         
        #region Get Nation by Id
        public async Task<NationModel> GetNationsAsync(int Id)
        {
            Nation Nation = await _crudDb.Nations.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return _mapper.Map<NationModel>(Nation);
        }
        #endregion
        #endregion

    }
}

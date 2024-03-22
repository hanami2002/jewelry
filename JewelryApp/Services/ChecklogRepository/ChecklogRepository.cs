using DataTranferObject.ChecklogDTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ChecklogRepository
{
    public class ChecklogRepository : IChecklogRepository
    {
        private readonly JewelryContext _dbContext;

        public ChecklogRepository(JewelryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CheckLog> GetByIdAsync(int id)
        {
            return await _dbContext.CheckLogs.FindAsync(id);
        }

        public async Task<List<CheckLog>> GetAllAsync()
        {
            return await _dbContext.CheckLogs.ToListAsync();
        }

        public async Task AddAsync(CheckLog checkLog)
        {
            _dbContext.CheckLogs.Add(checkLog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CheckLogResponeDTO>> GetByUserNameAsync(string? username)
        {
            //if(username != null)
            //{

            //    return await _dbContext.CheckLogs.Where(x => x.Username.ToLower().Contains(username.ToLower())).ToListAsync();
            //}

            //return await c
            throw new NotImplementedException();
        }

        Task<List<CheckLogResponeDTO>> IChecklogRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(CheckLogRequestDTO checkLog)
        {
            throw new NotImplementedException();
        }
    }
}

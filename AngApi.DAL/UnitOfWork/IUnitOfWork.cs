using AngApi.DAL.Model;
using AngApi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AngApi.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        
        ICalculationRepository Calculation { get; }
        IUserRepository User { get; }
        Task<int> CompleteAsync();
        int Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthenticationContext _context;
        public UnitOfWork(AuthenticationContext context)
        {
            this._context = context;
        }

        private ICalculationRepository _Calculation;
        private IUserRepository _User;
        public IUserRepository User
        {
            get
            {
                if (this._User == null)
                {
                    this._User = new UserRepository(_context);
                }
                return this._User;
            }
        }
        public ICalculationRepository Calculation
        {
            get
            {
                if (this._Calculation == null)
                {
                    this._Calculation = new CalculationRepository(_context);
                }
                return this._Calculation;
            }
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() => _context.Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K16231MilkBusiness.Interfaces
{
    public interface IGenericRepositoryFactory
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;   
    }
}

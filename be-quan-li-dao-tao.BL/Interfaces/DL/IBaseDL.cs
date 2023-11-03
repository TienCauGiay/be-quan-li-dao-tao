using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Interfaces.DL
{
    public interface IBaseDL<TEntity>
    {
        Task<IEnumerable<TEntity>?> GetAllAsync();

        Task<int> DeleteAsync(Guid id);

        Task<TEntity> GetByIdAsync(Guid id);
        Task<int> InsertAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
    }
}

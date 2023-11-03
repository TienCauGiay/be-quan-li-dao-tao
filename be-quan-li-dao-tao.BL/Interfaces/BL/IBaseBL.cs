using be_quan_li_dao_tao.BL.ResponseServices.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Interfaces.BL
{
    public interface IBaseBL<TEntity>
    {
        Task<ReponseService> GetAllAsync();

        Task<ReponseService> DeleteAsync(Guid id);

        Task<ReponseService> GetByIdAsync(Guid id);
        Task<ReponseService> InsertAsync(TEntity entity);
        Task<ReponseService> UpdateAsync(TEntity entity);
    }
}

using be_quan_li_dao_tao.BL.Interfaces.DL;
using be_quan_li_dao_tao.BL.Interfaces.UnitOfWork;
using be_quan_li_dao_tao.BL.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.DL.DL
{
    public class RoleDL : BaseDL<role>, IRoleDL
    {
        public RoleDL(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

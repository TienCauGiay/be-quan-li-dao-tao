using be_quan_li_dao_tao.BL.Interfaces.BL;
using be_quan_li_dao_tao.BL.Interfaces.DL;
using be_quan_li_dao_tao.BL.Interfaces.UnitOfWork;
using be_quan_li_dao_tao.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.BL
{
    public class RoleBL : BaseBL<role>, IRoleBL
    {
        private readonly IRoleDL _roleDL;
        private readonly IUnitOfWork _unitOfWork;
        public RoleBL(IRoleDL roleDL, IUnitOfWork unitOfWork) : base(roleDL,unitOfWork)
        {
            _roleDL = roleDL;
            _unitOfWork = unitOfWork;
        }
    }
}

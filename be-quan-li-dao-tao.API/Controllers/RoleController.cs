using be_quan_li_dao_tao.BL.Interfaces.BL;
using be_quan_li_dao_tao.BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_quan_li_dao_tao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<role>
    {
        private readonly IRoleBL _roleBL;
        public RoleController(IRoleBL roleBL) : base(roleBL)
        {
            _roleBL = roleBL;
        }
    }
}

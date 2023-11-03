using be_quan_li_dao_tao.BL.Interfaces.BL;
using be_quan_li_dao_tao.BL.Interfaces.DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_quan_li_dao_tao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase
    {
        protected readonly IBaseBL<TEntity> _baseBL;

        public BaseController(IBaseBL<TEntity> baseBL)
        {
            _baseBL = baseBL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _baseBL.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByID(Guid id)
        {
            var res = await _baseBL.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TEntity entity)
        {
            var res = await _baseBL.InsertAsync(entity);
            return Ok(res);
        }


        [HttpPut]
        public async Task<IActionResult> Put(TEntity entity)
        {
            var res = await _baseBL.UpdateAsync(entity);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _baseBL.DeleteAsync(id);
            return Ok(res);
        }
    }
}

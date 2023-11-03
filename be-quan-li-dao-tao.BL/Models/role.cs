using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public class role : BaseModel
    {
        public Guid role_id { get; set; }
        public string? description { get; set; }
    }
}

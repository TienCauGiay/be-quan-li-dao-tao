using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public class semester : BaseModel
    {
        public Guid semester_id { get; set; }
        public string semester_name { get; set;}
    }
}

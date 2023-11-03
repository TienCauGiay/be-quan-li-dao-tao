using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public class user : BaseModel
    {
        public string user_name { get; set; }
        public string pass_word { get; set; }
        public Guid role_id { get; set; }
        public int status { get; set; }
    }
}

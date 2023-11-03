using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public class subject : BaseModel
    {
        public Guid subject_id { get; set; }
        public Guid semeter_id { get; set; }
        public string subject_name { get; set; } 
        public int number_tc { get; set; }
    }
}

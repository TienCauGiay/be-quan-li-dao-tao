using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public abstract class BaseModel
    {
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime modified_date { get; set; }
        public string ? modified_by { get; set; }
    }
}

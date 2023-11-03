using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public class teacher : BaseModel
    {
        public Guid teacher_id { get; set; }
        public Guid faculty_id { get; set; }
        public string teacher_name { get;set; }
        public DateTime birthday { get; set; }
        public int gender { get; set; }
        public string? address { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? image { get; set; }
    }
}

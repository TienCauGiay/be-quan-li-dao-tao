using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public class student : BaseModel
    {
        public Guid student_id { get; set; }
        public Guid classes_id { get; set; }
        public string student_name { get; set; }
        public int gender { get; set; }
        public DateTime birthday { get; set; }
        public string? address { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? image { get; set; }
        public string? year_admission { get; set; }
    }
}

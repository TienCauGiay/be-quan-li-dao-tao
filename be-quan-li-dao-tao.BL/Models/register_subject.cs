using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public class register_subject : BaseModel
    {
        public Guid register_subject_id { get; set; }
        public Guid student_id { get; set; }
        public string? time_learning { get; set; }
        public string? address_learn { get; set; }
        public string? subject_name { get; set; }
        public string? teacher_name { get; set; }
        public int status { get; set; }
    }
}

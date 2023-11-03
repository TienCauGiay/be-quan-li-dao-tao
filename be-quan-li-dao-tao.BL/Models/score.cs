using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_quan_li_dao_tao.BL.Models
{
    public class score : BaseModel
    {
        public Guid student_id { get; set; }
        public Guid subject_id { get; set; }
        public float score_cc { get; set; }
        public float score_kt { get; set; }
        public float score_test { get; set; }
        public float score_tb { get; set; }
    }
}

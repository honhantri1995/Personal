using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongThiTracNghiem
{
    public class DeThi
    {
        public string ma { get; set; }
        public string mon { get; set; }
        public string ky { get; set; }
        public string tinhTrang { get; set; }
        public DateTime ngayTao { get; set; }

        public string de_filePath { get; set; }
        public string dapAn_filePath { get; set; }
        public Dictionary<int, CauHoi> cauHoi_dic { get; set; }

        public DeThi()
        {
            cauHoi_dic = new Dictionary<int, CauHoi>();
        }
    }
}

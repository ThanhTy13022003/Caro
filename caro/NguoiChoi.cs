using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro
{
    public class NguoiChoi
    {
        private string tennguoichoi;

        public string TenNguoiChoi
        {
            get { return tennguoichoi; }
            set { tennguoichoi = value; }
        }

        private Image danhdau;
        public Image DanhDau
        {
            get { return danhdau; }
            set { danhdau = value; }
        }
        public NguoiChoi(string name , Image mark)
        {
            this.TenNguoiChoi = name;
            this.DanhDau = mark;
        }
    }
}

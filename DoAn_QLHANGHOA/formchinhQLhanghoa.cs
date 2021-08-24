using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DoAn_QLHANGHOA.Class;

namespace DoAn_QLHANGHOA
{
    public partial class formchinhQLhanghoa : Form
    {
        xldulieu xl = new xldulieu();
        public formchinhQLhanghoa()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xl.khoichaydangnhap();
            Close();
        }

        private void formchinhQLhanghoa_Load(object sender, EventArgs e)
        {
            Class.xldulieu.Connect(); //Mở kết nối
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            xl.khoichaydangnhap();
            Close();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhacungcap cc = new nhacungcap();
            cc.MdiParent = this;
            cc.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanvien nv = new nhanvien();
            nv.MdiParent = this;
            nv.Show();
        }
        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hanghoa hh = new hanghoa();
            hh.MdiParent = this;
            hh.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            thongtinbanthan tt = new thongtinbanthan();
            tt.MdiParent = this;
            tt.Show();
        }
    }
}

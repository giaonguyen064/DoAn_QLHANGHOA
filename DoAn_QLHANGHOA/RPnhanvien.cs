using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_QLHANGHOA
{
    public partial class RPnhanvien : Form
    {
        public RPnhanvien()
        {
            InitializeComponent();
        }

        private void RPnhanvien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doAn_QLHANGHOADataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.doAn_QLHANGHOADataSet.NHANVIEN);
            // TODO: This line of code loads data into the 'doAn_QLHANGHOADataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.doAn_QLHANGHOADataSet.NHANVIEN);

            this.reportViewer1.RefreshReport();
        }
    }
}

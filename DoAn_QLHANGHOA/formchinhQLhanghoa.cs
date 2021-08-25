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
            tabControl1.Enabled = false;
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
            /*hh.MdiParent = this;
            hh.Show();*/
            tabControl1.Enabled = true;
            TabCreating(tabControl1, "HÀNG HÓA", hh);
        }

        private void thôngTinCáNhânToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            thongtinbanthan tt = new thongtinbanthan();
            tt.MdiParent = this;
            tt.Show();
        }
        public void TabCreating(TabControl TabControl, string Text, Form Form)
        {
            int Index = KiemTraTonTai(TabControl, Text);
            if (Index >= 0)
            {
                TabControl.SelectedTab = TabControl.TabPages[Index];
                TabControl.SelectedTab.Text = Text;

            }
            else
            {
                TabPage TabPage = new TabPage { Text = Text };
                TabControl.TabPages.Add(TabPage);
                TabControl.SelectedTab = TabPage;
                Form.TopLevel = false;
                Form.Parent = TabPage;
                //  Form.MdiParent = this;
                Form.Show();
                Form.Dock = DockStyle.Fill;
            }
        }
        private static int KiemTraTonTai(TabControl TabControlName, string TabName)
        {
            int temp = -1;
            for (int i = 0; i < TabControlName.TabPages.Count; i++)
            {
                if (TabControlName.TabPages[i].Text == TabName)
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font closefont = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
            Font titlefont = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Italic);
            if (e.Index > 0)
            {
                e.Graphics.DrawString("X", closefont, Brushes.Blue, e.Bounds.Right - 15, e.Bounds.Top + 5);
            }
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, titlefont, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 5);

        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {


            for (int i = 1; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle rPage = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(rPage.Right - 15, rPage.Top + 5, 10, 10);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Bạn Có Muốn Tắt Tab Này?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        break;
                    }

                }
            }
        }
    }
}

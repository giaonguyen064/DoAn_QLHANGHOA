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
    public partial class dangnhap : Form
    {
        xldulieu xl = new xldulieu();
        SqlConnection con1 = new SqlConnection(@"Data Source=LAPTOP-IR7RN1J2\MSSQLSERVER01;Initial Catalog=DoAn_QLHANGHOA;Persist Security Info=True;User ID=sa;Password=11015208");
        public dangnhap()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienThi.Checked == true) txtMatKhau.UseSystemPasswordChar = false;
            else txtMatKhau.UseSystemPasswordChar = true;
        }
        private string layUSER()
        {
            string user="";
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ACC WHERE TaiKhoan = '"+txtTaiKhoan.Text+"' AND PASS = '"+txtMatKhau.Text+"'", con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        user = dr["TaiKhoan"].ToString();
                    }
                } 
                    
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                con1.Close();
            }
            return user;
        }
        public static string userd = "";

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            //Kiểm tra nhập dữ liệu textbox
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            // Kiểm tra Tài Khoản và Mật Khẩu
            userd = layUSER();
            if (userd != "")
            {
                xl.khoichayformchinhQLhanghoa();
                Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc Mật khẩu không đúng");
            }
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}

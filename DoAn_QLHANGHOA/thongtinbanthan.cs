using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Forms;
using DoAn_QLHANGHOA.Class;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Diagnostics;

namespace DoAn_QLHANGHOA
{
    public partial class thongtinbanthan : Form
    {
        public thongtinbanthan()
        {
            InitializeComponent();
            // Chèn ảnh từ ổ cứng trực tiếp bằng thuộc tính ImageLocation
            // Thiết lập thuộc tính Size một cách tự động
            //pictureBox1.ImageLocation = @"E:\dowloang\ảnh\FB_IMG_16264571733990222.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btChinhsua_Click(object sender, EventArgs e)
        {
            txt1.Focus();
            txt1.ReadOnly = false;
            txt3.ReadOnly = false;
            txt4.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox1.ReadOnly = false;
            dateTimePicker1.Enabled = true;
            btLuu.Enabled = true;
            btUpanh.Enabled = true;
            comboBox1.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txt1.Text.Trim().Length == 0) //Nếu chưa nhập Tên Nhân viên
            {
                MessageBox.Show("Bạn phải nhập Họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1.Focus();
                return;
            }
            if (txt3.Text.Trim().Length == 0) //Nếu chưa nhập Địa chỉ
            {
                MessageBox.Show("Bạn phải nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt3.Focus();
                return;
            }
            if (txt4.Text.Trim().Length == 0) //Nếu chưa nhập SĐT
            {
                MessageBox.Show("Bạn phải nhập SĐT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt4.Focus();
                return;
            }
            sql = "UPDATE NHANVIEN SET MSNV='" + textBox2.Text.ToString() + "',TenNV=N'" + txt1.Text.ToString() + "',NgaySinh='" + xldulieu.ConvertDateTime(dateTimePicker1.Value.ToString()) + "',GioiTinh=N'" + comboBox1.SelectedItem.ToString() + "',DiaChi=N'" + txt3.Text.ToString() + "',SDT='" + txt4.Text.ToString() + "' WHERE MSNV='" + dangnhap.userd.ToString() + "'" +
                    " UPDATE ACC SET PASS='" + textBox1.Text.ToString() + "' WHERE TaiKhoan='" + dangnhap.userd.ToString() + "'" +
                    " UPDATE PIC SET PIC='" + pictureBox1.ImageLocation.ToString() + "',TenPIC=N'" + textBox3.Text.ToString() + "' WHERE MSNV='" + dangnhap.userd.ToString() + "'"; ;
            Class.xldulieu.Runsql(sql); //Thực hiện câu lệnh sql
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt1.ReadOnly = true;
            txt3.ReadOnly = true;
            txt4.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox1.ReadOnly = true;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            btLuu.Enabled = false;
            btUpanh.Enabled = false;
            checkBox1.Enabled = false;
        }

        private void thongtinbanthan_Load(object sender, EventArgs e)
        {
            
            string sql; //Lưu lệnh sql
            textBox2.Text = dangnhap.userd.ToString();
            sql = "SELECT TenNV FROM NHANVIEN WHERE MSNV = '" + dangnhap.userd.Trim() + "'";
            txt1.Text = xldulieu.GetFieldValues(sql);
            sql = "SELECT NgaySinh FROM NHANVIEN WHERE MSNV = '" + dangnhap.userd.Trim() + "'";
            dateTimePicker1.Text = xldulieu.ConvertDateTime(xldulieu.GetFieldValues(sql));
            sql = "SELECT GioiTinh FROM NHANVIEN WHERE MSNV = '" + dangnhap.userd.Trim() + "'";
            comboBox1.Text = xldulieu.GetFieldValues(sql);
            sql = "SELECT DiaChi FROM NHANVIEN WHERE MSNV = '" + dangnhap.userd.Trim() + "'";
            txt3.Text = xldulieu.GetFieldValues(sql);
            sql = "SELECT SDT FROM NHANVIEN WHERE MSNV = '" + dangnhap.userd.Trim() + "'";
            txt4.Text = xldulieu.GetFieldValues(sql);
            sql = "SELECT PASS FROM ACC WHERE TaiKhoan = '" + dangnhap.userd.Trim() + "'";
            textBox1.Text = xldulieu.GetFieldValues(sql);
            sql = "SELECT PIC FROM PIC WHERE MSNV = '" + dangnhap.userd.Trim() + "'";
            pictureBox1.ImageLocation = xldulieu.GetFieldValues(sql);
            sql = "SELECT TenPIC FROM PIC WHERE MSNV = '" + dangnhap.userd.Trim() + "'";
            textBox3.Text = xldulieu.GetFieldValues(sql);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox1.UseSystemPasswordChar = false;
            else textBox1.UseSystemPasswordChar = true;
        }
        private void btUpanh_Click(object sender, EventArgs e)
        {
            //StreamReader myfile;
            try
            {
                //Tạo bộ lọc các file khi mở OpenDialog
                //Filter lọc ra các file để bạn dễ dàng lựa chọn (ví dụ các fiel MP3, hay WMA,....)
                openFileDialog1.Filter = "JPG Files(*.JPG)|*.JPG|GIF Files(*.GIF)|*.GIF";
                //Tên của hộp thoại hiện lên - Không có thì sẽ là mặc định
                openFileDialog1.Title = "Chọn 1 hình ảnh";
                //Cho phép chọn nhiều file cùng lúc - Mặc định là false
                openFileDialog1.Multiselect = false;
                //Mở hộp thoại
                openFileDialog1.ShowDialog();
                Image img = Image.FromFile(openFileDialog1.FileName);
                // Xử lý...
                // Gán ảnh
                pictureBox1.Image = img;



                //Lấy giá trị

                /*
                                // Show hộp thoại open file ra
                                // Nhận kết quả trả về qua biến kiểu DialogResult
                                DialogResult result = openFileDialog1.ShowDialog();

                                //Kiểm tra xem người dùng đã chọn file chưa
                                if (result == DialogResult.OK)
                                {
                                    // Gán ....
                                    // Lấy hình ảnh
                                    Image img = Image.FromFile(openFileDialog1.FileName);
                                    // Xử lý...
                                    // Gán ảnh
                                    pictureBox1.Image = img;

                                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    
}

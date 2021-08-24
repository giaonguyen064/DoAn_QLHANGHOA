using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_QLHANGHOA.Class;

namespace DoAn_QLHANGHOA
{
    public partial class nhanvien : Form
    {
        DataTable NHANVIEN;
        public nhanvien()
        {
            InitializeComponent();
        }

        private void nhanvien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doAn_QLHANGHOADataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.doAn_QLHANGHOADataSet.NHANVIEN);
            LoadDataGrid();
        }
        private void ResetValue()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }
        private void LoadDataGrid()
        {
            string sql;
            sql = "SELECT * FROM NHANVIEN";
            dataGridView1.AllowUserToAddRows = false; //Ngăn người dùng thêm dữ liệu trực tiếp
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; //không cho sửa dữ liệu trực tiếp
            dataGridView1.Columns[0].HeaderText = "Mã NV";
            dataGridView1.Columns[1].HeaderText = "Tên NV";
            dataGridView1.Columns[2].HeaderText = "Ngày Sinh";
            dataGridView1.Columns[3].HeaderText = "Giới tính";
            dataGridView1.Columns[4].HeaderText = "Địa chỉ";
            dataGridView1.Columns[5].HeaderText = "SĐT";
            NHANVIEN = Class.xldulieu.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dataGridView1.DataSource = NHANVIEN; //Nguồn dữ liệu 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (NHANVIEN.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textBox1.Text = dataGridView1.CurrentRow.Cells["mSNVDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["tenNVDataGridViewTextBoxColumn"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["diaChiDataGridViewTextBoxColumn"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["sDTDataGridViewTextBoxColumn"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["ngaySinhDataGridViewTextBoxColumn"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["gioiTinhDataGridViewTextBoxColumn"].Value.ToString();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (NHANVIEN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox1.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox2.Text.Trim().Length == 0) //nếu chưa nhập tên nhà cung cấp
            {
                MessageBox.Show("Bạn chưa nhập Tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //nếu chưa nhập Địa chỉ 
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox4.Text.Trim().Length == 0) //nếu chưa nhập Email
            {
                MessageBox.Show("Bạn chưa nhập Sđt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NHANVIEN SET MSNV = '" + textBox1.Text.ToString() + "',TenNV = N'" + textBox2.Text.ToString() + "',NgaySinh = '" + xldulieu.ConvertDateTime(dateTimePicker1.Value.ToString()) + "',GioiTinh = N'" + comboBox1.SelectedItem.ToString() + "',DiaChi = N'" + textBox3.Text.ToString() + "',SDT = '" + textBox4.Text.ToString() + "' WHERE MSNV = '" + textBox1.Text.ToString()+"'";
            Class.xldulieu.Runsql(sql);
            LoadDataGrid();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (textBox1.Text.Trim().Length == 0) //Nếu chưa nhập Mã nhân viên
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0) //Nếu chưa nhập tên nhân viên
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //Nếu chưa nhập địa chỉ
            {
                MessageBox.Show("Bạn phải nhập địa chỉ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0) //Nếu chưa nhập sdt
            {
                MessageBox.Show("Bạn phải nhập sdt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (comboBox1.Text.Trim().Length == 0) //Nếu chưa nhập sdt
            {
                MessageBox.Show("Bạn phải chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "SELECT MSNV FROM NHANVIEN WHERE MSNV='" + textBox1.Text.Trim() + "'";
            if (Class.xldulieu.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            sql = "INSERT INTO NHANVIEN VALUES('" + textBox1.Text.Trim() + "',N'" + textBox2.Text.Trim() + "','" + xldulieu.ConvertDateTime(dateTimePicker1.Value.ToString()) + "', N'" + comboBox1.SelectedItem.ToString() + "',N'" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "')";
            Class.xldulieu.Runsql(sql); //Thực hiện câu lệnh sql
            LoadDataGrid(); //Nạp lại DataGridView
            ResetValue();
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            textBox1.Focus();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NHANVIEN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox1.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NHANVIEN WHERE MSNV='" + textBox1.Text + "'";
                Class.xldulieu.Rundel(sql);
                LoadDataGrid();
                ResetValue();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            RPnhanvien rpnv = new RPnhanvien();
            rpnv.Show();
        }
    }
}

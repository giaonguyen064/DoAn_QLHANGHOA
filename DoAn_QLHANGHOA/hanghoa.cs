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
    public partial class hanghoa : Form
    {
        DataTable HANGHOA;
        public hanghoa()
        {
            InitializeComponent();
        }
        private void LoadDataGrid()
        {
            string sql;
            sql = "SELECT * FROM HANGHOA";
            dataGridView1.AllowUserToAddRows = false; //Ngăn người dùng thêm dữ liệu trực tiếp
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; //không cho sửa dữ liệu trực tiếp
            dataGridView1.Columns[0].HeaderText = "Mã HH";
            dataGridView1.Columns[1].HeaderText = "Tên HH";
            dataGridView1.Columns[2].HeaderText = "Loại HH";
            dataGridView1.Columns[3].HeaderText = "Số Lượng";
            dataGridView1.Columns[4].HeaderText = "Giá bán";
            dataGridView1.Columns[5].HeaderText = "Đơn vị tính";
            HANGHOA = Class.xldulieu.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dataGridView1.DataSource = HANGHOA; //Nguồn dữ liệu 
        }
        private void KiemTraTextBox()
        {
            if (HANGHOA.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox1.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox2.Text.Trim().Length == 0) //nếu chưa nhập tên hàng hóa
            {
                MessageBox.Show("Bạn chưa nhập Tên hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //nếu chưa nhập Loại hàng hóa 
            {
                MessageBox.Show("Bạn chưa nhập Loại hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox4.Text.Trim().Length == 0) //nếu chưa nhập Số lượng
            {
                MessageBox.Show("Bạn chưa nhập Số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox5.Text.Trim().Length == 0) //nếu chưa nhập Giá bán
            {
                MessageBox.Show("Bạn chưa nhập Giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox6.Text.Trim().Length == 0) //nếu chưa nhập Đơn vị tính
            {
                MessageBox.Show("Bạn chưa nhập Đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void ResetValue()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "";
        }
        private void hanghoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doAn_QLHANGHOADataSet.HANGHOA' table. You can move, or remove it, as needed.
            this.hANGHOATableAdapter.Fill(this.doAn_QLHANGHOADataSet.HANGHOA);
            LoadDataGrid();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (HANGHOA.Rows.Count == 0)
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
                sql = "DELETE HANGHOA WHERE MaHH='" + textBox1.Text + "'";
                Class.xldulieu.Rundel(sql);
                LoadDataGrid();
                ResetValue();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (HANGHOA.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textBox1.Text = dataGridView1.CurrentRow.Cells["maHHDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["tenHHDataGridViewTextBoxColumn"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["loaiHHDataGridViewTextBoxColumn"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["soLuongDataGridViewTextBoxColumn"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["giaBanDataGridViewTextBoxColumn"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["donViTinhDataGridViewTextBoxColumn"].Value.ToString();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            KiemTraTextBox();
            sql = "UPDATE HANGHOA SET MaHH='" + textBox1.Text.Trim().ToString() + "', TenHH = N'" + textBox2.Text.Trim().ToString() + "',LoaiHH=N'" + textBox3.Text.Trim().ToString() + "',SoLuong=" + textBox4.Text.Trim() + ",GiaBan=" + textBox5.Text.Trim() + ",DonViTinh=N'" + textBox6.Text.ToString() + "' WHERE MaHH='" + textBox1.Text.Trim().ToString() + "'";
            Class.xldulieu.Runsql(sql);
            LoadDataGrid();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            textBox1.Focus();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            KiemTraTextBox();
            sql = "SELECT MaHH FROM HANGHOA WHERE MaHH='" + textBox1.Text.Trim() + "'";
            if (Class.xldulieu.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng hóa này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            sql = "INSERT INTO HANGHOA VALUES('" + textBox1.Text.Trim() + "',N'" + textBox2.Text.Trim() + "',N'" + textBox3.Text.Trim() + "'," + textBox4.Text.Trim() +"," + textBox5.Text.Trim() + ",N'" + textBox6.Text.Trim()+"')";
            Class.xldulieu.Runsql(sql); //Thực hiện câu lệnh sql
            LoadDataGrid(); //Nạp lại DataGridView
            ResetValue();
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

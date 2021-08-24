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
using System.Data.SqlClient;

namespace DoAn_QLHANGHOA
{
    public partial class nhacungcap : Form
    {
        DataTable NHACUNGCAP;
        public nhacungcap()
        {
            InitializeComponent();
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NHACUNGCAP.Rows.Count == 0)
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
                sql = "DELETE NHACUNGCAP WHERE MNCC='" + textBox1.Text + "'";
                Class.xldulieu.Rundel(sql);
                LoadDataGrid();
                ResetValue();
            }

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            textBox1.Focus();
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (textBox1.Text.Trim().Length == 0) //Nếu chưa nhập Mã nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0) //Nếu chưa nhập tên nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //Nếu chưa nhập địa chỉ
            {
                MessageBox.Show("Bạn phải nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            sql = "SELECT MNCC FROM NHACUNGCAP WHERE MNCC='" + textBox1.Text.Trim() + "'";
            if (Class.xldulieu.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            sql = "INSERT INTO NHACUNGCAP VALUES('" + textBox1.Text.Trim() + "',N'" + textBox2.Text.Trim() + "',N'" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "')";
            Class.xldulieu.Runsql(sql); //Thực hiện câu lệnh sql
            LoadDataGrid(); //Nạp lại DataGridView
            ResetValue();
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (NHACUNGCAP.Rows.Count == 0)
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
                MessageBox.Show("Bạn chưa nhập Tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox3.Text.Trim().Length == 0) //nếu chưa nhập Địa chỉ 
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox4.Text.Trim().Length == 0) //nếu chưa nhập Email
            {
                MessageBox.Show("Bạn chưa nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NHACUNGCAP SET MNCC='" + textBox1.Text.ToString() + "', TenNCC = N'" + textBox2.Text.ToString() + "',DiaChi=N'" + textBox3.Text.ToString() + "',Email='" + textBox4.Text.ToString() + "' WHERE MNCC='" + textBox1.Text.ToString() + "'";
            Class.xldulieu.Runsql(sql);
            LoadDataGrid();
        }
        private void ResetValue()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void nhacungcap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doAn_QLHANGHOADataSet.NHACUNGCAP' table. You can move, or remove it, as needed.
            this.nHACUNGCAPTableAdapter.Fill(this.doAn_QLHANGHOADataSet.NHACUNGCAP);
            //textBox1.Enabled = false;
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            string sql;
            sql = "SELECT * FROM NHACUNGCAP";
            dataGridView1.AllowUserToAddRows = false; //Ngăn người dùng thêm dữ liệu trực tiếp
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; //không cho sửa dữ liệu trực tiếp
            dataGridView1.Columns[0].HeaderText = "Mã NCC";
            dataGridView1.Columns[1].HeaderText = "Tên NCC";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Email";
            NHACUNGCAP = Class.xldulieu.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dataGridView1.DataSource = NHACUNGCAP; //Nguồn dữ liệu 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (NHACUNGCAP.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textBox1.Text = dataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn4"].Value.ToString();
        }
    }
}

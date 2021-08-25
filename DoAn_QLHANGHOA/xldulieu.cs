using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;

namespace DoAn_QLHANGHOA.Class
{
    class xldulieu
    {
        public static SqlConnection con;
        // Viết một hàm dùng để kết nối sql
        public static void Connect()
        {
            con = new SqlConnection();
            //con.ConnectionString = @"Data Source=LAPTOP-IR7RN1J2\MSSQLSERVER01;Initial Catalog=DoAn_QLHANGHOA;Persist Security Info=True;User ID=sa;Password=11015208";
            con.ConnectionString = @"Data Source=LAPTOP-KQC1SA87;Initial Catalog=DoAn_QLHANGHOA;Persist Security Info=True;User ID=sa;Password=1";
            con.Open();
            if (con.State == ConnectionState.Open)
                MessageBox.Show("Kết nối thành công!");
            else MessageBox.Show("Kết nối thất bại!");
        }
        //Viết một hàm dùng để đóng kết nối sql
        public static void Disconnect()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close(); //Đóng kết nối
                con.Dispose(); //Gỉải phóng tài nguyên
                con = null;
            }
        }
        //Viết một hàm không trả về giá trị và không có đối số thực hiện việc hiển thị dangnhap(form)
        public void Showdangnhap()
        {
            dangnhap dnhap = new dangnhap();
            dnhap.ShowDialog();
        }
        //Viết hàm khởi chạy form dangnhap
        public void khoichaydangnhap()
        {
            Thread thread = new Thread(new ThreadStart(Showdangnhap));//Tạo luồng mới
            thread.Start(); //Khởi chạy luồng
        }
        //Viết một hàm không trả về giá trị và không có đối số thực hiện việc hiển thị formchinhQLhanghoa(form)
        public void ShowformchinhQLhanghoa()
        {
            formchinhQLhanghoa tchu = new formchinhQLhanghoa();
            tchu.ShowDialog();
        }
        //viết hàm khởi chạy form formchinhQLhanghoa
        public void khoichayformchinhQLhanghoa()
        {
            Thread thread = new Thread(new ThreadStart(ShowformchinhQLhanghoa));//Tạo luồng mới
            thread.Start(); //Khởi chạy luồng
        }
        //Hàm kiểm tra khóa trùng
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else return false;
        }
        //Hàm thực hiện câu lệnh sql 
        public static void Runsql(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = con; //Gắn kết nối
            cmd.CommandText = sql; //Gắn lệnh sql
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh sql
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose(); //Giải phóng bộ nhớ
            cmd = null;
        }
        public static void Rundel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = xldulieu.con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        //Lấy dữ liệu vào bảng
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(); 
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = xldulieu.con; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        public static string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[0], elements[1], elements[2]);
            return dt;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
    }
}

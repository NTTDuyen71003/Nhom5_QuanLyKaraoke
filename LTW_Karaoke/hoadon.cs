using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hoadon
{
    public partial class hoadon : Form
    {
        public hoadon()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        SqlConnection conec = null;
        readonly string str = @"Data Source=LAPTOP-T4RGGNJJ;Initial Catalog=Karaoke_6Princesses;Integrated Security=True";

        private void MoKetNoi()
        {
            if (conec == null)
            {
                conec = new SqlConnection(str);
            }
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();

            }
        }
        private void DongKetNoi()
        {
            if (conec.State != null && conec.State == ConnectionState.Open)
            {
                conec.Close();
            }
        }

        private void hoadon_Load(object sender, EventArgs e)
        {
            HienThiProJect();
            HienThiProJect1();
        }

        private void HienThiProJect()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT IDHoaDon, IDPhong, ThoiGianBD, ThoiGianKT, DonGia FROM HOADONBANHANG WHERE ThanhTien IS NULL";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            lvTienPhong.Items.Clear();
            while (reader.Read())
            {
                int IDHoaDon = reader.GetInt32(0);
                int IDPhong = reader.GetInt32(1);
                DateTime ThoiGianBD = reader.GetDateTime(2);
                DateTime? ThoiGianKT = null;  // Khởi tạo biến ThoiGianKT với giá trị null

                if (!reader.IsDBNull(3))  // Kiểm tra xem giá trị trong cột có phải là null hay không
                {
                    ThoiGianKT = reader.GetDateTime(3);  // Gán giá trị từ cột vào biến ThoiGianKT
                }
                //float DonGia = reader.GetFloat(4);

                ListViewItem lv = new ListViewItem(IDHoaDon.ToString());
                lv.SubItems.Add(IDPhong.ToString());
                lv.SubItems.Add(ThoiGianBD.ToString());
                lv.SubItems.Add(ThoiGianKT.ToString());
                //lv.SubItems.Add(DonGia.ToString());

                lvTienPhong.Items.Add(lv);
            }
            reader.Close();
            conec.Close();
        }



        private void HienThiProJect1()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT IDHoaDon, IDMatHang, Sl, NgayTao, ThanhTien FROM HOADONBANHANG WHERE ThanhTien IS NOT NULL";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            LvDichVu.Items.Clear();
            while (reader.Read())
            {
                int IDHoaDon = reader.GetInt32(0);
                int IDMatHang = reader.GetInt32(1);
                string Sl = reader.GetString(2);
                DateTime NgayTao = reader.GetDateTime(3);
                decimal ThanhTien = reader.GetDecimal(4);

                ListViewItem lv = new ListViewItem(IDHoaDon.ToString());
                lv.SubItems.Add(IDMatHang.ToString());
                lv.SubItems.Add(Sl.ToString());
                lv.SubItems.Add(NgayTao.ToString());
                lv.SubItems.Add(ThanhTien.ToString());

                LvDichVu.Items.Add(lv);
            }
            reader.Close();
            conec.Close();
        }

        private void LvDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

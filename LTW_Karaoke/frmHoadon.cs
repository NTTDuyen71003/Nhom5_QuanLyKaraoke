using LTW_Karaoke;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hoadon
{
    public partial class frmHoadon : Form
    {
        public frmHoadon()
        {
            InitializeComponent();
        }

        public decimal tienphongDone;
        public decimal tiendvDone;

        SqlConnection conec = null;
        readonly string str = @"Data Source=LAPTOP-E03OOFES;Initial Catalog=Karaoke_Princesses;Integrated Security=True";

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
            DoDuLieuVaoComboBox();
        }

        private void DoDuLieuVaoComboBox()
        {
            try
            {
                MoKetNoi();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TenPhong FROM PHONG WHERE TrangThai = N'Đang thuê'";
                command.Connection = conec;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string tenPhong = reader.GetString(0);
                    cbbPhong.Items.Add(tenPhong);
                }
                reader.Close();
                DongKetNoi();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi khi đổ dữ liệu vào ComboBox: " + ex.Message);
            }
        }

        private void HienThiProJect()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT HD.IDHoaDon, HD.IDPhong, HD.ThoiGianBD, HD.ThoiGianKT,P.TenPhong FROM HOADONBANHANG HD JOIN Phong P ON HD.IDPhong = P.IDPhong WHERE HD.ThanhTien IS NULL";
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
                string TenPhong = reader.GetString(4);
                //float DonGia = reader.GetFloat(4);

                ListViewItem lv = new ListViewItem(IDHoaDon.ToString());
                lv.SubItems.Add(IDPhong.ToString());
                lv.SubItems.Add(ThoiGianBD.ToString());
                lv.SubItems.Add(ThoiGianKT.ToString());
                //lv.SubItems.Add(DonGia.ToString());
                lv.SubItems.Add(TenPhong);


                lvTienPhong.Items.Add(lv);
            }
            reader.Close();
            conec.Close();
        }



        private void lvTienPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTienPhong.SelectedItems.Count > 0)
            {
                // Lấy dòng được chọn trong ListView
                ListViewItem selectedRow = lvTienPhong.SelectedItems[0];

                // Lấy giá trị của cột ThoiGianBD và IDPhong
                string thoiGianBDStr = selectedRow.SubItems[2].Text;
                int IDPhong = int.Parse(selectedRow.SubItems[1].Text);
                string TenPhong = selectedRow.SubItems[4].Text;
                // Tìm và chọn phòng tương ứng trong ComboBox
                foreach (object item in cbbPhong.Items)
                {
                    if (item.ToString().Contains(TenPhong.ToString()))
                    {
                        cbbPhong.SelectedItem = item;                       
                        break;
                    }
                }

                DateTime thoiGianBD;
                if (DateTime.TryParse(thoiGianBDStr, out thoiGianBD))
                {
                    // Lấy thời gian hiện tại
                    DateTime thoiGianHienTai = DateTime.Now;

                    // Tính số giờ bằng hiệu của thời gian hiện tại và thời gian bắt đầu
                    TimeSpan soGio = thoiGianHienTai - thoiGianBD;

                    // Lấy số giờ và số phút
                    int gio = soGio.Hours;
                    int phut = soGio.Minutes;

                    // Lấy đơn giá từ bảng LoaiPhong dựa trên IDPhong
                    decimal donGia = LayDonGia(IDPhong);

                    // Tính tổng tiền phòng
                    decimal tongTienPhong = gio * donGia;

                    // Hiển thị kết quả vào textSoGio và textTienPhong
                    string ketQuaSoGio = gio.ToString() + " giờ " + phut.ToString() + " phút";
                    string ketQuaTienPhong = tongTienPhong.ToString();

                    textSoGio.Text = ketQuaSoGio;
                    textTienPhong.Text = ketQuaTienPhong;
                    tienphongDone = Decimal.Parse(ketQuaTienPhong);

                    decimal tongTien = tienphongDone + tiendvDone;
                    textTongTien.Text = tongTien.ToString();
                }
                else
                {
                    // Xử lý khi không thể chuyển đổi thành công thời gian
                    textSoGio.Text = "Không thể tính số giờ";
                    textTienPhong.Text = "";
                }
            }
        }

        private decimal LayDonGia(int IDPhong)
        {
            decimal donGia = 0;

            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT DonGia FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.IDLoaiPhong = Phong.IDLoaiPhong WHERE Phong.IDPhong = @IDPhong";
            command.Parameters.AddWithValue("@IDPhong", IDPhong);
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                donGia = reader.GetDecimal(0);
            }

            reader.Close();
            conec.Close();

            return donGia;
        }



        private void HienThiProJect1()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT IDHoaDon, IDMatHang, Sl, NgayTao, ThanhTien,IDPhong FROM HOADONBANHANG WHERE ThanhTien IS NOT NULL";
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
                int IDPhong = reader.GetInt32(5);

                ListViewItem lv = new ListViewItem(IDHoaDon.ToString());
                lv.SubItems.Add(IDMatHang.ToString());
                lv.SubItems.Add(Sl.ToString());
                lv.SubItems.Add(NgayTao.ToString());
                lv.SubItems.Add(ThanhTien.ToString());
                lv.SubItems.Add(IDPhong.ToString());

                LvDichVu.Items.Add(lv);
            }
            reader.Close();
            conec.Close();
        }

        private void LvDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LvDichVu.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = LvDichVu.SelectedItems[0];

                // Access subitems to get details
                string IDHoaDon = selectedItem.SubItems[0].Text;
                string IDMatHang = selectedItem.SubItems[1].Text;
                string Sl = selectedItem.SubItems[2].Text;
                string NgayTao = selectedItem.SubItems[3].Text;
                string ThanhTien = selectedItem.SubItems[4].Text;
                string IDPhong = selectedItem.SubItems[5].Text;

                // Display details (you can replace this with your logic)
                MessageBox.Show($"Selected Item:\nIDHoaDon: {IDHoaDon}\nIDMatHang: {IDMatHang}\nSl: {Sl}\nNgayTao: {NgayTao}\nThanhTien: {ThanhTien}\nIDPhong: {IDPhong}", "Selected Item Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textSoGio_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {


            // Xóa các mục hiện tại trong ListView
            LvDichVu.Items.Clear();
            // Lấy thông tin phòng được chọn từ ComboBox
            string tenPhong = cbbPhong.SelectedItem.ToString();

            // Lấy IDPhong tương ứng từ bảng Phong
            int IDPhong = LayIDPhong(tenPhong);

            // Hiển thị danh sách các mục trong bảng HOADONBANHANG có IDPhong tương ứng
            HienThiHoaDonTheoIDPhong(IDPhong);



            decimal tongThanhTien = TinhTongThanhTienTheoIDPhong(IDPhong);

            textTienDichVu.Text = tongThanhTien.ToString();

            decimal tienPhong = 0;
            decimal tienDichVu = 0;

            decimal.TryParse(textTienPhong.Text, out tienPhong);
            decimal.TryParse(textTienDichVu.Text, out tienDichVu);

            tiendvDone = tienDichVu;




        }

        private int LayIDPhong(string tenPhong)
        {
            int IDPhong = 0;

            try
            {
                MoKetNoi();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT IDPhong FROM Phong WHERE TenPhong = @TenPhong";
                command.Parameters.AddWithValue("@TenPhong", tenPhong);
                command.Connection = conec;
                IDPhong = (int)command.ExecuteScalar();
                conec.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy IDPhong từ tên phòng: " + ex.Message);
            }

            return IDPhong;
        }

        private void HienThiHoaDonTheoIDPhong(int IDPhong)
        {
            try
            {
                MoKetNoi();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT IDHoaDon, IDMatHang, Sl, NgayTao, ThanhTien, IDPhong FROM HOADONBANHANG WHERE IDPhong = @IDPhong AND ThanhTien IS NOT NULL";
                command.Parameters.AddWithValue("@IDPhong", IDPhong);
                command.Connection = conec;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem lv = new ListViewItem();

                    if (!reader.IsDBNull(0)) // Kiểm tra IDHoaDon null
                    {
                        int IDHoaDon = reader.GetInt32(0);
                        lv.Text = IDHoaDon.ToString();
                    }

                    if (!reader.IsDBNull(1)) // Kiểm tra IDMatHang null
                    {
                        int IDMatHang = reader.GetInt32(1);
                        lv.SubItems.Add(IDMatHang.ToString());
                    }

                    if (!reader.IsDBNull(2)) // Kiểm tra Sl null
                    {
                        string Sl = reader.GetString(2);
                        lv.SubItems.Add(Sl);
                    }

                    if (!reader.IsDBNull(3)) // Kiểm tra NgayTao null
                    {
                        DateTime NgayTao = reader.GetDateTime(3);
                        lv.SubItems.Add(NgayTao.ToString());
                    }

                    if (!reader.IsDBNull(4)) // Kiểm tra ThanhTien null
                    {
                        decimal ThanhTien = reader.GetDecimal(4);
                        lv.SubItems.Add(ThanhTien.ToString());
                    }

                    if (!reader.IsDBNull(5)) // Kiểm tra IDPhongHoaDon null
                    {
                        int IDPhongHoaDon = reader.GetInt32(5);
                        lv.SubItems.Add(IDPhongHoaDon.ToString());
                    }

                    LvDichVu.Items.Add(lv);
                }

                reader.Close();
                conec.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi hiển thị danh sách hóa đơn theo IDPhong: " + ex.Message);
            }
        }

        private decimal TinhTongThanhTienTheoIDPhong(int IDPhong)
        {
            decimal tongThanhTien = 0;

            try
            {
                MoKetNoi();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ThanhTien FROM HOADONBANHANG WHERE IDPhong = @IDPhong AND ThanhTien IS NOT NULL";
                command.Parameters.AddWithValue("@IDPhong", IDPhong);
                command.Connection = conec;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        decimal ThanhTien = reader.GetDecimal(0);
                        tongThanhTien += ThanhTien;
                    }
                }

                reader.Close();
                conec.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tính tổng ThanhTien theo IDPhong: " + ex.Message);
            }

            return tongThanhTien;
        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            if (cbbPhong.SelectedItem != null)
            {
                // Lấy thông tin phòng được chọn từ ComboBox
                string tenPhong = cbbPhong.SelectedItem.ToString();

                // Lấy IDPhong tương ứng từ bảng Phong
                int IDPhong = LayIDPhong(tenPhong);

                // Xóa dữ liệu trong ListView lvTienPhong theo IDPhong
                XoaDuLieuTheoIDPhong2(lvTienPhong, IDPhong);

                // Xóa dữ liệu trong ListView LvDichVu theo IDPhong
                XoaDuLieuTheoIDPhong2(LvDichVu, IDPhong);

                // Xóa dữ liệu trong bảng HOADONBANHANG theo IDPhong
                XoaDuLieuHOADONBANHANGTheoIDPhong(IDPhong);
                CapNhatTrangThaiPhong(IDPhong);
            }
            MessageBox.Show("Thanh toan1 phong thanh cong","Thong6 bao",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CapNhatTrangThaiPhong(int IDPhong)
        {
            string connectionString = "Data Source=LAPTOP-E03OOFES;Initial Catalog=Karaoke_Princesses;Integrated Security=True";
            string updateQuery = "UPDATE Phong SET TrangThai = N'Phòng trống' WHERE IDPhong = @IDPhong";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@IDPhong", IDPhong);
                    command.ExecuteNonQuery();
                }
            }
            
        }


        private void XoaDuLieuTheoIDPhong2(ListView listView, int IDPhong)
        {
            for (int i = listView.Items.Count - 1; i >= 0; i--)
            {
                ListViewItem item = listView.Items[i];
                int IDPhongItem = int.Parse(item.SubItems[1].Text);
                if (IDPhongItem == IDPhong)
                {
                    listView.Items.RemoveAt(i);
                }
            }
        }

        private void XoaDuLieuHOADONBANHANGTheoIDPhong(int IDPhong)
        {
            string connectionString = @"Data Source=LAPTOP-E03OOFES;Initial Catalog=Karaoke_Princesses;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Xây dựng câu lệnh SQL DELETE
                string sqlDelete = "DELETE FROM HOADONBANHANG WHERE IDPhong = @IDPhong";

                using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                {
                    // Thêm tham số IDPhong vào câu lệnh SQL
                    command.Parameters.AddWithValue("@IDPhong", IDPhong);

                    // Thực thi câu lệnh SQL DELETE
                    command.ExecuteNonQuery();
                }
            }
        }

        private void textTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDatPhong fm =new frmDatPhong();
            fm.ShowDialog();
        }
    }      
}

using hoadon;
using LTW_Karaoke.Model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LTW_Karaoke
{
    public partial class frmDatPhong : Form
    {
        public frmDatPhong()
        {
            InitializeComponent();
        }


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

        private void HienThiPhong()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT P.IDPhong, P.TenPhong, P.TrangThai, P.IDLoaiPhong, P.NgayTao, P.NgayCapNhat, L.NameLP FROM PHONG P INNER JOIN LOAIPHONG L ON P.IDLoaiPhong = L.IDLoaiPhong";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            lvPhong.Items.Clear();
            while (reader.Read())
            {
                int IDPhong = reader.GetInt32(0);
                string TenPhong = reader.GetString(1);
                string TrangThai = reader.GetString(2);
                int IDLoaiPhong = reader.GetInt32(3);
                DateTime NgayTao = reader.GetDateTime(4);
                DateTime NgayCapNhat = reader.GetDateTime(5);
                string TenLoaiPhong = reader.GetString(6);

                ListViewItem lv = new ListViewItem(IDPhong.ToString());
                lv.SubItems.Add(TenPhong);
                lv.SubItems.Add(TrangThai);
                lv.SubItems.Add(TenLoaiPhong);
                lv.SubItems.Add(NgayTao.ToString());
                lv.SubItems.Add(NgayCapNhat.ToString());

                switch (TrangThai)
                {
                    case "Đang thuê":
                        lv.BackColor = Color.Pink;
                        break;
                    case "Phòng đã đặt":
                        lv.BackColor = Color.Yellow;
                        break;
                    case "Phòng trống":
                        lv.BackColor = Color.Green;
                        break;
                    case "Phòng đã ngừng hoạt động":
                        lv.BackColor = Color.Red;
                        break;
                    default:
                        break;
                }

                lv.Tag = IDPhong;

                lvPhong.Items.Add(lv);
            }
            reader.Close();
            conec.Close();
        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                HienThiPhong(); // Call HienThiPhong to repopulate the ListView with original data
                return;
            }

            using (KaraokeDB context = new KaraokeDB())
            {
                var query = from P in context.PHONGs
                            where P.TenPhong.Contains(searchTerm) || P.LOAIPHONG.NameLP.Contains(searchTerm) || P.TrangThai.Contains(searchTerm)
                            select P;

                List<PHONG> PhongList = query.ToList();

                lvPhong.Items.Clear();

                foreach (PHONG pHONG in PhongList)
                {
                    ListViewItem item = new ListViewItem(pHONG.IDPhong.ToString());
                    item.SubItems.Add(pHONG.TenPhong);
                    item.SubItems.Add(pHONG.TrangThai);
                    item.SubItems.Add(pHONG.IDLoaiPhong.ToString());

                    lvPhong.Items.Add(item);
                }
            }
        }


        

        private void txtTimmathang_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimmathang.Text.Trim();

            using (KaraokeDB context = new KaraokeDB())
            {
                var query = from P in context.MATHANGs
                            where P.TenMatHang.Contains(searchTerm)
                            select P;

                List<MATHANG> MHList = query.ToList();

                lvMatHang.Items.Clear();

                foreach (MATHANG mHang in MHList)
                {
                    ListViewItem item = new ListViewItem(mHang.IDMatHang.ToString());
                    item.SubItems.Add(mHang.TenMatHang);
                    item.SubItems.Add(mHang.DonGiaBan.ToString());
                    lvMatHang.Items.Add(item);
                }
            }
        }


        private void HienThiMatHang()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT IDMatHang, TenMatHang, CAST(DonGiaBan AS money) FROM MATHANG";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            lvMatHang.Items.Clear();
            while (reader.Read())
            {
                int IDMatHang = reader.GetInt32(0);
                string TenMatHang = reader.GetString(1);
                decimal DonGiaBan = reader.GetDecimal(2);

                textMaMatHang.Text = IDMatHang.ToString();
                textTenMatHang.Text = TenMatHang;
                textDonGia.Text = DonGiaBan.ToString("N0"); // Định dạng đơn giá bán về phần nghìn

                ListViewItem lv = new ListViewItem(IDMatHang.ToString());
                lv.SubItems.Add(TenMatHang);
                lv.SubItems.Add(DonGiaBan.ToString("N0")); // Định dạng đơn giá bán về phần nghìn

                lv.Tag = IDMatHang;

                lvMatHang.Items.Add(lv);
            }
            reader.Close();
            conec.Close();
        }



        private void HienThiChiTietPhong(int IDPhong)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT P.TenPhong, P.TrangThai, L.NameLP FROM PHONG P INNER JOIN LOAIPHONG L ON P.IDLoaiPhong = L.IDLoaiPhong WHERE P.IDPhong = @IDPhong";
            command.Connection = conec;
            command.Parameters.AddWithValue("@IDPhong", IDPhong);

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string tenPhong = reader.GetString(reader.GetOrdinal("TenPhong"));
                    string trangThai = reader.GetString(reader.GetOrdinal("TrangThai"));
                    string tenLoaiPhong = reader.GetString(reader.GetOrdinal("NameLP"));

                    // Hiển thị thông tin chi tiết
                    txtTenPhong.Text = tenPhong;
                    cbbTrangThai.Text = trangThai;
                    cbbLoaiPhong.Text = tenLoaiPhong;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị chi tiết phòng: " + ex.Message);
            }
            finally
            {
                conec.Close();
            }
        }


        private void CbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị được chọn từ ComboBox
            string selectedPhong = cbbPhong.SelectedItem as string;

            // Kiểm tra nếu có giá trị được chọn
            if (!string.IsNullOrEmpty(selectedPhong))
            {
                // Hiển thị thông tin phòng
                MessageBox.Show("Phòng đang thuê: " + selectedPhong);
            }
        }


        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            HienThiMatHang();
            HienThiHoaDonBan();
            HienThiPhong();
            LoadLoaiPhong();
            // Gắn sự kiện SelectedIndexChanged cho ComboBox
            cbbPhong.SelectedIndexChanged += CbbPhong_SelectedIndexChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            txtTimmathang.TextChanged += txtTimmathang_TextChanged;
            // Gọi phương thức để đổ dữ liệu vào ComboBox
            DoDuLieuVaoComboBox();
            cbbPhong.DropDownStyle = ComboBoxStyle.DropDown;
        }


        private void LoadLoaiPhong()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT NameLP FROM LOAIPHONG";
            command.Connection = conec;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                adapter.Fill(dataTable);

                // Xóa dữ liệu cũ trong ComboBox
                cbbLoaiPhong.Items.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string tenLoaiPhong = row["NameLP"].ToString();
                    cbbLoaiPhong.Items.Add(tenLoaiPhong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu loại phòng: " + ex.Message);
            }
            finally
            {
                conec.Close();
            }
        }


        private void lvPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPhong.SelectedItems.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn 1 dòng dữ liệu để sửa", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListViewItem lv = lvPhong.SelectedItems[0];

            ListViewItem selectedItem = lvPhong.SelectedItems[0];
            int IDPhong = Convert.ToInt32(selectedItem.SubItems[0].Text); // Giả sử IDPhong là cột đầu tiên trong ListViewItem

            // Gán giá trị IDPhong vào TextBox
            txtMaPhong.Text = IDPhong.ToString();
            HienThiChiTietPhong(IDPhong);
        }


        private int GetIDLoaiPhong(string tenLoaiPhong)
        {
            int idLoaiPhong = 0;

            // Lấy IDLoaiPhong từ bảng LOAIPHONG dựa trên tên loại phòng
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT IDLoaiPhong FROM LOAIPHONG WHERE NameLP = @TenLoaiPhong";
            command.Connection = conec;
            command.Parameters.AddWithValue("@TenLoaiPhong", tenLoaiPhong);

            try
            {
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    idLoaiPhong = id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy ID loại phòng: " + ex.Message);
            }
            finally
            {
                conec.Close();
            }

            return idLoaiPhong;
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cbbTrangThai.Text == "" || txtMaPhong.Text == "" || txtTenPhong.Text == "" || cbbLoaiPhong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi cập nhật phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem selectedItem = lvPhong.SelectedItems[0];
            int IDPhong = (int)selectedItem.Tag;
            string tenPhong = txtTenPhong.Text;
            string trangThai = cbbTrangThai.Text;
            string tenLoaiPhong = cbbLoaiPhong.Text;
            DateTime ngayTao = DateTime.Now;
            DateTime thoiGianBD = DateTime.Now;

            // Kiểm tra ràng buộc khi thay đổi trạng thái phòng
            string trangThaiHienTai = selectedItem.SubItems[2].Text; // Giả sử trạng thái phòng nằm ở cột thứ 3
            if (trangThaiHienTai == "Đang thuê" && trangThai != "Đang thuê")
            {
                MessageBox.Show("Không thể thay đổi trạng thái phòng từ 'Đang thuê'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SuaPhong(IDPhong, tenPhong, trangThai, tenLoaiPhong);

            // Cập nhật thông tin trên giao diện
            selectedItem.SubItems[1].Text = tenPhong;
            selectedItem.SubItems[2].Text = trangThai;
            selectedItem.SubItems[3].Text = tenLoaiPhong;

            if (trangThai == "Đang thuê"&& !cbbPhong.Items.Contains(tenPhong))
            {              
                    cbbPhong.Items.Add(tenPhong);              
            }
            else if(trangThai != "Đang thuê" && cbbPhong.Items.Contains(tenPhong))
            {
                cbbPhong.Items.Remove(tenPhong);
            }
        }


        private void buttonDat_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                MoKetNoi();

                string enableIdentityInsert = "SET IDENTITY_INSERT HOADONBANHANG ON";
                SqlCommand enableInsertCommand = new SqlCommand(enableIdentityInsert, conec);
                enableInsertCommand.ExecuteNonQuery();

                // Lấy giá trị từ các TextBox và ComboBox
                int IDMatHang = int.Parse(textMaMatHang.Text);
                string SL = textSoLuong.Text;
                int soLuong = ParseSL(SL);
                float ThanhTien;
                if (!float.TryParse(textTienDichVu.Text, out ThanhTien))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Đóng kết nối đến cơ sở dữ liệu
                    DongKetNoi();
                    return;
                }
                string tenPhong = cbbPhong.SelectedItem.ToString();
                int IDPhong = GetIDPhongFromTenPhong(tenPhong);
                DateTime ngayTao = DateTime.Now;
                float donGia = float.Parse(textDonGia.Text);
                string sql = "INSERT INTO HOADONBANHANG (IDPhong,IDMatHang, ThoiGianBD,ThoiGianKT, Sl, DonGia, TenTaiKhoan, NgayTao, ThanhTien) VALUES (@IDPhong,@IDMatHang, GETDATE(),NULL, @Sl, @DonGia, @TenTaiKhoan, @NgayTao,@ThanhTien)";

                SqlCommand command = new SqlCommand(sql, conec);
                int IDHoaDon = 0;

                // Thêm tham số vào câu lệnh SQL
                //command.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                command.Parameters.AddWithValue("@IDPhong", IDPhong);
                command.Parameters.AddWithValue("@IDMatHang", IDMatHang);
                command.Parameters.AddWithValue("@Sl", soLuong);
                command.Parameters.AddWithValue("@DonGia", donGia);
                command.Parameters.AddWithValue("@TenTaiKhoan", "admin");
                command.Parameters.AddWithValue("@NgayTao", ngayTao);
                command.Parameters.AddWithValue("@ThanhTien", ThanhTien);

                // Kiểm tra trạng thái kết nối và mở kết nối nếu nó đã đóng
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }

                // Thực thi câu lệnh SQL
                int rowsAffected = command.ExecuteNonQuery();

                // Đóng kết nối đến cơ sở dữ liệu
                DongKetNoi();

                // Hiển thị thông báo khi thêm dữ liệu thành công
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đã thêm dữ liệu vào bảng HOADONBANHANG.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDL();
                }
                else
                {
                    MessageBox.Show("Không thể thêm dữ liệu vào bảng HOADONBANHANG.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //string tenPhong = cbbPhong.SelectedItem.ToString();
                int IDMatHANG = int.Parse(textMaMatHang.Text);
                string tenMatHang = textTenMatHang.Text;
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDL()
        {
            textDonGia.Text = "";
            textSoLuong.Text = "";
            textTienDichVu.Text = "";
        }

        private void SuaPhong(int IDPhong, string tenPhong, string trangThai, string tenLoaiPhong)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE PHONG SET TenPhong = @TenPhong, TrangThai = @TrangThai, NgayCapNhat = @NgayCapNhat, IDLoaiPhong = @IDLoaiPhong WHERE IDPhong = @IDPhong";
            command.Connection = conec;
            command.Parameters.AddWithValue("@TenPhong", tenPhong);
            command.Parameters.AddWithValue("@TrangThai", trangThai);
            command.Parameters.AddWithValue("@NgayCapNhat", DateTime.Now); // Ngày cập nhật là ngày hiện tại
            command.Parameters.AddWithValue("@IDLoaiPhong", GetIDLoaiPhong(tenLoaiPhong));
            command.Parameters.AddWithValue("@IDPhong", IDPhong);

            try
            {
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                command.ExecuteNonQuery();
                MessageBox.Show("Sửa phòng thành công!");

                // Cập nhật ListView
                HienThiPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa phòng: " + ex.Message);
            }
            finally
            {
                conec.Close();
            }
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
                    if (!cbbPhong.Items.Contains(tenPhong)) // Kiểm tra xem ComboBox đã chứa phòng đó chưa
                    {
                        cbbPhong.Items.Add(tenPhong);
                    }
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

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lvMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMatHang.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvMatHang.SelectedItems[0];
                int IDMatHang = Convert.ToInt32(selectedItem.Text);
                string TenMatHang = selectedItem.SubItems[1].Text;
                string DonGiaBan = selectedItem.SubItems[2].Text;

                // Hiển thị dữ liệu vào các TextBox
                textMaMatHang.Text = IDMatHang.ToString();
                textTenMatHang.Text = TenMatHang;
                textDonGia.Text = DonGiaBan;
            }
        }

        private bool IsValidInput()
        {
            if (!rbtMonAn.Checked && !radioDoUong.Checked)
            {
                MessageBox.Show("Vui lòng chọn đò ăn hoặc đồ uống", "Thông báo");
                return false;
            }

            return true;
        }

        private void textSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsValidInput())
                {
                    if (radioDoUong.Checked)
                    {
                        string input = textSoLuong.Text;

                        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int number))
                        {
                            int thung = number / 24; // Số thùng
                            int lon = number % 24; // Số lon (số dư)

                            if (thung > 0 && lon > 0)
                            {
                                textSoLuong.Text = thung + " thùng " + lon + " lon";
                            }
                            else if (thung > 0)
                            {
                                textSoLuong.Text = thung + " thùng";
                            }
                            else if (lon > 0)
                            {
                                textSoLuong.Text = lon + " lon";
                            }

                            // Lưu giá trị ban đầu vào biến soLuongBanDau
                            // ...

                            TinhTienDichVu();
                        }
                        else
                        {
                            textSoLuong.Text = string.Empty; // Xóa nội dung nếu không hợp lệ
                                                             //soLuongBanDau = string.Empty; // Xóa giá trị ban đầu
                        }
                    }
                    else if (rbtMonAn.Checked)
                    {
                        // Nếu RadioButton rbtDoAn được chọn, không thực hiện tính toán tiền dịch vụ
                        // và giữ nguyên các giá trị trong TextBox
                        TinhTienDichVu();

                    }
                }
            }
        }

        private void TinhTienDichVu()
        {
            try
            {
                // Lấy giá trị từ TextBox textSoLuong
                string input = textSoLuong.Text;

                if (!string.IsNullOrEmpty(input))
                {
                    // Lấy giá trị từ TextBox textDonGia
                    float donGia = float.Parse(textDonGia.Text);

                    float tienDichVu = 0;

                    if (radioDoUong.Checked)
                    {
                        // Kiểm tra và chuyển đổi giá trị textSoLuong
                        int thung = 0;
                        int lon = 0;
                        string strThung = "thùng";
                        string strLon = "lon";
                        //TH1
                        // n thung n lon
                        // 0   1   2  3
                        //TH2
                        // n thung
                        //TH3
                        // n lon

                        //TH1
                        if(input.Contains(strThung) && input.Contains(strLon))
                        { 
                            thung = int.Parse(input.Split(' ')[0]);
                            lon = int.Parse(input.Split(' ')[2]);
                        }
                        //TH2
                        else if(input.Contains(strThung) && !input.Contains(strLon))
                        {
                            thung = int.Parse(input.Split(' ')[0]);
                        }
                        //TH3
                        else
                        {
                            lon = int.Parse(input.Split(' ')[0]);
                        }
                        // Tính tiền dịch vụ
                        tienDichVu = (thung * 24 + lon) * donGia;
                    }
                    else if (rbtMonAn.Checked)
                    {
                        // Lấy giá trị số lượng từ TextBox textSoLuong
                        int soLuong = int.Parse(input);

                        // Tính tiền dịch vụ
                        tienDichVu = soLuong * donGia;
                    }

                    textTienDichVu.Text = tienDichVu.ToString("N0");
                }
                else
                {
                    // Nếu TextBox textSoLuong trống, gán giá trị 0 cho tiền dịch vụ
                    textTienDichVu.Text = "0";
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi khi tính tiền dịch vụ: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            MoKetNoi();

            // Lấy ngày giờ hiện tại
            DateTime ngayCapNhat = DateTime.Now;

            int soLuongThemThanhCong = 0;

            // Lặp qua từng mục trong ListView lvPhong
            foreach (ListViewItem item in lvPhong.Items)
            {
                // Kiểm tra nếu TrangThai là "Đang thuê"
                if (item.SubItems[2].Text == "Đang thuê")
                {
                    // Lấy thông tin từ ListView lvPhong
                    int IDPhong = int.Parse(item.SubItems[0].Text);

                    // Kiểm tra xem IDPhong đã tồn tại trong bảng HOADONBANHANG hay chưa
                    string checkExistQuery = "SELECT COUNT(*) FROM HOADONBANHANG WHERE IDPhong = @IDPhong";
                    SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, conec);
                    checkExistCommand.Parameters.AddWithValue("@IDPhong", IDPhong);
                    int existingRows = (int)checkExistCommand.ExecuteScalar();

                    if (existingRows == 0)
                    {
                        // Tạo câu lệnh SQL để chèn dữ liệu vào bảng HOADONBANHANG
                        string sql = "INSERT INTO HOADONBANHANG (IDPhong, ThoiGianBD, IDMatHang, ThoiGianKT, Sl, DonGia, TenTaiKhoan, NgayTao, ThanhTien) VALUES (@IDPhong, @ThoiGianBD, @IDMatHang, NULL, NULL, NULL, @TenTaiKhoan, NULL, NULL)";

                        // Tạo đối tượng SqlCommand
                        SqlCommand command = new SqlCommand(sql, conec);

                        // Thêm tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@IDPhong", IDPhong);
                        command.Parameters.AddWithValue("@ThoiGianBD", ngayCapNhat);
                        command.Parameters.AddWithValue("@IDMatHang", 1); // Đặt giá trị của IDMatHang là 1
                        command.Parameters.AddWithValue("@TenTaiKhoan", "admin"); 

                        // Thực thi câu lệnh SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            soLuongThemThanhCong++;
                        }
                    }
                }
            }

            conec.Close();

            // Hiển thị thông báo khi thêm dữ liệu thành công
            if (soLuongThemThanhCong > 0)
            {
                MessageBox.Show($"Đã cập nhật {soLuongThemThanhCong} bản ghi vào bảng HOADONBANHANG.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào được thêm vào bảng HOADONBANHANG.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int GetIDPhongFromTenPhong(string tenPhong)
        {
            MoKetNoi();

            // Tạo câu lệnh SQL để lấy IDPhong từ TenPhong
            string sql = "SELECT IDPhong FROM Phong WHERE TenPhong = @TenPhong";

            // Tạo đối tượng SqlCommand
            SqlCommand command = new SqlCommand(sql, conec);

            // Thêm tham số vào câu lệnh SQL
            command.Parameters.AddWithValue("@TenPhong", tenPhong);

            // Thực thi câu lệnh SQL và trả về IDPhong
            int idPhong = (int)command.ExecuteScalar();

            conec.Close();

            return idPhong;
        }

        private int ParseSL(string sl)
        {
            int soLuong = 0;
            if (sl.Contains("thùng"))
            {
                // Tách phần thùng và phần lon từ chuỗi "SL"
                string[] parts = sl.Split(' ');
                int thung = 0;
                int lon = 0;
                if (int.TryParse(parts[0], out thung))
                {
                    // Nếu có thể chuyển đổi thành số, lấy giá trị thùng
                    soLuong += thung * 24;
                }
                if (parts.Length > 1 && int.TryParse(parts[1], out lon))
                {
                    // Nếu có phần lon, thêm giá trị lon vào số lượng
                    soLuong += lon;
                }
            }
            else
            {
                // Trường hợp không có đơn vị thùng, xử lý số lượng theo logic của bạn
                // ...
            }
            return soLuong;
        }



        private void textTenMatHang_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manhinhchinh menu = new Manhinhchinh();
            menu.ShowDialog();
        }

        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDatPhong_Shown(object sender, EventArgs e)
        {
            DoDuLieuVaoComboBox();
        }

        private void frmDatPhong_Activated(object sender, EventArgs e)
        {
            DoDuLieuVaoComboBox();
        }

        private void HienThiHoaDonBan()
        {

        }

        private void textSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioDoUong_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHoadon frmHoadon = new frmHoadon();
            frmHoadon.ShowDialog();
        }
    }
}

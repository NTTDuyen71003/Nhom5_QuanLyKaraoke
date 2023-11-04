using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTW_Karaoke.Model;
using static System.Net.Mime.MediaTypeNames;

namespace LTW_Karaoke
{
    public partial class frmQLKhachHang : Form
    {
        KaraokeDB db;
        List<KHACHHANG> listKHACHHANG;
        public event Action KhachHangAdded;
        public event Action<KHACHHANG> KhachHangUpdated;
        public event Action KhachHangDeleted;
        public frmQLKhachHang()
        {
            InitializeComponent();
        }

        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            db = new KaraokeDB();
            listKHACHHANG = db.KHACHHANGs.ToList();
            BindGrid(listKHACHHANG);
            gbKHMoi.Visible = false;
            btnXoa.Enabled = false;
        }

        private void BindGrid(List<KHACHHANG> listKHACHHANG)
        {
            db = new KaraokeDB();
            dgvKH.Rows.Clear();

            foreach (KHACHHANG kh in db.KHACHHANGs.ToList())
            {
                if (kh.Status == 1)
                {
                    int index = dgvKH.Rows.Add();
                    dgvKH.Rows[index].Cells[0].Value = kh.HoTenKH;
                    dgvKH.Rows[index].Cells[1].Value = kh.SDT;
                    dgvKH.Rows[index].Cells[2].Value = kh.GioiTinh;
                    dgvKH.Rows[index].Cells[3].Value = kh.DiaChiKH;
                }
            }
        }
        public void ClearForm()
        {
            txtTenKH.Text = txtSDT.Text = txtDiaChi.Text = "";
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            gbKHMoi.Visible = true;          
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string hoTen = txtTenKH.Text;
            string SDT = txtSDT.Text;
            string gioiTinh = cbbGioiTinh.Text;
            string diaChi = txtDiaChi.Text;
            int TichLuy = 0;
            string HangThanhVien = "";
            if (hoTen == "" || SDT == "" || diaChi == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (KaraokeDB db = new KaraokeDB())
                {
                    KHACHHANG existingKhachHang = db.KHACHHANGs.FirstOrDefault(kh => kh.SDT == SDT);
                    if (existingKhachHang == null)
                    {

                        KHACHHANG KhachHangMoi = new KHACHHANG()
                        {
                            HoTenKH = hoTen,
                            SDT = SDT,
                            GioiTinh = gioiTinh,
                            DiaChiKH = diaChi,
                            Status = 1,
                        };

                        db.KHACHHANGs.Add(KhachHangMoi);
                        db.SaveChanges();

                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(dgvKH, hoTen, SDT, gioiTinh, diaChi, TichLuy, HangThanhVien);
                        dgvKH.Rows.Add(newRow);
                        KhachHangAdded?.Invoke();

                    }
                    else
                    {
                        existingKhachHang.HoTenKH = hoTen;
                        existingKhachHang.GioiTinh = gioiTinh;
                        existingKhachHang.DiaChiKH = diaChi;
                        existingKhachHang.Status = 1;

                        db.SaveChanges();
                        KhachHangUpdated?.Invoke(existingKhachHang);
                    }

                }
                MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                gbKHMoi.Visible = false;
                frmQLKhachHang_Load(sender, e);
            }
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            gbKHMoi.Visible = false;
            string searchTerm = txtTimKiem.Text.Trim();
            using (KaraokeDB db = new KaraokeDB())
            {
                var query = from kh in db.KHACHHANGs
                            where kh.HoTenKH.Contains(searchTerm) || kh.SDT.Contains(searchTerm)
                            select kh;

                List<KHACHHANG> listKhachHang = query.ToList();

                dgvKH.Rows.Clear();

                foreach (KHACHHANG khachHang in listKhachHang)
                {
                    if (khachHang.Status == 1) 
                    {
                        dgvKH.Rows.Add(khachHang.HoTenKH, khachHang.SDT, khachHang.GioiTinh, khachHang.DiaChiKH);
                    }
                }
            }
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void dgvKH_SelectionChanged(object sender, EventArgs e)
        {
            gbKHMoi.Visible = false;
            if (dgvKH.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvKH.SelectedRows[0];
                txtTenKH.Text = selectedRow.Cells[0].Value.ToString();
                txtSDT.Text = selectedRow.Cells[1].Value.ToString();
                cbbGioiTinh.Text = selectedRow.Cells[2].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[3].Value.ToString();
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string SDT = txtSDT.Text;
            using (KaraokeDB db = new KaraokeDB())
            {
                KHACHHANG xoaKH = db.KHACHHANGs.FirstOrDefault(kh => kh.SDT == SDT);
                if (xoaKH == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng " + xoaKH.HoTenKH, "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    xoaKH.Status = 0;
                    db.SaveChanges();

                    KhachHangDeleted?.Invoke();
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            frmQLKhachHang_Load(sender, e);
        }

        private void txtTenKH_Leave(object sender, EventArgs e)
        {
            error.Clear();
            System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox)sender;
            if (txtTenKH == textbox && string.IsNullOrEmpty(txtTenKH.Text))
            {
                error.SetError(txtTenKH, "Vui lòng nhập họ tên!");
                txtTenKH.Focus();
            }
            if (txtSDT == textbox && txtSDT.Text.Length != 10)
            {
                error.SetError(txtSDT, "Vui lòng nhập số điện thoại gồm đúng 10 chữ số!");
                txtSDT.Focus();
            }
            if (txtDiaChi == textbox && string.IsNullOrEmpty(txtDiaChi.Text))
            {
                error.SetError(txtDiaChi, "Vui lòng nhập địa chỉ!");
                txtDiaChi.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Manhinhchinh manhinhchinh = new Manhinhchinh();
            manhinhchinh.Show();
        }
    }
}

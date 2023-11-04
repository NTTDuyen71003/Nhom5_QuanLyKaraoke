using LTW_Karaoke.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LTW_Karaoke
{
    public partial class frmQLTaiKhoan : Form
    {
        KaraokeDB db;
        List<NHANVIEN> listNHANVIEN;
        public event Action NhanVienAdded;
        public event Action<NHANVIEN> NhanVienUpdated;
        public event Action NhanVienDeleted;

        public frmQLTaiKhoan()
        {
            InitializeComponent();           
        }      

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            db = new KaraokeDB();
            listNHANVIEN = db.NHANVIENs.ToList();
            BindGrid(listNHANVIEN);
            error.Clear();
        }
        private void BindGrid(List<NHANVIEN> listNHANVIEN)
        {
            db = new KaraokeDB();
            dgvTK.Rows.Clear();

            foreach (NHANVIEN nv in db.NHANVIENs.ToList())
            {
                if(nv.Status == 1)
                {
                    int index = dgvTK.Rows.Add();
                    dgvTK.Rows[index].Cells[0].Value = nv.TenTaiKhoan;
                    dgvTK.Rows[index].Cells[1].Value = nv.MatKhau;
                    dgvTK.Rows[index].Cells[2].Value = nv.HoVaTen;
                    dgvTK.Rows[index].Cells[3].Value = nv.SDT;
                    dgvTK.Rows[index].Cells[4].Value = nv.DiaChi;
                    dgvTK.Rows[index].Cells[5].Value = nv.LoaiTaiKhoan;
                }    
            }
        }

        public void ClearForm()
        {
            txtTenTK.Text = txtMK.Text = txtXNMK.Text = txtHoVaTen.Text = txtSDT.Text = txtDiaChi.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenTK = txtTenTK.Text;
            using (KaraokeDB db = new KaraokeDB())
            {
                NHANVIEN xoaNV = db.NHANVIENs.FirstOrDefault(nv => nv.TenTaiKhoan == tenTK);
                if (xoaNV == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    xoaNV.Status = 0;
                    db.SaveChanges();

                    NhanVienDeleted?.Invoke();
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            QLTaiKhoan_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Manhinhchinh manhinhchinh = new Manhinhchinh();
            manhinhchinh.Show();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();
            using (KaraokeDB db = new KaraokeDB())
            {
                var query = from nv in db.NHANVIENs
                            where nv.TenTaiKhoan.Contains(searchTerm) || nv.LoaiTaiKhoan.Contains(searchTerm)||nv.HoVaTen.Contains(searchTerm)
                            select nv;

                List<NHANVIEN> listNhanVien = query.ToList();

                dgvTK.Rows.Clear();

                foreach (NHANVIEN nhanVien in listNhanVien)
                {
                    dgvTK.Rows.Add(nhanVien.TenTaiKhoan, nhanVien.MatKhau, nhanVien.HoVaTen, nhanVien.SDT, nhanVien.DiaChi, nhanVien.LoaiTaiKhoan);
                }
            }
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void dgvTK_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTK.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTK.SelectedRows[0];
                txtTenTK.Text = selectedRow.Cells[0].Value.ToString();
                txtMK.Text = selectedRow.Cells[1].Value.ToString();
                txtHoVaTen.Text = selectedRow.Cells[2].Value.ToString();
                txtSDT.Text = selectedRow.Cells[3].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[4].Value.ToString();
                cbbLoaiTK.Text = selectedRow.Cells[5].Value.ToString();
            }

        }

        private void txtTenTK_Leave(object sender, EventArgs e)
        {
            error.Clear();
            System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox)sender;

            if (txtTenTK == textbox && string.IsNullOrEmpty(textbox.Text))
            {
                error.SetError(txtTenTK, "Vui lòng nhập tên tài khoản!");
                txtTenTK.Focus();
                return;
            }
            if (txtTenTK == textbox && txtTenTK.Text.Length < 3 || txtTenTK.Text.Length > 100)
            {
                error.SetError(txtTenTK, "Tên tài khoản không hợp lệ! Vui lòng nhập lại.");
                txtTenTK.Focus();
            }
            if (txtMK == textbox && string.IsNullOrEmpty(txtMK.Text))
            {
                error.SetError(txtMK, "Vui lòng nhập mật khẩu!");
                txtMK.Focus();
            }
            if (txtXNMK == textbox && string.IsNullOrEmpty(txtXNMK.Text))
            {
                error.SetError(txtXNMK, "Vui lòng xác nhận mật khẩu!");
                txtXNMK.Focus();
            }
            if (txtXNMK == textbox && !(txtXNMK.Text).Equals(txtMK.Text))
            {
                error.SetError(txtXNMK, "Vui lòng xác nhận đúng mật khẩu!");
                txtXNMK.Focus();
            }
            if (txtHoVaTen == textbox && string.IsNullOrEmpty(txtHoVaTen.Text))
            {
                error.SetError(txtHoVaTen, "Vui lòng nhập họ tên!");
                txtHoVaTen.Focus();
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

        private void txtHoVaTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTK.Text;
            string MK = txtMK.Text;
            string XNMK = txtXNMK.Text;
            string hoTen = txtHoVaTen.Text;
            string SDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            string loaiTK = cbbLoaiTK.Text;
            if (tenTK == "" || MK == "" || XNMK == "" || hoTen == "" || SDT == "" || diaChi == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (KaraokeDB db = new KaraokeDB())
                {
                    NHANVIEN existingNhanVien = db.NHANVIENs.FirstOrDefault(nv => nv.TenTaiKhoan == txtTenTK.Text);
                    if (existingNhanVien == null)
                    {

                        NHANVIEN NhanVienMoi = new NHANVIEN()
                        {
                            TenTaiKhoan = tenTK,
                            MatKhau = MK,
                            HoVaTen = hoTen,
                            SDT = SDT,
                            DiaChi = diaChi,
                            LoaiTaiKhoan = loaiTK,
                            Status = 1,
                        };

                        db.NHANVIENs.Add(NhanVienMoi);
                        db.SaveChanges();

                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(dgvTK, tenTK, MK, hoTen, SDT, diaChi, loaiTK);
                        dgvTK.Rows.Add(newRow);
                        NhanVienAdded?.Invoke();

                    }
                    else
                    {
                        existingNhanVien.MatKhau = MK;
                        existingNhanVien.HoVaTen = hoTen;
                        existingNhanVien.SDT = SDT;
                        existingNhanVien.DiaChi = diaChi;
                        existingNhanVien.LoaiTaiKhoan = loaiTK;
                        existingNhanVien.Status = 1;

                        db.SaveChanges();
                        NhanVienUpdated?.Invoke(existingNhanVien);
                    }

                }
                MessageBox.Show("Thêm tài khoản nhân viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                QLTaiKhoan_Load(sender, e);
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
                MessageBox.Show("Vui lòng nhập chữ", "Thông báo");
            }
        }
    }
}

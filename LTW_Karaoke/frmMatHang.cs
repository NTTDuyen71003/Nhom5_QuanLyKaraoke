using LTW_Karaoke;
using LTW_Karaoke.Model;
using QLKaraoke_6Priencesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKaraoke_6Priencesses
{
    public partial class frmMatHang : Form
    {
        static KaraokeDB context = new KaraokeDB();
        List<MATHANG> mhList = context.MATHANGs.ToList();


        public frmMatHang()
        {
            InitializeComponent();
            Binding(mhList);
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "N0";  // Định dạng phần nghìn
            dgvMatHang.Columns["dgvDonGiaBan"].DefaultCellStyle = style;
        }

        public void Binding(List<MATHANG> listMH)
        {
            dgvMatHang.Rows.Clear();
            foreach (var item in listMH)
            {
                int index = dgvMatHang.Rows.Add();
                dgvMatHang.Rows[index].Cells[0].Value = item.IDMatHang;
                dgvMatHang.Rows[index].Cells[1].Value = item.TenMatHang;
                dgvMatHang.Rows[index].Cells[2].Value = item.DonGiaBan;
                dgvMatHang.Rows[index].Cells[3].Value = item.NgayTao;
                dgvMatHang.Rows[index].Cells[4].Value = item.NgayCapNhat;
            }
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Thực hiện thoát chương trình
            this.Hide();
            Manhinhchinh menu = new Manhinhchinh();
            menu.ShowDialog();
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&!Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Thông báo");
                e.Handled = true;
            }
        }

       

        public bool checkNull()
        {
            if (txtTenmh.Text == "" || txtDongia.Text == "")
            {
                return false;
            }
            return true;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (KaraokeDB context = new KaraokeDB())
                if (!checkNull())
                {
                     MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                }
                if (context.MATHANGs.FirstOrDefault(d => d.TenMatHang == txtTenmh.Text) != null)
                {
                    MessageBox.Show("Mặt hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenmh.Text = "";
                    txtDongia.Text = "";
                    return;
                }

                MATHANG mh = new MATHANG();
                mh.TenMatHang = txtTenmh.Text;
                mh.DonGiaBan = float.Parse(txtDongia.Text);
                mh.NgayTao=DateTime.Now;
                mh.NgayCapNhat=DateTime.Now;


                context.MATHANGs.Add(mh);
                context.SaveChanges();

                Binding(context.MATHANGs.ToList());
                txtTenmh.Text = "";
                txtDongia.Text = "";
                MessageBox.Show("Thêm mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenmh.Text))
            {
                string newTenMH = txtTenmh.Text;

                using (KaraokeDB context = new KaraokeDB())
                {
                    try
                    {
                        MATHANG update = context.MATHANGs.FirstOrDefault(d => d.TenMatHang == newTenMH);
                        if (!checkNull())
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (update == null)
                        {
                            MessageBox.Show("Mặt hàng không tồn tại trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            var billItem = context.HOADONBANHANGs.FirstOrDefault(b => b.MATHANG.TenMatHang == newTenMH);
                            if (billItem != null)
                            {
                                MessageBox.Show("Không thể sửa món hàng đang hiện thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            update.TenMatHang = txtTenmh.Text;
                            update.NgayCapNhat = DateTime.Now;
                            if (int.TryParse(txtDongia.Text, out int donGia))
                            {
                                update.DonGiaBan = donGia;
                            }

                            MessageBox.Show("Sửa thông tin mặt hàng thành công!");

                            // Lưu thay đổi vào cơ sở dữ liệu
                            context.SaveChanges();

                            // Cập nhật thông tin trong DataGridView
                            Binding(context.MATHANGs.ToList());

                            // Clear các trường nhập liệu
                            txtTenmh.Text = "";
                            txtDongia.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvMatHang.Rows[e.RowIndex];
            txtTenmh.Text = r.Cells["dgvTenMH"].Value.ToString();
            txtDongia.Text = r.Cells["dgvDonGiaBan"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string NameToDelete = txtTenmh.Text;

                if (string.IsNullOrEmpty(NameToDelete))
                {
                    MessageBox.Show("Vui lòng chọn mặt hàng cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (KaraokeDB context = new KaraokeDB())
                {
                    bool Exists = context.MATHANGs.Any(s => s.TenMatHang == NameToDelete);
                    if (!Exists)
                    {
                        MessageBox.Show("Mặt hàng cần xóa không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    /*                    if (Exists == null)
                                        {
                                            MessageBox.Show("Mặt hàng không tồn tại trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }*/
                    var billItem = context.HOADONBANHANGs.FirstOrDefault(b => b.MATHANG.TenMatHang == NameToDelete);
                    if (billItem != null)
                    {
                        MessageBox.Show("Không thể xóa món hàng đang hiện thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        var Delete = context.MATHANGs.FirstOrDefault(s => s.TenMatHang == NameToDelete);
                        context.MATHANGs.Remove(Delete);
                        context.SaveChanges();

                        RemoveFromDataGridView(NameToDelete);

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Binding(context.MATHANGs.ToList());
                        // Xóa dữ liệu đã nhập trên TextBox
                        txtTenmh.Text = "";
                        txtDongia.Text = "";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể xóa món ăn đang hiện thành!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveFromDataGridView(string studentID)
        {
            foreach (DataGridViewRow row in dgvMatHang.Rows)
            {
                if (row.Cells[0].Value.ToString() == studentID)
                {
                    dgvMatHang.Rows.Remove(row);
                    break;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();

            using (KaraokeDB context = new KaraokeDB())
            {
                var query = from mh in context.MATHANGs
                            where mh.TenMatHang.Contains(searchTerm)
                            select mh;

                List<MATHANG> MatHangList = query.ToList();

                dgvMatHang.Rows.Clear();

                foreach (MATHANG matHang in MatHangList)
                {
                    dgvMatHang.Rows.Add(matHang.IDMatHang, matHang.TenMatHang, matHang.DonGiaBan, matHang.NgayTao, matHang.NgayCapNhat, matHang);
                }
            }
        }

        private void txtTenmh_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
 
        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenmh_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvMatHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}

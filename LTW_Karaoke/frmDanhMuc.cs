using LTW_Karaoke.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTW_Karaoke
{
    public partial class frmDanhMuc : Form
    {
        static KaraokeDB context = new KaraokeDB();
        List<DANHMUC> dmList = context.DANHMUCs.ToList();
        public frmDanhMuc()
        {
            InitializeComponent();
            Binding(dmList);
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        public void Binding(List<DANHMUC> list)
        {
            dgvDM.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvDM.Rows.Add();
                dgvDM.Rows[index].Cells[0].Value = item.IDDanhMuc;
                dgvDM.Rows[index].Cells[1].Value = item.TenDanhMuc;
                dgvDM.Rows[index].Cells[2].Value = item.NgayTao;
                dgvDM.Rows[index].Cells[3].Value = item.NgayCapNhat;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Thực hiện thoát chương trình
            this.Close();
        }

        private void txtDM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Vui lòng nhập chữ", "Thông báo");
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (KaraokeDB context = new KaraokeDB())
                if (txtDM.Text == "")
                 {
                    MessageBox.Show("Vui lòng nhập danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (context.DANHMUCs.Any(d => d.TenDanhMuc == txtDM.Text))
                {
                    MessageBox.Show("Danh mục đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDM.Text = "";
                    return;
                }


                DANHMUC dm = new DANHMUC();
                dm.TenDanhMuc = txtDM.Text;
                dm.NgayTao = DateTime.Now;
                dm.NgayCapNhat = DateTime.Now;

                context.DANHMUCs.Add(dm);
                context.SaveChanges();

                Binding(context.DANHMUCs.ToList());
                txtDM.Text = "";
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDM.Text))
            {
                string newTenDanhMuc = txtDM.Text;

                using (KaraokeDB context = new KaraokeDB())
                {
                    try
                    {
                        DANHMUC update = context.DANHMUCs.FirstOrDefault(d => d.TenDanhMuc == newTenDanhMuc);
                        if (update == null)
                        {
                            MessageBox.Show("Danh mục không tồn tại trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            update.TenDanhMuc = newTenDanhMuc;
                            update.NgayCapNhat = DateTime.Now;

                            context.SaveChanges();

                            MessageBox.Show("Sửa thông tin danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Binding(context.DANHMUCs.ToList());

                            txtDM.Text = "";
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

        private void dgvDM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvDM.Rows[e.RowIndex];
            txtDM.Text = r.Cells["dgvTenDM"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string NameToDelete = txtDM.Text;
                if (string.IsNullOrEmpty(NameToDelete))
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (KaraokeDB context = new KaraokeDB())
                {
                    bool Exists = context.DANHMUCs.Any(s => s.TenDanhMuc == NameToDelete);
                    if (!Exists)
                    {
                        MessageBox.Show("Danh mục không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        var Delete = context.DANHMUCs.FirstOrDefault(s => s.TenDanhMuc == NameToDelete);
                        context.DANHMUCs.Remove(Delete);
                        context.SaveChanges();

                        RemoveFromDataGridView(NameToDelete);

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Binding(context.DANHMUCs.ToList());
                        // Xóa dữ liệu đã nhập trên TextBox
                        txtDM.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveFromDataGridView(string ID)
        {
            foreach (DataGridViewRow row in dgvDM.Rows)
            {
                if (row.Cells[0].Value.ToString() == ID)
                {
                    dgvDM.Rows.Remove(row);
                    break;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();

            using (KaraokeDB context = new KaraokeDB())
            {
                var query = from dm in context.DANHMUCs
                            where dm.TenDanhMuc.Contains(searchTerm)
                            select dm;

                List<DANHMUC> dmList = query.ToList();

                dgvDM.Rows.Clear();

                foreach (DANHMUC dM in dmList)
                {
                    dgvDM.Rows.Add(dM.IDDanhMuc, dM.TenDanhMuc, dM.NgayTao, dM.NgayCapNhat);
                }
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Vui lòng tìm kiếm theo tên danh mục", "Thông báo");
                e.Handled = true;
            }
        }
    }
}

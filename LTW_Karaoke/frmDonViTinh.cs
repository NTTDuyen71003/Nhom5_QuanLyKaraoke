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
    public partial class frmDonViTinh : Form
    {
        static KaraokeDB context = new KaraokeDB();
        List<DONVITINH> dvtList = context.DONVITINHs.ToList();
        private string nhanvien = "admin";

        public frmDonViTinh()
        {
            InitializeComponent();
            Binding(dvtList);
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        public void Binding(List<DONVITINH> list)
        {
            dgvDVT.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvDVT.Rows.Add();
                dgvDVT.Rows[index].Cells[0].Value = item.IDDVT;
                dgvDVT.Rows[index].Cells[1].Value = item.TenDVT;
                dgvDVT.Rows[index].Cells[2].Value = item.NgayTao;     
                dgvDVT.Rows[index].Cells[3].Value = item.NgayCapNhat;
            }
        }

        private void txtDonvitinh_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (KaraokeDB context = new KaraokeDB())
                    if (txtDVT.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                if (context.DONVITINHs.Any(d => d.TenDVT == txtDVT.Text))
                {
                    MessageBox.Show("Đơn vị tính đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDVT.Text = "";
                    return;
                }
                

                DONVITINH dvt = new DONVITINH();
                dvt.TenDVT = txtDVT.Text;
                dvt.NgayTao = DateTime.Now;
                dvt.NgayCapNhat = DateTime.Now;

                context.DONVITINHs.Add(dvt);
                context.SaveChanges();

                Binding(context.DONVITINHs.ToList());
                txtDVT.Text = "";
                MessageBox.Show("Thêm đơn vị tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Vui lòng nhập chữ", "Thông báo");
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrEmpty(txtDVT.Text))
                {
                    string newTenDVT = txtDVT.Text;

                    using (KaraokeDB context = new KaraokeDB())
                    {
                        try
                        {
                            DONVITINH update = context.DONVITINHs.FirstOrDefault(d => d.TenDVT == newTenDVT);
                            if (update == null)
                            {
                                MessageBox.Show("Đơn vị tính không tồn tại trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                update.TenDVT = newTenDVT;
                                update.NgayCapNhat = DateTime.Now;

                                context.SaveChanges();

                                MessageBox.Show("Sửa thông tin đơn vị tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Binding(context.DONVITINHs.ToList());

                                txtDVT.Text = "";
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
                    MessageBox.Show("Vui lòng nhập tên đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        private void dgvDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvDVT.Rows[e.RowIndex];
            txtDVT.Text = r.Cells["dgvTenDVT"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string NameToDelete = txtDVT.Text;
                if (string.IsNullOrEmpty(NameToDelete))
                {
                    MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (KaraokeDB context = new KaraokeDB())
                {
                    bool Exists = context.DONVITINHs.Any(s => s.TenDVT == NameToDelete);
                    if (!Exists)
                    {
                        MessageBox.Show("Đơn vị tính không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn vị tính này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        var Delete = context.DONVITINHs.FirstOrDefault(s => s.TenDVT == NameToDelete);
                        context.DONVITINHs.Remove(Delete);
                        context.SaveChanges();

                        RemoveFromDataGridView(NameToDelete);

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Binding(context.DONVITINHs.ToList());
                        // Xóa dữ liệu đã nhập trên TextBox
                        txtDVT.Text = "";
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
            foreach (DataGridViewRow row in dgvDVT.Rows)
            {
                if (row.Cells[0].Value.ToString() == ID)
                {
                    dgvDVT.Rows.Remove(row);
                    break;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
                // Thực hiện thoát chương trình
                this.Close();  
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();

            using (KaraokeDB context = new KaraokeDB())
            {
                var query = from dvt in context.DONVITINHs
                            where dvt.TenDVT.Contains(searchTerm)
                            select dvt;

                List<DONVITINH> dvtList = query.ToList();

                dgvDVT.Rows.Clear();

                foreach (DONVITINH dvT in dvtList)
                {
                    dgvDVT.Rows.Add(dvT.IDDVT, dvT.TenDVT, dvT.NgayTao, dvT.NgayCapNhat);
                }
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Vui lòng tìm kiếm theo tên đơn vị tính", "Thông báo");
                e.Handled = true;
            }
        }
    }
}
    


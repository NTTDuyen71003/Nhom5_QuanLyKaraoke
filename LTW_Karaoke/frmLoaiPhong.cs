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

namespace LTW_Karaoke
{
    public partial class frmLoaiPhong : Form
    {
        static KaraokeDB context = new KaraokeDB();
        List<LOAIPHONG> lpList = context.LOAIPHONGs.ToList();

        public frmLoaiPhong()
        {
            InitializeComponent();
            Binding(lpList);
        }

        public void Binding(List<LOAIPHONG> listLP)
        {
            dgvLoaiPhong.Rows.Clear();
            foreach (var item in listLP)
            {
                int index = dgvLoaiPhong.Rows.Add();
                dgvLoaiPhong.Rows[index].Cells[0].Value = item.IDLoaiPhong;
                dgvLoaiPhong.Rows[index].Cells[1].Value = item.NameLP;
                dgvLoaiPhong.Rows[index].Cells[2].Value = item.DonGia;
                dgvLoaiPhong.Rows[index].Cells[3].Value = item.NgayCapNhat;
            }
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvLoaiPhong.Rows[e.RowIndex];
            txtDonGia.Text = r.Cells["dgvDonGia"].Value.ToString();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Thông báo");
                e.Handled = true;
            }
        }

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "N0";  // Định dạng phần nghìn
            dgvLoaiPhong.Columns["dgvDonGia"].ValueType = typeof(float);
            dgvLoaiPhong.Columns["dgvDonGia"].DefaultCellStyle = style;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manhinhchinh MENU = new Manhinhchinh();
            MENU.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDonGia.Text))
            {
                decimal newDG = decimal.Parse(txtDonGia.Text);

                using (KaraokeDB context = new KaraokeDB())
                {
                    try
                    {
                        if (dgvLoaiPhong.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Vui lòng chọn 1 dòng dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDonGia.Text = "";
                            return;
                        }
                        DataGridViewRow selectedRow = dgvLoaiPhong.SelectedRows[0];
                        int id = Convert.ToInt32(selectedRow.Cells["dgvIDLP"].Value);

                        // Tìm dòng dữ liệu cần sửa theo ID
                        LOAIPHONG update = context.LOAIPHONGs.FirstOrDefault(d => d.IDLoaiPhong == id);
                        if (update == null)
                        {
                            MessageBox.Show("Không tìm thấy dòng dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDonGia.Text = "";
                            return;
                        }
                        else
                        {
                            update.DonGia = newDG;
                            update.NgayCapNhat = DateTime.Now;

                            context.SaveChanges();

                            MessageBox.Show("Sửa giá phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Binding(context.LOAIPHONGs.ToList());

                            txtDonGia.Text = "";
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
                MessageBox.Show("Vui lòng nhập đơn giá cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

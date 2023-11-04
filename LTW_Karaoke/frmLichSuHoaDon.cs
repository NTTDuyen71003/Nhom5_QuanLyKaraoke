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
    public partial class frmLichSuHoaDon : Form
    {
        public frmLichSuHoaDon()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Vui lòng tìm kiếm theo tên loại phòng hoặc tên phòng", "Thông báo");
                e.Handled = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();

            using (KaraokeDB context = new KaraokeDB())
            {
                var query = from P in context.HOADONBANHANGs
                            where P.PHONG.TenPhong.Contains(searchTerm) || P.PHONG.LOAIPHONG.NameLP.Contains(searchTerm) || P.MATHANG.TenMatHang.Contains(searchTerm)
                            select P;

                List<HOADONBANHANG> List = query.ToList();

                dgvLichsuhoadon.Rows.Clear();

                foreach (HOADONBANHANG hoaDon in List)
                {
                    dgvLichsuhoadon.Rows.Add(hoaDon.IDHoaDon, hoaDon.PHONG.LOAIPHONG.NameLP, hoaDon.PHONG.TenPhong, hoaDon.MATHANG.TenMatHang, hoaDon.MATHANG.DonGiaBan, hoaDon.ThoiGianBD, hoaDon.ThoiGianKT);
                }
            }
        }
    }
}

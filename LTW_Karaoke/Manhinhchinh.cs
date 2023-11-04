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
using LTW_Karaoke.Model;
using QLKaraoke_6Priencesses;

namespace LTW_Karaoke
{
    public partial class Manhinhchinh : Form
    {
        public Manhinhchinh()
        {
            InitializeComponent();
            if (Session.LoginAccount.LoaiTaiKhoan != "QTV" )
            {
                quảnLýToolStripMenuItem.Visible = false;
            }
            lbxinChao.Text = "Xin chào, " + Session.LoginAccount.HoVaTen + "(" + Session.LoginAccount.LoaiTaiKhoan + ")";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangnhap f = new frmDangnhap();
            f.Show();
        }


        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmThongTinTaiKhoan thongTinTaiKhoan = new frmThongTinTaiKhoan();
            thongTinTaiKhoan.ShowDialog();
        }

        private void doanhMụcHangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMatHang childform2 = new frmMatHang();
            childform2.ShowDialog();
        }

        private void nhanVienToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLTaiKhoan qLTaiKhoanan = new frmQLTaiKhoan();
            qLTaiKhoanan.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLKhachHang a = new frmQLKhachHang();
            a.ShowDialog();
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyPhong childfr = new QuanLyPhong();
            childfr.ShowDialog();
        }

        private void lịchSửHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tácVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDatPhong frmDatPhong = new frmDatPhong();
            frmDatPhong.ShowDialog();
        }

        private void Manhinhchinh_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}

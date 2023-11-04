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
    public partial class frmDangnhap : Form
    {
        KaraokeDB db;
        public frmDangnhap()
        {
            InitializeComponent();
        }

        private void txttentk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar)) 
            { 
                e.Handled = true;
            }
            
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txttentk.Text) || string.IsNullOrEmpty(txtmatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txttentk.Select();
                return;
            }
            KaraokeDB db = new KaraokeDB();
            var tk = db.NHANVIENs.SingleOrDefault(x=>x.TenTaiKhoan == txttentk.Text && x.MatKhau == txtmatkhau.Text);
            if(tk != null)
            {
                Session.LoginAccount = tk;
                
                frmWaitForm waitForm = new frmWaitForm();
                waitForm.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttentk.Select();
                return;
            }     
        }
        private void link_thoat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void frmDangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                e.Cancel = true;
        }
    }
}
    


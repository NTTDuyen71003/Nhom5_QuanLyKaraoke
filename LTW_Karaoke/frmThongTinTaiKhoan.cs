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

namespace LTW_Karaoke
{
    public partial class frmThongTinTaiKhoan : Form
    {
        KaraokeDB db;
        string connectionString = "Data Source=LAPTOP-E03OOFES;Initial Catalog=Karaoke_Princesses;Integrated Security=True";
        public frmThongTinTaiKhoan()
        {
            InitializeComponent();
            ckbDTTCN.Visible = false;
            ckbDoiMK.Visible = false;
            gbTTCN.Visible = false;
            gbDoiMK.Visible = false;
            db = new KaraokeDB();
            txtTenTK.Text = Session.LoginAccount.TenTaiKhoan;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMK.Text != Session.LoginAccount.MatKhau)
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ckbDTTCN.Visible = false;
                ckbDTTCN.Checked = false;
                ckbDoiMK.Visible = false;
                ckbDoiMK.Checked = false;
                gbTTCN.Visible = false;
                gbDoiMK .Visible = false;
                return;
            }
            if (txtMK.Text == Session.LoginAccount.MatKhau)
            {
                ckbDTTCN.Visible = true;
                ckbDoiMK.Visible = true;
                ckbDTTCN.Checked = false;
                ckbDoiMK.Checked = false;
                txtMK.Text = "";
            }
        }


        private void ckbDTTCN_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDTTCN.Checked)
            {
                gbTTCN.Visible = true;
                txtHoVaTen.Text = Session.LoginAccount.HoVaTen;
                txtSDT.Text = Session.LoginAccount.SDT;
                txtDiaChi.Text = Session.LoginAccount.DiaChi;
            }
            else
            {
                gbTTCN.Visible = false;
            }
        }

        private void btnXacNhanTTCN_Click(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text != Session.LoginAccount.HoVaTen || txtSDT.Text != Session.LoginAccount.SDT || txtDiaChi.Text != Session.LoginAccount.DiaChi)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        string update = "Update NHANVIEN Set HoVaTen = '" + txtHoVaTen.Text + "', SDT = '" + txtSDT.Text + "', DiaChi = '" + txtDiaChi.Text + "' Where TenTaiKhoan = '" + txtTenTK.Text + "' ";
                        using (SqlCommand command = new SqlCommand(update, sqlConnection))
                        {
                            command.Parameters.AddWithValue("@HoVaTen", txtHoVaTen.Text);
                            command.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            command.Parameters.AddWithValue("@TenTaiKhoan", Session.LoginAccount.TenTaiKhoan);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                                // Cập nhật thông tin trong session
                                Session.LoginAccount.HoVaTen = txtHoVaTen.Text;
                                Session.LoginAccount.SDT = txtSDT.Text;
                                Session.LoginAccount.DiaChi = txtDiaChi.Text;
                                ckbDTTCN.Checked = false;
                                gbTTCN.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xác nhận thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                ckbDTTCN.Checked = false;
                gbTTCN.Visible = false;
            }
        }

        private void ckbDoiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDoiMK.Checked)
            {
                gbDoiMK.Visible = true;
            }
            else
            {
                gbDoiMK.Visible = false;
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMKMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtXNMKMoi.Text))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            if(!(txtXNMKMoi.Text).Equals(txtMKMoi.Text))
            {
                MessageBox.Show("Vui lòng xác nhận đúng mật khẩu mới!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        string update = "Update NHANVIEN Set MatKhau = '" + txtMKMoi.Text + "' Where TenTaiKhoan = '" + txtTenTK.Text + "' ";
                        using (SqlCommand command = new SqlCommand(update, sqlConnection))
                        {
                            command.Parameters.AddWithValue("@MatKhau", txtMKMoi.Text);
                            command.Parameters.AddWithValue("@TenTaiKhoan", Session.LoginAccount.TenTaiKhoan);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                                // Cập nhật thông tin trong session
                                Session.LoginAccount.MatKhau = txtMKMoi.Text;
                                txtMKMoi.Text = "";
                                txtXNMKMoi.Text = "";
                                ckbDoiMK.Checked = false;
                                gbDoiMK.Visible = false;
                                gbTTCN.Visible = false;
                                ckbDTTCN.Visible = false;
                                ckbDoiMK.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Manhinhchinh manhinhchinh = new Manhinhchinh();
            manhinhchinh.Show();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại gồm đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }
        }

        private void txtHoVaTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void frmThongTinTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void cbHienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienmatkhau.Checked)
            {
                txtMK.PasswordChar = '\0'; // Hiện mật khẩu
            }
            else
            {
                txtMK.PasswordChar = '*'; // Ẩn mật khẩu
            }
        }

        private void cbHMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHMK.Checked)
            {
                txtMKMoi.PasswordChar = '\0'; // Hiện mật khẩu
                txtXNMKMoi.PasswordChar = '\0';
            }
            else
            {
                txtMKMoi.PasswordChar = '*'; // Ẩn mật khẩu
                txtXNMKMoi.PasswordChar = '*';
            }
        }
    }
}

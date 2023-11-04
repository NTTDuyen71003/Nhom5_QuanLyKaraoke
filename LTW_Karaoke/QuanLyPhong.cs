using LTW_Karaoke.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTW_Karaoke
{
    public partial class QuanLyPhong : Form
    {
        public event Action PhongAdded;
        public event Action<PHONG> PhongUpdated;
        public event Action PhongDeleted;

        public QuanLyPhong()
        {
            InitializeComponent();
        }
        KaraokeDB db;
        List<PHONG> ListPhong;
        List<LOAIPHONG> ListLoaiPhong;

        //string ConnectionString = "Data Source=LAPTOP-E03OOFES;Initial Catalog = Karaoke_6Princesses; Integrated Security = True";

        private void QuanLyPhong_Load(object sender, EventArgs e)
        {
            db = new KaraokeDB();
            ListPhong = db.PHONGs.ToList();
            ListLoaiPhong = db.LOAIPHONGs.ToList();
            fillLoaiPhong(ListLoaiPhong);
            CapNhatDataGridView(ListPhong);
            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
        }

        private void CapNhatDataGridView(List<PHONG> ListPhong)
        {
            dgvPhong.Rows.Clear();

            foreach (var item in ListPhong)
            {
                int index = dgvPhong.Rows.Add();
                dgvPhong.Rows[index].Cells[0].Value = item.IDPhong;
                dgvPhong.Rows[index].Cells[1].Value = item.TenPhong;
                dgvPhong.Rows[index].Cells[2].Value = item.LOAIPHONG.NameLP;
                dgvPhong.Rows[index].Cells[3].Value = item.TrangThai;
                //dgvPhong.Rows[index].Cells[3].Value = item.LOAIPHONG.IDLoaiPhong;          
                dgvPhong.Rows[index].Cells[4].Value = item.NgayTao;
                dgvPhong.Rows[index].Cells[5].Value = item.NgayCapNhat;
            }
        }

        public void ClearForm()
        {
            txtTenPhong.Text = cbbTrangThai.Text = cmbLP.Text="";

        }

        private void fillLoaiPhong(List<LOAIPHONG> list)
        {
            this.cmbLP.DataSource = list;
            this.cmbLP.DisplayMember = "NameLP";
            this.cmbLP.ValueMember = "IDLoaiPhong";
        }

        public bool checkNull()
        {
            if (txtTenPhong.Text == "" || cbbTrangThai.Text == "" || cmbLP.Text == "")
            {
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaphong.Text;
            string tenPhong = txtTenPhong.Text;
            LOAIPHONG selectedLOAIPHONG = cmbLP.SelectedItem as LOAIPHONG;
            string tenLoaiPhong = ((LOAIPHONG)cmbLP.SelectedItem)?.NameLP;
            string trangThai = cbbTrangThai.Text;
            //string sucChua = txtSucChua.Text;
            DateTime ngayTao = DateTime.Now.Date;
            DateTime ngayCapNhat = DateTime.Now.Date;

            //int.TryParse(maPhong, out int MPhong);
            //int.TryParse(maLoaiPhong, out int MLoaiPhong);
            //int.TryParse(trangthai, out int TrangThai);
            //int.TryParse(sucChua, out int ParseSucChua);

            if (string.IsNullOrEmpty(tenPhong) || string.IsNullOrEmpty(cmbLP.Text)||string.IsNullOrEmpty(cbbTrangThai.Text))
            {
                MessageBox.Show("Vui lòng không bỏ trống bất kỳ thông tin nào!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool tenPhongDaTonTai = db.PHONGs.Any(p => p.TenPhong == tenPhong);

            if (tenPhongDaTonTai)
            {
                MessageBox.Show("Tên phòng đã tồn tại trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForm();
                return;
            }
            else
            {
                PHONG newPhong = new PHONG()
                {
                    TenPhong = tenPhong,
                    IDLoaiPhong = selectedLOAIPHONG?.IDLoaiPhong ?? 0,
                    //SucChua = int.Parse(sucChua),
                    TrangThai = trangThai,
                    NgayTao = ngayTao,
                    NgayCapNhat = ngayCapNhat,
                };
                using (KaraokeDB db = new KaraokeDB())
                {
                    db.PHONGs.Add(newPhong);
                    db.SaveChanges();
                }
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvPhong, maPhong, tenPhong, tenLoaiPhong, trangThai, ngayTao, ngayCapNhat);
                dgvPhong.Rows.Add(newRow);
                PhongAdded?.Invoke();
                MessageBox.Show("Thêm phòng mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                QuanLyPhong_Load(sender, e);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaphong.Text;
            string tenPhong = txtTenPhong.Text;
            LOAIPHONG selectedLOAIPHONG = cmbLP.SelectedItem as LOAIPHONG;
            string trangThai = cbbTrangThai.Text;
            DateTime ngayCapNhat = DateTime.Now.Date;

            int.TryParse(maPhong, out int ParseMaPhong);

            if (string.IsNullOrEmpty(tenPhong) || string.IsNullOrEmpty(cmbLP.Text))
            {
                MessageBox.Show("Vui lòng không để trống bất cứ thông tin nào khi cập nhật!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cbbTrangThai.Text=="Đang thuê")
            {
                MessageBox.Show("Vui lòng không cập nhật phòng đang sử dụng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearForm();
                return;
            }
            else
            {
                using (KaraokeDB db = new KaraokeDB())
                {
                    PHONG existingPhong = db.PHONGs.FirstOrDefault(p => p.IDPhong == ParseMaPhong);
                    if (existingPhong == null)
                    {
                        MessageBox.Show("Không tìm thấy phòng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    existingPhong.TenPhong = tenPhong;
                    existingPhong.IDLoaiPhong = selectedLOAIPHONG?.IDLoaiPhong ?? 0;
                    existingPhong.TrangThai = trangThai;
                    existingPhong.NgayCapNhat = ngayCapNhat;

                    db.SaveChanges();
                    PhongUpdated?.Invoke(existingPhong);
                }
                QuanLyPhong_Load(sender, e);
                MessageBox.Show("Cập nhật thông tin phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvQuanLyPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhong.SelectedRows.Count > 0 && dgvPhong.SelectedRows[0].Index != -1)
            {
                DataGridViewRow selectedRow = dgvPhong.SelectedRows[0];

                if (!selectedRow.IsNewRow) // Check if it's not a new row
                {
                    string Id = selectedRow.Cells[0].Value.ToString();

                    using (KaraokeDB db = new KaraokeDB())
                    {
                        if (int.TryParse(Id, out int idPhong)) // Convert Id to an integer
                        {
                            PHONG selectedP = db.PHONGs.FirstOrDefault(s => s.IDPhong == idPhong);

                            if (selectedP != null)
                            {
                                txtMaphong.Text = selectedP.IDPhong.ToString();
                                txtTenPhong.Text = selectedP.TenPhong;
                                cbbTrangThai.Text = selectedP.TrangThai.ToString();
                                if(cbbTrangThai.Text == "Đang thuê")
                                {
                                    cbbTrangThai.Enabled = false;
                                }
                                else
                                {
                                    cbbTrangThai.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            btnCapNhat.Enabled = true;
            btnThem.Enabled = false;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ClearForm();          
            string searchTerm = txtTimKiem.Text.Trim();
            using (KaraokeDB db = new KaraokeDB())
            {
                var query = from p in db.PHONGs
                            where p.TenPhong.Contains(searchTerm) 
                            select p;

                List<PHONG> listPhong = query.ToList();

                dgvPhong.Rows.Clear();

                foreach (PHONG phong in listPhong)
                {
                    dgvPhong.Rows.Add(phong.IDPhong, phong.TenPhong,phong.LOAIPHONG.NameLP, phong.TrangThai, phong.NgayTao, phong.NgayCapNhat);
                }
            }
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manhinhchinh MENU = new Manhinhchinh();
            MENU.ShowDialog();
        }

        private void loạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiPhong frmLoaiPhong = new frmLoaiPhong();
            frmLoaiPhong.ShowDialog();
        }
    }
}

 
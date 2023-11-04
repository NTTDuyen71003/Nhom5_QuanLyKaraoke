namespace QLKaraoke_6Priencesses
{
    partial class frmMatHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatHang));
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvMatHang = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.txtTenmh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grpThongtinmathang = new System.Windows.Forms.GroupBox();
            this.dgvMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDonGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNgayTạo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNgayCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).BeginInit();
            this.grpThongtinmathang.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Location = new System.Drawing.Point(691, 609);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 44);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvMatHang
            // 
            this.dgvMatHang.AllowUserToAddRows = false;
            this.dgvMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMH,
            this.dgvTenMH,
            this.dgvDonGiaBan,
            this.dgvNgayTạo,
            this.dgvNgayCN});
            this.dgvMatHang.Location = new System.Drawing.Point(22, 228);
            this.dgvMatHang.Name = "dgvMatHang";
            this.dgvMatHang.ReadOnly = true;
            this.dgvMatHang.Size = new System.Drawing.Size(744, 365);
            this.dgvMatHang.TabIndex = 14;
            this.dgvMatHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatHang_CellClick);
            this.dgvMatHang.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMatHang_CellFormatting);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(651, 126);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 44);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(541, 164);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 44);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(541, 95);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 44);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên mặt hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(74, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 44);
            this.label1.TabIndex = 8;
            this.label1.Text = "QUẢN LÝ DANH SÁCH MẶT HÀNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "Đơn giá";
            // 
            // txtDongia
            // 
            this.txtDongia.Location = new System.Drawing.Point(150, 77);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.Size = new System.Drawing.Size(280, 27);
            this.txtDongia.TabIndex = 19;
            this.txtDongia.TextChanged += new System.EventHandler(this.txtDongia_TextChanged);
            this.txtDongia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDongia_KeyPress);
            // 
            // txtTenmh
            // 
            this.txtTenmh.Location = new System.Drawing.Point(150, 32);
            this.txtTenmh.Name = "txtTenmh";
            this.txtTenmh.Size = new System.Drawing.Size(280, 27);
            this.txtTenmh.TabIndex = 10;
            this.txtTenmh.Click += new System.EventHandler(this.txtTenmh_Click);
            this.txtTenmh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenmh_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(78, 621);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 22);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(166, 618);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(320, 27);
            this.txtTimKiem.TabIndex = 22;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // grpThongtinmathang
            // 
            this.grpThongtinmathang.BackColor = System.Drawing.Color.CornflowerBlue;
            this.grpThongtinmathang.Controls.Add(this.txtDongia);
            this.grpThongtinmathang.Controls.Add(this.label4);
            this.grpThongtinmathang.Controls.Add(this.txtTenmh);
            this.grpThongtinmathang.Controls.Add(this.label2);
            this.grpThongtinmathang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongtinmathang.ForeColor = System.Drawing.Color.Black;
            this.grpThongtinmathang.Location = new System.Drawing.Point(55, 82);
            this.grpThongtinmathang.Name = "grpThongtinmathang";
            this.grpThongtinmathang.Size = new System.Drawing.Size(463, 126);
            this.grpThongtinmathang.TabIndex = 25;
            this.grpThongtinmathang.TabStop = false;
            this.grpThongtinmathang.Text = "Thông tin mặt hàng";
            // 
            // dgvMH
            // 
            this.dgvMH.HeaderText = "IDMH";
            this.dgvMH.Name = "dgvMH";
            this.dgvMH.ReadOnly = true;
            // 
            // dgvTenMH
            // 
            this.dgvTenMH.HeaderText = "Tên Mặt Hàng";
            this.dgvTenMH.Name = "dgvTenMH";
            this.dgvTenMH.ReadOnly = true;
            this.dgvTenMH.Width = 200;
            // 
            // dgvDonGiaBan
            // 
            this.dgvDonGiaBan.HeaderText = "Đơn Gía Bán";
            this.dgvDonGiaBan.Name = "dgvDonGiaBan";
            this.dgvDonGiaBan.ReadOnly = true;
            this.dgvDonGiaBan.Width = 150;
            // 
            // dgvNgayTạo
            // 
            this.dgvNgayTạo.HeaderText = "Ngày Tạo";
            this.dgvNgayTạo.Name = "dgvNgayTạo";
            this.dgvNgayTạo.ReadOnly = true;
            this.dgvNgayTạo.Width = 120;
            // 
            // dgvNgayCN
            // 
            this.dgvNgayCN.HeaderText = "Ngày Cập Nhật";
            this.dgvNgayCN.Name = "dgvNgayCN";
            this.dgvNgayCN.ReadOnly = true;
            this.dgvNgayCN.Width = 150;
            // 
            // frmMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 665);
            this.ControlBox = false;
            this.Controls.Add(this.grpThongtinmathang);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgvMatHang);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmMatHang";
            this.Text = "Mặt Hàng";
            this.Load += new System.EventHandler(this.frmMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).EndInit();
            this.grpThongtinmathang.ResumeLayout(false);
            this.grpThongtinmathang.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvMatHang;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDongia;
        private System.Windows.Forms.TextBox txtTenmh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox grpThongtinmathang;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDonGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNgayTạo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNgayCN;
    }
}
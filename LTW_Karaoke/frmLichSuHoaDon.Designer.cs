namespace LTW_Karaoke
{
    partial class frmLichSuHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLichSuHoaDon));
            this.dgvLichsuhoadon = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvIDHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenLP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDonGiaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvThoiGianBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvThoiGianKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTongHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichsuhoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLichsuhoadon
            // 
            this.dgvLichsuhoadon.AllowUserToAddRows = false;
            this.dgvLichsuhoadon.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichsuhoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichsuhoadon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIDHD,
            this.dgvTenLP,
            this.dgvTenPhong,
            this.dgvTenMH,
            this.dgvDonGiaMH,
            this.dgvThoiGianBD,
            this.dgvThoiGianKT,
            this.dgvTongHoaDon});
            this.dgvLichsuhoadon.Location = new System.Drawing.Point(28, 212);
            this.dgvLichsuhoadon.Name = "dgvLichsuhoadon";
            this.dgvLichsuhoadon.ReadOnly = true;
            this.dgvLichsuhoadon.Size = new System.Drawing.Size(744, 371);
            this.dgvLichsuhoadon.TabIndex = 31;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Transparent;
            this.btnXoa.Location = new System.Drawing.Point(352, 143);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 33);
            this.btnXoa.TabIndex = 30;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Transparent;
            this.btnSua.Location = new System.Drawing.Point(228, 143);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 33);
            this.btnSua.TabIndex = 29;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Firebrick;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(220, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 44);
            this.label1.TabIndex = 25;
            this.label1.Text = "LỊCH SỬ HÓA ĐƠN";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(175, 105);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(320, 27);
            this.txtTimKiem.TabIndex = 34;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Firebrick;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(87, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "Tìm kiếm";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Transparent;
            this.btnThoat.Location = new System.Drawing.Point(697, 611);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 33);
            this.btnThoat.TabIndex = 32;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvIDHD
            // 
            this.dgvIDHD.HeaderText = "ID Hóa Đơn";
            this.dgvIDHD.Name = "dgvIDHD";
            this.dgvIDHD.ReadOnly = true;
            // 
            // dgvTenLP
            // 
            this.dgvTenLP.HeaderText = "Tên Loại Phòng";
            this.dgvTenLP.Name = "dgvTenLP";
            this.dgvTenLP.ReadOnly = true;
            this.dgvTenLP.Width = 120;
            // 
            // dgvTenPhong
            // 
            this.dgvTenPhong.HeaderText = "Tên Phòng";
            this.dgvTenPhong.Name = "dgvTenPhong";
            this.dgvTenPhong.ReadOnly = true;
            this.dgvTenPhong.Width = 120;
            // 
            // dgvTenMH
            // 
            this.dgvTenMH.HeaderText = "Tên Mặt Hàng";
            this.dgvTenMH.Name = "dgvTenMH";
            this.dgvTenMH.ReadOnly = true;
            this.dgvTenMH.Width = 120;
            // 
            // dgvDonGiaMH
            // 
            this.dgvDonGiaMH.HeaderText = "Gía Mặt Hàng";
            this.dgvDonGiaMH.Name = "dgvDonGiaMH";
            this.dgvDonGiaMH.ReadOnly = true;
            // 
            // dgvThoiGianBD
            // 
            this.dgvThoiGianBD.HeaderText = "Thời Gian Bắt Đầu";
            this.dgvThoiGianBD.Name = "dgvThoiGianBD";
            this.dgvThoiGianBD.ReadOnly = true;
            this.dgvThoiGianBD.Width = 120;
            // 
            // dgvThoiGianKT
            // 
            this.dgvThoiGianKT.HeaderText = "Thời Gian Kết Thúc";
            this.dgvThoiGianKT.Name = "dgvThoiGianKT";
            this.dgvThoiGianKT.ReadOnly = true;
            this.dgvThoiGianKT.Width = 120;
            // 
            // dgvTongHoaDon
            // 
            this.dgvTongHoaDon.HeaderText = "Tổng Hóa Đơn";
            this.dgvTongHoaDon.Name = "dgvTongHoaDon";
            this.dgvTongHoaDon.ReadOnly = true;
            this.dgvTongHoaDon.Width = 120;
            // 
            // frmLichSuHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 666);
            this.ControlBox = false;
            this.Controls.Add(this.dgvLichsuhoadon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThoat);
            this.Name = "frmLichSuHoaDon";
            this.Text = "Lịch Sử Hóa Đơn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichsuhoadon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLichsuhoadon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIDHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenLP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDonGiaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvThoiGianBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvThoiGianKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTongHoaDon;
    }
}
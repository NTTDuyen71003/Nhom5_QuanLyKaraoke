namespace LTW_Karaoke
{
    partial class frmDatPhong
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
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.cbbTrangThai = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvPhong = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDat = new System.Windows.Forms.Button();
            this.lvMatHang = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbbPhong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textMaMatHang = new System.Windows.Forms.TextBox();
            this.textDonGia = new System.Windows.Forms.TextBox();
            this.textTenMatHang = new System.Windows.Forms.TextBox();
            this.textSoLuong = new System.Windows.Forms.TextBox();
            this.textTienDichVu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.radioDoUong = new System.Windows.Forms.RadioButton();
            this.rbtMonAn = new System.Windows.Forms.RadioButton();
            this.buttonCapNhat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTimmathang = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Enabled = false;
            this.txtMaPhong.Location = new System.Drawing.Point(165, 38);
            this.txtMaPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(219, 32);
            this.txtMaPhong.TabIndex = 31;
            // 
            // cbbTrangThai
            // 
            this.cbbTrangThai.FormattingEnabled = true;
            this.cbbTrangThai.Items.AddRange(new object[] {
            "Phòng trống",
            "Đang thuê",
            "Phòng đã ngừng hoạt động",
            "Phòng đã đặt"});
            this.cbbTrangThai.Location = new System.Drawing.Point(573, 38);
            this.cbbTrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbTrangThai.Name = "cbbTrangThai";
            this.cbbTrangThai.Size = new System.Drawing.Size(239, 34);
            this.cbbTrangThai.TabIndex = 29;
            this.cbbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbbTrangThai_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.txtMaPhong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbTrangThai);
            this.groupBox1.Controls.Add(this.cbbLoaiPhong);
            this.groupBox1.Controls.Add(this.txtTenPhong);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 108);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(835, 206);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 26);
            this.label2.TabIndex = 30;
            this.label2.Text = "Mã Phòng";
            // 
            // cbbLoaiPhong
            // 
            this.cbbLoaiPhong.Enabled = false;
            this.cbbLoaiPhong.FormattingEnabled = true;
            this.cbbLoaiPhong.Location = new System.Drawing.Point(165, 144);
            this.cbbLoaiPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbLoaiPhong.Name = "cbbLoaiPhong";
            this.cbbLoaiPhong.Size = new System.Drawing.Size(219, 34);
            this.cbbLoaiPhong.TabIndex = 28;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Enabled = false;
            this.txtTenPhong.Location = new System.Drawing.Point(165, 86);
            this.txtTenPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(219, 32);
            this.txtTenPhong.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(16, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "Loại Phòng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(423, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Trạng Thái";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên Phòng";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(1437, 37);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 42);
            this.btnThoat.TabIndex = 38;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(196, 385);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(652, 32);
            this.txtTimKiem.TabIndex = 37;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 389);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 26);
            this.label11.TabIndex = 36;
            this.label11.Text = "Tìm Kiếm Phòng";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(15, 330);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(132, 38);
            this.btnCapNhat.TabIndex = 35;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(619, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 54);
            this.label1.TabIndex = 32;
            this.label1.Text = "ĐẶT PHÒNG";
            // 
            // lvPhong
            // 
            this.lvPhong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPhong.FullRowSelect = true;
            this.lvPhong.GridLines = true;
            this.lvPhong.HideSelection = false;
            this.lvPhong.Location = new System.Drawing.Point(15, 442);
            this.lvPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvPhong.Name = "lvPhong";
            this.lvPhong.Size = new System.Drawing.Size(833, 496);
            this.lvPhong.TabIndex = 40;
            this.lvPhong.UseCompatibleStateImageBehavior = false;
            this.lvPhong.View = System.Windows.Forms.View.Details;
            this.lvPhong.SelectedIndexChanged += new System.EventHandler(this.lvPhong_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã phòng";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên phòng ";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Trạng thái";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Loại Phòng";
            this.columnHeader4.Width = 150;
            // 
            // buttonDat
            // 
            this.buttonDat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDat.Location = new System.Drawing.Point(531, 222);
            this.buttonDat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDat.Name = "buttonDat";
            this.buttonDat.Size = new System.Drawing.Size(129, 42);
            this.buttonDat.TabIndex = 41;
            this.buttonDat.Text = "Đặt món";
            this.buttonDat.UseVisualStyleBackColor = false;
            this.buttonDat.Click += new System.EventHandler(this.buttonDat_Click);
            // 
            // lvMatHang
            // 
            this.lvMatHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8});
            this.lvMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMatHang.FullRowSelect = true;
            this.lvMatHang.GridLines = true;
            this.lvMatHang.HideSelection = false;
            this.lvMatHang.Location = new System.Drawing.Point(868, 124);
            this.lvMatHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvMatHang.Name = "lvMatHang";
            this.lvMatHang.Size = new System.Drawing.Size(676, 354);
            this.lvMatHang.TabIndex = 42;
            this.lvMatHang.UseCompatibleStateImageBehavior = false;
            this.lvMatHang.View = System.Windows.Forms.View.Details;
            this.lvMatHang.SelectedIndexChanged += new System.EventHandler(this.lvMatHang_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mã mặt hàng";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tên mặt hàng";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Đơn giá";
            this.columnHeader8.Width = 160;
            // 
            // cbbPhong
            // 
            this.cbbPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPhong.FormattingEnabled = true;
            this.cbbPhong.Location = new System.Drawing.Point(177, 27);
            this.cbbPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbPhong.Name = "cbbPhong";
            this.cbbPhong.Size = new System.Drawing.Size(309, 33);
            this.cbbPhong.TabIndex = 32;
            this.cbbPhong.SelectedIndexChanged += new System.EventHandler(this.cbbPhong_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 26);
            this.label5.TabIndex = 32;
            this.label5.Text = "Số lượng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 26);
            this.label7.TabIndex = 32;
            this.label7.Text = "Tên mặt hàng:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 26);
            this.label8.TabIndex = 46;
            this.label8.Text = "Mã mặt hàng:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 26);
            this.label9.TabIndex = 47;
            this.label9.Text = "Tên Phòng:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 26);
            this.label10.TabIndex = 48;
            this.label10.Text = "Đơn giá:";
            // 
            // textMaMatHang
            // 
            this.textMaMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMaMatHang.Location = new System.Drawing.Point(177, 75);
            this.textMaMatHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textMaMatHang.Name = "textMaMatHang";
            this.textMaMatHang.ReadOnly = true;
            this.textMaMatHang.Size = new System.Drawing.Size(309, 32);
            this.textMaMatHang.TabIndex = 49;
            // 
            // textDonGia
            // 
            this.textDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDonGia.Location = new System.Drawing.Point(177, 166);
            this.textDonGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDonGia.Name = "textDonGia";
            this.textDonGia.ReadOnly = true;
            this.textDonGia.Size = new System.Drawing.Size(309, 32);
            this.textDonGia.TabIndex = 50;
            this.textDonGia.TextChanged += new System.EventHandler(this.textDonGia_TextChanged);
            // 
            // textTenMatHang
            // 
            this.textTenMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTenMatHang.Location = new System.Drawing.Point(177, 123);
            this.textTenMatHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textTenMatHang.Name = "textTenMatHang";
            this.textTenMatHang.ReadOnly = true;
            this.textTenMatHang.Size = new System.Drawing.Size(309, 32);
            this.textTenMatHang.TabIndex = 51;
            this.textTenMatHang.TextChanged += new System.EventHandler(this.textTenMatHang_TextChanged);
            // 
            // textSoLuong
            // 
            this.textSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSoLuong.Location = new System.Drawing.Point(177, 212);
            this.textSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textSoLuong.Name = "textSoLuong";
            this.textSoLuong.Size = new System.Drawing.Size(309, 32);
            this.textSoLuong.TabIndex = 52;
            this.textSoLuong.TextChanged += new System.EventHandler(this.textSoLuong_TextChanged);
            this.textSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSoLuong_KeyDown);
            // 
            // textTienDichVu
            // 
            this.textTienDichVu.Enabled = false;
            this.textTienDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTienDichVu.Location = new System.Drawing.Point(177, 258);
            this.textTienDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textTienDichVu.Name = "textTienDichVu";
            this.textTienDichVu.Size = new System.Drawing.Size(309, 32);
            this.textTienDichVu.TabIndex = 53;
            this.textTienDichVu.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 266);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 26);
            this.label12.TabIndex = 54;
            this.label12.Text = "Tiền dịch vụ:";
            // 
            // radioDoUong
            // 
            this.radioDoUong.AutoSize = true;
            this.radioDoUong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDoUong.Location = new System.Drawing.Point(531, 114);
            this.radioDoUong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioDoUong.Name = "radioDoUong";
            this.radioDoUong.Size = new System.Drawing.Size(115, 30);
            this.radioDoUong.TabIndex = 55;
            this.radioDoUong.TabStop = true;
            this.radioDoUong.Text = "Đồ uống";
            this.radioDoUong.UseVisualStyleBackColor = true;
            this.radioDoUong.CheckedChanged += new System.EventHandler(this.radioDoUong_CheckedChanged);
            // 
            // rbtMonAn
            // 
            this.rbtMonAn.AutoSize = true;
            this.rbtMonAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMonAn.Location = new System.Drawing.Point(531, 166);
            this.rbtMonAn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtMonAn.Name = "rbtMonAn";
            this.rbtMonAn.Size = new System.Drawing.Size(105, 30);
            this.rbtMonAn.TabIndex = 56;
            this.rbtMonAn.TabStop = true;
            this.rbtMonAn.Text = "Món ăn";
            this.rbtMonAn.UseVisualStyleBackColor = true;
            // 
            // buttonCapNhat
            // 
            this.buttonCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCapNhat.Location = new System.Drawing.Point(165, 331);
            this.buttonCapNhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCapNhat.Name = "buttonCapNhat";
            this.buttonCapNhat.Size = new System.Drawing.Size(184, 37);
            this.buttonCapNhat.TabIndex = 57;
            this.buttonCapNhat.Text = "Tính thời gian";
            this.buttonCapNhat.UseVisualStyleBackColor = false;
            this.buttonCapNhat.Click += new System.EventHandler(this.buttonCapNhat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.btnThanhToan);
            this.groupBox2.Controls.Add(this.rbtMonAn);
            this.groupBox2.Controls.Add(this.radioDoUong);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textTienDichVu);
            this.groupBox2.Controls.Add(this.textSoLuong);
            this.groupBox2.Controls.Add(this.textTenMatHang);
            this.groupBox2.Controls.Add(this.textDonGia);
            this.groupBox2.Controls.Add(this.textMaMatHang);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbbPhong);
            this.groupBox2.Controls.Add(this.buttonDat);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(868, 556);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(677, 382);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(131, 316);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(451, 42);
            this.btnThanhToan.TabIndex = 64;
            this.btnThanhToan.Text = "Xác nhận thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(1065, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(220, 26);
            this.label13.TabIndex = 59;
            this.label13.Text = "Danh Sách Mặt Hàng";
            // 
            // txtTimmathang
            // 
            this.txtTimmathang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimmathang.Location = new System.Drawing.Point(1089, 495);
            this.txtTimmathang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimmathang.Name = "txtTimmathang";
            this.txtTimmathang.Size = new System.Drawing.Size(455, 32);
            this.txtTimmathang.TabIndex = 61;
            this.txtTimmathang.TextChanged += new System.EventHandler(this.txtTimmathang_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(873, 498);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(205, 26);
            this.label20.TabIndex = 60;
            this.label20.Text = "Tìm Kiếm Mặt Hàng";
            // 
            // frmDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::LTW_Karaoke.Properties.Resources._58bd5e593902fd8e92023230c88aea481;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1469, 795);
            this.ControlBox = false;
            this.Controls.Add(this.txtTimmathang);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCapNhat);
            this.Controls.Add(this.lvMatHang);
            this.Controls.Add(this.lvPhong);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDatPhong";
            this.Text = "Đặt Phòng";
            this.Activated += new System.EventHandler(this.frmDatPhong_Activated);
            this.Load += new System.EventHandler(this.frmDatPhong_Load);
            this.Shown += new System.EventHandler(this.frmDatPhong_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.ComboBox cbbTrangThai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbLoaiPhong;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvPhong;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonDat;
        private System.Windows.Forms.ListView lvMatHang;
        private System.Windows.Forms.ComboBox cbbPhong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textMaMatHang;
        private System.Windows.Forms.TextBox textDonGia;
        private System.Windows.Forms.TextBox textTenMatHang;
        private System.Windows.Forms.TextBox textSoLuong;
        private System.Windows.Forms.TextBox textTienDichVu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radioDoUong;
        private System.Windows.Forms.RadioButton rbtMonAn;
        private System.Windows.Forms.Button buttonCapNhat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox txtTimmathang;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnThanhToan;
    }
}


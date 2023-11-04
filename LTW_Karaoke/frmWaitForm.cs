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
    public partial class frmWaitForm : Form
    {
        private Timer timer;
        private int elapsedTimeInSeconds;
        public frmWaitForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000; // mỗi giây
            timer.Tick += Timer_Tick;

            // Khởi tạo thời gian đã trôi qua
            elapsedTimeInSeconds = 0;

            // Bắt đầu đếm thời gian
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;

            // Kiểm tra xem đã đủ 3 giây chưa
            if (elapsedTimeInSeconds >= 2)
            {
                // Dừng timer
                timer.Stop();

                // Đóng form loading
                this.Close();
                Manhinhchinh f = new Manhinhchinh();
                f.ShowDialog();
            }
        }
        private void WaitForm_Load(object sender, EventArgs e)
        {

        }
    }
}

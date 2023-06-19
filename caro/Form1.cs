namespace caro
{
    public partial class Form1 : Form
    {
        #region Properties
        QuanLiBanCo BanCo;
        SocketManager socket;
        #endregion
        public Form1()
        {
            InitializeComponent();
            BanCo = new QuanLiBanCo(pnlBanCo, txtTenNguoiChoi, pctbKiHieu);
            BanCo.EndGame += BanCo_EndGame;
            BanCo.NguoiChoiDaClick += BanCo_NguoiChoiDaClick;

            prcbDemNguoc.Step = hangso.BuocNhayThoiGian;
            prcbDemNguoc.Maximum = hangso.ThoiGian_KetThuc;
            prcbDemNguoc.Value = 0; //thời gian bắt đầu

            tmDemNguoc.Interval = hangso.KhoangThoiGianDemNguoc;//cài time cho timer
            socket = new SocketManager();
            NewGame();

        }
        #region methods
        void EndGame()
        {
            tmDemNguoc.Stop();
            pnlBanCo.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            MessageBox.Show("Kết thúc ùi!!");
        }
        void NewGame()
        {
            prcbDemNguoc.Value = 0;
            tmDemNguoc.Stop();
            BanCo.VeBanCo();

        }
        void Quit()
        {
            Application.Exit();
        }
        void Undo()
        {
            BanCo.Undo();
        }

        private void BanCo_NguoiChoiDaClick(object? sender, EventArgs e)
        {
            tmDemNguoc.Start();
            prcbDemNguoc.Value = 0;
        }

        private void BanCo_EndGame(object? sender, EventArgs e)
        {
            EndGame();
        }

        private void tmDemNguoc_Tick(object sender, EventArgs e)
        {
            prcbDemNguoc.PerformStep();
            if (prcbDemNguoc.Value >= prcbDemNguoc.Maximum)
            {
                EndGame();
            }

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)

                e.Cancel = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        #endregion

        private void btnLan_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;
            if (!socket.ConnectServer())
            {
                socket.CreateServer();
                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            Listen();
                            break;
                        }
                        catch { }
                        
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();

            }
            else
            {
                Thread listenThread = new Thread(() =>
                {
                    Listen();
                });
                listenThread.IsBackground = true;
                listenThread.Start();

                socket.Send("Thông tin từ client");
            }

           
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
             if(string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Ethernet);
            }    
        }
        void Listen()
        {
            string data = (string)socket.Receive();
            MessageBox.Show(data);
        }
    }
}
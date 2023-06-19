using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro
{
    public class QuanLiBanCo
    {

        #region Properties
        private Panel banCo;
        public Panel BanCo { get => banCo; set => banCo = value; }
        private List<NguoiChoi> nguoichoi;
        public List<NguoiChoi> Nguoichoi
        {
            get { return nguoichoi; }
            set { nguoichoi = value; }
        }
        private int nguoichoihientai;
        public int NguoiChoiHienTai
        {
            get { return nguoichoihientai; }
            set { nguoichoihientai = value; }
        }
        private TextBox tenNguoiChoi;
        public TextBox TenNguoiChoi
        {
            get { return tenNguoiChoi; }
            set { tenNguoiChoi = value; }
        }
        private PictureBox luotChoi;
        public PictureBox LuotChoi
        {
            get { return luotChoi; }
            set { luotChoi = value; }
        }

        public List<List<Button>> Matran
        {
            get { return matran; }
            set { matran = value; }

        }

        private List<List<Button>> matran;
        private event EventHandler nguoiChoiDaClick;
        public event EventHandler  NguoiChoiDaClick
        {
            add
            {
               nguoiChoiDaClick += value;
            }
            remove
            {
               nguoiChoiDaClick -= value;
            }
        }
        private event EventHandler endGame;
        public event EventHandler EndGame
        {
            add
            {
               endGame += value;
            }
            remove
            {
                endGame -= value;
            }
        }

        private Stack<ThongTInNguoiChoi> thoigiannguoichoithuc;
        public Stack<ThongTInNguoiChoi> ThoiGianNguoiChoiThuc
        {
            get { return thoigiannguoichoithuc; }
            set { thoigiannguoichoithuc = value; }
        }
        #endregion
        #region Initialize
        public QuanLiBanCo(Panel banCo, TextBox tenNguoiChoi, PictureBox LuotChoi)
        {
            this.BanCo = banCo;
            this.TenNguoiChoi = tenNguoiChoi;
            this.LuotChoi = LuotChoi;
            this.Nguoichoi = new List<NguoiChoi>()
            {
                new NguoiChoi("NguoiChoi1", Image.FromFile(Application.StartupPath+"\\Resources\\x.jpg")),
                new NguoiChoi("NguoiChoi2", Image.FromFile(Application.StartupPath + "\\Resources\\o.jpg"))
            };
        }
        #endregion
        #region Methods
        public void VeBanCo()
        {
            BanCo.Enabled = true;
            BanCo.Controls.Clear();
            ThoiGianNguoiChoiThuc = new Stack<ThongTInNguoiChoi>();
            NguoiChoiHienTai = 0;
            DoiNguoiChoi(); // vẽ xong bàn cờ thì đổi người chơi
            matran = new List<List<Button>>();
            Button old_btn = new Button() { Width = 0, Location = new Point(0, 0) };// Do kích thước ban đầu lớn nên set chiều ngang = 0 và vị trí là 0,0
            for (int i = 0; i < hangso.BANCO_ChieuNgang; i++)
            {
                Matran.Add(new List<Button>());
                for (int j = 0; j < hangso.BANCO_ChieuDoc; j++)
                {
                    Button btn = new Button()
                    {
                        Width = hangso.CO_ChieuNgang,
                        Height = hangso.CO_ChieuDoc,
                        Location = new Point(old_btn.Location.X + hangso.CO_ChieuNgang, old_btn.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString() // xác định mình đang ở hàng nào 
                    };
                    btn.Click += btn_Click;
                    BanCo.Controls.Add(btn);
                    Matran[i].Add(btn); // thêm button vào ma trận 
                    old_btn = btn;
                }
                old_btn.Location = new Point(0, old_btn.Location.Y + hangso.CO_ChieuDoc);
                old_btn.Width = 0;
                old_btn.Height = 0;
            }
        }
        private void btn_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null) { return; } // không cho đè lên icon đã đc đánh
            DanhDau(btn);
            
            
            ThoiGianNguoiChoiThuc.Push(new ThongTInNguoiChoi(LayToaDo(btn), NguoiChoiHienTai));
            NguoiChoiHienTai = NguoiChoiHienTai == 1 ? 0 : 1; // đổ người chơi

            DoiNguoiChoi();
            if (nguoiChoiDaClick != null) { nguoiChoiDaClick(this, new EventArgs()); }
            
            if (GameDaKetThucHayChua(btn))
            {
                KetThucGame();
            }
            
        }
        public bool Undo()
        {
            if(ThoiGianNguoiChoiThuc.Count<=0) return false; // nếu không còn nước nào để undo
            ThongTInNguoiChoi DiemCu = ThoiGianNguoiChoiThuc.Pop();
            Button btn = Matran[DiemCu.Point.Y][DiemCu.Point.X];
            btn.BackgroundImage = null;
            
            if(ThoiGianNguoiChoiThuc.Count <= 0)
            {
                NguoiChoiHienTai = 0;
            }
            else
            {
                DiemCu = ThoiGianNguoiChoiThuc.Peek();
                NguoiChoiHienTai = DiemCu.CurentPlayer == 1 ? 0 : 1;
            }
            
            DoiNguoiChoi();
            return true;
        }
        public void KetThucGame()
        {
            if ( endGame  != null)
            {
                endGame(this, new EventArgs());
            }    
                
        }
        private bool GameDaKetThucHayChua(Button btn)
        {
            return GameDaKetThucHayChua_HangNgang(btn) || GameDaKetThucHayChua_HangDoc(btn) || GameDaKetThucHayChua_HangCheoChinh(btn) || GameDaKetThucHayChua_HangCheoPhu(btn) ;
        }
        private Point LayToaDo(Button btn)
        {
            Point p = new Point();

            int doc = Convert.ToInt32(btn.Tag);
            int ngang = Matran[doc].IndexOf(btn);
            p = new Point(ngang, doc);
            return p;
        }
        private bool GameDaKetThucHayChua_HangNgang(Button btn)
        {
            Point p = LayToaDo(btn);
            int DemBenTrai = 0;
            for (int i = p.X; i >=0; i--)
            {
                if (Matran[p.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    DemBenTrai++;
                }
                else { break; }
            }
            int DemBenPhai = 0;
            for (int i = p.X+1; i < hangso.BANCO_ChieuNgang;i++)
            {
                if (Matran[p.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    DemBenPhai++;
                }
                else { break; }
            }
            return DemBenPhai + DemBenTrai == 5;
        }
        private bool GameDaKetThucHayChua_HangDoc(Button btn)
        {
            Point p = LayToaDo(btn);
            int DemPhiaTren = 0;
            for (int i = p.Y; i >= 0; i--)
            {
                if (Matran[i][p.X].BackgroundImage == btn.BackgroundImage)
                {
                    DemPhiaTren++;
                }
                else { break; }
            }
            int DemPhiaDuoi = 0;
            for (int i = p.Y + 1; i < hangso.BANCO_ChieuDoc;i++)
            {
                if (Matran[i][p.X].BackgroundImage == btn.BackgroundImage)
                {
                    DemPhiaDuoi++;
                }
                else { break; }
            }
            return DemPhiaDuoi + DemPhiaTren == 5;
        }
        private bool GameDaKetThucHayChua_HangCheoChinh(Button btn)//Chéo sang phải
        {
            Point p = LayToaDo(btn);
            int DemPhiaTren = 0;
            for (int i = 0; i <= p.X; i++)
            {
                if(p.X - i < 0 || p.Y - i < 0)
                {
                    break;
                }    
                if (Matran[p.Y - i][p.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    DemPhiaTren++;
                }
                else { break; }
            }
            int DemPhiaDuoi = 0;
            for (int i = 1; i <= hangso.BANCO_ChieuNgang- p.X; i++)
            {
                if (p.Y + i >= hangso.BANCO_ChieuDoc || p.X + i >= hangso.BANCO_ChieuNgang)
                {
                    break;
                }    
                if (Matran[p.Y + i][p.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    DemPhiaDuoi++;
                }
                else { break; }
            }
            return DemPhiaDuoi + DemPhiaTren == 5;
        }
        private bool GameDaKetThucHayChua_HangCheoPhu(Button btn)
        {
            Point p = LayToaDo(btn);
            int DemPhiaTren = 0;
            for (int i = 0; i <= p.X; i++)
            {
                if (p.X + i > hangso.BANCO_ChieuNgang || p.Y - i < 0)
                {
                    break;
                }
                if (Matran[p.Y - i][p.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    DemPhiaTren++;
                }
                else { break; }
            }
            int DemPhiaDuoi = 0;
            for (int i = 1; i <= hangso.BANCO_ChieuNgang - p.X; i++)
            {
                if (p.Y + i >= hangso.BANCO_ChieuDoc || p.X - i < 0 )
                {
                    break;
                }
                if (Matran[p.Y + i][p.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    DemPhiaDuoi++;
                }
                else { break; }
            }
            return DemPhiaDuoi + DemPhiaTren == 5;
        }
        private void DanhDau(Button btn)// Thêm hình vào button
        {
            btn.BackgroundImage = Nguoichoi[NguoiChoiHienTai].DanhDau;
        }
        private void DoiNguoiChoi() // đổi người chơi
        {
            TenNguoiChoi.Text = Nguoichoi[NguoiChoiHienTai].TenNguoiChoi;
            LuotChoi.Image = Nguoichoi[NguoiChoiHienTai].DanhDau;
        }
        #endregion

    }
}

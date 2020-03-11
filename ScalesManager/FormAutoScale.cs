using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using log4net;
using log4net.Config;
using openalprnet;
using ScalesManager.Bussiness;
using ScalesManager.Component;
using ScalesManager.Controller;
using ScalesManager.DataLayer;
using ScalesManager.Reports;

namespace ScalesManager
{
    public partial class FormAutoScale : Office2007Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FormAutoScale));
        bool isAutoScale = false;
        bool isManualScaleDone = false;

        // camera
        public static Camera camTruoc, camSau, camToanCanh, camTruoc01;

        PhieuCanCtrl _PhieuCanCtrl = new PhieuCanCtrl();
        LoaiHangCtrl m_loaiHangCtrl = new LoaiHangCtrl();
        QuyDinh quyDinh = new QuyDinh();

        //cau hinh can
        CauHinhCanCtrl cauHinhCanCtrl = new CauHinhCanCtrl();
        CauHinhCanInfo cauHinhCanInfo = new CauHinhCanInfo();

        DateTime today = DateTime.Now;
        decimal KLXe = 0;
        decimal KLMax = 0;
        bool luu = true;
        int timespan = 0;
        DateTime tgluu = DateTime.Now;

        //can tu dong
        PhieuCanTDCtrl m_phieucanCtrl = new PhieuCanTDCtrl();

        public FormAutoScale()
        {
            InitializeComponent();

            btnSuaphieu.Enabled = false;
                        
            dtpNgayCan.Value = DateTime.Now;
            DataService.OpenConnection();
            Control.CheckForIllegalCrossThreadCalls = false;
            m_loaiHangCtrl.HienThiComboBox(cbLoaiHang);

            // Che do can tu dong
            if ("1".Equals(ConfigurationManager.AppSettings.Get("AUTO")))
            {
                isAutoScale = true;
                Thread autoScaleThread = new Thread(new ThreadStart(RunAutoScale));
                autoScaleThread.IsBackground = true;
                autoScaleThread.Start();
            }                
        }        

        private void FormAutoScale_Load(object sender, EventArgs e)
        {
            hienThiPhieuCan();            
        }

        private void hienThiPhieuCan()
        {
            // lay che do can
            string chedoCan = "";
            if (rbNhapkho.Checked)
                chedoCan = rbNhapkho.Text;
            else if (rbXuatkho.Checked)
                chedoCan = rbXuatkho.Text;
            else if (rbDichvu.Checked)
                chedoCan = rbDichvu.Text;
            else if (rbNoibo.Checked)
                chedoCan = rbNoibo.Text;

            DateTime ngayCan = dtpNgayCan.Value;
            if (ngayCan != null)
            {
                if (rdDsCanLan2.Checked == true)
                {
                    _PhieuCanCtrl.HienThi(dGVPhieuCan, bindingNavigatorPhieuCan, ngayCan, quyDinh.LAN1, txtTimBsx.Text, chedoCan);
                }
                else if (rdDsDaCan.Checked == true)
                {
                    _PhieuCanCtrl.HienThi(dGVPhieuCan, bindingNavigatorPhieuCan, ngayCan, quyDinh.LAN2, txtTimBsx.Text, chedoCan);
                }
                else
                    _PhieuCanCtrl.HienThi(dGVPhieuCan, bindingNavigatorPhieuCan, ngayCan, quyDinh.TATCA, txtTimBsx.Text, chedoCan);
            }           
        }

        private void rbNhapkho_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNhapkho.Checked)
                hienThiPhieuCan();
        }

        private void rbXuatkho_CheckedChanged(object sender, EventArgs e)
        {
            if (rbXuatkho.Checked)
                hienThiPhieuCan();
        }

        private void rbDichvu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDichvu.Checked)
                hienThiPhieuCan();
        }

        private void rbNoibo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoibo.Checked)
                hienThiPhieuCan();
        }       

        private async Task LayBienSo()
        {
            resetUI();

            // reset bien so
            Utilities.BienSoXe = null;

            Utilities.Cam1 = camTruoc.TakeSnapshot();
            Utilities.Cam2 = camTruoc01.TakeSnapshot();
            Utilities.Cam3 = camSau.TakeSnapshot();
            Utilities.Cam4 = camToanCanh.TakeSnapshot();

            // nhan dien cam truoc - nhan dien bien so chu nhat
            log.Info("Nhan dien bien so ngang");
            Recognizer recognizer = Recognizer.Instance;
            AlprPlateNet plate = recognizer.Recognize(Utilities.Cam1);
            if (plate != null)
            {
                // hien thi len phieu can                
                txtBienSoXe.Text = FormatBXS(plate.Characters);
            }
            else
            {
                // nhan dien cam truoc 01                
                plate = recognizer.Recognize(Utilities.Cam2);
                if (plate != null)
                    txtBienSoXe.Text = FormatBXS(plate.Characters);
                else
                {
                    // nhan dien cam sau
                    plate = recognizer.Recognize(Utilities.Cam3);
                    if (plate != null)
                        txtBienSoXe.Text = FormatBXS(plate.Characters);
                    //txtBienSoXe.Text = (plate == null) ? "Lấy biển số lỗi" : FormatBXS(plate.Characters);
                }

            }

            // nhan dien bien so vuong neu bien so hinh chu nhat khong nhan dien dc
            if (plate == null)
            {
                log.Info("Nhan dien bien so vuong");
                string plateNumber = await recognizer.RegconizeTwoLinePlate(Utilities.Cam1);
                if (plateNumber != null)
                    txtBienSoXe.Text = FormatBXS(plateNumber);
                else  // nhan dien cam2, neu cam1 NOT ok
                {
                    plateNumber = await recognizer.RegconizeTwoLinePlate(Utilities.Cam3);
                    if (plateNumber != null)
                        txtBienSoXe.Text = FormatBXS(plateNumber);
                    else
                        txtBienSoXe.Text = "Lấy biển số lỗi";
                }
            }

            // show bien so image
            pictureBoxBSXVao.Image = Utilities.BienSoXe;
        }

        private async void btnLayBienSo_Click(object sender, EventArgs e)
        {
            await LayBienSo();
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBienSoXe.Text))
            {
                MessageBox.Show(this, "Chưa lấy biển số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // neu lay bsx loi, van cho can bt
            if(txtBienSoXe.Text.Equals("Lấy biển số lỗi"))
            {
                txtKLTong.Text = string.Format("{0:#,0}", int.Parse(blKLCan.Text));
                txtGioCanTong.Text = DateTime.Now.ToString();
                return;
            }
           
            // load thong tin xe da luu csdl            
            XeCtrl xeCtrl = new XeCtrl();
            XeInfo xeInfo = xeCtrl.LayThongTinXe(txtBienSoXe.Text);
            if (xeInfo != null) //xe da luu csdl
            {
                txtKhachHang.Text = xeInfo.Khachhang;
                txtLaiXe.Text = xeInfo.TaiXe;
                txtKLTong.Text = string.Format("{0:#,0}", int.Parse(blKLCan.Text));
                txtKLBi.Text = string.Format("{0:#,0}", xeInfo.TrongLuong);
                txtKLHang.Text = string.Format("{0:#,0}", (int.Parse(blKLCan.Text) - xeInfo.TrongLuong));
                txtGioCanTong.Text = DateTime.Now.ToString();
                
                Utilities.XeDaCoTrongCSDL = true;
                Utilities.klXe = xeInfo.TrongLuong;
            }
            else // xe chua co trong csdl
            {    
                // tim phieu can theo bsx
                PhieuCanInfo phieucan = _PhieuCanCtrl.LayPhieuCanTheoBSX(txtBienSoXe.Text);
                // neu da co phieu can (da can lan 1)
                if (phieucan != null)
                {
                    txtMaPhieu.Text = phieucan.MaPhieu;
                    txtKhachHang.Text = phieucan.KhachHang;
                    txtLaiXe.Text = phieucan.LaiXe;
                    cbLoaiHang.Text = phieucan.LoaiHang;
                    txtDonGia.Text = phieucan.DonGia.ToString();

                    decimal klCanLan1 = phieucan.KLCanLan1;
                    decimal klCan = decimal.Parse(blKLCan.Text);
                    
                    if (klCan < klCanLan1) // da can tong, chua can bi
                    {
                        txtKLTong.Text = string.Format("{0:#,0}", klCanLan1);
                        txtKLBi.Text = string.Format("{0:#,0}", klCan);
                        txtKLHang.Text = string.Format("{0:#,0}", (klCanLan1 - klCan));
                        txtGioCanTong.Text = phieucan.NgayCanLan1.ToString();
                        txtGioCanBi.Text = DateTime.Now.ToString();                        
                    }
                    else // da can bi, chua can tong
                    {
                        txtKLTong.Text = string.Format("{0:#,0}", klCan);
                        txtKLBi.Text = string.Format("{0:#,0}", klCanLan1);
                        txtKLHang.Text = string.Format("{0:#,0}", (klCan - klCanLan1));
                        txtGioCanTong.Text = DateTime.Now.ToString();
                        txtGioCanBi.Text = phieucan.NgayCanLan1.ToString(); 
                    }
                    Utilities.klXe = decimal.Parse(txtKLBi.Text);
                }
                else // neu chua co phieu can
                {
                    txtKLTong.Text = string.Format("{0:#,0}", int.Parse(blKLCan.Text));
                    txtGioCanTong.Text = DateTime.Now.ToString();
                }
                
            }
            // thanh tien
            txtThanhTien.Text = (string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtKLHang.Text)) ? "" : (decimal.Parse(txtDonGia.Text) * decimal.Parse(txtKLHang.Text)).ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBienSoXe.Text))
            {
                //MessageBox.Show(this, "Chưa lấy biển số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Chua lay bien so, khong luu phieu");
                return;
            }            

            PhieuCanInfo phieuCanInfo = new PhieuCanInfo();           
            phieuCanInfo.BSX = txtBienSoXe.Text;
            phieuCanInfo.KhachHang = txtKhachHang.Text;
            phieuCanInfo.KieuCanLan1 = "Tự động";
            phieuCanInfo.LoaiHang = cbLoaiHang.Text;
            phieuCanInfo.NgayCanLan1 = DateTime.Now;
            phieuCanInfo.KLCanLan1 = string.IsNullOrWhiteSpace(txtKLTong.Text) ? 0 : decimal.Parse(txtKLTong.Text);
            phieuCanInfo.DonGia = string.IsNullOrWhiteSpace(txtDonGia.Text) ? 0 : decimal.Parse(txtDonGia.Text);
            phieuCanInfo.LaiXe = txtLaiXe.Text;
            phieuCanInfo.ChedoCan = getChedoCan();
            phieuCanInfo.KLCanLan2 = string.IsNullOrWhiteSpace(txtKLBi.Text) ? 0 : decimal.Parse(txtKLBi.Text); // trọng lượng xe
            phieuCanInfo.TenNhanVienCanLan2 = "Auto";
            phieuCanInfo.MaNhanVienCanLan2 = "Auto";

            //neu xe da co trong csdl
            if (Utilities.XeDaCoTrongCSDL)
                phieuCanInfo.BienSoXeRa = Utilities.BienSoXe;
            
            // kiem tra phieu da can lan 1?
            PhieuCanInfo phieucan = _PhieuCanCtrl.LayPhieuCanTheoBSX(txtBienSoXe.Text);
            if (phieucan != null)   //neu da co phieu can lan 1
            {
                phieuCanInfo.MaPhieu = phieucan.MaPhieu;
                phieuCanInfo.NgayCanLan1 = phieucan.NgayCanLan1;
                phieuCanInfo.NgayCanLan2 = DateTime.Now;
                phieuCanInfo.BienSoXeRa = Utilities.BienSoXe;   //ghi hinh bsx ra
            }

            _PhieuCanCtrl.LuuPhieuCanTuDong(phieuCanInfo);

            txtMaPhieu.Text = phieuCanInfo.MaPhieu;

            // update danh sach hom nay
            dtpNgayCan.Value = DateTime.Now;
            hienThiPhieuCan();

            // thong bao ve PLC            
            isManualScaleDone = true;

            // reset flag
            Utilities.XeDaCoTrongCSDL = false;

            // reset bien so
            Utilities.BienSoXe = null;
            Utilities.Cam1 = null;
            Utilities.Cam2 = null;
            Utilities.Cam3 = null;
            Utilities.Cam4 = null;
        }

        private string FormatBXS(string bsx)
        {
            if (string.IsNullOrEmpty(bsx))
                return bsx;
            // chen ki tu -
            bsx = bsx.Insert(3, "-");
            // neu bien 5 so, chen dau .
            if (bsx.Length == 9)
                bsx = bsx.Insert(7, ".");
            return bsx;
        }

        private void FormAutoScale_FormClosing(object sender, FormClosingEventArgs e)
        {
            isAutoScale = false;

            if (camTruoc != null)
                camTruoc.StopCapture();
            if (camTruoc01 != null)
                camTruoc01.StopCapture();
            if (camSau != null)
                camSau.StopCapture();
            if (camToanCanh != null)
                camToanCanh.StopCapture();
        }        

        private void dGVPhieuCan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSuaphieu.Enabled = true;

            if (dGVPhieuCan.DataSource == null)
                return;
            if (string.IsNullOrWhiteSpace(dGVPhieuCan.CurrentRow.Cells["MaPhieu"].Value.ToString()))
                return;

            PhieuCanInfo phieuCan = _PhieuCanCtrl.LayPhieuCan2(dGVPhieuCan.CurrentRow.Cells["MaPhieu"].Value.ToString());
            txtMaPhieu.Text = phieuCan.MaPhieu;
            txtKhachHang.Text = phieuCan.KhachHang;
            txtBienSoXe.Text = phieuCan.BSX;
            txtLaiXe.Text = phieuCan.LaiXe;
            cbLoaiHang.Text = phieuCan.LoaiHang;
            txtDonGia.Text = phieuCan.DonGia.ToString();
            txtThanhTien.Text = (phieuCan.DonGia > 0) ? ((phieuCan.DonGia * (phieuCan.KLCanLan1 - phieuCan.KLCanLan2)).ToString()) : "0";
            txtKLTong.Text = phieuCan.KLCanLan1.ToString("0,0.##");
            txtKLBi.Text = phieuCan.KLCanLan2.ToString("0,0.##");
            txtKLHang.Text = (phieuCan.KLCanLan1 - phieuCan.KLCanLan2).ToString("0,0.##");
            txtGioCanTong.Text = phieuCan.NgayCanLan1.ToString();
            txtGioCanBi.Text = phieuCan.NgayCanLan2.ToString();
            pictureBoxBSXVao.Image = phieuCan.BienSoXe;
            pictureBoxBSXRa.Image = phieuCan.BienSoXeRa;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            //reset UI
            resetUI();

            // reload phieu can
            hienThiPhieuCan();
        }

        private void resetUI()
        {
            txtMaPhieu.Text = "";
            txtKhachHang.Text = "";
            txtBienSoXe.Text = "";
            txtLaiXe.Text = "";
            //cbLoaiHang.Text = "";
            //txtDonGia.Text = "";
            txtThanhTien.Text = "";
            txtKLTong.Text = "";
            txtKLBi.Text = "";
            txtKLHang.Text = "";
            txtGioCanTong.Text = "";
            txtGioCanBi.Text = "";
            pictureBoxBSXVao.Image = null;
            pictureBoxBSXRa.Image = null;
            btnSuaphieu.Enabled = false;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Utilities.IN = false;
            //frmBaoCao _frmBaoCao = new frmBaoCao();
            FormPhieuCanA5 _frmBaoCao = new FormPhieuCanA5();
            _frmBaoCao._maphieu = txtMaPhieu.Text;
            _frmBaoCao.Show();
            PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
            phieuCanInfo = _PhieuCanCtrl.LaySoLanIn(txtMaPhieu.Text);
            decimal lanin = phieuCanInfo.LanIn;
            phieuCanInfo.LanIn = lanin + 1;
            phieuCanInfo.MaPhieu = txtMaPhieu.Text;
            _PhieuCanCtrl.LuuLanIn(phieuCanInfo);
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            Utilities.IN = true;
            //frmBaoCao _frmBaoCao = new frmBaoCao();
            FormPhieuCanA5 _frmBaoCao = new FormPhieuCanA5();
            _frmBaoCao._maphieu = txtMaPhieu.Text;
            _frmBaoCao.Show();
            PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
            phieuCanInfo = _PhieuCanCtrl.LaySoLanIn(txtMaPhieu.Text);
            decimal lanin = phieuCanInfo.LanIn;
            phieuCanInfo.LanIn = lanin + 1;
            phieuCanInfo.MaPhieu = txtMaPhieu.Text;
            _PhieuCanCtrl.LuuLanIn(phieuCanInfo);
        }

        private void FormAutoScale_Shown(object sender, EventArgs e)
        {
            // ket noi dau can
            setSerialPortCOM();
            Thread thread = new Thread(new ThreadStart(showWeightThread));
            thread.IsBackground = true;
            thread.Start();

            // xy ly camera            
            ProtectedPictureBox pictureBox1 = new ProtectedPictureBox();
            pictureBox1.Name = "cam1";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;            
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.camera;
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 1);
            camTruoc = new Camera(ConfigurationManager.AppSettings.Get("cam1"), pictureBox1); // HIKVISION Camera
            camTruoc.StartCapture();

            ProtectedPictureBox pictureBox2 = new ProtectedPictureBox();
            pictureBox2.Name = "cam2";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox2.Image = Properties.Resources.camera;
            tableLayoutPanel1.Controls.Add(pictureBox2, 1, 1);
            camTruoc01 = new Camera(ConfigurationManager.AppSettings.Get("cam2"), pictureBox2);
            camTruoc01.StartCapture();

            ProtectedPictureBox pictureBox3 = new ProtectedPictureBox();
            pictureBox3.Name = "cam3";
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox3.Image = Properties.Resources.camera;
            tableLayoutPanel1.Controls.Add(pictureBox3, 0, 3);
            camSau = new Camera(ConfigurationManager.AppSettings.Get("cam3"), pictureBox3);
            camSau.StartCapture();

            ProtectedPictureBox pictureBox4 = new ProtectedPictureBox();
            pictureBox4.Name = "cam4";
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox4.Image = Properties.Resources.camera;
            tableLayoutPanel1.Controls.Add(pictureBox4, 1, 3);
            camToanCanh = new Camera(ConfigurationManager.AppSettings.Get("cam4"), pictureBox4);
            camToanCanh.StartCapture();
        }

        private void btnTimkiemnhanh_Click(object sender, EventArgs e)
        {
            hienThiPhieuCan();
        }

        private String getChedoCan()
        {
            if (rbNhapkho.Checked)
                return rbNhapkho.Text;
            if (rbXuatkho.Checked)
                return rbXuatkho.Text;
            if (rbDichvu.Checked)
                return rbDichvu.Text;
            return rbNoibo.Text;
        }

        private void setSerialPortCOM()
        {
            cauHinhCanInfo = cauHinhCanCtrl.LayCauHinhCan();
            string portName = cauHinhCanInfo.COM;
            Utilities.KtuNgat = cauHinhCanInfo.KiTuNgat;
            int baudRate = Convert.ToInt32(cauHinhCanInfo.RAUDRATE);
            short dataBits = Convert.ToInt16(cauHinhCanInfo.DATABITS);
            StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), cauHinhCanInfo.STOPBIT);
            Handshake handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
            Parity parity = (Parity)Enum.Parse(typeof(Parity), cauHinhCanInfo.PARITY);
            Utilities.serialPortCOM = new SerialPortCOM(portName, baudRate, dataBits, stopBits, handshake, parity);
            Utilities.serialPortCOM.comPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceivedEventArgs);
            Utilities.serialPortCOM.openConnection();
        }

        public void showWeightThread()
        {
            while (true)
            {
                Thread.Sleep(300);
                Utilities.serialPortCOM.comPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceivedEventArgs);
            }

        }

        private void dGVPhieuCan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show("Nooix");
        }

        private void dGVPhieuCan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            XemLaiXe xemLaiXe = new XemLaiXe(txtMaPhieu.Text);
            xemLaiXe.Show(this);
        }

        private void btnSuaphieu_Click(object sender, EventArgs e)
        {
            if (btnSuaphieu.Text.Equals("Sửa phiếu"))
            {
                if (KtraQuyen_Update())
                {
                    //nếu admin mới sửa được khối lượng
                    if ("LND001".Equals(Utilities.NguoiDung.LoaiND.MaLoai))
                    {
                        txtKLTong.ReadOnly = false;
                        txtKLBi.ReadOnly = false;
                        txtKLHang.ReadOnly = false;
                    }                    
                    btnSuaphieu.Text = "Lưu phiếu";
                }
            }
            else
            {
                btnSuaphieu.Text = "Sửa phiếu";
                txtKLTong.ReadOnly = true;
                txtKLBi.ReadOnly = true;
                txtKLHang.ReadOnly = true;
                btnSuaphieu.Enabled = false;

                PhieuCanInfo phieuCanInfo = new PhieuCanInfo();

                phieuCanInfo.BSX = txtBienSoXe.Text;
                phieuCanInfo.MaPhieu = txtMaPhieu.Text;                
                phieuCanInfo.KhachHang = txtKhachHang.Text;        
                phieuCanInfo.KLCanLan1 = string.IsNullOrWhiteSpace(txtKLTong.Text) ? 0 : decimal.Parse(txtKLTong.Text);                
                phieuCanInfo.LaiXe = txtLaiXe.Text;                
                phieuCanInfo.KLCanLan2 = string.IsNullOrWhiteSpace(txtKLBi.Text) ? 0 : decimal.Parse(txtKLBi.Text); // trọng lượng xe

                new PhieuCanData().CapNhatPhieuCan(phieuCanInfo);
                MessageBox.Show(this, "Sửa phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void serialDataReceivedEventArgs(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                TimeSpan aInterval = new System.TimeSpan(0, 0, 0, 0, 300);

                // Thêm một khoảng thời gian.
                DateTime newTime = today.Add(aInterval);
                if (DateTime.Now.CompareTo(newTime) > 0)
                {
                    today = DateTime.Now;
                    SerialPort sp = (SerialPort)sender;
                    String outPut = sp.ReadExisting();
                    if (outPut != String.Empty)
                    {
                        outPut = outPut.Trim();
                        string[] arrayData = outPut.Split(char.Parse(Utilities.KtuNgat));
                        Decimal klCan = convertDataToWeight(arrayData, blKLCan.Text);

                        // reset kl can bi khi xe ra khoi can
                        if (klCan == 0)
                            Utilities.klXe = 0;

                        if (klCan > Utilities.TapChat)
                        {
                            // hien thi khoi luong sau khi tru tap chat                        
                            this.blKLCan.Invoke(new System.Action(() => this.blKLCan.Text = (klCan - Utilities.TapChat).ToString()));

                            // hien thi bang led
                            //sp.Write("@" + (klCan - Utilities.TapChat).ToString().PadLeft(8) + "F");                            
                        }
                        else
                        {
                            this.blKLCan.Invoke(new System.Action(() => this.blKLCan.Text = klCan.ToString()));
                            // hien thi bang led
                            //sp.Write("@" + klCan.ToString().PadLeft(8) + "F");
                        }

                        // hien thi led theo format A000000T000000G000000, tuong ung voi CanTong, CanBi va KlHang
                        if (Utilities.klXe == 0)
                            sp.Write("A" + klCan.ToString().PadLeft(6, '0') + "T000000G000000");
                        else
                            sp.Write("A" + klCan.ToString().PadLeft(6, '0') +
                                     "T" + Utilities.klXe.ToString().PadLeft(6, '0') +
                                     "G" + (klCan - Utilities.klXe).ToString().PadLeft(6, '0'));

                        if (decimal.Parse(blKLCan.Text) == KLXe)
                        {
                            if (luu == true)
                            {
                                TimeSpan timel = new System.TimeSpan(0, 0, 0, timespan, 0);
                                if ((DateTime.Now - tgluu) >= timel)
                                {
                                    if (KLXe > KLMax)
                                    {
                                        PhieuCanTDInfo phieuCanTDInfo = new PhieuCanTDInfo();
                                        phieuCanTDInfo.KLXe = KLXe;
                                        phieuCanTDInfo.NgayGio = DateTime.Now;
                                        m_phieucanCtrl.LuuPhieuCanLan1(phieuCanTDInfo);
                                        luu = false;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                        else
                        {
                            tgluu = DateTime.Now;
                            KLXe = decimal.Parse(blKLCan.Text);
                            luu = true;
                        }
                    }
                }
                aInterval = new System.TimeSpan(0, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error(ex.StackTrace);
                Utilities.serialPortCOM.closeConnection();
            }
        }

        private void btnXoaphieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
                return;
            if (KtraQuyen_Update())
            {
                if (MessageBoxEx.Show("Bạn có chắc chắn xóa phiếu này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _PhieuCanCtrl.XoaPhieuCan(txtMaPhieu.Text);
                    Utilities.frmMain.lbThongBao.Text = "Đã xóa.";

                    //reset UI
                    resetUI();
                    // reload phieu can
                    hienThiPhieuCan();
                }
            }
        }

        private Decimal convertDataToWeight(string[] arrayData, string lb)
        {
            cauHinhCanInfo = cauHinhCanCtrl.LayCauHinhCan();
            Decimal outputDecimal;
            if (lb != "")
            {
                if (decimal.Parse(lb) != 0)
                {
                    outputDecimal = decimal.Parse(lb);
                }
                else
                    outputDecimal = 0;
            }
            else
                outputDecimal = 0;
            if (arrayData == null || arrayData.Length == 0)
            {
                return outputDecimal;
            }
            for (int i = arrayData.Length - 1; i > 0; i--)
            {
                if (arrayData[i].Length > Convert.ToInt32(cauHinhCanInfo.DATALENGHT))
                {
                    outputDecimal = Decimal.Parse(arrayData[i].Substring(Convert.ToInt32(cauHinhCanInfo.SFROM), Convert.ToInt32(cauHinhCanInfo.STO)).Trim());
                    break;
                }
            }
            return outputDecimal;
        }

        private bool KtraQuyen_Update()
        {
            frmNhapMaPIN frmNhapMaPIN = new frmNhapMaPIN();
            frmNhapMaPIN.ShowDialog();
            if (!string.IsNullOrWhiteSpace(Utilities.MaPIN))
                return Utilities.MaPIN == Utilities.NguoiDung.PIN;
            return false;
        }

        private void RunAutoScale()
        {
            try
            {
                log.Info("Start running auto scale");

                string comName = ConfigurationManager.AppSettings.Get("COM");
                SerialPort serialPort = new SerialPort(comName, 9600, Parity.None, 8);

                serialPort.Open();
                string inputData = "";

                // doc du lieu com - nhan lenh tu PLC
                log.Info("Cho nhan lenh tu PLC");
                while (isAutoScale)
                {                   
                    inputData = serialPort.ReadExisting();

                    if (!string.IsNullOrEmpty(inputData))
                        log.Info("Du lieu nhan dc tu PLC: " + inputData);

                    // bat dau can tu dong
                    if ("Y1".Equals(inputData))
                    {
                        //reset UI
                        resetUI();

                        // lay bien so
                        log.Info("Bat dau lay bien so xe");
                        //btnLayBienSo.PerformClick();                        
                        var task = LayBienSo();
                        task.GetAwaiter().GetResult();

                        if (Utilities.BienSoXe == null)
                        {
                            serialPort.WriteLine("TLayBienSoLoi");
                            log.Error("Loi lay bien so xe");
                            //MessageBox.Show(this, "Lỗi lấy biển số xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        // lay bsx loi, van thuc hien can tu dong
                        try
                        {
                            // can
                            log.Info("Bat dau can xe");
                            btnCan.PerformClick();

                            // luu
                            log.Info("Luu phieu can");
                            btnLuu.PerformClick();
                            isManualScaleDone = false; //reset manual

                            // neu in phieu
                            if ("1".Equals(ConfigurationManager.AppSettings.Get("PRINT")))
                            {
                                log.Info("In phieu can");
                                btnIn.PerformClick();
                            }

                            // xuat thong bao ket thuc ra com
                            log.Info("Thong bao ve PLC");
                            serialPort.WriteLine("T" + blKLCan.Text.PadLeft(6, '0') + "X1");

                            log.Info("Ket thuc 1 lan can tu dong");
                        }
                        catch (Exception ex)
                        {
                            // thong bao loi va tiep tuc doi lenh can tu dong
                            log.Info("Thong bao ve PLC can tu dong loi: " + "TCanTuDongLoi");
                            serialPort.WriteLine("TCanTuDongLoi");
                            log.Error(ex.Message);
                            log.Error(ex.StackTrace);
                        }
                    }
                    else
                    {
                        if (isManualScaleDone) // thong bao ve PLC neu can bang tay xong
                        {
                            log.Info("Thong bao ve PLC sau khi can bang tay: " + "T" + blKLCan.Text.PadLeft(6, '0') + "X1");
                            serialPort.WriteLine("T" + blKLCan.Text.PadLeft(6, '0') + "X1");
                            isManualScaleDone = false;
                        }
                        else
                            serialPort.WriteLine("T" + blKLCan.Text.PadLeft(6, '0') + "X0");                        
                    }
                    // tam dung 1/4 giay
                    Thread.Sleep(250);

                }
                serialPort.Close();
                log.Info("Dong chuc nang can tu dong");
            }
            catch(Exception ex)
            {
                log.Error("Loi can tu dong");
                log.Error(ex.Message);
                log.Error(ex.StackTrace);                
                MessageBox.Show(this, "Lỗi cân tự động", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            
        }
    }
}
using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ScalesManager.Controller;
using ScalesManager.Component;
using DevComponents.DotNetBar;
using ScalesManager.Bussiness;
using ScalesManager.Reports;
using System.IO.Ports;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using System.Drawing.Imaging;
using openalprnet;
using System.Configuration;
using OpenCvSharp.Extensions;

namespace ScalesManager
{
    public partial class frmScalesManager : Office2007Form
    {
        #region Fields
        PhieuCanCtrl _PhieuCanCtrl = new PhieuCanCtrl();
        KhachHangCtrl m_KhachHangCtrl = new KhachHangCtrl();
        CauHinhCanCtrl cauHinhCanCtrl = new CauHinhCanCtrl();
        CauHinhCanInfo cauHinhCanInfo = new CauHinhCanInfo();
        LoaiHangCtrl m_loaiHangCtrl = new LoaiHangCtrl();
        PhieuCanTDCtrl m_phieucanCtrl = new PhieuCanTDCtrl();
        CauHinhCanTDInfo cauHinhCanTDInfo = new CauHinhCanTDInfo();
        CauHinhCanTDCtrl cauHinhCanTDCtrl = new CauHinhCanTDCtrl();
        frmMain frmMain = null;
        frmPhieuCan _frmPhieuCan = null;
        // lanCan1 = true: dang can lan 1, lanCan1 = false: dang can lan 2
        //bool flag_LanCan1 = true;
        bool luu = true;
        QuyDinh quyDinh = new QuyDinh();
        Random random = new Random();
        DateTime today = DateTime.Now;
        static string m_luugtrikl1 = "0";
        static string m_luugtrikl2 = "0";
        static DateTime tgluu = DateTime.Now;
        static decimal KLXe = 0;
        static decimal KLMax = 0;
        static int timespan = 0;

        // camera
        Camera camTruoc, camSau, camToanCanh;
        
        #endregion

        #region Constructor
        public frmScalesManager(frmMain _frmMain)
        {
            this.frmMain = _frmMain;
            InitializeComponent();
            dtpNgayCan.Value = DateTime.Now;
            DataService.OpenConnection();
            //Disable_ThongTin();
            setSerialPortCOM();
            Thread thread = new Thread(new ThreadStart(showWeightThread));
            thread.IsBackground = true;
            thread.Start();
            Control.CheckForIllegalCrossThreadCalls = false;

        }
        #endregion

        #region Load
        #endregion



        private void frmScalesManager_Load(object sender, EventArgs e)
        {
            hienThiPhieuCan();

            #region Do du lieu vo autocomplete
            //txtKhachHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            //m_KhachHangCtrl.HienThiAutoComplete(autoCompleteStringCollection, txtKhachHang.Text);
            //txtKhachHang.AutoCompleteCustomSource = autoCompleteStringCollection;
            #endregion

            #region hiện thị combobox loại hàng

            //m_loaiHangCtrl.HienThiDataGridViewComboBoxColumn(LoaiHang);
            //m_loaiHangCtrl.HienThiComboBox(cbLoaiHang);
            #endregion
            cauHinhCanTDInfo = cauHinhCanTDCtrl.LayCauHinhCan();
            KLMax = cauHinhCanTDInfo.KhoiLuong;
            timespan = cauHinhCanTDInfo.TimeSleep;
            ThongKe();



            // xy ly camera
            ProtectedPictureBox pictureBoxTruoc = new ProtectedPictureBox();
            pictureBoxTruoc.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTruoc.Size = new System.Drawing.Size(282, 235);
            tableLayoutPanel1.Controls.Add(pictureBoxTruoc, 0, 1);
            camTruoc = new Camera(ConfigurationManager.AppSettings.Get("cam1"), pictureBoxTruoc); // HIKVISION Camera
            camTruoc.StartCapture();

            ProtectedPictureBox pictureBoxSau = new ProtectedPictureBox();
            pictureBoxSau.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSau.Size = new System.Drawing.Size(282, 235);
            tableLayoutPanel1.Controls.Add(pictureBoxSau, 1, 1);
            camSau = new Camera(ConfigurationManager.AppSettings.Get("cam2"), pictureBoxSau);
            camSau.StartCapture();

            ProtectedPictureBox pictureBoxToanCanh = new ProtectedPictureBox();
            pictureBoxToanCanh.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxToanCanh.Size = new System.Drawing.Size(282, 235);
            tableLayoutPanel1.Controls.Add(pictureBoxToanCanh, 2, 1);
            camToanCanh = new Camera(ConfigurationManager.AppSettings.Get("cam3"), pictureBoxToanCanh);
            camToanCanh.StartCapture();
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
            Utilities.serialPortCOM.openConnection(frmMain);
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

                        if(klCan > Utilities.TapChat)
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
                                     "G" + (klCan-Utilities.klXe).ToString().PadLeft(6, '0'));                       

                        if (decimal.Parse(blKLCan.Text) == KLXe)
                        {
                            if(luu == true)
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
            catch (Exception)
            {
                Utilities.serialPortCOM.closeConnection(frmMain);
            }
        }
        public void showWeightThread()
        {
            while (1 > 0)
            {
                Thread.Sleep(300);
                Utilities.serialPortCOM.comPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceivedEventArgs);
            }

        }
        public Decimal convertDataToWeight(string[] arrayData, string lb)
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

        private void dGVPhieuCan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        public void hienThiPhieuCan()
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
            if (dGVPhieuCan.RowCount == 0)
            {
                btnXuatExcel.Enabled = false;
            }
            else
            {
                btnXuatExcel.Enabled = true;
            }

        }

        
        void ThongKe()
        {
            #region Thong ke
            string fm = "dd/MM/yyyy";
            lbNgayCan.Text = DateTime.Now.ToString(fm);
            lbSLCanLan1.Text = _PhieuCanCtrl.DemPhieuCanLan1().ToString();
            lbSLCanLan2.Text = _PhieuCanCtrl.DemPhieuCanLan2().ToString();
            lbChoCan.Text = (int.Parse(lbSLCanLan1.Text) - int.Parse(lbSLCanLan2.Text)).ToString();
            #endregion
        }       
                

        #region Kiem tra va Bat loi        
        #endregion     

       

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            hienThiPhieuCan();
        }
            
      
        private void dGVPhieuCan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow;
                numrow = e.RowIndex;
                Utilities.PhieuCan = _PhieuCanCtrl.LayPhieuCan2(dGVPhieuCan.Rows[numrow].Cells[0].Value.ToString());
                Utilities.KLCan = blKLCan.Text;
                frmPhieuCan frmPhieuCan = new frmPhieuCan(this);
                frmPhieuCan.ShowDialog();
            }
            catch
            {
                Utilities.frmMain.lbThongBao.Text = "Lỗi";
            }            
        }
        
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {                      
            Utilities.KLCan = blKLCan.Text;
            _frmPhieuCan = new frmPhieuCan(this);

            // reset BSX 
            Utilities.BienSoXe = null;

            new Thread(new ThreadStart(LayBienSoXe)).Start();

            _frmPhieuCan.ShowDialog();            
        }

        private void LayBienSoXe()
        {
            Utilities.frmMain.lbThongBao.Text = "";

            Utilities.Cam1 = camTruoc.TakeSnapshot();
            Utilities.Cam2 = camSau.TakeSnapshot();
            Utilities.Cam3 = camToanCanh.TakeSnapshot();

            // nhan dien cam truoc
            Recognizer recognizer = Recognizer.Instance;
            AlprPlateNet plate = recognizer.Recognize(Utilities.Cam1);
            if (plate != null)
            {
                // hien thi len phieu can                
                _frmPhieuCan.TxtBSX.Text = FormatBXS(plate.Characters);
            }
            else
            {
                // nhan dien cam sau - neu cam truoc ko dc
                plate = recognizer.Recognize(Utilities.Cam2);
                _frmPhieuCan.TxtBSX.Text = (plate == null) ? "Lấy biển số lỗi" : FormatBXS(plate.Characters);
            }        

            // load cac thong tin liên quan nếu nhận diện được
            if (plate != null)
            {
                XeCtrl xeCtrl = new XeCtrl();
                XeInfo xeInfo = xeCtrl.LayThongTinXe(FormatBXS(plate.Characters));
                if (xeInfo != null)
                {
                    _frmPhieuCan.TxtKhachHang.Text = xeInfo.Khachhang;
                    _frmPhieuCan.TxtTenLaiXe.Text = xeInfo.TaiXe;
                    _frmPhieuCan.TxtKLCanLan2.Text = xeInfo.TrongLuong.ToString();
                    _frmPhieuCan.TxtKLHang.Text = (int.Parse(blKLCan.Text) - xeInfo.TrongLuong).ToString();
                    Utilities.XeDaCoTrongCSDL = true;
                    Utilities.klXe = xeInfo.TrongLuong;
                }
                else
                {
                    frmMain.lbThongBao.Text = "Xe này chưa có trong cơ sở dữ liệu";
                }                
            }
        }

        private string FormatBXS(string bsx)
        {
            if (string.IsNullOrEmpty(bsx))
                return bsx;            
            // chen ki tu -
            bsx = bsx.Insert(3, "-");
            // neu bien 5 so, chen dau .
            if(bsx.Length == 9)              
                bsx = bsx.Insert(7, ".");
            return bsx;          
        }
      

        #region BindingNavigatorItems
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dGVPhieuCan.RowCount == 0)
                bindingNavigatorPhieuCan.Enabled = false;

            else if (MessageBoxEx.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigatorPhieuCan.BindingSource.RemoveCurrent();
                if (dGVPhieuCan.RowCount == 0)
                {
                    btnXuatExcel.Enabled = false;
                }
                else
                {
                    btnXuatExcel.Enabled = true;
                }
            }
        }

        public Boolean KiemTraTruocKhiLuu(String cellString)
        {
            foreach (DataGridViewRow row in dGVPhieuCan.Rows)
            {
                if (row.Cells[cellString].Value != null)
                {
                    String str = row.Cells[cellString].Value.ToString();
                    if (str == "")
                    {
                        Utilities.frmMain.lbThongBao.Text = "Thông tin phiếu cân không hợp lệ.";
                        return false;
                    }
                }
            }
            return true;
        }

        private bool KtraQuyen_Update()
        {
            if (Utilities.NguoiDung.LoaiND.MaLoai.ToString() == "LND001")
                return true;
            else
            {
                frmNhapMaPIN frmNhapMaPIN = new frmNhapMaPIN();
                frmNhapMaPIN.ShowDialog();
                if (Utilities.MaPIN != "" || Utilities.MaPIN != null)
                    if (Utilities.MaPIN == Utilities.NguoiDung.PIN.ToString())
                        return true;
                    else return false;
                else return false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KtraQuyen_Update() == true)
            {
                PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
                try
                {
                    if (KiemTraTruocKhiLuu("MaPhieu") == true &&
                  KiemTraTruocKhiLuu("BSX") == true &&
                  KiemTraTruocKhiLuu("KhachHang") == true &&
                  KiemTraTruocKhiLuu("LoaiHang") == true &&
                  KiemTraTruocKhiLuu("KLCanLan1") == true &&
                  KiemTraTruocKhiLuu("KieuCanLan1") == true &&
                  KiemTraTruocKhiLuu("NgayCanLan1") == true &&
                  KiemTraTruocKhiLuu("NVCanLan1") == true &&
                  KiemTraTruocKhiLuu("LaiXe") == true)
                    {
                        bindingNavigatorPositionItem.Focus();
                        _PhieuCanCtrl.LuuPhieuCan();
                    }
                    Utilities.frmMain.lbThongBao.Text = "Lưu thành công.";
                }
                catch
                {
                    Utilities.frmMain.lbThongBao.Text = "Lỗi.";
                }
            }
            else
            {
                Utilities.frmMain.lbThongBao.Text = "Lỗi! Sai mã PIN";
            }
        }

        #endregion
        #region xuất ra excel

        private void xuatraexcel(DataGridView dgvphieucan)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;

            //lấy tiêu đề cột
            for (int i = 1; i < dgvphieucan.Columns.Count + 1; i++)
            {
                Microsoft.Office.Interop.Excel.Range formatRange;
                formatRange = obj.get_Range("a1");
                formatRange.EntireRow.Font.Bold = true;
                obj.Cells[1, i] = "Bold";
                obj.Cells[1, i] = dgvphieucan.Columns[i - 1].HeaderText;
            }
            //lấy giá trị trong cột

            for (int i = 0; i < dgvphieucan.Rows.Count; i++)
                for (int j = 0; j < dgvphieucan.Columns.Count; j++)
                    if (dgvphieucan.Rows[i].Cells[j].Value != null)
                        if (i == 1)
                        {
                            Microsoft.Office.Interop.Excel.Range formatRange;
                            formatRange = obj.get_Range("a" + (j + 2).ToString());
                            formatRange.NumberFormat = "#######";
                            obj.Cells[i + 2, j + 1] = dgvphieucan.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            obj.Cells[i + 2, j + 1] = dgvphieucan.Rows[i].Cells[j].Value.ToString();
                        }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel file|*.xlsx";
            saveFileDialog1.Title = "Chọn thư mục lưu";
            saveFileDialog1.ShowDialog();
            obj.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
            obj.ActiveWorkbook.Saved = true;
            Utilities.frmMain.lbThongBao.Text = "Lưu thành công";

        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            xuatraexcel(dGVPhieuCan);
        }
        #endregion

        private void dGVPhieuCan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow = e.RowIndex;
                if (dGVPhieuCan.Rows[numrow].Cells[6].Value.ToString() != "")
                {
                    if (decimal.Parse(dGVPhieuCan.Rows[numrow].Cells[6].Value.ToString()) > decimal.Parse(dGVPhieuCan.Rows[numrow].Cells[5].Value.ToString())
                        || int.Parse(dGVPhieuCan.Rows[numrow].Cells[6].Value.ToString()) < 0)
                    {
                        dGVPhieuCan.Rows[numrow].Cells[6].Value = m_luugtrikl2;
                    }
                }
            }
            catch
            {
            }
            try
            {
                int numrow = e.RowIndex;
                if (dGVPhieuCan.Rows[numrow].Cells[5].Value.ToString() != "")
                {
                    if (decimal.Parse(dGVPhieuCan.Rows[numrow].Cells[5].Value.ToString()) < decimal.Parse(dGVPhieuCan.Rows[numrow].Cells[6].Value.ToString())
                        || decimal.Parse(dGVPhieuCan.Rows[numrow].Cells[5].Value.ToString()) > 999999
                        || int.Parse(dGVPhieuCan.Rows[numrow].Cells[5].Value.ToString()) < 0)
                    {
                        dGVPhieuCan.Rows[numrow].Cells[5].Value = m_luugtrikl1;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtKLCanLan1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtKLCanLan2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenLaiXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenLaiXe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTapChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cbKieuCan_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbKieuCan_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbKieuCan_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            Utilities.KLCan = blKLCan.Text;
            _frmPhieuCan = new frmPhieuCan(this);
            _frmPhieuCan.ShowDialog();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void btnCanBi_Click(object sender, EventArgs e)
        {
            Utilities.KLCan = blKLCan.Text;
            Utilities.LoaiCan = "CanBi";
            _frmPhieuCan = new frmPhieuCan(this);
            _frmPhieuCan.ShowDialog();
        }

        private void btnCanTong_Click(object sender, EventArgs e)
        {
            Utilities.KLCan = blKLCan.Text;
            Utilities.LoaiCan = "CanTong";
            _frmPhieuCan = new frmPhieuCan(this);
            _frmPhieuCan.ShowDialog();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.F5)) //phím nóng quy định
            {
                // do smt
                frmTapChat frmTapChat = new frmTapChat();
                frmTapChat.ShowDialog();
                return true;
            }
            else
            {
                return false;
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

        public String getChedoCan()
        {
            if (rbNhapkho.Checked)
                return rbNhapkho.Text;
            if (rbXuatkho.Checked)
                return rbXuatkho.Text;
            if (rbDichvu.Checked)
                return rbDichvu.Text;
            return rbNoibo.Text;
        }

        private void frmScalesManager_Closing(object sender, FormClosingEventArgs e)
        {
            if (camTruoc != null)
                camTruoc.StopCapture();
            if (camSau != null)
                camSau.StopCapture();
            if (camToanCanh != null)
                camToanCanh.StopCapture();
        }
    }
}
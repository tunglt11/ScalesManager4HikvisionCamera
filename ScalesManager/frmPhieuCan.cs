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

namespace ScalesManager
{
    public partial class frmPhieuCan : Office2007Form
    {
        #region Fields
        PhieuCanCtrl _PhieuCanCtrl = new PhieuCanCtrl();
        // lanCan1 = true: dang can lan 1, lanCan1 = false: dang can lan 2
        QuyDinh quyDinh = new QuyDinh();
        Random random = new Random();
        LoaiHangCtrl m_loaiHangCtrl = new LoaiHangCtrl();
        KhachHangCtrl m_khachHangCtrl = new KhachHangCtrl();
        //bool flag_LanCan1 = true;
        frmScalesManager frmScalesManager = null;
        #endregion

        private void frmPhieuCan_Load(object sender, EventArgs e)
        {
            #region Do du lieu vo autocomplete
            txtKhachHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            m_khachHangCtrl.HienThiAutoComplete(autoCompleteStringCollection, txtKhachHang.Text);
            txtKhachHang.AutoCompleteCustomSource = autoCompleteStringCollection;
            #endregion

            //#region hiện thị combobox loại hàng
            //m_loaiHangCtrl.HienThiComboBox(cbLoaiHang);
            //#endregion
        }

        #region Constructor
        public frmPhieuCan(frmScalesManager _frmScalesManager)
        {
            InitializeComponent();
            DataService.OpenConnection();
            frmScalesManager = _frmScalesManager;
            btnLuu.Hide();
            btnLuuCanLan1.Hide();
            btnLuuCanLan2.Hide();
            btnLuuCanBi.Hide();
            btnLuuCanTong.Hide();
            btnCanTong.Hide();
            btnCanLan2.Hide();
            //load combobox loai hang
            m_loaiHangCtrl.HienThiComboBox(cbLoaiHang);
   
            if (Utilities.PhieuCan != null)
            {
                //da can 2 lan
                if (!string.IsNullOrEmpty(Utilities.PhieuCan.TenNhanVienCanLan2) &&
                    !string.IsNullOrEmpty(Utilities.PhieuCan.TenNhanVienCanLan1))
                {
                    btnCanLan1.Enabled = false;
                    btnCanLan2.Enabled = false;
                    btnCanBi.Enabled = false;
                    btnCanTong.Enabled = false;

                    txtMaPhieu.Text = Utilities.PhieuCan.MaPhieu;
                    txtKhachHang.Text = Utilities.PhieuCan.KhachHang;
                    txtBSX.Text = Utilities.PhieuCan.BSX;
                    txtKLCanLan1.Text = Utilities.PhieuCan.KLCanLan1.ToString();
                    txtKLCanLan2.Text = Utilities.PhieuCan.KLCanLan2.ToString();
                    cbKieuCan.Text = Utilities.PhieuCan.KieuCanLan1;
                    txtTenLaiXe.Text = Utilities.PhieuCan.LaiXe;
                    cbLoaiHang.Text = Utilities.PhieuCan.LoaiHang;
                    txtGioVaoCan.Text = Utilities.PhieuCan.NgayCanLan1.ToString();
                    txtGioRaCan.Text = Utilities.PhieuCan.NgayCanLan2.ToString();
                    txtDonGia.Text = Utilities.PhieuCan.DonGia.ToString();
                    btnSua.Enabled = true;
                    cbKieuCan.Enabled = false;
                    Disable_ThongTin();
                }
                //da can lan 1 chua can lan 2
                else if(!string.IsNullOrEmpty(Utilities.PhieuCan.TenNhanVienCanLan1) 
                    && string.IsNullOrEmpty(Utilities.PhieuCan.TenNhanVienCanLan2))
                {
                    txtMaPhieu.Text = Utilities.PhieuCan.MaPhieu;
                    txtKhachHang.Text = Utilities.PhieuCan.KhachHang;
                    txtBSX.Text = Utilities.PhieuCan.BSX;
                    txtKLCanLan1.Text = Utilities.PhieuCan.KLCanLan1.ToString();
                    txtKLCanLan2.Text = "0";
                    cbKieuCan.Text = Utilities.PhieuCan.KieuCanLan1;
                    txtTenLaiXe.Text = Utilities.PhieuCan.LaiXe;
                    cbLoaiHang.Text = Utilities.PhieuCan.LoaiHang;
                    txtGioVaoCan.Text = Utilities.PhieuCan.NgayCanLan1.ToString();
                    txtDonGia.Text = Utilities.PhieuCan.DonGia.ToString();

                    btnCanLan1.Enabled = false;
                    btnCanTong.Enabled = false;
                    btnCanLan2.Enabled = true;
                    btnCanLan2.Show();
                    btnCanBi.Enabled = false;
                    btnCanBi.Hide();
                    Disable_ThongTin();
                    cbKieuCan.Enabled = true;
                    btnSua.Enabled = true;
                }
                //chua can lan 1 da can lan 2
                else if(string.IsNullOrEmpty(Utilities.PhieuCan.TenNhanVienCanLan1) 
                    && !string.IsNullOrEmpty(Utilities.PhieuCan.TenNhanVienCanLan2))
                {
                    btnCanLan1.Enabled = false;
                    btnCanLan1.Hide();
                    btnCanLan2.Enabled = false;
                    btnCanBi.Enabled = false;
                    btnCanTong.Enabled = true;
                    btnCanTong.Show();
                    txtKLCanLan1.Text = "0";
                    txtMaPhieu.Text = Utilities.PhieuCan.MaPhieu;
                    txtKhachHang.Text = Utilities.PhieuCan.KhachHang;
                    txtBSX.Text = Utilities.PhieuCan.BSX;
                    txtKLCanLan2.Text = Utilities.PhieuCan.KLCanLan2.ToString();
                    cbKieuCan.Text = Utilities.PhieuCan.KieuCanLan2;
                    txtTenLaiXe.Text = Utilities.PhieuCan.LaiXe;
                    cbLoaiHang.Text = Utilities.PhieuCan.LoaiHang;
                    txtGioRaCan.Text = Utilities.PhieuCan.NgayCanLan2.ToString();
                    txtDonGia.Text = Utilities.PhieuCan.DonGia.ToString();
                    btnSua.Enabled = true;
                    cbKieuCan.Enabled = false;
                    Disable_ThongTin();
                }
            }
            else
                  {
                    cbKieuCan.SelectedValue = "1";
                    txtMaPhieu.Text = "";
                    txtKLCanLan1.Text = "0";
                    txtKLCanLan2.Text = "0";
                    txtBSX.Text = "";
                    txtKhachHang.Text = "";
                    cbKieuCan.SelectedIndex = 0;
                    txtDonGia.Text = "0";
                    cbKieuCan.Enabled = true;
                    btnSua.Enabled = false;
                    btnIn.Enabled = false;
                    btnCanLan2.Enabled = false;
                    btnXoa.Enabled = false;
                }
            TinhToan(txtKLCanLan1.Text, txtKLCanLan2.Text, txtDonGia.Text);

        }
        #endregion

        #region TinhToan
        void TinhToan(string kl1, string kl2, string dongia)
        {
            decimal _kl1 = decimal.Parse(kl1);
            decimal _kl2 = decimal.Parse(kl2);           
            decimal _dongia = decimal.Parse(dongia);
            txtKLHang.Text = (_kl1 - _kl2).ToString();
            txtThanhTien.Text = (((decimal)(_kl1 - _kl2) * _dongia).ToString());
        }
        #endregion


        void Disable_ThongTin()
        {
            txtKhachHang.Enabled = false;
            txtBSX.Enabled = false;
            txtKLCanLan1.Enabled = false;
            txtKLCanLan2.Enabled = false;
            cbKieuCan.Enabled = false;
            txtTenLaiXe.Enabled = false;
            cbLoaiHang.Enabled = false;
            txtGioRaCan.Enabled = false;
            txtGioVaoCan.Enabled = false;
            txtDonGia.Enabled = false;
        }

        void Enabled_ThongTin()
        {
            txtKhachHang.Enabled = true;
            txtBSX.Enabled = true;
            cbKieuCan.Enabled = true;
            txtTenLaiXe.Enabled = true;
            cbLoaiHang.Enabled = true;
            txtDonGia.Enabled = true;
        }

        private void btnCanLan1_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu
            if (KtraDuLieuCan() == true)
            {
                //Kiểm tra kiểu cân
                if (cbKieuCan.SelectedItem.ToString() != "")
                {
                    btnCanLan1.Enabled = false;
                    btnCanLan1.Hide();
                }
                //flag_LanCan1 = true;
                string _kieucan = cbKieuCan.SelectedItem.ToString().Replace('{', ' ');
                _kieucan.Replace('}', ' ');
                if (_kieucan.Trim() != "")
                {
                    if (_kieucan.Trim() == "Nhập bằng tay")
                    {
                        if (txtKLCanLan1.Text == "0")
                        {
                            Utilities.frmMain.lbThongBao.Text = "Nhập thiếu khối lượng.";
                            btnCanLan1.Enabled = true;
                        }
                        else
                        {
                            Disable_ThongTin();
                            txtKLCanLan1.Enabled = false;
                            txtKLCanLan2.Enabled = false;
                            btnLuuCanLan1.Show();
                            btnCanLan1.Hide();
                        }
                    }
                    else
                    {
                        if (_kieucan.Trim() == "Tự động")
                        {
                            txtKLCanLan1.Enabled = false;
                            txtKLCanLan2.Enabled = false;
                            txtKLCanLan1.Text = (decimal.Parse(Utilities.KLCan) - Utilities.TapChat).ToString();
                            btnLuuCanLan1.Show();
                            btnCanLan1.Hide();
                            Disable_ThongTin();
                            txtKLCanLan1.Enabled = false;

                        }
                    }
                }
                else
                    LoiKieuCan();
            }
            else
                Utilities.frmMain.lbThongBao.Text = "Nhập thiếu dữ liệu.";
        }

        void luulan1()
        {
            PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
            //Lưu dữ liệu
            phieuCanInfo.BSX = txtBSX.Text;
            phieuCanInfo.KhachHang = txtKhachHang.Text;
            phieuCanInfo.KieuCanLan1 = cbKieuCan.SelectedItem.ToString();
            phieuCanInfo.LoaiHang = cbLoaiHang.Text;
            phieuCanInfo.KLCanLan1 = decimal.Parse(txtKLCanLan1.Text);
            phieuCanInfo.DonGia = decimal.Parse(txtDonGia.Text);
            phieuCanInfo.LaiXe = txtTenLaiXe.Text;
            phieuCanInfo.ChedoCan = frmScalesManager.getChedoCan();

            //nếu xe đã có trong csdl
            if (Utilities.XeDaCoTrongCSDL)
            {
                phieuCanInfo.KLCanLan2 = decimal.Parse(TxtKLCanLan2.Text); // trọng lượng xe
                phieuCanInfo.LaiXe = txtTenLaiXe.Text;
                phieuCanInfo.KhachHang = txtKhachHang.Text;
                phieuCanInfo.TenNhanVienCanLan2 = "Auto";
                phieuCanInfo.MaNhanVienCanLan2 = "Auto";                
                
                // reset flag
                Utilities.XeDaCoTrongCSDL = false;                
            }

            _PhieuCanCtrl.LuuPhieuCanLan1(phieuCanInfo);
        }


        #region Kiem tra va Bat loi 
        public void LoiKieuCan()
        {
            Utilities.frmMain.lbThongBao.Text = "Chưa chọn kiểu cân.";
        }

        public bool KtraDuLieuCan()
        {
            if (txtBSX.Text != "" && txtTenLaiXe.Text != ""
                 || cbKieuCan.SelectedItem.ToString() != null && txtBSX.Text != "")
                return true;
            return false;
        }
        #endregion

        private void btnCanLan2_Click(object sender, EventArgs e)
        {
            //flag_LanCan1 = false;
            //Kiểm tra kiểu cân
            if (KtraDuLieuCan() == true)
            {
                string _kieucan = cbKieuCan.SelectedItem.ToString().Replace('{', ' ');
                _kieucan.Replace('}', ' ');
                if (_kieucan.Trim() != "")
                {
                        if (decimal.Parse(txtKLCanLan2.Text) > decimal.Parse(txtKLCanLan1.Text))
                        {
                            Utilities.frmMain.lbThongBao.Text = "Khối lượng cân lần 2 lớn hơn lần 1.";
                        }
                        else
                        {
                            //txtKLCanLan2.Maximum = txtKLCanLan1.Value;
                            btnCanLan1.Enabled = false;
                            btnCanLan2.Enabled = false;
                            cbKieuCan.Enabled = false;
                            if (_kieucan.Trim() == "Nhập bằng tay")
                            {
                                if (txtKLCanLan2.Text == "0")
                                {
                                    Utilities.frmMain.lbThongBao.Text = "Nhập thiếu khối lượng.";
                                    btnCanLan2.Enabled = true;
                                }
                                else
                                {
                                    txtKLCanLan2.Enabled = false;
                                    txtKLCanLan1.Enabled = false;
                                    btnLuuCanLan2.Show();
                                    btnCanLan2.Hide();
                                }
                            }
                            else
                            {
                                if (_kieucan.Trim() == "Tự động")
                                {
                                    btnLuuCanLan2.Show();
                                    btnCanLan2.Hide();
                                    txtKLCanLan2.Enabled = false;
                                    txtKLCanLan1.Enabled = false;
                                    txtKLCanLan2.Text = Utilities.KLCan;
                                }
                            }
                        }
                }
                else
                    LoiKieuCan();
            }
            else
            {
                LoiKieuCan();
            }
        }

        void luulan2()
        {
            PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
            //lưu dữ liệu
            phieuCanInfo.MaPhieu = txtMaPhieu.Text;
            phieuCanInfo.KieuCanLan2 = cbKieuCan.SelectedItem.ToString();
            phieuCanInfo.KLCanLan2 = decimal.Parse(txtKLCanLan2.Text);
            _PhieuCanCtrl.LuuPhieuCanLan2(phieuCanInfo);

            //load lại ds phiếu cân
            //hienThiPhieuCan();
            //ThongKe();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //if (Utilities.NguoiDung.LoaiND.MaLoai == "LND001")
            //{
            //DialogResult drl = MessageBoxEx.Show("Bạn có muốn xem trước khi in?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (drl == DialogResult.Yes)
            //{
            //    Utilities.IN = true;
            //    frmBaoCao _frmBaoCao = new frmBaoCao();
            //    _frmBaoCao._maphieu = txtMaPhieu.Text;
            //    _frmBaoCao.Show();
            //}
            //else
            //    if (drl == DialogResult.No)
            //{
                Utilities.IN = false;
                frmBaoCao _frmBaoCao = new frmBaoCao();
                _frmBaoCao._maphieu = txtMaPhieu.Text;
                _frmBaoCao.Show();
                PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
                phieuCanInfo = _PhieuCanCtrl.LaySoLanIn(txtMaPhieu.Text);
                decimal lanin = phieuCanInfo.LanIn;
                phieuCanInfo.LanIn = lanin + 1;
                phieuCanInfo.MaPhieu = txtMaPhieu.Text;
                _PhieuCanCtrl.LuuLanIn(phieuCanInfo);
            //}
            //}
            //else
            //{
            //    Utilities.IN = false;
            //    frmBaoCao _frmBaoCao = new frmBaoCao();
            //    _frmBaoCao._maphieu = Utilities.PhieuCan.MaPhieu;
            //    _frmBaoCao.Show();
            //    PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
            //    phieuCanInfo = _PhieuCanCtrl.LaySoLanIn(txtMaPhieu.Text);
            //    decimal lanin = phieuCanInfo.LanIn;
            //    phieuCanInfo.LanIn = lanin + 1;
            //    phieuCanInfo.MaPhieu = Utilities.PhieuCan.MaPhieu;
            //    _PhieuCanCtrl.LuuLanIn(phieuCanInfo);
            //}
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

        private void cbKieuCan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbKieuCan.SelectedIndex == 1)
            //{
            //    if (KtraQuyen_Update() == true)
            //    {
            //        cbKieuCan.SelectedIndex = 1;
            //        txtKLCanLan1.Enabled = true;
            //        txtKLCanLan2.Enabled = true;
            //    }
            //    else
            //    {
            //        cbKieuCan.SelectedIndex = 0;
            //    }
            //}
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double flTienThuong = double.Parse(txtDonGia.Text.Replace(",", ""));
                txtDonGia.Text = flTienThuong.ToString("0,0.##");
                txtDonGia.Select(txtDonGia.TextLength, 0);
            }
            catch
            {
            }
        }

        private void txtDonGia_Leave(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhieuCan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utilities.PhieuCan = null;
            Utilities.KLCan = "0";
            frmScalesManager.hienThiPhieuCan();
            //reset tap chat
            //Utilities.TapChat = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Utilities.PhieuCan != null)
            {
                if (Utilities.PhieuCan.TenNhanVienCanLan2.ToString() != "")
                {
                    sualan2();
                    Utilities.frmMain.lbThongBao.Text = "Sửa thành công";
                    this.Close();
                }
                else
                {
                    sualan1();
                    Utilities.frmMain.lbThongBao.Text = "Sửa thành công";
                    this.Close();
                }
            }
            else
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Hide();
            btnLuu.Show();
            btnLuu.Enabled = true;
            cbKieuCan.Enabled = false;
            Enabled_ThongTin();
            if (Utilities.PhieuCan != null)
            {
                if (Utilities.PhieuCan.TenNhanVienCanLan2.ToString() != "")
                {
                }
                else
                {
                    btnCanLan2.Enabled = false;
                }
            }
            else
            {
            }
        }

        void sualan1()
        {
            //Lưu dữ liệu
            Utilities.PhieuCan.BSX = txtBSX.Text;
            Utilities.PhieuCan.KhachHang = txtKhachHang.Text;
            Utilities.PhieuCan.KieuCanLan1 = cbKieuCan.SelectedItem.ToString();
            Utilities.PhieuCan.LoaiHang = cbLoaiHang.Text;
            Utilities.PhieuCan.KLCanLan1 = decimal.Parse(txtKLCanLan1.Text);
            Utilities.PhieuCan.DonGia = decimal.Parse(txtDonGia.Text);
            Utilities.PhieuCan.LaiXe = txtTenLaiXe.Text;
            _PhieuCanCtrl.SuaCanLan1(Utilities.PhieuCan);
        }

        void sualan2()
        {
            //Lưu dữ liệu
            Utilities.PhieuCan.BSX = txtBSX.Text;
            Utilities.PhieuCan.KhachHang = txtKhachHang.Text;
            Utilities.PhieuCan.KieuCanLan1 = cbKieuCan.SelectedItem.ToString();
            Utilities.PhieuCan.KieuCanLan2 = cbKieuCan.SelectedItem.ToString();
            Utilities.PhieuCan.LoaiHang = cbLoaiHang.Text;
            Utilities.PhieuCan.KLCanLan1 = decimal.Parse(txtKLCanLan1.Text);
            Utilities.PhieuCan.KLCanLan2 = decimal.Parse(txtKLCanLan2.Text);
            Utilities.PhieuCan.DonGia = decimal.Parse(txtDonGia.Text);
            Utilities.PhieuCan.LaiXe = txtTenLaiXe.Text;
            _PhieuCanCtrl.SuaCanLan2(Utilities.PhieuCan);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KtraQuyen_Update() == true)
            {
                if (MessageBoxEx.Show("Bạn có chắc chắn xóa phiếu này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _PhieuCanCtrl.XoaPhieuCan(Utilities.PhieuCan);
                    Utilities.frmMain.lbThongBao.Text = "Đã xóa.";
                    this.Close();
                }
            }
            else
            {
                Utilities.frmMain.lbThongBao.Text = "Sai mã PIN.";
            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double flTienThuong = double.Parse(txtThanhTien.Text.Replace(",", ""));
                txtThanhTien.Text = flTienThuong.ToString("0,0.##");
                txtThanhTien.Select(txtThanhTien.TextLength, 0);
            }
            catch
            {
            }
        }

        private void txtKLSach_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtKLTapChat_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtKLHang_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double flTienThuong = double.Parse(txtKLHang.Text.Replace(",", ""));
                txtKLHang.Text = flTienThuong.ToString("0,0.##");
                txtKLHang.Select(txtKLHang.TextLength, 0);
            }
            catch
            {
            }
        }

        private void txtKLCanLan2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double flTienThuong = double.Parse(txtKLCanLan2.Text.Replace(",", ""));
                txtKLCanLan2.Text = flTienThuong.ToString("0,0.##");
                txtKLCanLan2.Select(txtKLCanLan2.TextLength, 0);
            }
            catch
            {
            }
        }

        private void txtKLCanLan1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double flTienThuong = double.Parse(txtKLCanLan1.Text.Replace(",", ""));
                txtKLCanLan1.Text = flTienThuong.ToString("0,0.##");
                txtKLCanLan1.Select(txtKLCanLan1.TextLength, 0);
            }
            catch
            {
            }
        }

        private void cbKieuCan_Leave(object sender, EventArgs e)
        {
            if (cbKieuCan.SelectedIndex == 1)
            {
                // bỏ yêu cầu PIN khi nhập bằng tay
                txtKLCanLan1.Enabled = true;
                txtKLCanLan2.Enabled = true;
                /*
                if (KtraQuyen_Update() == true)
                {
                    cbKieuCan.SelectedIndex = 1;
                    txtKLCanLan1.Enabled = true;
                    txtKLCanLan2.Enabled = true;
                }
                else
                {
                    cbKieuCan.SelectedIndex = 0;
                }
                */
            }
            else
            {
                txtKLCanLan1.Enabled = false;
                txtKLCanLan2.Enabled = false;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities.PhieuCan = _PhieuCanCtrl.LayPhieuCan2(txtTimKiem.Text);
                if (Utilities.PhieuCan.NgayCanLan1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
                {
                    if (Utilities.PhieuCan.TenNhanVienCanLan2.ToString() != "")
                    {
                        btnCanLan1.Enabled = false;
                        btnCanLan2.Enabled = false;

                        txtMaPhieu.Text = Utilities.PhieuCan.MaPhieu;
                        txtKhachHang.Text = Utilities.PhieuCan.KhachHang;
                        txtBSX.Text = Utilities.PhieuCan.BSX;
                        txtKLCanLan1.Text = Utilities.PhieuCan.KLCanLan1.ToString();
                        txtKLCanLan2.Text = Utilities.PhieuCan.KLCanLan2.ToString();
                        cbKieuCan.Text = Utilities.PhieuCan.KieuCanLan1;
                        txtTenLaiXe.Text = Utilities.PhieuCan.LaiXe;
                        cbLoaiHang.Text = Utilities.PhieuCan.LoaiHang;
                        txtGioVaoCan.Text = Utilities.PhieuCan.NgayCanLan1.ToString();
                        txtGioRaCan.Text = Utilities.PhieuCan.NgayCanLan2.ToString();
                        txtDonGia.Text = Utilities.PhieuCan.DonGia.ToString();
                        btnSua.Enabled = true;
                        cbKieuCan.Enabled = false;
                        Disable_ThongTin();
                    }
                    else
                    {
                        txtMaPhieu.Text = Utilities.PhieuCan.MaPhieu;
                        txtKhachHang.Text = Utilities.PhieuCan.KhachHang;
                        txtBSX.Text = Utilities.PhieuCan.BSX;
                        txtKLCanLan1.Text = Utilities.PhieuCan.KLCanLan1.ToString();
                        txtKLCanLan2.Text = Utilities.PhieuCan.KLCanLan2.ToString();
                        cbKieuCan.Text = Utilities.PhieuCan.KieuCanLan1;
                        txtTenLaiXe.Text = Utilities.PhieuCan.LaiXe;
                        cbLoaiHang.Text = Utilities.PhieuCan.LoaiHang;
                        txtGioVaoCan.Text = Utilities.PhieuCan.NgayCanLan1.ToString();
                        txtDonGia.Text = Utilities.PhieuCan.DonGia.ToString();

                        btnCanLan1.Enabled = false;
                        btnCanLan2.Enabled = true;
                        Disable_ThongTin();
                        cbKieuCan.Enabled = false;
                        btnSua.Enabled = true;
                    }
                }
                else
                {
                    cbKieuCan.SelectedValue = "1";
                    txtMaPhieu.Text = "";
                    txtKLCanLan1.Text = "";
                    txtKLCanLan2.Text = "";
                    txtBSX.Text = "";
                    txtKhachHang.Text = "";
                    cbKieuCan.SelectedIndex = 0;
                    //cbLoaiHang.Text = "";
                    //txtDonGia.Text = "";

                    btnSua.Enabled = false;
                    btnIn.Enabled = false;
                    btnCanLan2.Enabled = false;
                    btnXoa.Enabled = false;
                    Utilities.frmMain.lbThongBao.Text = "Không tìm thấy phiếu cân.";
                }
            }
            catch
            {
                Utilities.frmMain.lbThongBao.Text = "Lỗi.";
            }
        }

        private void btnLuuCanLan1_Click(object sender, EventArgs e)
        {
            luulan1();
            Utilities.frmMain.lbThongBao.Text = "Lưu thành công.";            
            //Utilities.frmScalesManager.CamSau.Resume();
            //Utilities.frmScalesManager.CamToanCanh.Resume();
            this.Close();
        }

        private void btnLuuCanLan2_Click(object sender, EventArgs e)
        {
            luulan2();
            Utilities.frmMain.lbThongBao.Text = "Lưu thành công.";
            this.Close();
        }

        private void btnCanTong_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu
            if (KtraDuLieuCan() == true)
            {
                //Kiểm tra kiểu cân
                if (cbKieuCan.SelectedItem.ToString() != "")
                {
                    btnCanBi.Enabled = false;
                    btnCanBi.Hide();
                }
                //flag_LanCan1 = true;
                string _kieucan = cbKieuCan.SelectedItem.ToString().Replace('{', ' ');
                _kieucan.Replace('}', ' ');
                if (_kieucan.Trim() != "")
                {
                    if (_kieucan.Trim() == "Nhập bằng tay")
                    {
                        if (txtKLCanLan2.Text == "0")
                        {
                            Utilities.frmMain.lbThongBao.Text = "Nhập thiếu khối lượng.";
                            btnCanBi.Enabled = true;
                        }
                        else
                        {
                            Disable_ThongTin();
                            txtKLCanLan1.Enabled = false;
                            txtKLCanLan2.Enabled = false;
                            btnLuuCanTong.Show();
                            btnCanBi.Hide();
                        }
                    }
                    else
                    {
                        if (_kieucan.Trim() == "Tự động")
                        {
                            txtKLCanLan1.Enabled = false;
                            txtKLCanLan2.Enabled = false;
                            txtKLCanLan2.Text = Utilities.KLCan;
                            btnLuuCanTong.Show();
                            btnCanBi.Hide();
                            Disable_ThongTin();
                            txtKLCanLan2.Enabled = false;

                        }
                    }
                }
                else
                    LoiKieuCan();
            }
            else
                Utilities.frmMain.lbThongBao.Text = "Nhập thiếu dữ liệu.";
        }
        void luutong()
        {
            PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
            //Lưu dữ liệu
            phieuCanInfo.BSX = txtBSX.Text;
            phieuCanInfo.KhachHang = txtKhachHang.Text;
            phieuCanInfo.KieuCanLan2 = cbKieuCan.SelectedItem.ToString();
            phieuCanInfo.LoaiHang = cbLoaiHang.Text;
            phieuCanInfo.KLCanLan2 = decimal.Parse(txtKLCanLan2.Text);
            phieuCanInfo.DonGia = decimal.Parse(txtDonGia.Text);
            phieuCanInfo.LaiXe = txtTenLaiXe.Text;
            phieuCanInfo.ChedoCan = frmScalesManager.getChedoCan();
            
            _PhieuCanCtrl.LuuPhieuCanTong(phieuCanInfo);
        }

        private void btnLuuCanTong_Click(object sender, EventArgs e)
        {
            luutong();
            Utilities.frmMain.lbThongBao.Text = "Lưu thành công.";
            this.Close();
        }

        private void btnLuuCanBi_Click(object sender, EventArgs e)
        {
            luubi();
            Utilities.frmMain.lbThongBao.Text = "Lưu thành công.";
            this.Close();
        }

        private void btnCanBi_Click(object sender, EventArgs e)
        {
            //flag_LanCan1 = false;
            //Kiểm tra kiểu cân
            if (KtraDuLieuCan() == true)
            {
                string _kieucan = cbKieuCan.SelectedItem.ToString().Replace('{', ' ');
                _kieucan.Replace('}', ' ');
                if (_kieucan.Trim() != "")
                {
                            //txtKLCanLan2.Maximum = txtKLCanLan1.Value;
                            btnCanLan1.Enabled = false;
                            btnCanLan2.Enabled = false;
                            btnCanTong.Enabled = false;
                            btnCanBi.Enabled = false;
                            cbKieuCan.Enabled = false;
                            if (_kieucan.Trim() == "Nhập bằng tay")
                            {
                                if (txtKLCanLan1.Text == "0")
                                {
                                    Utilities.frmMain.lbThongBao.Text = "Nhập thiếu khối lượng.";
                                    btnCanTong.Enabled = true;
                                }
                                else
                                {
                                    txtKLCanLan2.Enabled = false;
                                    txtKLCanLan1.Enabled = false;
                                    btnCanTong.Enabled = false;
                                    btnCanBi.Enabled = false;
                                    btnLuuCanBi.Show();
                                    btnCanTong.Hide();
                                }
                            }
                            else
                            {
                                if (_kieucan.Trim() == "Tự động")
                                {
                                    btnLuuCanBi.Show();
                                    btnCanTong.Hide();
                                    txtKLCanLan2.Enabled = false;
                                    txtKLCanLan1.Enabled = false;
                                    txtKLCanLan1.Text = (decimal.Parse(Utilities.KLCan) - Utilities.TapChat).ToString();
                                }
                            }
                }
                else
                    LoiKieuCan();
            }
            else
            {
                LoiKieuCan();
            }
        }
        //luu can bi
        void luubi()
        {
            PhieuCanInfo phieuCanInfo = new PhieuCanInfo();
            //lưu dữ liệu
            phieuCanInfo.MaPhieu = txtMaPhieu.Text;
            phieuCanInfo.KieuCanLan1 = cbKieuCan.SelectedItem.ToString();
            phieuCanInfo.KLCanLan1 = decimal.Parse(txtKLCanLan1.Text);
            _PhieuCanCtrl.LuuPhieuCanBi(phieuCanInfo);

        }

    }
}

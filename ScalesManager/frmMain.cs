using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ScalesManager.Controller;
using ScalesManager.Component;
using ScalesManager.Reports;
using DevComponents.DotNetBar;
using System.IO;
using System.IO.Ports;

namespace ScalesManager
{
    public partial class frmMain : Office2007RibbonForm
    {
        #region Fields
        NguoiDungCtrl m_NguoiDungCtrl = new NguoiDungCtrl();
        KeysCtrl m_KeysCtrl = new KeysCtrl();
        frmDoiMatKhau m_FrmDoiMatKhau = null;
        frmDangNhap m_FrmLogin = null;
        frmNguoiDung m_FrmNguoiDung = null;
        frmConnection m_Connection = null;
        frmKhachHang m_FrmKhachHang = null;
        frmThongtinXe m_FrmThongtinXe = null;
        frmCauHinhCan m_FrmCauHinhCan = null;
        frmThongKe m_FrmThongKe = null;
        frmCauHinhMayIn m_FrmCauHinhMayIn = null;
        frmThongTinCongTy m_FrmThongTinCT = null;
        frmExpirationDate m_FrmExpirationDate = null;
        frmCauHinhCanTD m_FrmCauHinhCanTuDong = null;
        frmLoaiHang m_FrmLoaiHang = null;
        frmPhieuCanTD m_FrmPhieuCanTD = null;
        FormAutoScale m_FrmAutoScale = null;
        #endregion

        #region frmMain
        #region Constructor
        public frmMain()
        {
            InitializeComponent();
            frmSplash f = new frmSplash();
            Utilities.frmMain = this;
            f.Show();
            System.Threading.Thread.Sleep(2000);
            f.Close();
        }
        #endregion

        #region Load
        private void frmMain_Load(object sender, System.EventArgs e)
        {

            if (DataService.OpenConnection())
            {
                DateTime startDate = m_KeysCtrl.LayKey().StartDate;
                TimeSpan date = DateTime.Now - startDate;
                int ngay = date.Days;                
                //if (ngay > 30)
                //{
                //    frmExpirationDate frmExpirationDate = new frmExpirationDate();
                //    frmExpirationDate.ShowDialog();
                //}
                Default();
                DangNhap();

                this.Cursor = MyCursors.Create(System.IO.Path.Combine(Application.StartupPath, "Pointer.cur"));

                // Create the list of frequently used commands for the QAT Customize menu
                ribbonControl.QatFrequentCommands.Add(btnDangNhap);
                ribbonControl.QatFrequentCommands.Add(btnDangXuat);
                ribbonControl.QatFrequentCommands.Add(btnThoat);

                // Load Quick Access Toolbar layout if one is saved from last session...
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\DevComponents\Ribbon");
                if (key != null)
                {
                    try
                    {
                        string layout = key.GetValue("RibbonPadCSLayout", "").ToString();
                        if (layout != "" && layout != null)
                            ribbonControl.QatLayout = layout;
                    }
                    finally
                    {
                        key.Close();
                    }
                }

                // Pulse the Application Button
                buttonFile.Pulse(11);
            }
            else
            {
                Default();
                ReConnection();
            }
        }
        #endregion

        #region Kết nối lại CSDL
        public void ReConnection()
        {
            MessageBoxEx.Show("Lỗi kết nối đến cơ sở dữ liệu! Xin vui lòng thiết lập lại kết nối...", "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            if (m_Connection == null || m_Connection.IsDisposed)
                m_Connection = new frmConnection();

            if (m_Connection.ShowDialog() == DialogResult.OK)
            {
                MessageBoxEx.Show("Đã thiết lập kết nối cho lần chạy đầu tiên.\nHãy khởi động lại chương trình để thực thi kết nối!", "SUCCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                return;
        }
        #endregion

        #region Lưu lại trạng thái khi thoát chương trình
        private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Save Quick Access Toolbar layout if it has changed...
            if (ribbonControl.QatLayoutChanged)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\DevComponents\Ribbon");
                try
                {
                    key.SetValue("RibbonPadCSLayout", ribbonControl.QatLayout);
                }
                finally
                {
                    key.Close();
                }
            }
        }
        #endregion
        #endregion

        #region Form show
        #region Menu start
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (m_FrmLogin == null || m_FrmLogin.IsDisposed)
                m_FrmLogin = new frmDangNhap();

            m_FrmLogin.txtUsername.Text = "";
            m_FrmLogin.txtPassword.Text = "";
            m_FrmLogin.lblUserError.Text = "";
            m_FrmLogin.lblPassError.Text = "";

            DangNhap();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            lblTenNguoiDung.Text = "Không có";
            Default();
            DongFormCon();
            if (m_FrmLogin == null || m_FrmLogin.IsDisposed)
                m_FrmLogin = new frmDangNhap();

            m_FrmLogin.txtUsername.Text = "";
            m_FrmLogin.txtPassword.Text = "";
            DangNhap();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (m_FrmDoiMatKhau == null || m_FrmDoiMatKhau.IsDisposed)
                m_FrmDoiMatKhau = new frmDoiMatKhau();

            m_FrmDoiMatKhau.txtOldPassword.Text = "";
            m_FrmDoiMatKhau.txtNewPassword.Text = "";
            m_FrmDoiMatKhau.txtReNPassword.Text = "";
            m_FrmDoiMatKhau.lblOldPassError.Text = "";
            m_FrmDoiMatKhau.lblNewPassError.Text = "";
            m_FrmDoiMatKhau.lblReNPassError.Text = "";

            DoiMatKhau();
        }

        private void btnQLNguoiDung_Click(object sender, EventArgs e)
        {
            if (m_FrmNguoiDung == null || m_FrmNguoiDung.IsDisposed)
            {
                m_FrmNguoiDung = new frmNguoiDung();
                m_FrmNguoiDung.MdiParent = this;
                m_FrmNguoiDung.Show();
            }
            else
                m_FrmNguoiDung.Activate();
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            if (backupDialog.ShowDialog() == DialogResult.OK)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("BACKUP DATABASE " + Utilities.DatabaseName + " TO DISK = '" + backupDialog.FileName.ToString() + "'");
                DataService data = new DataService();
                data.Load(cmd);
                MessageBoxEx.Show("Sao lưu dữ liệu thành công!", "BACKUP COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                return;
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            if (restoreDialog.ShowDialog() == DialogResult.OK)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("USE master RESTORE DATABASE " + Utilities.DatabaseName + " FROM DISK = '" + restoreDialog.FileName.ToString() + "'");
                DataService data = new DataService();
                data.Load(cmd);
                MessageBoxEx.Show("Phục hồi dữ liệu thành công!", "RESTORE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                return;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Menu quan ly
        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            ThamSo.ShowFormKetNoi();
        }

        #endregion





        #region Menu giup do
        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace, HelpNavigator.TableOfContents);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ThamSo.ShowFormThongTin();
        }
        #endregion
        #endregion

        #region Permissions
        #region DangNhap
        public void DangNhap()
        {

        Cont:
            if (m_FrmLogin == null || m_FrmLogin.IsDisposed)
                m_FrmLogin = new frmDangNhap();

            if (m_FrmLogin.ShowDialog() == DialogResult.OK)
            {
                if (m_FrmLogin.txtUsername.Text == "")
                {
                    m_FrmLogin.lblPassError.Text = "";
                    m_FrmLogin.lblUserError.Text = "Bạn chưa nhập tên!";
                    goto Cont;
                }

                if (m_FrmLogin.txtPassword.Text == "")
                {
                    m_FrmLogin.lblUserError.Text = "";
                    m_FrmLogin.lblPassError.Text = "Bạn chưa nhập mật khẩu!";
                    goto Cont;
                }

                int ketQua = m_NguoiDungCtrl.DangNhap(m_FrmLogin.txtUsername.Text, m_FrmLogin.txtPassword.Text);

                switch (ketQua)
                {
                    case 0:
                        m_FrmLogin.lblPassError.Text = "";
                        m_FrmLogin.lblUserError.Text = "Người dùng này không tồn tại!";
                        goto Cont;
                    case 1:
                        m_FrmLogin.lblUserError.Text = "";
                        m_FrmLogin.lblPassError.Text = "Mật khẩu không hợp lệ!";
                        goto Cont;
                    case 2:
                        lblTenNguoiDung.Text = Utilities.NguoiDung.TenND;
                        Permissions(Utilities.NguoiDung.LoaiND.MaLoai);
                        //ThamSo.ShowFormQuanLyCan(this);
                        ThamSo.ShowFormAutoScale(this);
                        break;
                }
            }
            else
                return;
        }
        #endregion

        #region Phân quyền
        public void Permissions(String m_Per)
        {
            switch (m_Per)
            {
                case "LND001": IsAdmin(); break;
                case "LND002": IsUser(); break;
                case "LND003": IsUser(); break;
                default: Default(); break;
            }
        }
        #endregion

        #region DoiMatKhau
        public void DoiMatKhau()
        {
        Cont:
            if (m_FrmDoiMatKhau.ShowDialog() == DialogResult.OK)
            {
                if (m_FrmDoiMatKhau.txtOldPassword.Text == "")
                {
                    m_FrmDoiMatKhau.lblOldPassError.Text = "Chưa nhập mật khẩu hiện tại!";
                    m_FrmDoiMatKhau.lblNewPassError.Text = "";
                    m_FrmDoiMatKhau.lblReNPassError.Text = "";
                    goto Cont;
                }

                if (m_FrmDoiMatKhau.txtNewPassword.Text == "")
                {
                    m_FrmDoiMatKhau.lblOldPassError.Text = "";
                    m_FrmDoiMatKhau.lblNewPassError.Text = "Chưa nhập mật khẩu mới!";
                    m_FrmDoiMatKhau.lblReNPassError.Text = "";
                    goto Cont;
                }

                if (m_FrmDoiMatKhau.txtReNPassword.Text == "")
                {
                    m_FrmDoiMatKhau.lblOldPassError.Text = "";
                    m_FrmDoiMatKhau.lblNewPassError.Text = "";
                    m_FrmDoiMatKhau.lblReNPassError.Text = "Chưa nhập xác nhận mật khẩu!";
                    goto Cont;
                }

                String m_Username = m_FrmLogin.txtUsername.Text;
                String m_Password = m_FrmLogin.txtPassword.Text;

                String m_OldPassword = m_FrmDoiMatKhau.txtOldPassword.Text;
                String m_NewPassword = m_FrmDoiMatKhau.txtNewPassword.Text;
                String m_ReNPassword = m_FrmDoiMatKhau.txtReNPassword.Text;

                if (m_Password != m_OldPassword)
                {
                    m_FrmDoiMatKhau.lblOldPassError.Text = "Nhập sai mật khẩu cũ!";
                    m_FrmDoiMatKhau.lblNewPassError.Text = "";
                    m_FrmDoiMatKhau.lblReNPassError.Text = "";
                    goto Cont;
                }
                else if (m_NewPassword != m_ReNPassword)
                {
                    m_FrmDoiMatKhau.lblOldPassError.Text = "";
                    m_FrmDoiMatKhau.lblNewPassError.Text = "";
                    m_FrmDoiMatKhau.lblReNPassError.Text = "Nhập xác nhận không khớp!";
                    goto Cont;
                }
                else
                {
                    m_NguoiDungCtrl.ChangePassword(m_Username, m_NewPassword);
                    MessageBoxEx.Show("Đổi mật khẩu thành công!", "PASSWORD CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                return;
        }
        #endregion

        #region Giao diện mặc định
        public void Default()
        {
            //True
            btnDangNhap.Enabled = true;
            btn_DangNhap.Enabled = true;
            btnDangNhapContext.Enabled = true;
            btnThoat.Enabled = true;
            btnThoatContext.Enabled = true;
            btnHuongDan.Enabled = true;
            btnThongTin.Enabled = true;

            //False
            TabDuLieu.Enabled = false;
            btnCauHinh.Enabled = false;
            btn_LoaiHang.Enabled = false;
            btn_ThongTinCT.Enabled = false;
            btn_CauHinhMayIn.Enabled = false;
            btnQlyKH.Enabled = false;
            btnConfigDatabase.Enabled = false;
            btn_KetNoiServer.Enabled = false;
            btnDangXuat.Enabled = false;
            btn_DangXuat.Enabled = false;
            btnScalesManagerForm.Enabled = false;
            btnDangXuatContext.Enabled = false;
            btnDoiMatKhau.Enabled = false;
            btn_DoiMatKhau.Enabled = false;
            btnDoiMatKhauContext.Enabled = false;
            btnQLNguoiDung.Enabled = false;
            btn_QuanLyNguoiDung.Enabled = false;
            btnSaoLuu.Enabled = false;
            btn_SaoLuu.Enabled = false;
            btnPhucHoi.Enabled = false;
            btn_PhucHoi.Enabled = false;
            btnThongKe.Enabled = false;
            btnCauHinh.Enabled = false;
            btn_KhachHang.Enabled = false;
            btnQLCanTD.Enabled = false;
            btnCauHinhCanTD.Enabled = false;

        }
        #endregion

        #region Giao diện user
        public void IsUser()
        {
            //True
            btnThoat.Enabled = true;
            btnThoatContext.Enabled = true;
            btnHuongDan.Enabled = true;
            btnThongTin.Enabled = true;
            btnDangXuat.Enabled = true;
            btn_DangXuat.Enabled = true;
            btnScalesManagerForm.Enabled = true;
            btnDoiMatKhau.Enabled = true;
            btn_DoiMatKhau.Enabled = true;
            btnDoiMatKhauContext.Enabled = true;
            btnQlyKH.Enabled = true;
            btn_CauHinhMayIn.Enabled = true;
            btnCauHinh.Enabled = true;
            btnThongKe.Enabled = true;
            btn_ThongTinCT.Enabled = true;
            btn_LoaiHang.Enabled = true;
            btn_KhachHang.Enabled = true;
            btnQLCanTD.Enabled = true;
            btnCauHinhCanTD.Enabled = true;
            //False
            TabDuLieu.Enabled = false;
            btnCauHinh.Enabled = false;
            btnDangNhap.Enabled = false;
            btn_DangNhap.Enabled = false;
            btnDangNhapContext.Enabled = false;
            btnDangXuatContext.Enabled = false;
            btnQLNguoiDung.Enabled = false;
            btn_QuanLyNguoiDung.Enabled = false;
            btnSaoLuu.Enabled = false;
            btn_SaoLuu.Enabled = false;
            btnPhucHoi.Enabled = false;
            btn_PhucHoi.Enabled = false;

        }
        #endregion

        #region Giao diện khi đăng nhập với quyền Admin
        public void IsAdmin()
        {
            //False
            btnDangNhap.Enabled = false;
            btn_DangNhap.Enabled = false;
            btnDangNhapContext.Enabled = false;

            //True
            TabDuLieu.Enabled = true;
            btnCauHinh.Enabled = true;
            btn_LoaiHang.Enabled = true;
            btn_ThongTinCT.Enabled = true;
            btnDangXuat.Enabled = true;
            btn_DangXuat.Enabled = true;
            btnDangXuatContext.Enabled = true;
            btnDoiMatKhau.Enabled = true;
            btn_DoiMatKhau.Enabled = true;
            btnDoiMatKhauContext.Enabled = true;
            btnQLNguoiDung.Enabled = true;
            btn_QuanLyNguoiDung.Enabled = true;
            btnSaoLuu.Enabled = true;
            btn_SaoLuu.Enabled = true;
            btnPhucHoi.Enabled = true;
            btn_PhucHoi.Enabled = true;
            btnThoat.Enabled = true;
            btnThoatContext.Enabled = true;
            btnScalesManagerForm.Enabled = true;
            btnHuongDan.Enabled = true;
            btnThongTin.Enabled = true;
            btnCauHinh.Enabled = true;
            btnThongKe.Enabled = true;
            btnConfigDatabase.Enabled = true;
            btn_KetNoiServer.Enabled = true;
            btnQlyKH.Enabled = true;
            btn_CauHinhMayIn.Enabled = true;
            btn_KhachHang.Enabled = true;
            btnQLCanTD.Enabled = true;
            btnCauHinhCanTD.Enabled = true;
        }
        #endregion

        #endregion

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (m_FrmThongKe == null || m_FrmThongKe.IsDisposed)
            {
                m_FrmThongKe = new frmThongKe();
                m_FrmThongKe.MdiParent = this;
                m_FrmThongKe.Show();
            }
            else
                m_FrmThongKe.Activate();
        }

        private void btnScalesManagerForm_Click(object sender, EventArgs e)
        {
            ThamSo.ShowFormQuanLyCan(this);
        }

        private void btnConfigDatabase_Click(object sender, EventArgs e)
        {
            ThamSo.ShowFormKetNoi();
        }

        private void ribbonTabGiupDo_Click(object sender, EventArgs e)
        {

        }
        #region Ribon Nguoi dung
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (m_FrmLogin == null || m_FrmLogin.IsDisposed)
                m_FrmLogin = new frmDangNhap();

            m_FrmLogin.txtUsername.Text = "";
            m_FrmLogin.txtPassword.Text = "";
            DangNhap();
        }
        #endregion
        #region Kiểm tra tồn tại của form con
        private bool KTra(String name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void DongFormCon()
        {
            if (KTra("frmKhachHang") == true)
            {
                m_FrmKhachHang.Close();
            }
            if (KTra("frmNguoiDung") == true)
            {
                m_FrmNguoiDung.Close();
            }
            if (KTra("frmScalesManager") == true)
            {
                ThamSo.CloseFormQuanLyCan();
            }
            if (KTra("frmThongKe") == true)
            {
                m_FrmThongKe.Close();
            }
            if (KTra("FormAutoScale") == true)
            {
                ThamSo.CloseFormAutoScale();
            }
        }
        #endregion

        private void btnQlyKH_Click(object sender, EventArgs e)
        {
            if (m_FrmKhachHang == null || m_FrmKhachHang.IsDisposed)
            {
                m_FrmKhachHang = new frmKhachHang();
                m_FrmKhachHang.MdiParent = this;
                m_FrmKhachHang.Show();
            }
            else
                m_FrmKhachHang.Activate();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            lblTenNguoiDung.Text = "Không có";
            Default();
            DongFormCon();
            if (m_FrmLogin == null || m_FrmLogin.IsDisposed)
                m_FrmLogin = new frmDangNhap();

            m_FrmLogin.txtUsername.Text = "";
            m_FrmLogin.txtPassword.Text = "";
            DangNhap();

        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            if (m_FrmDoiMatKhau == null || m_FrmDoiMatKhau.IsDisposed)
                m_FrmDoiMatKhau = new frmDoiMatKhau();

            m_FrmDoiMatKhau.txtOldPassword.Text = "";
            m_FrmDoiMatKhau.txtNewPassword.Text = "";
            m_FrmDoiMatKhau.txtReNPassword.Text = "";
            m_FrmDoiMatKhau.lblOldPassError.Text = "";
            m_FrmDoiMatKhau.lblNewPassError.Text = "";
            m_FrmDoiMatKhau.lblReNPassError.Text = "";

            DoiMatKhau();
        }

        private void btn_QuanLyNguoiDung_Click(object sender, EventArgs e)
        {

            if (m_FrmNguoiDung == null || m_FrmNguoiDung.IsDisposed)
            {
                m_FrmNguoiDung = new frmNguoiDung();
                m_FrmNguoiDung.MdiParent = this;
                m_FrmNguoiDung.Show();
            }
            else
                m_FrmNguoiDung.Activate();
        }

        private void btn_SaoLuu_Click(object sender, EventArgs e)
        {
            if (backupDialog.ShowDialog() == DialogResult.OK)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("BACKUP DATABASE " + Utilities.DatabaseName + " TO DISK = '" + backupDialog.FileName.ToString() + "'");
                DataService data = new DataService();
                data.Load(cmd);
                MessageBoxEx.Show("Sao lưu dữ liệu thành công!", "BACKUP COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                return;
        }

        private void btn_PhucHoi_Click(object sender, EventArgs e)
        {
            if (restoreDialog.ShowDialog() == DialogResult.OK)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("USE master RESTORE DATABASE " + Utilities.DatabaseName + " FROM DISK = '" + restoreDialog.FileName.ToString() + "'");
                DataService data = new DataService();
                data.Load(cmd);
                MessageBoxEx.Show("Phục hồi dữ liệu thành công!", "RESTORE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                return;
        }

        private void btn_KetNoiServer_Click(object sender, EventArgs e)
        {
            ThamSo.ShowFormKetNoi();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            Utilities.serialPortCOM.closeConnection(this);
            m_FrmCauHinhCan = new frmCauHinhCan();
            m_FrmCauHinhCan.ShowDialog();
        }

        private void btn_CauHinhMayIn_Click(object sender, EventArgs e)
        {
            m_FrmCauHinhMayIn = new frmCauHinhMayIn();
            m_FrmCauHinhMayIn.ShowDialog();
        }

        private void btn_ThongTinCT_Click(object sender, EventArgs e)
        {
            if (m_FrmThongTinCT == null || m_FrmThongTinCT.IsDisposed)
            {
                m_FrmThongTinCT = new frmThongTinCongTy();
                m_FrmThongTinCT.MdiParent = this;
                m_FrmThongTinCT.Show();
            }
            else
                m_FrmThongTinCT.Activate();
        }

        private void btn_LoaiHang_Click(object sender, EventArgs e)
        {
            if (m_FrmLoaiHang == null || m_FrmLoaiHang.IsDisposed)
            {
                m_FrmLoaiHang = new frmLoaiHang();
                m_FrmLoaiHang.MdiParent = this;
                m_FrmLoaiHang.Show();
            }
            else
                m_FrmLoaiHang.Activate();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Utilities.serialPortCOM != null)
                Utilities.serialPortCOM.closeConnection();
        }

        private void btn_LoaiHang_Click_1(object sender, EventArgs e)
        {
            if (m_FrmLoaiHang == null || m_FrmLoaiHang.IsDisposed)
            {
                m_FrmLoaiHang = new frmLoaiHang();
                m_FrmLoaiHang.MdiParent = this;
                m_FrmLoaiHang.Show();
            }
            else
                m_FrmLoaiHang.Activate();
        }

        private void btn_ThongTinCT_Click_1(object sender, EventArgs e)
        {
            if (m_FrmThongTinCT == null || m_FrmThongTinCT.IsDisposed)
            {
                m_FrmThongTinCT = new frmThongTinCongTy();
                m_FrmThongTinCT.MdiParent = this;
                m_FrmThongTinCT.Show();
            }
            else
                m_FrmThongTinCT.Activate();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            if (m_FrmKhachHang == null || m_FrmKhachHang.IsDisposed)
            {
                m_FrmKhachHang = new frmKhachHang();
                m_FrmKhachHang.MdiParent = this;
                m_FrmKhachHang.Show();
            }
            else
                m_FrmKhachHang.Activate();
        }

        private void btnQLCanTD_Click(object sender, EventArgs e)
        {
            if (m_FrmPhieuCanTD == null || m_FrmPhieuCanTD.IsDisposed)
            {
                m_FrmPhieuCanTD = new frmPhieuCanTD();
                m_FrmPhieuCanTD.MdiParent = this;
                m_FrmPhieuCanTD.Show();
            }
            else
                m_FrmPhieuCanTD.Activate();
        }

        private void btCauHinhCanTD_Click(object sender, EventArgs e)
        {
            m_FrmCauHinhCanTuDong = new frmCauHinhCanTD();
            m_FrmCauHinhCanTuDong.ShowDialog();
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void btn_ThongtinXe_Click(object sender, EventArgs e)
        {
            if (m_FrmThongtinXe == null || m_FrmThongtinXe.IsDisposed)
            {
                m_FrmThongtinXe = new frmThongtinXe();
                m_FrmThongtinXe.MdiParent = this;
                m_FrmThongtinXe.Show();
            }
            else
                m_FrmThongtinXe.Activate();
        }

        private void btnCanTuDong_Click(object sender, EventArgs e)
        {
            ThamSo.ShowFormAutoScale(this);
        }
    }
}
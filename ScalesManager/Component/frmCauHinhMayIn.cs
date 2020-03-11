using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Text;
using System.Windows.Forms;
using ScalesManager.Controller;
using ScalesManager.Bussiness;
using DevComponents.DotNetBar;

namespace ScalesManager.Component
{
    public partial class frmCauHinhMayIn : Office2007Form
    {
        CauHinhMayInCtrl m_cauHinhMayInCtrl = new CauHinhMayInCtrl();
        public frmCauHinhMayIn()
        {
            InitializeComponent();
            txtSoPhieu.Text = "1";
            try
            {
                using (ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("SELECT * FROM Win32_Printer"))
                {
                    foreach (ManagementObject printer in searcher.Get())
                    {
                        cbb_COMPort.Items.Add(printer["Name"]);                      
                    }
                }
            }
            catch (Exception)
            {
                lbStatus.Text = "Chưa kết nối với máy in!!!";
            }
        }

        #region kiểm tra lỗi
        bool KtraRong()
        {
            if (cbb_COMPort.Text != "" && cbb_COMPort.Text != null &&
                txtSoPhieu.Text != "" && txtSoPhieu.Text != null)
                return true;
            else
                return false;
        }
        bool KtraSoPhieu()
        {
            if (int.Parse(txtSoPhieu.Text) > 10)
                return false;
            return true;
        }
        #endregion
     
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CauHinhMayInInfo cauHinhMayInInfo = new CauHinhMayInInfo();
            if (KtraRong() == true)
            {
                if (KtraSoPhieu() == true)
                {
                    try
                    {
                        if (m_cauHinhMayInCtrl.DemCauHinhMayIn() == 1)
                        {
                            cauHinhMayInInfo.ID = m_cauHinhMayInCtrl.LayIDCauHinhMayIn();
                            cauHinhMayInInfo.TenMayIn = cbb_COMPort.Text;
                            cauHinhMayInInfo.SoPhieu = txtSoPhieu.Text;
                            m_cauHinhMayInCtrl.LuuCauHinhMayIn_LanN(cauHinhMayInInfo);
                        }
                        else
                        {
                            cauHinhMayInInfo.ID = "CAUHINH";
                            cauHinhMayInInfo.TenMayIn = cbb_COMPort.Text;
                            cauHinhMayInInfo.SoPhieu = txtSoPhieu.Text;
                            m_cauHinhMayInCtrl.LuuCauHinhMayIn_Lan1(cauHinhMayInInfo);
                        }
                        lbStatus.Text = "Lưu thành công!";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        lbStatus.Text = "Lỗi!!!";
                    }
                }
                else
                    lbStatus.Text = "Số phiếu không được lớn hơn 10!!!";
            }
            else
                lbStatus.Text = "Nhập thiếu dữ liệu!!!";
        }

        private void txtSoPhieu_TextChanged(object sender, EventArgs e)
        {
            if (txtSoPhieu.Text != "")
            {
                try
                {
                    int u = Int32.Parse(txtSoPhieu.Text.Trim());
                }
                catch
                {
                    txtSoPhieu.Text = "";
                    txtSoPhieu.Focus();
                    return;
                }
            }
        }

        private void txtSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    internal class ProcessConnection
    {
        public static ConnectionOptions ProcessConnectionOptions()
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.Authentication = AuthenticationLevel.Default;
            options.EnablePrivileges = true;
            return options;
        }

        public static ManagementScope ConnectionScope(string machineName, ConnectionOptions options, string path)
        {
            ManagementScope connectScope = new ManagementScope();
            connectScope.Path = new ManagementPath(@"\\" + machineName + path);
            connectScope.Options = options;
            connectScope.Connect();
            return connectScope;
        }
    }

    public class COMPortInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public COMPortInfo() { }

        public static List<COMPortInfo> GetCOMPortsInfo()
        {
            List<COMPortInfo> comPortInfoList = new List<COMPortInfo>();

            ConnectionOptions options = ProcessConnection.ProcessConnectionOptions();
            ManagementScope connectionScope = ProcessConnection.ConnectionScope(Environment.MachineName, options, @"\root\CIMV2");

            ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");
            ManagementObjectSearcher comPortSearcher = new ManagementObjectSearcher(connectionScope, objectQuery);

            using (comPortSearcher)
            {
                string caption = null;
                foreach (ManagementObject obj in comPortSearcher.Get())
                {
                    if (obj != null)
                    {
                        object captionObj = obj["Caption"];
                        if (captionObj != null)
                        {
                            caption = captionObj.ToString();
                            if (caption.Contains("(COM"))
                            {
                                COMPortInfo comPortInfo = new COMPortInfo();
                                comPortInfo.Name = caption.Substring(caption.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
                                comPortInfo.Description = caption;
                                comPortInfoList.Add(comPortInfo);
                            }
                        }
                    }
                }
            }
            return comPortInfoList;
        }

    }
}


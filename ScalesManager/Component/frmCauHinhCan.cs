using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// Thêm 3 em này vào là OK, để sài SerialPort
using System.IO;
using System.IO.Ports;
using System.Xml;
using ScalesManager.Controller;
using ScalesManager.Bussiness;
using DevComponents.DotNetBar;
using System.Threading;

namespace ScalesManager.Component
{
    public partial class frmCauHinhCan : Form
    {
        CauHinhCanCtrl _CauHinhCtrl = new CauHinhCanCtrl();
        CauHinhCanInfo _CauHinhCanInfo = new CauHinhCanInfo();
        delegate void SetTextCallback(string text);
        // Khai báo 1 Object SerialPort mới.
        string InputData = String.Empty; // Khai báo string buff dùng cho hiển thị dữ liệu sau này.
                                         // delegate void SetTextCallback(string text); // Khai bao delegate SetTextCallBack voi tham so string
        DateTime today = DateTime.Now;
        public frmCauHinhCan()
        {
            InitializeComponent();
            // Cài đặt các thông số cho COM
            // Mảng string port để chứa tất cả các cổng COM đang có trên máy tính
            string[] ports = SerialPort.GetPortNames();
            _CauHinhCanInfo = _CauHinhCtrl.LayCauHinhCan();
            // Thêm toàn bộ các COM đã tìm được vào combox cbCom
            cbCom.Items.AddRange(ports); // Sử dụng AddRange thay vì dùng foreach
                                         //serialPort.ReadTimeout = 1000;
                                         // Khai báo hàm delegate bằng phương thức DataReceived của Object SerialPort;
                                         // Cái này khi có sự kiện nhận dữ liệu sẽ nhảy đến phương thức DataReceive
                                         // Nếu ko hiểu đoạn này bạn có thể tìm hiểu về Delegate, còn ko cứ COPY . Ko cần quan tâm


            // Cài đặt cho BaudRate
            string[] BaudRate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            cbRate.Items.AddRange(BaudRate);

            // Cài đặt cho DataBits
            string[] Databits = { "6", "7", "8" };
            cbBits.Items.AddRange(Databits);

            //Cho Parity
            string[] Parity = { "None", "Odd", "Even" };
            cbParity.Items.AddRange(Parity);

            //Cho Stop bit
            string[] stopbit = { "1", "1.5", "2" };
            cbBit.Items.AddRange(stopbit);
            //  _frmMain.lbTrangThaiCan.Text = "";


            Control.CheckForIllegalCrossThreadCalls = false;
        }
        // *****
        public void showWeightThread()
        {
            while (1 > 0)
            {
                Thread.Sleep(100);
                Utilities.serialPortCOM.comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
            }
        }
        public Decimal convertDataToWeight(string[] arrayData, string lb)
        {
            int start = int.Parse(txtFrom.Value.ToString());
            int end = int.Parse(txtTo.Value.ToString());
            int datalenght = int.Parse(txtDataLenght.Value.ToString());
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
                if (arrayData[i].Length > datalenght)
                {
                    try
                    {
                        outputDecimal = Decimal.Parse(arrayData[i].Substring(start, end).Trim());
                        break;
                    }
                    catch (Exception)
                    {
                        outputDecimal = 0;
                        break;
                    }
                }
            }
            return outputDecimal;
        }
        //******
        // Hàm này được sự kiện nhận dử liệu gọi đến. Mục đích để hiển thị thôi
        private void DataReceive(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                TimeSpan aInterval = new System.TimeSpan(0, 0, 0, 0, 10);

                // Thêm một khoảng thời gian.
                DateTime newTime = today.Add(aInterval);
                if (DateTime.Now.CompareTo(newTime) > 0)
                {
                    today = DateTime.Now;
                    SerialPort sp = (SerialPort)sender;
                    String outPut = sp.ReadExisting();
                    SetText(outPut);
                    if (outPut != String.Empty)
                    {
                        outPut = outPut.Trim();
                        string[] arrayData = outPut.Split(char.Parse(txtKiTuNgat.Text));
                        Decimal klCan = convertDataToWeight(arrayData, txtKLCantest.Text);
                        this.txtKLCantest.Invoke(new System.Action(() => this.txtKLCantest.Text = klCan.ToString().Trim()));

                    }
                }
                aInterval = new System.TimeSpan(0, 0, 0, 0, 0);
            }
            catch (Exception)
            {
                Utilities.serialPortCOM.closeConnection();
            }
        }


        #region kiểm tra lỗi
        bool KtraRong()
        {
            if (cbCom.Text != "" && cbCom.Text != null &&
                cbRate.Text != "" && cbRate.Text != null &&
                cbBit.Text != "" && cbBit.Text != null &&
                cbBits.Text != "" && cbBits.Text != null &&
                cbParity.Text != "" && cbParity.Text != null &&
                 txtDataLenght.Text != "" && txtDataLenght.Text != null &&
                  txtFrom.Text != "" && txtFrom.Text != null &&
                   txtTo.Text != "" && txtTo.Text != null)
                return true;
            else
                return false;
        }

        #endregion
        private void btLuuCauHinh_Click(object sender, EventArgs e)
        {
            CauHinhCanInfo cauHinhCanInfo = new CauHinhCanInfo();
            if (KtraRong() == true)
            {
                try
                {
                    if (_CauHinhCtrl.DemCauHinhCan() == 1)
                    {
                        cauHinhCanInfo.ID = _CauHinhCtrl.LayIDCauHinh();
                        cauHinhCanInfo.COM = cbCom.Text;
                        cauHinhCanInfo.RAUDRATE = cbRate.Text;
                        cauHinhCanInfo.DATABITS = cbBits.Text;
                        cauHinhCanInfo.PARITY = cbParity.Text;
                        cauHinhCanInfo.STOPBIT = cbBit.Text;
                        cauHinhCanInfo.DATALENGHT = txtDataLenght.Text;
                        cauHinhCanInfo.SFROM = txtFrom.Text;
                        cauHinhCanInfo.STO = txtTo.Text;
                        cauHinhCanInfo.KiTuNgat = txtKiTuNgat.Text;
                        _CauHinhCtrl.LuuCauHinh_LanN(cauHinhCanInfo);
                    }
                    else
                    {
                        cauHinhCanInfo.ID = "CAUHINH";
                        cauHinhCanInfo.COM = cbCom.Text;
                        cauHinhCanInfo.RAUDRATE = cbRate.Text;
                        cauHinhCanInfo.DATABITS = cbBits.Text;
                        cauHinhCanInfo.PARITY = cbParity.Text;
                        cauHinhCanInfo.STOPBIT = cbBit.Text;
                        cauHinhCanInfo.DATALENGHT = txtDataLenght.Text;
                        cauHinhCanInfo.SFROM = txtFrom.Text;
                        cauHinhCanInfo.STO = txtTo.Text;
                        cauHinhCanInfo.KiTuNgat = txtKiTuNgat.Text;
                        _CauHinhCtrl.LuuCauHinh_Lan1(cauHinhCanInfo);
                    }
                    status.Text = "Lưu thành công";
                }
                catch (Exception ex)
                {
                    status.Text = "Lỗi!!!";
                    MessageBox.Show(ex.Message);
                }
            }
            else
                status.Text = "Nhập thiếu dữ liệu !!!";

        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.serialPortCOM.closeConnection();
            Utilities.serialPortCOM.comPort.PortName = cbCom.SelectedItem.ToString(); // Gán PortName bằng COM đã chọn 
        }

        private void cbRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.serialPortCOM.closeConnection();
            Utilities.serialPortCOM.comPort.BaudRate = Convert.ToInt32(cbRate.Text);
        }

        private void cbBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.serialPortCOM.closeConnection();
            Utilities.serialPortCOM.comPort.DataBits = Convert.ToInt32(cbBits.Text);
        }

        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.serialPortCOM.closeConnection();
            // Với thằng Parity hơn lằng nhằng. Nhưng cũng OK thôi. ^_^
            switch (cbParity.SelectedItem.ToString())
            {
                case "Odd":
                    Utilities.serialPortCOM.comPort.Parity = Parity.Odd;
                    break;
                case "None":
                    Utilities.serialPortCOM.comPort.Parity = Parity.None;
                    break;
                case "Even":

                    Utilities.serialPortCOM.comPort.Parity = Parity.Even;
                    break;
            }
        }

        private void cbBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.serialPortCOM.closeConnection();

            switch (cbBit.SelectedItem.ToString())
            {
                case "1":
                    Utilities.serialPortCOM.comPort.StopBits = StopBits.One;
                    break;
                case "1.5":
                    Utilities.serialPortCOM.comPort.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    Utilities.serialPortCOM.comPort.StopBits = StopBits.Two;
                    break;
            }
        }

        private void frmCauHinhCan_Load(object sender, EventArgs e)// sẽ được gọi khi mở chương trình.
        {
            try
            {
                cbCom.SelectedIndex = 0;
                cbRate.SelectedText = _CauHinhCanInfo.RAUDRATE.ToString(); // 9600
                cbBits.SelectedText = _CauHinhCanInfo.DATABITS.ToString();// 8
                cbParity.SelectedText = _CauHinhCanInfo.PARITY.ToString(); // None
                cbBit.SelectedText = _CauHinhCanInfo.STOPBIT.ToString();  // None
                txtDataLenght.Text = _CauHinhCanInfo.DATALENGHT.ToString();
                txtFrom.Text = _CauHinhCanInfo.SFROM.ToString();
                txtTo.Text = _CauHinhCanInfo.STO.ToString();
                txtKiTuNgat.Text = _CauHinhCanInfo.KiTuNgat.ToString();
                // Hiện thị Status cho Pro tí
                status.Text = "Hãy chọn 1 cổng COM để kết nối.";
            }
            catch
            {
                status.Text = "Chưa kết nối với máy cân.";
            }
        }

        private void btKetNoi_Click(object sender, EventArgs e)
        {           
            try
            {
                //Utilities.serialPortCOM.comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
                //Utilities.serialPortCOM.closeConnection();
                Utilities.serialPortCOM.openConnection();
                Thread threads = new Thread(new ThreadStart(showWeightThread));
                threads.IsBackground = true;
                threads.Start();

                // Hiện thị Status
                status.Text = "Đang kết nối với cổng " + cbCom.SelectedItem.ToString();
                _Disable_NhapLieu();
                btThoat.Enabled = false;
                btKetNoi.Enabled = false;
                btNgat.Enabled = true;
            }
            catch 
            { 
                MessageBox.Show("Không kết nối được.", "Thử lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btNgat_Click(object sender, EventArgs e)
        {
            btKetNoi.Enabled = false;
            btNgat.Enabled = false;
            btThoat.Enabled = false;
            btXoa.Enabled = false;
            Utilities.serialPortCOM.closeConnection();
            Thread.Sleep(2000);
            // Hiện thị Status
            status.Text = "Đã Ngắt Kết Nối";
            btKetNoi.Enabled = true;
            btNgat.Enabled = false;
            btThoat.Enabled = true;
            btXoa.Enabled = true;
            _Enable_NhapLieu();

        }
        void _Disable_NhapLieu()
        {
            cbBit.Enabled = false;
            cbBits.Enabled = false;
            cbCom.Enabled = false;
            cbParity.Enabled = false;
            cbRate.Enabled = false;
            btLuuCauHinh.Enabled = false;
            txtDataLenght.Enabled = false;
            txtFrom.Enabled = false;
            txtTo.Enabled = false;
        }
        void _Enable_NhapLieu()
        {
            cbBit.Enabled = true;
            cbBits.Enabled = true;
            cbCom.Enabled = true;
            cbParity.Enabled = true;
            cbRate.Enabled = true;
            btLuuCauHinh.Enabled = true;
            txtDataLenght.Enabled = true;
            txtFrom.Enabled = true;
            txtTo.Enabled = true;
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn thực sự muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // MessageBox.Show("Cảm ơn bạn đã sử dụng chương trình","Thông báo");
                this.Close();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            txtkq.Text = "";
            txtSend.Text = "";
        }

        private void txtDataLenght_ValueChanged(object sender, EventArgs e)
        {
            //if (txtTo.Value > txtDataLenght.Value)
            //    txtTo.Value = txtDataLenght.Value;

        }

        private void txtTo_ValueChanged(object sender, EventArgs e)
        {

            //if (txtTo.Value > txtDataLenght.Value)
            //    txtTo.Value = txtDataLenght.Value;

            //if (txtFrom.Value > txtTo.Value)
            //    txtFrom.Value = txtTo.Value;

        }

        private void txtFrom_ValueChanged(object sender, EventArgs e)
        {
            //if (txtFrom.Value > txtTo.Value)
            //    txtFrom.Value = txtTo.Value;
        }

        private void frmCauHinhCan_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Utilities.serialPortCOM.closeConnection();
            //Utilities.serialPortCOM.openConnection(Utilities.frmMain);
        }

        private void SetText(string text)
        {
            if (this.txtkq.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText); // khởi tạo 1 delegate mới gọi đến SetText
                this.Invoke(d, new object[] { text });
            }
            else
            {

                this.txtkq.Text += "\n" + text;
            }
        }

        private void frmCauHinhCan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utilities.serialPortCOM.closeConnection();
            Utilities.serialPortCOM.openConnection(Utilities.frmMain);
        }

        private void txtDataLenght_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

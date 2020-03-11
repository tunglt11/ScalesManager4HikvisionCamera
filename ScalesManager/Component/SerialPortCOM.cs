using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ScalesManager.Component
{
    public class SerialPortCOM
    {

        public SerialPort comPort = new SerialPort();

        public Decimal outPutData = 0;

        public SerialPortCOM(string PortName, int BaudRate, short DataBits, StopBits StopBits, Handshake Handshake, Parity Parity)
        {
            comPort.PortName = PortName;
            comPort.BaudRate = BaudRate;
            comPort.DataBits = DataBits;
            comPort.StopBits = StopBits;
            comPort.Handshake = Handshake;
            comPort.Parity = Parity;
            //comPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceivedEventArgs);
        }

        public void openConnection(frmMain frmMain)
        {
            if (!comPort.IsOpen)
            {
                try
                {
                    comPort.Open();
                    try
                    {
                        Utilities.frmMain.lbTrangThaiCan.Text = "Kết nối thành công";
                    }
                    catch
                    {
                    }
                }
                catch (System.IO.IOException)
                {
                    Utilities.frmMain.lbTrangThaiCan.Text = "Kết nối thất bại";
                }
            }

        }

        public void openConnection()
        {
            if (!comPort.IsOpen)
            {
                try
                {
                    comPort.Open();
                    Utilities.frmMain.lbTrangThaiCan.Text = "Kết nối thành công";
                }
                catch (System.IO.IOException)
                {
                    Utilities.frmMain.lbTrangThaiCan.Text = "Kết nối thất bại";
                }
            }

        }
        private void serialDataReceivedEventArgs(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            String outPut = sp.ReadExisting();
            if (outPut != String.Empty)
            {
                outPut = outPut.Trim();
                //string[] arrayData = outPut.Split('+');
                string[] arrayData = outPut.Split('*');
                outPutData = convertDataToWeight(arrayData);
            }
        }

        public Decimal convertDataToWeight(string[] arrayData)
        {
            Decimal outputDecimal = 0;
            if (arrayData == null || arrayData.Length == 0)
            {
                return outputDecimal;
            }
            for (int i = arrayData.Length - 1; i > 0; i--)
            {
                if (arrayData[i].Length > 2)
                {
                    outputDecimal = Decimal.Parse(arrayData[i].Substring(1, arrayData[i].Length-1).Trim());
                    break;
                }
            }
            return outputDecimal;
        }
        public void closeConnection(frmMain frmMain)
        {
            if (comPort.IsOpen)
            {
                comPort.DtrEnable = false;
                comPort.RtsEnable = false;
                comPort.DiscardInBuffer();
                comPort.DiscardOutBuffer();
                Thread CloseDown = new Thread(new ThreadStart(CloseSerialOnExit));
                CloseDown.Start();
                frmMain.lbTrangThaiCan.Text = "Ngắt kết nối";
            }


        }
        public void closeConnection()
        {
            if (comPort.IsOpen)
            {
                comPort.DtrEnable = false;
                comPort.RtsEnable = false;
                comPort.DiscardInBuffer();
                comPort.DiscardOutBuffer();
                Thread CloseDown = new Thread(new ThreadStart(CloseSerialOnExit));
                CloseDown.Start();
            }


        }

        private void CloseSerialOnExit()

        {
            try
            {
                comPort.Close(); //close the serial port
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch any serial port closing error messages
            }
            comPort.Close();  //now close back in the main thread
        }

    }
}

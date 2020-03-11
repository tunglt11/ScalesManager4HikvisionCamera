using System;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Windows.Forms;
using ScalesManager.Bussiness;
using ScalesManager.Controller;
using DevComponents.DotNetBar;
using System.Collections.Generic;
using System.Drawing;

namespace ScalesManager.Component
{
    #region Utilities
    public static class Utilities
    {
        public static NguoiDungInfo NguoiDung = null;
        public static PhieuCanInfo PhieuCan;
        public static String DatabaseName;
        public static String MaPIN = null;
        public static SerialPortCOM serialPortCOM = null;
        public static bool IN = false;
        public static frmMain frmMain;
        public static frmScalesManager frmScalesManager;
        public static String KLCan = null;
        public static String KtuNgat = ")";
        public static String LoaiCan = null;
        public static decimal TapChat = 0;
        public static Bitmap Cam1;
        public static Bitmap Cam2;
        public static Bitmap Cam3;
        public static Bitmap Cam4;
        public static Bitmap BienSoXe;
        public static bool XeDaCoTrongCSDL = false;
        public static decimal klXe = 0;
    }
    #endregion

    #region ThamSo
    public static class ThamSo
    {
        #region Fields

        public static frmConnection             m_FrmConnection         = null;
        public static frmAbout                  m_FrmAbout              = null;
        public static frmScalesManager          m_FrmScalesManager      = null;
        public static FormAutoScale             m_formAutoScale         = null;
        public static frmCauHinhCan             m_FrmCauHinhCan         = null;
        #endregion

        #region Ham goi hien form

        public static void ShowFormKetNoi()
        {
            if (m_FrmConnection == null || m_FrmConnection.IsDisposed)
            {
                m_FrmConnection = new frmConnection();
                m_FrmConnection.Show();
            }
            else
                m_FrmConnection.Activate();
        }
        #endregion
      
        #region Menu giup do
        public static void ShowFormThongTin()
        {
            if (m_FrmAbout == null || m_FrmAbout.IsDisposed)
            {
                m_FrmAbout = new frmAbout();
                m_FrmAbout.Show();
            }
            else
                m_FrmAbout.Activate();
        }
        #endregion
        #region Quan ly can
        public static void ShowFormQuanLyCan(frmMain _frmMain)
        {
            if (m_FrmScalesManager == null || m_FrmScalesManager.IsDisposed)
            {
                m_FrmScalesManager = new frmScalesManager(_frmMain);
                m_FrmScalesManager.MdiParent = frmMain.ActiveForm;
                m_FrmScalesManager.Show();
                m_FrmScalesManager.WindowState = FormWindowState.Maximized;
            }
            else
                m_FrmScalesManager.Activate();
        }
        public static void CloseFormQuanLyCan()
        {
            m_FrmScalesManager.Close();
        }
        #endregion


        public static void ShowFormAutoScale(frmMain _frmMain)
        {
            if (m_formAutoScale == null || m_formAutoScale.IsDisposed)
            {
                m_formAutoScale = new FormAutoScale();
                m_formAutoScale.MdiParent = frmMain.ActiveForm;
                m_formAutoScale.WindowState = FormWindowState.Maximized;
                m_formAutoScale.Show();                
            }
            else
                m_formAutoScale.Activate();
        }
        public static void CloseFormAutoScale()
        {
            m_formAutoScale.Close();
        }

    }
    #endregion

    #region Các hàm xử lý tập tin XML
    public class XML
    {
        public static XmlDocument XMLReader(String filename)
        {
            XmlDocument xmlR = new XmlDocument();
            try
            {
                xmlR.Load(filename);
            }
            catch
            {
                MessageBoxEx.Show("Không đọc được hoặc không tồn tại tập tin cấu hình " + filename, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return xmlR;
        }

        public static void XMLWriter(String filename, String servname, String database, String costatus)
        {
            XmlTextWriter xmlW = new XmlTextWriter(filename, null);
            xmlW.Formatting = Formatting.Indented;

            xmlW.WriteStartDocument();
            xmlW.WriteComment("\nKhong duoc thay doi noi dung file nay!\n" +
                                "Thong so co ban:\n\t" +
                                "costatus = true : quyen Windows\n\t" +
                                "costatus = false: quyen SQL Server\n\t" +
                                "servname: ten server\n\t" +
                                "username: ten dang nhap he thong\n\t" +
                                "password: mat khau dang nhap he thong\n\t" +
                                "database: ten co so du lieu\n");
            xmlW.WriteStartElement("config");

            xmlW.WriteStartElement("costatus");
            xmlW.WriteString(costatus);
            xmlW.WriteEndElement();
            
            xmlW.WriteStartElement("servname");
            xmlW.WriteString(servname);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("username");
            xmlW.WriteString("");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("password");
            xmlW.WriteString("");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("database");
            xmlW.WriteString(database);
            xmlW.WriteEndElement();

            xmlW.WriteEndElement();
            xmlW.WriteEndDocument();

            xmlW.Close();
        }

        public static void XMLWriter(String filename, String servname, String username, String password, String database, String costatus)
        {
            XmlTextWriter xmlW = new XmlTextWriter(filename, null);
            xmlW.Formatting = Formatting.Indented;

            xmlW.WriteStartDocument();
            xmlW.WriteComment("\nKhong duoc thay doi noi dung file nay!\n" +
                                "Thong so co ban:\n\t" +
                                "costatus = true : quyen Windows\n\t" +
                                "costatus = false: quyen SQL Server\n\t" +
                                "servname: ten server\n\t" +
                                "username: ten dang nhap he thong\n\t" +
                                "password: mat khau dang nhap he thong\n\t" +
                                "database: ten co so du lieu\n");
            xmlW.WriteStartElement("config");
            
            xmlW.WriteStartElement("costatus");
            xmlW.WriteString(costatus);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("servname");
            xmlW.WriteString(servname);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("username");
            xmlW.WriteString(username);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("password");
            xmlW.WriteString(password);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("database");
            xmlW.WriteString(database);
            xmlW.WriteEndElement();

            xmlW.WriteEndElement();
            xmlW.WriteEndDocument();

            xmlW.Close();
        }
    }
    #endregion
    #region QuyDinh
    public class QuyDinh
    {
        public String yyyy_MM_dd    = "yyyy/MM/dd";
        public String yyyyMMdd      = "yyyyMMdd";
        public String ddMMyyyy      = "ddMMyyyy";
        public String dd_MM_yyyy      = "dd/MM/yyyy";
        public String LAN1          = "LAN1";
        public String LAN2          = "LAN2";
        public String TATCA         = "TATCA";
        public String ArrayToString(String[] array, int n)
        {
            String str = "";
            for (int i = 0; i < n; i++)
            {
                if (i != n - 1)
                    str += array[i] + ";";
                else
                    str += array[i];
            }
            return str;
        }

        public String LaySTT(int autoNum)
        {
            if (autoNum < 10)
                return "000" + autoNum;

            else if (autoNum >= 10 && autoNum < 100)
                return "00" + autoNum;

            else if (autoNum >= 100 && autoNum < 1000)
                return "0" + autoNum;

            else if (autoNum >= 1000 && autoNum < 10000)
                return "" + autoNum;

            else
                return "";
        }
    }
    #endregion
}
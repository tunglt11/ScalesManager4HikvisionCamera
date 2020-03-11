using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using ScalesManager.DataLayer;
using ScalesManager.Component;
using ScalesManager.Bussiness;

namespace ScalesManager.Controller
{
    class PhieuCanTDCtrl
    {
        PhieuCanTDData _PhieuCanTDData = new PhieuCanTDData();
        PhieuCanTDInfo _PhieuCanTDInfo = new PhieuCanTDInfo();
        QuyDinh quyDinh = new QuyDinh();

        #region lấy phiếu cân
        public PhieuCanTDInfo LayPhieuCan(string _id)
        {
            foreach (DataRow row in _PhieuCanTDData.LayPhieuCan(_id).Rows)
            {
                _PhieuCanTDInfo.ID = row[0].ToString();
                _PhieuCanTDInfo.KLXe = decimal.Parse(row[1].ToString());
                _PhieuCanTDInfo.NgayGio = DateTime.Parse(row[2].ToString());
            }
            return _PhieuCanTDInfo;
        }

        public PhieuCanTDInfo LayPhieuCan2(string _id)
        {
            foreach (DataRow row in _PhieuCanTDData.LayPhieuCan2(_id).Rows)
            {
                _PhieuCanTDInfo.ID = row[0].ToString();
                _PhieuCanTDInfo.KLXe = decimal.Parse(row[1].ToString());
                _PhieuCanTDInfo.NgayGio = DateTime.Parse(row[2].ToString());
            }
            return _PhieuCanTDInfo;
        }
        #endregion

        #region Do du lieu vao DataGridView
        public void HienThi(DataGridViewX dGV, BindingNavigator bN)
        {
            BindingSource bS = new BindingSource();

            bS.DataSource = _PhieuCanTDData.LayDsPhieuCan();
            bN.BindingSource = bS;
            dGV.DataSource = bS;
            dGV.Columns["KLXe"].DefaultCellStyle.Format = "#,###";
            dGV.Columns["NgayGio"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
        }
        public void HienThi(DataGridViewX dGV, BindingNavigator bN, DateTime ngayCan)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = _PhieuCanTDData.LayDsPhieuCanTatCa(ngayCan);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
            if (bS.Count > 0)
            {
                dGV.Columns["KLXe"].DefaultCellStyle.Format = "#,###";
                dGV.Columns["NgayGio"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"; 
            }
            else
            {

            }
        }
        #endregion

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return _PhieuCanTDData.ThemDongMoi();
        }

        public void ThemPhieuCan(DataRow m_Row)
        {
            _PhieuCanTDData.ThemPhieuCan(m_Row);
        }
        #endregion

        #region Luu du lieu
        public bool LuuPhieuCanLan1(PhieuCanTDInfo phieuCanTDInfo)
        {
            String toDayStr = DateTime.Now.ToString(quyDinh.yyyyMMdd);
            phieuCanTDInfo.ID = Guid.NewGuid().ToString();
            phieuCanTDInfo.NgayGio = DateTime.Now;
            return _PhieuCanTDData.LuuCanlan1(phieuCanTDInfo);
        }               
       


        public bool XoaPhieuCan(PhieuCanTDInfo phieuCanTDInfo)
        {
            return _PhieuCanTDData.XoaPhieuCan(phieuCanTDInfo);
        }

        public bool LuuPhieuCan()
        {
            return _PhieuCanTDData.LuuPhieuCan();
        }

        #endregion
        #region In phiếu cân
        public void InPhieuCan(string maphieu)
        {
            _PhieuCanTDData.InPhieuCan(maphieu);
        }
        #endregion
    }
}

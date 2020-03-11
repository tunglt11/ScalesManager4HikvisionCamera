namespace ScalesManager
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            System.Windows.Forms.DialogResult rs;
            rs = DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn thoát khỏi chương trình không?", "THOÁT KHỎI CHƯƠNG TRÌNH?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
            if (rs == System.Windows.Forms.DialogResult.Yes)
            {
                base.Dispose(disposing);
                System.Windows.Forms.Application.Exit();
            }
                
            if (disposing && (components != null))
                components.Dispose();
        }

        #region Windows Form Designer generated code
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanelQuanLy = new DevComponents.DotNetBar.RibbonPanel();
            this.rbCauHinh = new DevComponents.DotNetBar.RibbonBar();
            this.btnCauHinh = new DevComponents.DotNetBar.ButtonItem();
            this.btn_CauHinhMayIn = new DevComponents.DotNetBar.ButtonItem();
            this.btnCauHinhCanTD = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBarKetQua = new DevComponents.DotNetBar.RibbonBar();
            this.btnThongKe = new DevComponents.DotNetBar.ButtonItem();
            this.btnQLCanTD = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBarLop = new DevComponents.DotNetBar.RibbonBar();
            this.btnScalesManagerForm = new DevComponents.DotNetBar.ButtonItem();
            this.btn_ThongTinCT = new DevComponents.DotNetBar.ButtonItem();
            this.btn_LoaiHang = new DevComponents.DotNetBar.ButtonItem();
            this.btn_KhachHang = new DevComponents.DotNetBar.ButtonItem();
            this.btn_ThongtinXe = new DevComponents.DotNetBar.ButtonItem();
            this.btnCanTuDong = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanelGiupDo = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBarHuongDan = new DevComponents.DotNetBar.RibbonBar();
            this.btnHuongDan = new DevComponents.DotNetBar.ButtonItem();
            this.btnThongTin = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_KetNoiServer = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_SaoLuu = new DevComponents.DotNetBar.ButtonItem();
            this.btn_PhucHoi = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_DangNhap = new DevComponents.DotNetBar.ButtonItem();
            this.btn_DangXuat = new DevComponents.DotNetBar.ButtonItem();
            this.btn_DoiMatKhau = new DevComponents.DotNetBar.ButtonItem();
            this.btn_QuanLyNguoiDung = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabQuanLy = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.TabDuLieu = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabGiupDo = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonFile = new DevComponents.DotNetBar.Office2007StartButton();
            this.menuFileContainer = new DevComponents.DotNetBar.ItemContainer();
            this.menuFileItems = new DevComponents.DotNetBar.ItemContainer();
            this.btnDangNhap = new DevComponents.DotNetBar.ButtonItem();
            this.btnDangXuat = new DevComponents.DotNetBar.ButtonItem();
            this.btnDoiMatKhau = new DevComponents.DotNetBar.ButtonItem();
            this.btnQLNguoiDung = new DevComponents.DotNetBar.ButtonItem();
            this.btnSaoLuu = new DevComponents.DotNetBar.ButtonItem();
            this.btnPhucHoi = new DevComponents.DotNetBar.ButtonItem();
            this.btnConfigDatabase = new DevComponents.DotNetBar.ButtonItem();
            this.btnQlyKH = new DevComponents.DotNetBar.ButtonItem();
            this.btnThoat = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem = new DevComponents.DotNetBar.QatCustomizeItem();
            this.ribbonTabItemGroup = new DevComponents.DotNetBar.RibbonTabItemGroup();
            this.bottomBar = new DevComponents.DotNetBar.Bar();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lbTrangThaiCan = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lbThongBao = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblTenNguoiDung = new DevComponents.DotNetBar.LabelX();
            this.lblNguoiDung = new DevComponents.DotNetBar.LabelX();
            this.tabStrip = new DevComponents.DotNetBar.TabStrip();
            this.mdiClient = new System.Windows.Forms.MdiClient();
            this.ctxMenuMain = new DevComponents.DotNetBar.ContextMenuBar();
            this.btnMenuMain = new DevComponents.DotNetBar.ButtonItem();
            this.btnDangNhapContext = new DevComponents.DotNetBar.ButtonItem();
            this.btnDangXuatContext = new DevComponents.DotNetBar.ButtonItem();
            this.btnDoiMatKhauContext = new DevComponents.DotNetBar.ButtonItem();
            this.btnThoatContext = new DevComponents.DotNetBar.ButtonItem();
            this.backupDialog = new System.Windows.Forms.SaveFileDialog();
            this.restoreDialog = new System.Windows.Forms.OpenFileDialog();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.superTooltip = new DevComponents.DotNetBar.SuperTooltip();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.ribbonControl.SuspendLayout();
            this.ribbonPanelQuanLy.SuspendLayout();
            this.ribbonPanelGiupDo.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBar)).BeginInit();
            this.bottomBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctxMenuMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.ribbonControl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl.CaptionVisible = true;
            this.ribbonControl.Controls.Add(this.ribbonPanelQuanLy);
            this.ribbonControl.Controls.Add(this.ribbonPanelGiupDo);
            this.ribbonControl.Controls.Add(this.ribbonPanel2);
            this.ribbonControl.Controls.Add(this.ribbonPanel1);
            this.ribbonControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl.Expanded = false;
            this.ribbonControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ribbonControl.ForeColor = System.Drawing.Color.Black;
            this.ribbonControl.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabQuanLy,
            this.ribbonTabItem1,
            this.TabDuLieu,
            this.ribbonTabGiupDo});
            this.ribbonControl.KeyTipsFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControl.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonFile,
            this.qatCustomizeItem});
            this.ribbonControl.Size = new System.Drawing.Size(1250, 141);
            this.ribbonControl.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonControl.SystemText.MaximizeRibbonText = "Cực &đại menu Ribbon";
            this.ribbonControl.SystemText.MinimizeRibbonText = "Cực &tiểu menu Ribbon";
            this.ribbonControl.SystemText.QatAddItemText = "&Thêm vào thanh công cụ truy xuất nhanh";
            this.ribbonControl.SystemText.QatCustomizeMenuLabel = "Thanh công cụ truy xuất nhanh";
            this.ribbonControl.SystemText.QatCustomizeText = "&Tùy chọn đối tượng hiển thị...";
            this.ribbonControl.SystemText.QatDialogAddButton = "&Thêm >>";
            this.ribbonControl.SystemText.QatDialogCancelButton = "Hủy bỏ";
            this.ribbonControl.SystemText.QatDialogCaption = "TÙY CHỌN ĐỐI TƯỢNG HIỂN THỊ";
            this.ribbonControl.SystemText.QatDialogCategoriesLabel = "&Chọn đối tượng từ danh sách:";
            this.ribbonControl.SystemText.QatDialogOkButton = "Đồng ý";
            this.ribbonControl.SystemText.QatDialogPlacementCheckbox = "&Dời thanh công cụ xuống dưới menu Ribbon";
            this.ribbonControl.SystemText.QatDialogRemoveButton = "&Loại bỏ";
            this.ribbonControl.SystemText.QatPlaceAboveRibbonText = "&Dời thanh công cụ lên trên menu Ribbon";
            this.ribbonControl.SystemText.QatPlaceBelowRibbonText = "&Dời thanh công cụ xuống dưới menu Ribbon";
            this.ribbonControl.SystemText.QatRemoveItemText = "&Loại bỏ khỏi thanh công cụ truy xuất nhanh";
            this.ribbonControl.TabGroupHeight = 14;
            this.ribbonControl.TabGroups.AddRange(new DevComponents.DotNetBar.RibbonTabItemGroup[] {
            this.ribbonTabItemGroup});
            this.ribbonControl.TabGroupsVisible = true;
            this.ribbonControl.TabIndex = 0;
            this.ribbonControl.Click += new System.EventHandler(this.ribbonControl_Click);
            // 
            // ribbonPanelQuanLy
            // 
            this.ribbonPanelQuanLy.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ctxMenuMain.SetContextMenuEx(this.ribbonPanelQuanLy, this.btnMenuMain);
            this.ribbonPanelQuanLy.Controls.Add(this.rbCauHinh);
            this.ribbonPanelQuanLy.Controls.Add(this.ribbonBarKetQua);
            this.ribbonPanelQuanLy.Controls.Add(this.ribbonBarLop);
            this.ribbonPanelQuanLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanelQuanLy.Location = new System.Drawing.Point(0, 57);
            this.ribbonPanelQuanLy.Name = "ribbonPanelQuanLy";
            this.ribbonPanelQuanLy.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanelQuanLy.Size = new System.Drawing.Size(1250, 82);
            // 
            // 
            // 
            this.ribbonPanelQuanLy.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanelQuanLy.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanelQuanLy.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanelQuanLy.TabIndex = 1;
            // 
            // rbCauHinh
            // 
            this.rbCauHinh.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.rbCauHinh.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbCauHinh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbCauHinh.ContainerControlProcessDialogKey = true;
            this.rbCauHinh.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbCauHinh.DragDropSupport = true;
            this.rbCauHinh.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCauHinh,
            this.btn_CauHinhMayIn,
            this.btnCauHinhCanTD});
            this.rbCauHinh.Location = new System.Drawing.Point(716, 0);
            this.rbCauHinh.Name = "rbCauHinh";
            this.rbCauHinh.Size = new System.Drawing.Size(364, 79);
            this.rbCauHinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.rbCauHinh.TabIndex = 5;
            this.rbCauHinh.Text = "Cài đặt";
            // 
            // 
            // 
            this.rbCauHinh.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbCauHinh.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnCauHinh
            // 
            this.btnCauHinh.Name = "btnCauHinh";
            this.btnCauHinh.SplitButton = true;
            this.btnCauHinh.Text = "<div align=\"center\">Cấu hình máy cân</div>";
            this.btnCauHinh.Tooltip = "Cấu hình máy cân";
            this.btnCauHinh.Click += new System.EventHandler(this.btnCauHinh_Click);
            // 
            // btn_CauHinhMayIn
            // 
            this.btn_CauHinhMayIn.Name = "btn_CauHinhMayIn";
            this.btn_CauHinhMayIn.SubItemsExpandWidth = 14;
            this.btn_CauHinhMayIn.Text = "<div align=\"center\">Cấu hình máy in</div>";
            this.btn_CauHinhMayIn.Click += new System.EventHandler(this.btn_CauHinhMayIn_Click);
            // 
            // btnCauHinhCanTD
            // 
            this.btnCauHinhCanTD.Name = "btnCauHinhCanTD";
            this.btnCauHinhCanTD.SubItemsExpandWidth = 14;
            this.btnCauHinhCanTD.Text = "Cấu hình cân tự động";
            this.btnCauHinhCanTD.Click += new System.EventHandler(this.btCauHinhCanTD_Click);
            // 
            // ribbonBarKetQua
            // 
            this.ribbonBarKetQua.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBarKetQua.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarKetQua.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarKetQua.ContainerControlProcessDialogKey = true;
            this.ribbonBarKetQua.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBarKetQua.DragDropSupport = true;
            this.ribbonBarKetQua.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnThongKe,
            this.btnQLCanTD});
            this.ribbonBarKetQua.Location = new System.Drawing.Point(521, 0);
            this.ribbonBarKetQua.Name = "ribbonBarKetQua";
            this.ribbonBarKetQua.Size = new System.Drawing.Size(195, 79);
            this.ribbonBarKetQua.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarKetQua.TabIndex = 4;
            this.ribbonBarKetQua.Text = "Báo cáo";
            // 
            // 
            // 
            this.ribbonBarKetQua.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarKetQua.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.SplitButton = true;
            this.btnThongKe.Text = "<div align=\"center\">Thống kê</div>";
            this.btnThongKe.Tooltip = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnQLCanTD
            // 
            this.btnQLCanTD.Name = "btnQLCanTD";
            this.btnQLCanTD.SubItemsExpandWidth = 14;
            this.btnQLCanTD.Text = "Quản lý cân tự động";
            this.btnQLCanTD.Click += new System.EventHandler(this.btnQLCanTD_Click);
            // 
            // ribbonBarLop
            // 
            this.ribbonBarLop.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBarLop.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarLop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarLop.ContainerControlProcessDialogKey = true;
            this.ribbonBarLop.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBarLop.DragDropSupport = true;
            this.ribbonBarLop.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnScalesManagerForm,
            this.btn_ThongTinCT,
            this.btn_LoaiHang,
            this.btn_KhachHang,
            this.btn_ThongtinXe,
            this.btnCanTuDong});
            this.ribbonBarLop.Location = new System.Drawing.Point(3, 0);
            this.ribbonBarLop.Name = "ribbonBarLop";
            this.ribbonBarLop.Size = new System.Drawing.Size(518, 79);
            this.ribbonBarLop.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarLop.TabIndex = 1;
            this.ribbonBarLop.Text = "Quản lý";
            // 
            // 
            // 
            this.ribbonBarLop.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarLop.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnScalesManagerForm
            // 
            this.btnScalesManagerForm.ImagePaddingHorizontal = 0;
            this.btnScalesManagerForm.ImagePaddingVertical = 0;
            this.btnScalesManagerForm.Name = "btnScalesManagerForm";
            this.btnScalesManagerForm.SplitButton = true;
            this.btnScalesManagerForm.Text = "<div align=\"center\">Quản lý cân</div>";
            this.btnScalesManagerForm.Tooltip = "Quản lý cân";
            this.btnScalesManagerForm.Visible = false;
            this.btnScalesManagerForm.Click += new System.EventHandler(this.btnScalesManagerForm_Click);
            // 
            // btn_ThongTinCT
            // 
            this.btn_ThongTinCT.Name = "btn_ThongTinCT";
            this.btn_ThongTinCT.SubItemsExpandWidth = 14;
            this.btn_ThongTinCT.Text = "Thông tin công ty";
            this.btn_ThongTinCT.Click += new System.EventHandler(this.btn_ThongTinCT_Click_1);
            // 
            // btn_LoaiHang
            // 
            this.btn_LoaiHang.Name = "btn_LoaiHang";
            this.btn_LoaiHang.SubItemsExpandWidth = 14;
            this.btn_LoaiHang.Text = "Loại hàng";
            this.btn_LoaiHang.Click += new System.EventHandler(this.btn_LoaiHang_Click_1);
            // 
            // btn_KhachHang
            // 
            this.btn_KhachHang.Name = "btn_KhachHang";
            this.btn_KhachHang.SubItemsExpandWidth = 14;
            this.btn_KhachHang.Text = "Khách hàng";
            this.btn_KhachHang.Click += new System.EventHandler(this.btn_KhachHang_Click);
            // 
            // btn_ThongtinXe
            // 
            this.btn_ThongtinXe.Name = "btn_ThongtinXe";
            this.btn_ThongtinXe.SubItemsExpandWidth = 14;
            this.btn_ThongtinXe.Text = "Thông tin xe";
            this.btn_ThongtinXe.Click += new System.EventHandler(this.btn_ThongtinXe_Click);
            // 
            // btnCanTuDong
            // 
            this.btnCanTuDong.Name = "btnCanTuDong";
            this.btnCanTuDong.SubItemsExpandWidth = 14;
            this.btnCanTuDong.Text = "Cân tự động";
            this.btnCanTuDong.Click += new System.EventHandler(this.btnCanTuDong_Click);
            // 
            // ribbonPanelGiupDo
            // 
            this.ribbonPanelGiupDo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ctxMenuMain.SetContextMenuEx(this.ribbonPanelGiupDo, this.btnMenuMain);
            this.ribbonPanelGiupDo.Controls.Add(this.ribbonBarHuongDan);
            this.ribbonPanelGiupDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanelGiupDo.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanelGiupDo.Name = "ribbonPanelGiupDo";
            this.ribbonPanelGiupDo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanelGiupDo.Size = new System.Drawing.Size(1250, 139);
            // 
            // 
            // 
            this.ribbonPanelGiupDo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanelGiupDo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanelGiupDo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanelGiupDo.TabIndex = 3;
            this.ribbonPanelGiupDo.Visible = false;
            // 
            // ribbonBarHuongDan
            // 
            this.ribbonBarHuongDan.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBarHuongDan.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarHuongDan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarHuongDan.ContainerControlProcessDialogKey = true;
            this.ribbonBarHuongDan.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBarHuongDan.DragDropSupport = true;
            this.ribbonBarHuongDan.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnHuongDan,
            this.btnThongTin});
            this.ribbonBarHuongDan.Location = new System.Drawing.Point(3, 0);
            this.ribbonBarHuongDan.Name = "ribbonBarHuongDan";
            this.ribbonBarHuongDan.Size = new System.Drawing.Size(156, 136);
            this.ribbonBarHuongDan.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarHuongDan.TabIndex = 1;
            this.ribbonBarHuongDan.Text = "Hướng Dẫn";
            // 
            // 
            // 
            this.ribbonBarHuongDan.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarHuongDan.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnHuongDan
            // 
            this.btnHuongDan.Name = "btnHuongDan";
            this.btnHuongDan.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHuongDan.SplitButton = true;
            this.btnHuongDan.Text = "<div align=\"center\">Hướng dẫn<br/>sử dụng</div>";
            this.btnHuongDan.Tooltip = "Hướng dẫn sử dụng (F1)";
            this.btnHuongDan.Click += new System.EventHandler(this.btnHuongDan_Click);
            // 
            // btnThongTin
            // 
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.SplitButton = true;
            this.btnThongTin.Text = "<div align=\"center\">Thông tin<br/>phần mềm</div>";
            this.btnThongTin.Tooltip = "Thông tin phần mềm";
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel2.Controls.Add(this.ribbonBar3);
            this.ribbonPanel2.Controls.Add(this.ribbonBar2);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(1250, 139);
            // 
            // 
            // 
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 5;
            this.ribbonPanel2.Visible = false;
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.DragDropSupport = true;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_KetNoiServer});
            this.ribbonBar3.Location = new System.Drawing.Point(125, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(98, 136);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar3.TabIndex = 1;
            this.ribbonBar3.Text = "Server";
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_KetNoiServer
            // 
            this.btn_KetNoiServer.Name = "btn_KetNoiServer";
            this.btn_KetNoiServer.SubItemsExpandWidth = 14;
            this.btn_KetNoiServer.Text = "Kết nối server";
            this.btn_KetNoiServer.Click += new System.EventHandler(this.btn_KetNoiServer_Click);
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_SaoLuu,
            this.btn_PhucHoi});
            this.ribbonBar2.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(122, 136);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar2.TabIndex = 0;
            this.ribbonBar2.Text = "Dữ liệu";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_SaoLuu
            // 
            this.btn_SaoLuu.Name = "btn_SaoLuu";
            this.btn_SaoLuu.SubItemsExpandWidth = 14;
            this.btn_SaoLuu.Text = "Sao lưu";
            this.btn_SaoLuu.Click += new System.EventHandler(this.btn_SaoLuu_Click);
            // 
            // btn_PhucHoi
            // 
            this.btn_PhucHoi.Name = "btn_PhucHoi";
            this.btn_PhucHoi.SubItemsExpandWidth = 14;
            this.btn_PhucHoi.Text = "Phục hồi";
            this.btn_PhucHoi.Click += new System.EventHandler(this.btn_PhucHoi_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(1250, 139);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 4;
            this.ribbonPanel1.Visible = false;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_DangNhap,
            this.btn_DangXuat,
            this.btn_DoiMatKhau,
            this.btn_QuanLyNguoiDung});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(360, 136);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Người dùng";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.SubItemsExpandWidth = 14;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.SubItemsExpandWidth = 14;
            this.btn_DangXuat.Text = "Đăng xuất";
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // btn_DoiMatKhau
            // 
            this.btn_DoiMatKhau.Name = "btn_DoiMatKhau";
            this.btn_DoiMatKhau.SubItemsExpandWidth = 14;
            this.btn_DoiMatKhau.Text = "Đổi mật khẩu";
            this.btn_DoiMatKhau.Click += new System.EventHandler(this.btn_DoiMatKhau_Click);
            // 
            // btn_QuanLyNguoiDung
            // 
            this.btn_QuanLyNguoiDung.Name = "btn_QuanLyNguoiDung";
            this.btn_QuanLyNguoiDung.SubItemsExpandWidth = 14;
            this.btn_QuanLyNguoiDung.Text = "Quản lý người dùng";
            this.btn_QuanLyNguoiDung.Click += new System.EventHandler(this.btn_QuanLyNguoiDung_Click);
            // 
            // ribbonTabQuanLy
            // 
            this.ribbonTabQuanLy.Checked = true;
            this.ribbonTabQuanLy.Name = "ribbonTabQuanLy";
            this.ribbonTabQuanLy.Panel = this.ribbonPanelQuanLy;
            this.ribbonTabQuanLy.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.ribbonTabQuanLy.Text = "&Quản lý";
            this.ribbonTabQuanLy.Tooltip = "Quản lý (F2)";
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "Người dùng";
            // 
            // TabDuLieu
            // 
            this.TabDuLieu.Name = "TabDuLieu";
            this.TabDuLieu.Panel = this.ribbonPanel2;
            this.TabDuLieu.Text = "Dữ liệu";
            // 
            // ribbonTabGiupDo
            // 
            this.ribbonTabGiupDo.Name = "ribbonTabGiupDo";
            this.ribbonTabGiupDo.Panel = this.ribbonPanelGiupDo;
            this.ribbonTabGiupDo.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.ribbonTabGiupDo.Text = "&Giúp đỡ";
            this.ribbonTabGiupDo.Tooltip = "Giúp đỡ (F6)";
            this.ribbonTabGiupDo.Click += new System.EventHandler(this.ribbonTabGiupDo_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.AutoExpandOnClick = true;
            this.buttonFile.CanCustomize = false;
            this.buttonFile.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonFile.Image = global::ScalesManager.Properties.Resources.start;
            this.buttonFile.ImagePaddingHorizontal = 2;
            this.buttonFile.ImagePaddingVertical = 2;
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.ShowSubItems = false;
            this.buttonFile.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.menuFileContainer});
            this.buttonFile.Text = "F&ile";
            this.buttonFile.Tooltip = "Nút điều khiển chương trình";
            // 
            // menuFileContainer
            // 
            // 
            // 
            // 
            this.menuFileContainer.BackgroundStyle.Class = "RibbonFileMenuContainer";
            this.menuFileContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.menuFileContainer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.menuFileContainer.Name = "menuFileContainer";
            this.menuFileContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.menuFileItems});
            // 
            // 
            // 
            this.menuFileContainer.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.menuFileContainer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // menuFileItems
            // 
            // 
            // 
            // 
            this.menuFileItems.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer";
            this.menuFileItems.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.menuFileItems.ItemSpacing = 5;
            this.menuFileItems.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.menuFileItems.MinimumSize = new System.Drawing.Size(120, 0);
            this.menuFileItems.Name = "menuFileItems";
            this.menuFileItems.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDangNhap,
            this.btnDangXuat,
            this.btnDoiMatKhau,
            this.btnQLNguoiDung,
            this.btnSaoLuu,
            this.btnPhucHoi,
            this.btnConfigDatabase,
            this.btnQlyKH,
            this.btnThoat});
            // 
            // 
            // 
            this.menuFileItems.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.menuFileItems.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.SubItemsExpandWidth = 24;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.SubItemsExpandWidth = 24;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BeginGroup = true;
            this.btnDoiMatKhau.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.SubItemsExpandWidth = 24;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnQLNguoiDung
            // 
            this.btnQLNguoiDung.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnQLNguoiDung.Name = "btnQLNguoiDung";
            this.btnQLNguoiDung.SubItemsExpandWidth = 24;
            this.btnQLNguoiDung.Text = "Quản lý người dùng";
            this.btnQLNguoiDung.Click += new System.EventHandler(this.btnQLNguoiDung_Click);
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.BeginGroup = true;
            this.btnSaoLuu.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.SubItemsExpandWidth = 24;
            this.btnSaoLuu.Text = "Sao lưu dữ liệu";
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.SubItemsExpandWidth = 24;
            this.btnPhucHoi.Text = "Phục hồi dữ liệu";
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // btnConfigDatabase
            // 
            this.btnConfigDatabase.Name = "btnConfigDatabase";
            this.btnConfigDatabase.Text = "Kết nối server";
            this.btnConfigDatabase.Click += new System.EventHandler(this.btnConfigDatabase_Click);
            // 
            // btnQlyKH
            // 
            this.btnQlyKH.Name = "btnQlyKH";
            this.btnQlyKH.Text = "Quản lý khách hàng";
            this.btnQlyKH.Click += new System.EventHandler(this.btnQlyKH_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BeginGroup = true;
            this.btnThoat.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.SubItemsExpandWidth = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // qatCustomizeItem
            // 
            this.qatCustomizeItem.Name = "qatCustomizeItem";
            this.qatCustomizeItem.Tooltip = "Thanh công cụ truy xuất nhanh";
            // 
            // ribbonTabItemGroup
            // 
            this.ribbonTabItemGroup.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Orange;
            this.ribbonTabItemGroup.GroupTitle = "Tab Group";
            this.ribbonTabItemGroup.Name = "ribbonTabItemGroup";
            // 
            // 
            // 
            this.ribbonTabItemGroup.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(158)))), ((int)(((byte)(159)))));
            this.ribbonTabItemGroup.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.ribbonTabItemGroup.Style.BackColorGradientAngle = 90;
            this.ribbonTabItemGroup.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup.Style.BorderBottomWidth = 1;
            this.ribbonTabItemGroup.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(58)))), ((int)(((byte)(59)))));
            this.ribbonTabItemGroup.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup.Style.BorderLeftWidth = 1;
            this.ribbonTabItemGroup.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup.Style.BorderRightWidth = 1;
            this.ribbonTabItemGroup.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup.Style.BorderTopWidth = 1;
            this.ribbonTabItemGroup.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonTabItemGroup.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.ribbonTabItemGroup.Style.TextColor = System.Drawing.Color.Black;
            this.ribbonTabItemGroup.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // bottomBar
            // 
            this.bottomBar.AccessibleDescription = "DotNetBar Bar (bottomBar)";
            this.bottomBar.AccessibleName = "DotNetBar Bar";
            this.bottomBar.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.bottomBar.AlwaysDisplayDockTab = true;
            this.bottomBar.AntiAlias = true;
            this.bottomBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.ctxMenuMain.SetContextMenuEx(this.bottomBar, this.btnMenuMain);
            this.bottomBar.Controls.Add(this.labelX4);
            this.bottomBar.Controls.Add(this.lbTrangThaiCan);
            this.bottomBar.Controls.Add(this.labelX3);
            this.bottomBar.Controls.Add(this.lbThongBao);
            this.bottomBar.Controls.Add(this.labelX1);
            this.bottomBar.Controls.Add(this.lblTenNguoiDung);
            this.bottomBar.Controls.Add(this.lblNguoiDung);
            this.bottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bottomBar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
            this.bottomBar.IsMaximized = false;
            this.bottomBar.ItemSpacing = 2;
            this.bottomBar.Location = new System.Drawing.Point(5, 575);
            this.bottomBar.Name = "bottomBar";
            this.bottomBar.Size = new System.Drawing.Size(1250, 26);
            this.bottomBar.Stretch = true;
            this.bottomBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bottomBar.TabIndex = 7;
            this.bottomBar.TabStop = false;
            this.bottomBar.Text = "barStatus";
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelX4.Location = new System.Drawing.Point(3459, 5);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(300, 19);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "VuDuyControl Co., Ltd - Hotline 0905745562";
            // 
            // lbTrangThaiCan
            // 
            this.lbTrangThaiCan.AutoSize = true;
            this.lbTrangThaiCan.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbTrangThaiCan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTrangThaiCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrangThaiCan.ForeColor = System.Drawing.Color.Red;
            this.lbTrangThaiCan.Location = new System.Drawing.Point(552, 6);
            this.lbTrangThaiCan.Name = "lbTrangThaiCan";
            this.lbTrangThaiCan.Size = new System.Drawing.Size(0, 0);
            this.lbTrangThaiCan.TabIndex = 5;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelX3.Location = new System.Drawing.Point(456, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(94, 18);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "Trạng thái cân:";
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbThongBao.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.ForeColor = System.Drawing.Color.Red;
            this.lbThongBao.Location = new System.Drawing.Point(892, 6);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(0, 0);
            this.lbThongBao.TabIndex = 2;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelX1.Location = new System.Drawing.Point(821, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(72, 18);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Thông báo:";
            // 
            // lblTenNguoiDung
            // 
            this.lblTenNguoiDung.AutoSize = true;
            this.lblTenNguoiDung.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTenNguoiDung.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTenNguoiDung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNguoiDung.ForeColor = System.Drawing.Color.Red;
            this.lblTenNguoiDung.Location = new System.Drawing.Point(174, 6);
            this.lblTenNguoiDung.Name = "lblTenNguoiDung";
            this.lblTenNguoiDung.Size = new System.Drawing.Size(0, 0);
            this.lblTenNguoiDung.TabIndex = 0;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.AutoSize = true;
            this.lblNguoiDung.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblNguoiDung.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDung.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblNguoiDung.Location = new System.Drawing.Point(0, 6);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(179, 18);
            this.lblNguoiDung.TabIndex = 0;
            this.lblNguoiDung.Text = "Người dùng đang đăng nhập:";
            // 
            // tabStrip
            // 
            this.tabStrip.AutoSelectAttachedControl = true;
            this.tabStrip.CanReorderTabs = true;
            this.tabStrip.CloseButtonOnTabsVisible = true;
            this.tabStrip.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabStrip.CloseButtonVisible = false;
            this.ctxMenuMain.SetContextMenuEx(this.tabStrip, this.btnMenuMain);
            this.tabStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabStrip.Location = new System.Drawing.Point(5, 142);
            this.tabStrip.MdiForm = this;
            this.tabStrip.MdiTabbedDocuments = true;
            this.tabStrip.Name = "tabStrip";
            this.tabStrip.SelectedTab = null;
            this.tabStrip.SelectedTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStrip.Size = new System.Drawing.Size(1250, 32);
            this.tabStrip.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabStrip.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top;
            this.tabStrip.TabIndex = 1;
            this.tabStrip.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabStrip.Text = "tabStrip";
            // 
            // mdiClient
            // 
            this.mdiClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.mdiClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mdiClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdiClient.Location = new System.Drawing.Point(5, 174);
            this.mdiClient.Name = "mdiClient";
            this.mdiClient.Size = new System.Drawing.Size(1250, 401);
            this.mdiClient.TabIndex = 2;
            // 
            // ctxMenuMain
            // 
            this.ctxMenuMain.AntiAlias = true;
            this.ctxMenuMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxMenuMain.IsMaximized = false;
            this.ctxMenuMain.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnMenuMain});
            this.ctxMenuMain.Location = new System.Drawing.Point(436, 329);
            this.ctxMenuMain.Name = "ctxMenuMain";
            this.ctxMenuMain.Size = new System.Drawing.Size(90, 29);
            this.ctxMenuMain.Stretch = true;
            this.ctxMenuMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ctxMenuMain.TabIndex = 8;
            this.ctxMenuMain.TabStop = false;
            this.ctxMenuMain.Text = "ctxMenu";
            // 
            // btnMenuMain
            // 
            this.btnMenuMain.AutoExpandOnClick = true;
            this.btnMenuMain.Name = "btnMenuMain";
            this.btnMenuMain.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuMain.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDangNhapContext,
            this.btnDangXuatContext,
            this.btnDoiMatKhauContext,
            this.btnThoatContext});
            this.btnMenuMain.Text = "Menu";
            // 
            // btnDangNhapContext
            // 
            this.btnDangNhapContext.Name = "btnDangNhapContext";
            this.btnDangNhapContext.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlL);
            this.btnDangNhapContext.Text = "Đăng nhập";
            this.btnDangNhapContext.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangXuatContext
            // 
            this.btnDangXuatContext.Name = "btnDangXuatContext";
            this.btnDangXuatContext.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlO);
            this.btnDangXuatContext.Text = "Đăng xuất hệ thống";
            this.btnDangXuatContext.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDoiMatKhauContext
            // 
            this.btnDoiMatKhauContext.Name = "btnDoiMatKhauContext";
            this.btnDoiMatKhauContext.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
            this.btnDoiMatKhauContext.Text = "Đổi mật khẩu";
            this.btnDoiMatKhauContext.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnThoatContext
            // 
            this.btnThoatContext.Name = "btnThoatContext";
            this.btnThoatContext.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF4);
            this.btnThoatContext.Text = "Thoát chương trình";
            this.btnThoatContext.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // backupDialog
            // 
            this.backupDialog.DefaultExt = "*.BAK";
            this.backupDialog.FileName = "SCALES_MANAGER_DB";
            this.backupDialog.Filter = "Backup files (*.BAK)|*.BAK";
            this.backupDialog.FilterIndex = 2;
            this.backupDialog.Title = "SAO LƯU DỮ LIỆU";
            // 
            // restoreDialog
            // 
            this.restoreDialog.DefaultExt = "*.BAK";
            this.restoreDialog.FileName = "ScalesManager.BAK";
            this.restoreDialog.Filter = "Backup files (*.BAK)|*.BAK";
            this.restoreDialog.FilterIndex = 2;
            this.restoreDialog.Title = "PHỤC HỒI DỮ LIỆU";
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "ScalesManager.chm";
            // 
            // superTooltip
            // 
            this.superTooltip.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTooltip.DefaultTooltipSettings = new DevComponents.DotNetBar.SuperTooltipInfo("", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.Gray);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(261, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "VuDuyControl Co., Ltd Hotline 0905745562";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1260, 603);
            this.Controls.Add(this.ctxMenuMain);
            this.Controls.Add(this.tabStrip);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.bottomBar);
            this.Controls.Add(this.mdiClient);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ribbonControl.ResumeLayout(false);
            this.ribbonControl.PerformLayout();
            this.ribbonPanelQuanLy.ResumeLayout(false);
            this.ribbonPanelGiupDo.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            this.ribbonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bottomBar)).EndInit();
            this.bottomBar.ResumeLayout(false);
            this.bottomBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctxMenuMain)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion

        #region Components
        private System.Windows.Forms.MdiClient mdiClient;
        private System.Windows.Forms.SaveFileDialog backupDialog;
        private System.Windows.Forms.OpenFileDialog restoreDialog;
        private System.Windows.Forms.HelpProvider helpProvider;
        private DevComponents.DotNetBar.SuperTooltip superTooltip;
        private DevComponents.DotNetBar.RibbonControl ribbonControl;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabQuanLy;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabGiupDo;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanelQuanLy;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanelGiupDo;
        private DevComponents.DotNetBar.ItemContainer menuFileContainer;
        private DevComponents.DotNetBar.Office2007StartButton buttonFile;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem;
        private DevComponents.DotNetBar.RibbonBar ribbonBarLop;
        private DevComponents.DotNetBar.RibbonBar ribbonBarHuongDan;
        private DevComponents.DotNetBar.ButtonItem btnHuongDan;
        private DevComponents.DotNetBar.RibbonTabItemGroup ribbonTabItemGroup;
        private DevComponents.DotNetBar.Bar bottomBar;
        private DevComponents.DotNetBar.RibbonBar ribbonBarKetQua;
        private DevComponents.DotNetBar.ButtonItem btnThongKe;
        private DevComponents.DotNetBar.ButtonItem btnThongTin;
        private DevComponents.DotNetBar.TabStrip tabStrip;
        private DevComponents.DotNetBar.ItemContainer menuFileItems;
        private DevComponents.DotNetBar.ButtonItem btnDangNhap;
        private DevComponents.DotNetBar.ButtonItem btnDangXuat;
        private DevComponents.DotNetBar.ButtonItem btnDoiMatKhau;
        private DevComponents.DotNetBar.ButtonItem btnQLNguoiDung;
        private DevComponents.DotNetBar.ButtonItem btnSaoLuu;
        private DevComponents.DotNetBar.ButtonItem btnPhucHoi;
        private DevComponents.DotNetBar.ButtonItem btnThoat;
        private DevComponents.DotNetBar.LabelX lblNguoiDung;
        private DevComponents.DotNetBar.ContextMenuBar ctxMenuMain;
        private DevComponents.DotNetBar.ButtonItem btnMenuMain;
        private DevComponents.DotNetBar.ButtonItem btnDangNhapContext;
        private DevComponents.DotNetBar.ButtonItem btnDangXuatContext;
        private DevComponents.DotNetBar.ButtonItem btnDoiMatKhauContext;
        private DevComponents.DotNetBar.LabelX lblTenNguoiDung;
        private DevComponents.DotNetBar.ButtonItem btnThoatContext;
        #endregion

        private DevComponents.DotNetBar.ButtonItem btnScalesManagerForm;
        private DevComponents.DotNetBar.RibbonBar rbCauHinh;
        private DevComponents.DotNetBar.ButtonItem btnCauHinh;
        private DevComponents.DotNetBar.ButtonItem btnConfigDatabase;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btn_DangNhap;
        private DevComponents.DotNetBar.ButtonItem btn_DangXuat;
        private DevComponents.DotNetBar.ButtonItem btn_DoiMatKhau;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.ButtonItem btn_QuanLyNguoiDung;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.ButtonItem btn_KetNoiServer;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem btn_SaoLuu;
        private DevComponents.DotNetBar.ButtonItem btn_PhucHoi;
        private DevComponents.DotNetBar.RibbonTabItem TabDuLieu;
        private DevComponents.DotNetBar.ButtonItem btnQlyKH;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        public DevComponents.DotNetBar.LabelX lbThongBao;
        public DevComponents.DotNetBar.LabelX lbTrangThaiCan;
        private DevComponents.DotNetBar.ButtonItem btn_CauHinhMayIn;
        private DevComponents.DotNetBar.ButtonItem btn_ThongTinCT;
        private DevComponents.DotNetBar.ButtonItem btn_LoaiHang;
        private DevComponents.DotNetBar.ButtonItem btn_KhachHang;
        private DevComponents.DotNetBar.ButtonItem btnQLCanTD;
        private DevComponents.DotNetBar.ButtonItem btnCauHinhCanTD;
        private DevComponents.DotNetBar.ButtonItem btn_ThongtinXe;
        private DevComponents.DotNetBar.ButtonItem btnCanTuDong;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
    }
}
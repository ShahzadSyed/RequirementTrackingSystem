namespace RTS
{
    partial class Dashboard
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.setupMenuMain = new Telerik.WinControls.UI.RadMenuItem();
            this.setup_menu = new Telerik.WinControls.UI.RadMenuItem();
            this.transactionMenu = new Telerik.WinControls.UI.RadMenuItem();
            this.complaintStatus_menu = new Telerik.WinControls.UI.RadMenuItem();
            this.office2007BlackTheme1 = new Telerik.WinControls.Themes.Office2007BlackTheme();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.setupMenuMain,
            this.transactionMenu});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(714, 28);
            this.radMenu1.TabIndex = 0;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Office2007Black";
            // 
            // setupMenuMain
            // 
            this.setupMenuMain.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.setup_menu});
            this.setupMenuMain.Name = "setupMenuMain";
            this.setupMenuMain.Text = "Setup";
            // 
            // setup_menu
            // 
            this.setup_menu.Name = "setup_menu";
            this.setup_menu.Text = "Complaints";
            this.setup_menu.Click += new System.EventHandler(this.setup_menu_Click);
            // 
            // transactionMenu
            // 
            this.transactionMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.complaintStatus_menu});
            this.transactionMenu.Name = "transactionMenu";
            this.transactionMenu.Text = "Transaction";
            // 
            // complaintStatus_menu
            // 
            this.complaintStatus_menu.Name = "complaintStatus_menu";
            this.complaintStatus_menu.Text = "Complaint Status";
            this.complaintStatus_menu.Click += new System.EventHandler(this.complaintStatus_menu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::RTS.Properties.Resources._1520240641853;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 521);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 549);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radMenu1);
            this.Name = "Dashboard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.ThemeName = "Office2007Black";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem setupMenuMain;
        private Telerik.WinControls.UI.RadMenuItem transactionMenu;
        private Telerik.WinControls.UI.RadMenuItem setup_menu;
        private Telerik.WinControls.UI.RadMenuItem complaintStatus_menu;
        private Telerik.WinControls.Themes.Office2007BlackTheme office2007BlackTheme1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

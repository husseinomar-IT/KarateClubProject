namespace KarateWindowsFormsApplication
{
    partial class FrmEditPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditPeriod));
            this.txtPeriodID = new Bunifu.Framework.UI.BunifuTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditPeriod = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSearch = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFeesPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataview1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.Controls.Add(this.btnSearch);
            this.bunifuCards1.Controls.Add(this.btnEditPeriod);
            this.bunifuCards1.Controls.Add(this.txtPeriodID);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Location = new System.Drawing.Point(268, 199);
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.Size = new System.Drawing.Size(918, 426);
            this.bunifuCards1.Controls.SetChildIndex(this.btnAddPeriod, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label5, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label6, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.rdbIsPaid, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.rdbNoPaid, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label8, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.btnCanacel, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.lstboxMembers, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label2, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.StartDatePicker, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.EndDatePicker, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label3, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.numericFeesPeriod, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label1, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.txtPeriodID, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.btnEditPeriod, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.btnSearch, 0);
            // 
            // btnCanacel
            // 
            this.btnCanacel.IconRightVisible = true;
            this.btnCanacel.IconVisible = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(441, 258);
            // 
            // rdbNoPaid
            // 
            this.rdbNoPaid.Location = new System.Drawing.Point(684, 258);
            // 
            // rdbIsPaid
            // 
            this.rdbIsPaid.Location = new System.Drawing.Point(593, 258);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(429, 211);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(429, 87);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(44, 78);
            // 
            // lstboxMembers
            // 
            this.lstboxMembers.Location = new System.Drawing.Point(144, 84);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(552, 70);
            // 
            // numericFeesPeriod
            // 
            this.numericFeesPeriod.Location = new System.Drawing.Point(552, 212);
            this.numericFeesPeriod.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(429, 141);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(552, 135);
            // 
            // btnAddPeriod
            // 
            this.btnAddPeriod.IconRightVisible = true;
            this.btnAddPeriod.IconVisible = true;
            // 
            // btnFrmDelPeriod
            // 
            this.btnFrmDelPeriod.IconRightVisible = true;
            this.btnFrmDelPeriod.IconVisible = true;
            // 
            // btnFrmEditPeriod
            // 
            this.btnFrmEditPeriod.IconRightVisible = true;
            this.btnFrmEditPeriod.IconVisible = true;
            this.btnFrmEditPeriod.Click += new System.EventHandler(this.btnFrmEditPeriod_Click);
            // 
            // btnFrmAddPeriod
            // 
            this.btnFrmAddPeriod.BackColor = System.Drawing.Color.Gray;
            this.btnFrmAddPeriod.IconRightVisible = true;
            this.btnFrmAddPeriod.IconVisible = true;
            // 
            // btnFrmPeriodList
            // 
            this.btnFrmPeriodList.IconRightVisible = true;
            this.btnFrmPeriodList.IconVisible = true;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmSubscription
            // 
            this.btnFrmSubscription.FlatAppearance.BorderSize = 0;
            this.btnFrmSubscription.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmSubscription.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmSubscription.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmPayment
            // 
            this.btnFrmPayment.FlatAppearance.BorderSize = 0;
            this.btnFrmPayment.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmBeltTest
            // 
            this.btnFrmBeltTest.FlatAppearance.BorderSize = 0;
            this.btnFrmBeltTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmBeltTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmBeltTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmBeltRanks
            // 
            this.btnFrmBeltRanks.FlatAppearance.BorderSize = 0;
            this.btnFrmBeltRanks.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmBeltRanks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmBeltRanks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmMembersInstructor
            // 
            this.btnFrmMembersInstructor.FlatAppearance.BorderSize = 0;
            this.btnFrmMembersInstructor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmMembersInstructor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmMembersInstructor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmUsers
            // 
            this.btnFrmUsers.FlatAppearance.BorderSize = 0;
            this.btnFrmUsers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmInstructor
            // 
            this.btnFrmInstructor.FlatAppearance.BorderSize = 0;
            this.btnFrmInstructor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmInstructor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmInstructor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmMembers
            // 
            this.btnFrmMembers.FlatAppearance.BorderSize = 0;
            this.btnFrmMembers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmMembers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmMembers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFrmDashboard
            // 
            this.btnFrmDashboard.FlatAppearance.BorderSize = 0;
            this.btnFrmDashboard.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnCloseFrm
            // 
            this.btnCloseFrm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCloseFrm.FlatAppearance.BorderSize = 0;
            this.btnCloseFrm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnCloseFrm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            // 
            // txtPeriodID
            // 
            this.txtPeriodID.BackColor = System.Drawing.Color.White;
            this.txtPeriodID.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPeriodID.BackgroundImage")));
            this.txtPeriodID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtPeriodID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.txtPeriodID.Icon = ((System.Drawing.Image)(resources.GetObject("txtPeriodID.Icon")));
            this.txtPeriodID.Location = new System.Drawing.Point(351, 21);
            this.txtPeriodID.Name = "txtPeriodID";
            this.txtPeriodID.Size = new System.Drawing.Size(250, 42);
            this.txtPeriodID.TabIndex = 83;
            this.txtPeriodID.text = "";
            this.txtPeriodID.OnTextChange += new System.EventHandler(this.txtPeriodID_OnTextChange);
            this.txtPeriodID.DoubleClick += new System.EventHandler(this.txtPeriodID_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Imprint MT Shadow", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(235, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 82;
            this.label1.Text = "PeriodID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnEditPeriod
            // 
            this.btnEditPeriod.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnEditPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(28)))), ((int)(((byte)(228)))), ((int)(((byte)(31)))));
            this.btnEditPeriod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditPeriod.BorderRadius = 7;
            this.btnEditPeriod.ButtonText = "Save";
            this.btnEditPeriod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditPeriod.DisabledColor = System.Drawing.Color.Gray;
            this.btnEditPeriod.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEditPeriod.Iconimage = global::KarateWindowsFormsApplication.Properties.Resources.icons8_checked_user_male_30px;
            this.btnEditPeriod.Iconimage_right = null;
            this.btnEditPeriod.Iconimage_right_Selected = null;
            this.btnEditPeriod.Iconimage_Selected = null;
            this.btnEditPeriod.IconMarginLeft = 0;
            this.btnEditPeriod.IconMarginRight = 0;
            this.btnEditPeriod.IconRightVisible = true;
            this.btnEditPeriod.IconRightZoom = 0D;
            this.btnEditPeriod.IconVisible = true;
            this.btnEditPeriod.IconZoom = 75D;
            this.btnEditPeriod.IsTab = false;
            this.btnEditPeriod.Location = new System.Drawing.Point(484, 308);
            this.btnEditPeriod.Name = "btnEditPeriod";
            this.btnEditPeriod.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(28)))), ((int)(((byte)(228)))), ((int)(((byte)(31)))));
            this.btnEditPeriod.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnEditPeriod.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEditPeriod.selected = false;
            this.btnEditPeriod.Size = new System.Drawing.Size(137, 39);
            this.btnEditPeriod.TabIndex = 84;
            this.btnEditPeriod.Text = "Save";
            this.btnEditPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditPeriod.Textcolor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditPeriod.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPeriod.Click += new System.EventHandler(this.btnEditPeriod_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Image = global::KarateWindowsFormsApplication.Properties.Resources.icons8_search_30px;
            this.btnSearch.ImageActive = null;
            this.btnSearch.Location = new System.Drawing.Point(607, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 44);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSearch.TabIndex = 113;
            this.btnSearch.TabStop = false;
            this.btnSearch.Zoom = 10;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmEditPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1213, 660);
            this.Name = "FrmEditPeriod";
            this.Load += new System.EventHandler(this.FrmEditPeriod_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFeesPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataview1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuTextbox txtPeriodID;
        protected System.Windows.Forms.Label label1;
        public Bunifu.Framework.UI.BunifuFlatButton btnEditPeriod;
        private Bunifu.Framework.UI.BunifuImageButton btnSearch;
    }
}
